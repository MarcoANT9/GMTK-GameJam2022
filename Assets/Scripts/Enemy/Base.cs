using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [Header("Basic Stats")]
    private int currentHP;
    private int maxHP = 100;

    private bool inRange;
    private CircleCollider2D distance;
    private float attackTimer;

    public GameObject target;
    public float attackRange;
    public float attackSpeed;

    // Start is called before the first frame update
    void Start()
    {
        distance = gameObject.AddComponent<CircleCollider2D>() as CircleCollider2D;
        distance.isTrigger = true;
        currentHP = maxHP; 
        distance.radius = attackRange / 2f;
        attackTimer = 0f;  
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer = Mathf.Clamp(attackTimer + 1f * Time.deltaTime, 0, attackSpeed);
        if (!inRange)
        {
            gameObject.SendMessage("Move", target, SendMessageOptions.DontRequireReceiver);
        }
        else if (attackTimer == attackSpeed)
        {
            gameObject.SendMessage("attackPlayer", target, SendMessageOptions.DontRequireReceiver);
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
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Applies indicated damage to NPC
    /// </summary>
    /// <param name="damage"> Damage done by player´s attack </param>
    void applyDamage(int damage)
    {
        
        currentHP -= damage;
        Debug.Log("ay - " + currentHP);
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
}
