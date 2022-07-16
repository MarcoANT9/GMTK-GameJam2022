using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [Header("Basic Stats")]
    private int currentHP;

    private int maxHP = 100;

    [HideInInspector]
    public GameObject gameAdmin;

    public bool isPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        gameAdmin = GameObject.Find("GameManager");
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
            Destroy (gameObject);
            if (isPlayer == true)
            {
                Debug.Log("ª");
                gameAdmin.SendMessage("restartGame");
            }
            else
            {
                Debug.Log("Enemy Killed");
                gameAdmin.SendMessage("incrementDeathCount");
                gameAdmin.SendMessage("decreaceEnemyCount");
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

    /// <summary>
    /// Sets Unit HP.
    /// </summary>
    /// <param name="value"> Health Value </param>
    void setHP(int value)
    {
        maxHP = value;
        currentHP = value;
    }
}
