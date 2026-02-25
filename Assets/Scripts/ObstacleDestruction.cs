using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestruction : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //find the playerhealth child
            GameObject hearts = collision.gameObject.transform.Find("Main Camera/Player Health").gameObject;
            Animator anim = hearts.GetComponent<Animator>();
            PlayerMovement pm = collision.gameObject.GetComponent<PlayerMovement>();

            Destroy(this.gameObject);
            PlayerHealth.health -= 1;
            anim.SetInteger("remainingHearts", PlayerHealth.health);
            pm.collisionWithObstacle();
        }
    }
}
