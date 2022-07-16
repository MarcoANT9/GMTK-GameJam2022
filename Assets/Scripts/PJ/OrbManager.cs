using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbManager : MonoBehaviour
{
    [Header("Orb Placement")]
    // ========================================================
    // Orb Initialization variables
    // ========================================================
    public int nOrbs;

    public GameObject pjOrb;

    private float angle;

    private float radius = 3.0f;

    // ========================================================
    // Orb Rotation Variables
    // ========================================================
    private float rotationSpeed = 100.0f;

    private float maxRotationSpeed = 500.0f;

    private float minRotationSpeed = 100.0f;

    //private float coolDownTime = 5.0f;
    // ========================================================
    // Orb Translation Variables
    // ========================================================
    private float transSpeed = 15.0f;

    private Vector3 target;

    private Vector3 currentPosition;

    // ========================================================
    // Orb Data
    // ========================================================
    private GameObject dataDiceGameObject;

    private DiceData diceData;

    private int diceType;

    private int maxValue;

    private Color spriteColor = Color.white;

    /// <summary>
    /// Execute at the start
    /// </summary>
    void Start()
    {
        dataDiceGameObject = GameObject.Find("GameManager");
        diceData = dataDiceGameObject.GetComponent<DiceData>();
        nOrbs = Random.Range(3, 7);

        // Distribute the Ball equally around a circle, transform to Radians
        angle = (360 / nOrbs) * Mathf.Deg2Rad;

        // Create initial 3 Balls
        for (int i = 0; i < nOrbs; i++)
        {
            GameObject Orb =
                Instantiate(pjOrb,
                new Vector3(radius * Mathf.Cos(i * angle),
                    radius * Mathf.Sin(i * angle),
                    0),
                Quaternion.identity,
                transform) as
                GameObject;

            // Assign Values to each Orb
            diceType = Random.Range(1, 101);

            if (diceType <= 10)
            {
                // Dice Type
                diceType = 0;

                // Color / Sprite Select
                spriteColor = diceData.grayColor;
                // Maximum dice value
                maxValue = diceData.D4;
            }
            else if (diceType > 10 && diceType <= 30)
            {
                // Dice Type
                diceType = 1;

                // Color / Sprite Select
                spriteColor = diceData.greenColor;
                // Maximum dice value
                maxValue = diceData.D6;
            }
            else if (diceType > 30 && diceType <= 60)
            {
                // Dice Type
                diceType = 2;

                // Color / Sprite Select
                spriteColor = diceData.blueColor;
                // Maximum dice value
                maxValue = diceData.D8;
            }
            else if (diceType > 60 && diceType <= 90)
            {
                // Dice Type
                diceType = 3;

                // Color / Sprite Select
                spriteColor = diceData.purpleColor;
                // Maximum dice value
                maxValue = diceData.D10;
            }
            else
            {
                // Dice Type
                diceType = 4;

                // Color / Sprite Select
                spriteColor = diceData.yellowColor;
                // Maximum dice value
                maxValue = diceData.D20;
            }
            
            Orb.SendMessage("assingColor", spriteColor);
            Orb.SendMessage("assingMaxValue", maxValue);
            Orb.SendMessage("assingDiceType", diceType);
        }

        target = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentPosition = transform.position;

        // Rotates the whole GameObject
        transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));

        // Accelerates the rotation of the Balls (up to 500.0f) and moves their reference to the mouse location
        if (Input.GetMouseButton(0))
        {
            accelerateBalls();
            moveBalls();
        }
        else
        {
            rotationSpeed -= 10.0f;
            if (rotationSpeed < minRotationSpeed)
                rotationSpeed = minRotationSpeed;
            transform.position =
                Vector3
                    .MoveTowards(currentPosition,
                    transform.parent.position,
                    transSpeed * Time.deltaTime);
        }

        // Moves Towards Cursor
    }

    /// <summary>
    /// Accelerate the orbs if cooldown allows it
    /// </summary>
    void accelerateBalls()
    {
        rotationSpeed += 10.0f;

        if (rotationSpeed > maxRotationSpeed) rotationSpeed = maxRotationSpeed;
    }

    /// <summary>
    /// Move Balls to the location of the mouse
    /// </summary>
    void moveBalls()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z;
        transform.position =
            Vector3
                .MoveTowards(transform.position,
                target,
                transSpeed * Time.deltaTime);
    }
}
