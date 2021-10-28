using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    public bool Ready = true;
    [SerializeField]
    public bool Bullet_InMotion = false;
    [SerializeField]
    private float BulletSpeed = 5;
    [SerializeField]
    private GameObject Player;

    private float playermoveX;

    void Update()
    {
        if (!Player)
        {
            return;
        }

        if (Input.GetButtonDown("Fire2")|| Ready)
        {
            if (Ready && !Input.GetButtonDown("Fire2"))
            {
                Bullet_InMotion = false;
            }
            else
            {
                Bullet_InMotion = true;
                Ready = false;
            }
        }
        if (Bullet_InMotion )
        {
            transform.localPosition += Time.deltaTime * (new Vector3(BulletSpeed, 0f, 0f));
        }
        else
        {
            playermoveX = Input.GetAxisRaw("Horizontal");
            if (Input.GetButtonDown("A") || playermoveX == -1)
                BulletSpeed = (-1) * Mathf.Abs(BulletSpeed);
            if (Input.GetButtonDown("D") || playermoveX == 1)
                BulletSpeed = Mathf.Abs(BulletSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Bullet_InMotion)
        {
            if (collision.CompareTag("Ground") || collision.CompareTag("Danger") || collision.CompareTag("Exit") || collision.CompareTag("Stopper"))
            {
                Ready = true;
            }
        }
    }
}
