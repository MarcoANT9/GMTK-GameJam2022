using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPositionGenerator : MonoBehaviour
{
    // ========================================================
    // Enemy Characters Prefabs
    // ========================================================
    [Header("NPCs Prefabs")]
    public GameObject[] enemyPrefabs = new GameObject[4];

    private int[] enemyHPValues = { 100, 90, 75, 80 };

    // ========================================================
    // Spawn Points
    // ========================================================
    [Header("Spawn Points")]
    public Transform[] enemySpawnPoints = new Transform[3];

    private int spawnPoint;

    Vector3 spawnPosition = new Vector3();

    [HideInInspector]
    public int enemyCount = 0;

    [HideInInspector]
    public int enemyKillCount = 0;

    private int enemyType;

    //private int totalEnemies;
    private float secondsBetweenSpawns;

    private float elapsedTime = 0.0f;

    void Start()
    {
        secondsBetweenSpawns = 3.0f;

        //totalEnemies = 15;
        enemyCount = 0;
        enemyKillCount = 0;
    }

    // Click the "instantiate button to create a prefab
    // Somewhere within -10.0 and 10.0 (inclusive) on the x-z plane
    void OnGUI()
    {
        GUI.Button(new Rect(10, 10, 100, 50), ("Enemies: " + enemyCount));
        GUI.Button(new Rect(10, 80, 150, 50), ("Kil Count: " + enemyKillCount));
    }

    void FixedUpdate()
    {
        //secondsBetweenSpawns = 2.0f;
        elapsedTime += Time.deltaTime;

        if (elapsedTime > secondsBetweenSpawns && enemyCount < 10)
        {
            elapsedTime = 0;

            // Select random spawn point
            spawnPoint = Random.Range(0, 3);
            spawnPosition = enemySpawnPoints[spawnPoint].position;

            // Select random type of enemy
            enemyType = Random.Range(0, 4);
            GameObject enemySpawned =
                Instantiate(enemyPrefabs[enemyType],
                spawnPosition,
                Quaternion.identity) as
                GameObject;

            // Adjust HP values according to the type of enemy
            //int enemyHP = enemyHPValues[enemyType];
            // Adds to the count of enemies
            enemyCount++;
        }
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
