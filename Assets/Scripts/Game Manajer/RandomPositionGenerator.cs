using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPositionGenerator : MonoBehaviour
{
    public GameObject prefabEnemyMelee;

    public GameObject prefabEnemyAdc;

    public GameObject prefabEnemyMage;

    public GameObject prefabEnemySpecialist;

    [HideInInspector]
    public int enemyCount;
    [HideInInspector]
    public int enemyDeadRound;
    private int enemyCountRound;

    private int enemyType;

    private int round;

    void Start()
    {
        round = 1;
        enemyCountRound = round * 10;
        enemyCount = 0;
    }

    // Click the "instantiate button to create a prefab
    // Somewhere within -10.0 and 10.0 (inclusive) on the x-z plane
    void OnGUI()
    {
        GUI.Button(new Rect(10, 10, 100, 50), ("Round: " + round));
        GUI.Button(new Rect(10, 80, 100, 50), ("Enemies: " + enemyCountRound));
    }

    void Update()
    {
        if (round == 2)
        {
            finnishGame();
        }
        if (enemyCount >= 0 && enemyCount < 5)
        {
            enemyType = Random.Range(1, 5);
            switch (enemyType)
            {
                case 1:
                    GameObject enemyMelee =
                    Instantiate(prefabEnemyMelee,
                    new Vector3(1, 1, 0),
                    Quaternion.identity) as
                    GameObject;

                    Debug.Log("Enemy " + enemyCount + " Spawned.");
                    enemyMelee.SendMessage("setHP", 150);
                    break;

                case 2:
                    GameObject enemyAdc =
                    Instantiate(prefabEnemyAdc,
                    new Vector3(-1, 1, 0),
                    Quaternion.identity) as
                    GameObject;
                    
                    Debug.Log("Enemy " + enemyCount + " Spawned.");
                    enemyAdc.SendMessage("setHP", 50);
                    break;

                case 3:
                    GameObject enemyMage =
                    Instantiate(prefabEnemyMage,
                    new Vector3(1, -1, 0),
                    Quaternion.identity) as
                    GameObject;

                    Debug.Log("Enemy " + enemyCount + " Spawned.");
                    enemyMage.SendMessage("setHP", 75);
                    break;

                case 4:
                    GameObject enemySpecialist =
                    Instantiate(prefabEnemySpecialist,
                    new Vector3(-1, -1, 0),
                    Quaternion.identity) as
                    GameObject;

                    Debug.Log("Enemy " + enemyCount + " Spawned.");                    
                    enemySpecialist.SendMessage("setHP", 150);
                    break;

                default:
                    Debug.Log("No enemies for you!");
                    break;
            }

        if (enemyCount > 3)
        {
            StartCoroutine(EnemyCoolDown());
        }
        if (enemyDeadRound == enemyCountRound)
        {
            round ++;
            enemyDeadRound = 0;
            enemyCountRound = round * 10;
        }

        }
    }

    public void incrementDeathCount()
    {
        enemyDeadRound++;
    }

    private void finnishGame()
    {
        Debug.Log("Game Over");
    }

    IEnumerator EnemyCoolDown()
    {
        yield return new WaitForSeconds(20);
    }

}
