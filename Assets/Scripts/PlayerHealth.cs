using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static int health = 5;

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) { 
            Destroy(this.gameObject);
        }
    }
}
