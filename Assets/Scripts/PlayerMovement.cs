using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform playerT;
    private Vector2 movement;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float speedY = -5f;
    [SerializeField] private float distanceInterval = 20f;
    private float lastDistance;
    [SerializeField] private float multiplier = 1.05f;
    private float distanceMoved = 0f;
    [SerializeField] private Slider progressSlider;
    [SerializeField] private float levelLength = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
        playerT = GetComponent<Transform>();
        progressSlider.value = 0f;
        lastDistance = rb.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = lastDistance - rb.position.y;
        distanceMoved += distance;
        float x = Input.GetAxisRaw("Horizontal");
        
        //speed multiplier  
        if (distanceMoved >= distanceInterval)
        {
            speedY = speedY * multiplier;
            speed = speed * multiplier;
            movement.x = x * speed;
            movement.y = speedY;
            distanceMoved = 0f;
        }
        else 
        {
            movement.y = speedY;
            movement.x = x * speed;
        }

        //restrict player movement to wihtin the camera
        if (transform.position.x >= 19.70f && movement.x > 0)
        {
            movement.x = 0;
        }
        else if (transform.position.x <= -19.70f && movement.x < 0) 
        {
            movement.x = 0;
        }

        //update the velocity
        rb.velocity = movement;
        lastDistance = rb.position.y;

        //update progress slider
        progressSlider.value = -(rb.position.y) / levelLength;
    }

    public void collisionWithObstacle()
    { 
        Vector2 velocity = rb.velocity;
        velocity.y = 0;
        rb.velocity = velocity;
    }
}
