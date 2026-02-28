using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        float distance = lastDistance - rb.position.y;
        distanceMoved += distance;

        if (distanceMoved >= distanceInterval)
        {
            stormSpeedY = stormSpeedY * multiplier;
            rb.velocity = new Vector2(0, stormSpeedY);
            distanceMoved = 0f;
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
            SceneManager.LoadScene("GameOver");
        }
    }
}
