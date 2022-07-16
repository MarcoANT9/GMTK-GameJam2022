using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPositionGenerator : MonoBehaviour
{
    public GameObject prefabEnemyMelee;

    public GameObject prefabEnemyAdc;

    public GameObject prefabEnemyMage;

    public GameObject prefabEnemySpecialist;

    public int enemyCount;
    private int enemyType;
    private int round;

    void Start()
    {
        enemyCount = 0;
        round = 1;
    }


    // Click the "instantiate button to create a prefab
    // Somewhere within -10.0 and 10.0 (inclusive) on the x-z plane
    void OnGUI()
    {
        GUI.Button(new Rect(10, 10, 100, 50), ("Round: " + round));
        GUI.Button(new Rect(10, 80, 100, 50), ("Enemies: " + enemyCount));
    }


}