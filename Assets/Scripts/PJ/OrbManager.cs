using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbManager : MonoBehaviour
{
    [Header("Orb Placement")]
    public int nOrbs = 3;

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

    /// <summary>
    /// Execute at the start
    /// </summary>
    void Start()
    {
        // Distribute the Ball equally around a circle, transform to Radians
        angle = (360 / nOrbs) * Mathf.Deg2Rad;

        // Create initial 3 Balls
        for (int i = 0; i < nOrbs; i++)
        {
            Instantiate(pjOrb,
            new Vector3(radius * Mathf.Cos(i * angle),
                radius * Mathf.Sin(i * angle),
                0),
            Quaternion.identity,
            transform);
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
                Vector3.MoveTowards(currentPosition, transform.parent.position, transSpeed * Time.deltaTime);
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
        transform.position = Vector3.MoveTowards(transform.position, target, transSpeed * Time.deltaTime);
    }
}
