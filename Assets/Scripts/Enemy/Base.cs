using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [Header("Basic Stats")]
    private int currentHP;
    private int maxHP;


    // Start is called before the first frame update
    void Start()
    {
        maxHP = 500;
        currentHP = maxHP;
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

}
