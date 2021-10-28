using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterGate_Entry : MonoBehaviour
{
    [SerializeField]
    private Transform ExitGate;
    [SerializeField]
    private float boxcolliderlen = 5;
    private Vector2 PlyrPosnew;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlyrPosnew.x = ExitGate.position.x + boxcolliderlen;
            PlyrPosnew.y = ExitGate.position.y;
            GameObject.FindGameObjectWithTag("Player").transform.position = PlyrPosnew;

        }
    }
}
