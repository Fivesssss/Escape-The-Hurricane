using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform playerT;
    private Vector2 movement;
    [SerializeField] private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
        playerT = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        movement.x = x * speed;
        movement.y = -5;

        rb.velocity = movement;
    }

    public void collisionWithObstacle()
    { 
        Vector2 velocity = rb.velocity;
        velocity.y = 0;
        rb.velocity = velocity;
    }
}
