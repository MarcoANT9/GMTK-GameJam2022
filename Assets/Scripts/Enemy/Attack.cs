using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject attack;
    public void attackPlayer(GameObject target)
    {
        Instantiate(attack, this.transform);
    }
}
