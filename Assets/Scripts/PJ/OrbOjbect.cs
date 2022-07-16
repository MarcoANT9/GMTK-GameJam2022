using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbOjbect : MonoBehaviour
{
    // Maximum Value for each die.
    private int maxValue;

    // Dice type... not sure if it will be usefull but meh.
    private int diceType;

    // Orb Damage.
    private int damageDealtOrb;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// Gives Maximum value to the die.
    /// </summary>
    /// <param name="value"> Maximum Value of the Die for Damage. </param>
    public void assingMaxValue(int value)
    {
        maxValue = value;
    }

    /// <summary>
    /// Select Color/Sprite for the die.
    /// </summary>
    /// <param name="value"> Color/Sprite for the die. </param>
    public void assingColor(Color value)
    {
        gameObject.GetComponent<Renderer>().material.color = value;
    }

    /// <summary>
    /// Select Type for the die.
    /// </summary>
    /// <param name="value"> Die Type... not sure why we need this but there it is. </param>
    public void assingDiceType(int value)
    {
        diceType = value;
    }

    /// <summary>
    /// Damages an enemy when Orb enters collision with the "Enemy Type".
    /// </summary>
    /// <param name="collision"> Other Element. </param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        damageDealtOrb = Random.Range(1, maxValue + 1);
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("applyDamage", damageDealtOrb);
        }
    }
}
