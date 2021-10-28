using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //[SerializeField]
    //private float BulletSpeed = 5;
    //[SerializeField]
    //private GameObject Bullet;
    //private bool Bullet_InMotion;
    //public GameObject player;
    public Rigidbody2D mybody;
    private float playermoveX;
    private bool playerjump;
    private bool OnGround = true;
    private bool OnWall = false;

    // private bool IsAlive = true;
    //private bool IsHit = false;
    private Animator anim;
    //private string WALK_ANIMATION = "WALK";
    //private string JUMP_ANIMATION= "JUMP";
    //private string HIT_ANIMATION= "HIT";
    private int PlayerHitCount=0;
    private bool gravitydown = true;
    private int jumpsign;
    
    [SerializeField]
    private float MoveForce = 10f;
    [SerializeField]
    private float JumpForce = 10f;
    [SerializeField]
    private float WallJumpForce = 14f;
    // Start is called before the first frame update
    void Start()
    {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //Bullet = GameObject.FindGameObjectWithTag("Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
    }
    private void FixedUpdate()
    {
        //if (Input.GetButtonDown("Fire1")|| Bullet_InMotion)
        //    Bullet_Fire();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnGround = true;
          //  anim.SetBool(WALK_ANIMATION, true);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            OnWall = true;
            //  anim.SetBool(WALK_ANIMATION, true);
        }
        if (collision.gameObject.CompareTag("Danger"))
        {
            PlayerHit();
        }
        if (collision.gameObject.CompareTag("Exit"))
        {
            Destroy(gameObject);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay Select");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GravityTrigger"))
        {
            gravitydown ^= true;
        }
    }

    void PlayerMoveKeyboard()
    {
        playermoveX = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("D") || playermoveX == 1)
        {
            transform.position += Time.deltaTime * (new Vector3(playermoveX, 0f)) * MoveForce;
        }
        if(Input.GetButtonDown("A") || playermoveX == -1)
        {
            transform.position += Time.deltaTime * (new Vector3(playermoveX, 0f)) * MoveForce;
        }
        playerjump = Input.GetButtonDown("Jump");
        if ((Input.GetButtonDown("W") || playerjump) && (OnGround || OnWall))
        {
            float Force;
            if (OnWall)
                Force = WallJumpForce;
            // or we can decrese gravity here
            else
                Force = JumpForce;
            OnGround = false;
            OnWall = false;
            if (!gravitydown)
                jumpsign = -1;
            else
                jumpsign = 1;
            mybody.AddForce(new Vector2(0f, Force*jumpsign), ForceMode2D.Impulse);
        }
        //else 
        //    Bullet.transform.position = transform.position;
    }
    void PlayerHit()
    {
        if(PlayerHitCount < 3)
        {
            mybody.AddForce(new Vector2(-playermoveX*2, 4f), ForceMode2D.Impulse);
         //   anim.SetBool(HIT_ANIMATION, true);
            PlayerHitCount += 1;
        }
        else if(PlayerHitCount == 3)
        {
            Destroy(gameObject);
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
    }

    //void Bullet_Fire()
    //{
    //    Bullet.transform.position += Time.deltaTime*(new Vector3(BulletSpeed,0f,0f));
    //}
}
