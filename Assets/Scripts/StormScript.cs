using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        rb.velocity = new Vector2(0, -5);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") { 
            Destroy(collision.gameObject);
        }
    }
}
