using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceData : MonoBehaviour
{
    [HideInInspector]
    // D4 - 10%
    public Color grayColor = Color.grey;

    [HideInInspector]
    // D6 - 30%
    public Color greenColor = Color.green;

    [HideInInspector]
    // D8 - 60%
    public Color blueColor = Color.blue;

    [HideInInspector]
    // D10 - 90%
    public Color purpleColor = Color.magenta;

    [HideInInspector]
    // D20 - 100%
    public Color yellowColor = Color.yellow;

    [HideInInspector]
    // Type 0
    public int D4 = 4;

    [HideInInspector]
    // Type 1
    public int D6 = 6;

    [HideInInspector]
    // Type 2
    public int D8 = 8;

    [HideInInspector]
    // Type 3
    public int D10 = 10;

    [HideInInspector]
    // Type 4
    public int D20 = 20;
}
