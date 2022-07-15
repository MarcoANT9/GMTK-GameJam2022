using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPositionGenerator : MonoBehaviour
{
    
    public GameObject prefab;

    // Click the "instantiate button to create a prefab
    // Somewhere within -10.0 and 10.0 (inclusive) on the x-z plane

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 50), "Instantiate!"))
        {
            var position = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), 0);
            Instantiate(prefab, position, Quaternion.identity);
        }
    }
        
}
