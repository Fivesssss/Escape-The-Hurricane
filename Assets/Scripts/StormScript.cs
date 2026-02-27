using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float distanceInterval = 25f;
    private float lastDistance;
    [SerializeField] private float multiplier = 1.02f;
    private float distanceMoved = 0f;
    [SerializeField] private float stormSpeedY = -5f;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastDistance = rb.position.y;
    }

    public void FixedUpdate()
    {
        distanceMoved = lastDistance - rb.position.y;

        if (distanceMoved >= distanceInterval)
        {
            stormSpeedY = stormSpeedY * multiplier;
            rb.velocity = new Vector2(0, stormSpeedY);
        }
        else
        {
            rb.velocity = new Vector2(0, stormSpeedY);
        }

        lastDistance = rb.position.y;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") { 
            Destroy(collision.gameObject);
        }
    }
}
