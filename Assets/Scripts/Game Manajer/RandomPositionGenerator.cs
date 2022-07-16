using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPositionGenerator : MonoBehaviour
{
    // ========================================================
    // Enemy Characters Prefabs
    // ========================================================
    [Header("NPCs Prefabs")]
    public GameObject prefabEnemyMelee;

    public GameObject prefabEnemyAdc;

    public GameObject prefabEnemyMage;

    public GameObject prefabEnemySpecialist;

    // ========================================================
    // Spawn Points
    // ========================================================
    [Header("Spawn Points")]
    public GameObject spawnPointNort;

    //public GameObject SpawnPointEast;

    //public GameObject SpawnPointWest;

    [HideInInspector]
    public int enemyCount;

    [HideInInspector]
    public int enemyKillCount;

    private int enemyType;

    private int totalEnemies;

    void Start()
    {
        totalEnemies = 15;
        enemyCount = 0;
        enemyKillCount = 0;
    }

    // Click the "instantiate button to create a prefab
    // Somewhere within -10.0 and 10.0 (inclusive) on the x-z plane
    void OnGUI()
    {
        GUI
            .Button(new Rect(10, 10, 150, 50),
            ("Total Enemies: " + totalEnemies));
        GUI.Button(new Rect(10, 80, 100, 50), ("Enemies: " + enemyCount));
        GUI
            .Button(new Rect(10, 150, 150, 50),
            ("Kil Count: " + enemyKillCount));
    }

    void FixedUpdate()
    {

    }

    public void incrementDeathCount()
    {
        enemyKillCount++;
    }

    public void decreaceEnemyCount()
    {
        if (enemyCount > 0) enemyCount--;
    }

    private void finnishGame()
    {
        Debug.Log("Game Over");
        Application.Quit();
    }

    // IEnumerator EnemyCoolDown()
    // {
    //     yield return new WaitForSeconds(20);
    // }
}
