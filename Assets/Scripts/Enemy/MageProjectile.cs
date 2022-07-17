using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageProjectile : MonoBehaviour
{
    public float lifespan;
    public float moveSpeed;
    public int damage;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        lifespan -= Time.deltaTime;
        if (lifespan <= 0f)
            Destroy(transform.parent.gameObject);
        transform.up = target.transform.position - transform.position;
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
