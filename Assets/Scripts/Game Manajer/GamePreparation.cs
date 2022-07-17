using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePreparation : MonoBehaviour
{
    // Target Player
    public GameObject targetPlayer;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Application Quit");
            Application.Quit();
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(200, 10, 150, 50), ("WASD: Move"));
        GUI.Label(new Rect(200, 50, 150, 50), ("Mouse: Look"));
        GUI.Label(new Rect(200, 90, 150, 50), ("Left Click: Attack"));
    }
}
