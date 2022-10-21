using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;




public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject player;
    public Transform followPoint;
    public float enemySpeed;
    private Animator anim;
    public GameObject prefab;
    public GameObject spear;
    public Transform attackpoint;
    [SerializeField] float currentHealth, maxHealth = 100f;
    float attackMeter = 10f;
    public int attackDamage = 10;
    bool attackReady;
    PlayerScript playerScript;
    Vector2 movementDirection;
    public Transform target;
    public float moveSpeed = 5f;
    private Vector2 movement;
    HelperScript helper;
    int state;
    private enemypatrol enemyPatrol;
    [SerializeField] private LayerMask playerLayer;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        attackReady = false;
        player = GameObject.FindGameObjectWithTag("player");
        helper = gameObject.AddComponent<HelperScript>();
       

        state = IdleState;
    }
    private void Update()
    {

        if( attackReady)
        {
            helper.SetColor(Color.red);
        }
        else
        {
            helper.SetColor(Color.white);
        }


        if (currentHealth <= 0)
        {
            Die();
        }
        if (currentHealth > 0)
        {
            if( state == IdleState )
            {
                if (CheckforAttack() == true)
                {
                    state = AttackState;
                }


            }

            if ( state == MoveState )
            {
                PlayerMovement(movement);
                
                if( CheckforAttack() == true )
                {
                    state = AttackState;
                }
            }

            if (state == AttackState)
            {
                DoAttack();
            }

            Direction();
        }

  
    }
    void Die()
    {
        anim.SetTrigger("Death");
        Invoke(nameof(Timestop), 1f);
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        anim.SetTrigger("Hurt");
        print("enemy hit. Damage=" + currentHealth);
        
    }
    void Timestop()
    {
        Destroy(gameObject);
    }

    void Fireball()
    {
        if (attackMeter > 0)
        {
            attackMeter = attackMeter - 7;
            GameObject projectileInstance;
            projectileInstance = Instantiate(prefab, attackpoint);
            Rigidbody2D rb = projectileInstance.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(10, 0);
        }
        if (attackMeter < 10)
        {
            attackMeter += Time.deltaTime * 1f;
        }
    }

    void Direction()
    {
        Vector3 direction = followPoint.position - transform.position;
        direction.Normalize();
        movement = direction;
    }

    void PlayerMovement(Vector2 direction)
    {
        anim.SetTrigger("Run");
     transform.position = Vector2.MoveTowards(this.transform.position, target.position, moveSpeed * Time.deltaTime);
    }


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "player")
        {
            print("*** enemy no longer colliding with player");
            col.gameObject.GetComponent<HelperScript>().SetColor(Color.white);
        }


    }

 
    void OnTriggerStay2D(Collider2D col)
    {
        

        if (col.gameObject.tag == "player")
        {
            print("*** enemy collided with player");
            col.gameObject.GetComponent<HelperScript>().SetColor(Color.red);
        }

        if ((col.gameObject.tag == "player") && attackReady)
        {
            PlayerScript player = col.gameObject.GetComponent<PlayerScript>();
            player.TakeDamage(attackDamage);
            attackReady=false;
            //print("collision with " + col.gameObject.tag);
        }
    }



    bool CheckforAttack()
    {
        Vector2 dist = player.transform.position - transform.position;
        if (dist.x < 1 && dist.x > 0)
        {
            // player is on right side
            return true;

        }
        if ((dist.x > -1.2f) && (dist.x < 0))
        {
            return true;
            // player is on left side
            //helper.FlipObject(gameObject, Left);
            //print("do flip");
        }
        return false;
    }

    void DoAttack()
    {
    //  check for enemy distance from player

        

    //print("dist=" + dist.x);


        //if (attackMeter > 0)
        {
            anim.SetTrigger("Attack");
            //attackReady = false;
            //print("do attack");
        }

    }



    public void StartOfAtttack()
    {
        attackReady = true;
        
    }

    public void EndOfAttack()
    {
        attackReady = false;
        state = IdleState;
    }
}
