using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceData : MonoBehaviour
{
    [HideInInspector]
    public Color[]
        diceColors =
        { Color.grey, Color.green, Color.blue, Color.magenta, Color.yellow };

    [HideInInspector]
    public int[] diceValues = { 4, 6, 8, 10, 20 };

    public GameObject[] diceObjects;

    public Sprite[] diceSpriteArray= new Sprite[5];

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            diceSpriteArray[i] = diceObjects[i].GetComponent<SpriteRenderer>().sprite;
        }
    }
}
