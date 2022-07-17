using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedProjectile : MonoBehaviour
{
    public float lifespan;
    public float moveSpeed;
    public int damage;
    void Update()
    {
        lifespan -= Time.deltaTime;
        if (lifespan <= 0f)
            Destroy(transform.parent.gameObject);
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.gameObject.GetComponentInParent<Base>().applyDamage(damage);
            Destroy(transform.parent.gameObject);
        }
    }
}
