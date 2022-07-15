using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyElement : MonoBehaviour
{
    private float timer = 2.0f;

    void Start()
    {
        StartCoroutine(DeathCount());
    }

    IEnumerator DeathCount()
    {
        Debug.Log("Inititate Self Destruct");
        yield return new WaitForSeconds(timer);
        Debug.Log("GOKUUUUU AAAAAA");
        Destroy(gameObject);
    }
}
