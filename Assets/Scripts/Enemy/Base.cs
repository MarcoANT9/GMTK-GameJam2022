using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [Header("Basic Stats")]
    private int currentHP;

    public int maxHP = 100;

    private GameObject gameAdmin;

    public bool isPlayer = false;

    private GamePreparation gameData;

    public GameObject playerTarget = null;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        gameAdmin = GameObject.Find("GameManager");
        gameData = gameAdmin.GetComponent<GamePreparation>();
        if (isPlayer == false) playerTarget = gameData.targetPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayer && playerTarget)
        {
            transform.up = playerTarget.transform.position - transform.position;
            SendMessage("Move", playerTarget, SendMessageOptions.DontRequireReceiver);
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
            if (isPlayer == true)
            {
                Debug.Log("ª");
                gameAdmin.SendMessage("restartGame");
            }
            else
            {
                Destroy(transform.parent.gameObject);
                gameAdmin.GetComponent<RandomPositionGenerator>().incrementDeathCount();
                gameAdmin.GetComponent<RandomPositionGenerator>().decreaceEnemyCount();
            }
        }
    }

    /// <summary>
    /// Applies indicated damage to NPC
    /// </summary>
    /// <param name="damage"> Damage done by player´s attack </param>
    public void applyDamage(int damage)
    {
        currentHP -= damage;

        //Debug.Log (currentHP);
        checkHealth();
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
