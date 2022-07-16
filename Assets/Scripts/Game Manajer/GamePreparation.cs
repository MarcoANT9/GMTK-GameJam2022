using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePreparation : MonoBehaviour
{
    public GameObject prefabPlayerChar;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerChar =
            Instantiate(prefabPlayerChar, Vector3.zero, Quaternion.identity) as
            GameObject;
        
        playerChar.SendMessage("setHP", 500);
        playerChar.SendMessage("stPej", true);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
