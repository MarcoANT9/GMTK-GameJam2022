using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Attack : MonoBehaviour
{

    public GameObject projectile;
    public bool isRanged;
    public float attackSpeed;

    //Need this to know if target is in Range
    private Movement movement;
    private float attackTimer;
    private GameObject target;
    private GameObject projectilePool;

    private void Start()
    {
        movement = GetComponent<Movement>();
        target = GameObject.FindGameObjectWithTag("Player");
        projectilePool = GameObject.Find("Projectiles");
    }

    private void Update()
    {
        attackTimer += Time.deltaTime;
        if (movement.inRange && attackTimer >= attackSpeed)
        {
            if (isRanged)
            {
                Instantiate(projectile, transform.position, transform.rotation, projectilePool.transform);
            }
            else
            {
                target.SendMessage("applyDamage", 10);
            }
            attackTimer = 0f;
        }
    }
}
