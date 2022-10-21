using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class PlayerScript : MonoBehaviour
{
    public Transform attackpoint;
    public float attackRange = 0.5f;
    public float currentHealth = 0f;
    public float playerHealth = 100f;
    private Rigidbody2D rb;
    private Animator anim;
    public bool isGrounded;
    bool isJumping;
    public GameObject bulletPrefab;
    HelperScript helper;
    public GameObject StartPos;
    public bool isAttacking;
    int state;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        helper = gameObject.AddComponent<HelperScript>();
        currentHealth = playerHealth;

        

        isJumping = false;

    }

    // Update is called once per frame
    void Update()

    {
        DoJump();
        DoMove();
        DoLand();
        DoShoot();
        HealthTest();
        Death();

        isGrounded = helper.ColCheck();
    }
        void DoJump()
        {
            Vector2 velocity = rb.velocity;

            // check for jump
            if (Input.GetKey("space") && (isGrounded == true))
            {
                velocity.y = 6f;    // give the player a velocity of 5 in the y axis
                anim.SetBool("jump", true);
                isJumping = true;
            }

            rb.velocity = velocity;

        }



        void DoMove()
        {


            Vector2 velocity = rb.velocity;



            // stop player sliding when not pressing left or right
            velocity.x = 0;

            // check for moving left
            if (Input.GetKey("left"))
            {
                velocity.x = -2;

                anim.SetBool("walk", true);

            }
            else
            {
                anim.SetBool("walk", false);
            }
            // check for moving right

            if (Input.GetKey("right"))
            {
                velocity.x = 2;
                anim.SetBool("walk", true);
            }
            else
            {
                anim.SetBool("walk", false);
            }

            if (velocity.x != 0)
            {
                anim.SetBool("walk", true );
            }
            else
            {
                anim.SetBool("walk", false );
            }


            // make player face left or right depending on whether his velocity is positive or negative
            if (velocity.x < -0.5f)
            {
                helper.FlipObject(gameObject, Left);
                helper.FlipObjectTest(gameObject, true);
            }
            if (velocity.x > 0.5f)
            {
                helper.FlipObject(gameObject, Right);
            }


            rb.velocity = velocity;
        }


        void DoLand()
        {
            // check for player landing

            if (isJumping && isGrounded && (rb.velocity.y <= 0))
            {
                print("landed!");
                // player was jumping and has now hit the ground
                isJumping = false;
                anim.SetBool("jump", false);
            }
        }

        void DoShoot()
        {
            float x, y;
            float xvel;
            if (Input.GetKeyDown("s"))
            {
                x = transform.position.x;
                y = transform.position.y+1;



                // if player is facing left, move the bullet left
                if (helper.GetObjectDir(gameObject) == Left)
                {
                    xvel = -65;


                }
                else
                {
                    xvel = 65;


                }

                helper.MakeBullet(bulletPrefab, x, y, xvel, 0, 0);
            }

        }

        void HealthTest()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                playerHealth -= 20;
                print(playerHealth);
            }
        }

    public  void Death()
    {
        if (currentHealth <= 0)
        {
            anim.SetTrigger("Death");
            Invoke(nameof(Timestop),2f);
        }
        
    }
 
    void Timestop()
    {
        transform.position = StartPos.transform.position;
        playerHealth = 100;
        state = IdleState;
    }
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        //anim.SetTrigger("Hurt");
        print("player hit. Damage=" + currentHealth);

    }
}
