using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterGate_Exit : MonoBehaviour
{
    [SerializeField]
    private Transform EntryGate;
    [SerializeField]
    private float boxcolliderlen=5;
    private Vector2 PlyrPosnew;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlyrPosnew.x = EntryGate.position.x + boxcolliderlen;
            PlyrPosnew.y = EntryGate.position.y;
            GameObject.FindGameObjectWithTag("Player").transform.position = PlyrPosnew;

        }
    }
}
