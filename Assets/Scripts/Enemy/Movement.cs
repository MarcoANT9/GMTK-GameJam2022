using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public float rangeDistance;
    public bool moveAway;
    public GameObject pjObject;

    public void Move(GameObject target)
    {
        // Rotate towards player
        transform.right = target.transform.position - transform.position;

        // Move towards player
        this.transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }
}
