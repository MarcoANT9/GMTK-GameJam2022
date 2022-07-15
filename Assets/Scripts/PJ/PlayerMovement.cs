using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 20.0f;

    private Rigidbody2D body;

    private float vertical;

    private float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Vector2 speed = new Vector2(horizontal, vertical);
        body.velocity = speed.normalized * MoveSpeed;
    }
}
