using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lt : MonoBehaviour
{
    public float lifeT;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeT);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
