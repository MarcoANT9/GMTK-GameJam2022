using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public bool inRange;
    public float range;
    private GameObject target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        inRange = false;
    }

    public void Update()
    {
        if (Vector2.Distance(transform.position, target.transform.position) <= range)
            inRange = true;
        else
            inRange = false;
    }

    public void Move()
    {   if(!inRange)
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }
}
