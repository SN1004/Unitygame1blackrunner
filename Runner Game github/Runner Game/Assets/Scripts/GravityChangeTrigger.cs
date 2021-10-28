using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChangeTrigger : MonoBehaviour
{
    private Rigidbody2D player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")|| collision.CompareTag("Bullet"))
        {
            player = PlayerMovement.FindObjectOfType<Rigidbody2D>();
            player.gravityScale *= (-1);
        }
    }
}
