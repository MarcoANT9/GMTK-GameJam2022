using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public float lifeTime;
    public float moveSpeed;

    void Update()
    {
        this.transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
            Destroy(gameObject);
    }
}
