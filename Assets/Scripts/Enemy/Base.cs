using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [Header("Basic Stats")]
    private int currentHP;
    private bool inRange;
    private CircleCollider2D distance;
    private float attackTimer;
    public float attackRange;
    public float attackSpeed;
    public int maxHP = 100;
    private GameObject gameAdmin;
    public bool isPlayer = false;
    private GamePreparation gameData;
    public GameObject playerTarget = null;

    // Start is called before the first frame update
    void Start()
    {
        distance = gameObject.AddComponent<CircleCollider2D>() as CircleCollider2D;
        distance.isTrigger = true;
        distance.radius = attackRange / 2f;
        currentHP = maxHP; 
        attackTimer = 0f;  
        gameAdmin = GameObject.Find("GameManager");
        gameData = gameAdmin.GetComponent<GamePreparation>();
        if (isPlayer == false) playerTarget = gameData.targetPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer = Mathf.Clamp(attackTimer + 1f * Time.deltaTime, 0, attackSpeed);
        if (!inRange)
        {
            gameObject.SendMessage("Move", playerTarget, SendMessageOptions.DontRequireReceiver);
        }
        else if (attackTimer == attackSpeed)
        {
            gameObject.SendMessage("attackPlayer", playerTarget, SendMessageOptions.DontRequireReceiver);
            attackTimer = 0f;
        }
    }

    /// <summary>
    /// Checks if the NPC is alive
    /// </summary>
    void checkHealth()
    {
        if (currentHP <= 0)
        {
            // Animation Here
            // SFX Here
            // NPC goes splat
            Destroy (gameObject);
            if (isPlayer == true)
            {
                Debug.Log("ª");
                gameAdmin.SendMessage("restartGame");
            }
            else
            {
                gameAdmin.GetComponent<RandomPositionGenerator>().incrementDeathCount();
                gameAdmin.GetComponent<RandomPositionGenerator>().decreaceEnemyCount();
            }
        }
    }

    /// <summary>
    /// Applies indicated damage to NPC
    /// </summary>
    /// <param name="damage"> Damage done by player´s attack </param>
    void applyDamage(int damage)
    {
        currentHP -= damage;

        //Debug.Log (currentHP);
        checkHealth();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            inRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            inRange = false;
    }
    /// <summary>
    /// Sets Unit HP.
    /// </summary>
    /// <param name="value"> Health Value </param>
    /// void setHP(int value)
    public void setHP(int value)
    {
        maxHP = value;
        currentHP = value;
    }

    /// <summary>
    /// Shows character max HP
    /// </summary>
    public void showMaxHP()
    {
        Debug.Log("Max HP = " + maxHP);
    }
}
