using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercombat : MonoBehaviour
{
    public Animator anim;
    public Transform attackpoint;
    public float attackRange = 1f;
    public LayerMask enemyLayers;
    public int attackDamage = 20;
    public int boltDamage = 70;
    PlayerScript player;
    bool attackReady;
    public GameObject prefab;
    float mana = 100;
    HelperScript  helper;
    public GameObject boltPrefab;
    public bool canShoot;

    private void Start()
    {

        player = GetComponent<PlayerScript>();
        attackReady = false;
        helper = gameObject.AddComponent<HelperScript>();
       

    }
    // Update is called once per frame
    void Update()
    {
        Attack();
        unlockFire();
        print("attackready=" + attackReady);
        Bolt();
    }


    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("attacking");
            attackReady = false;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {

        if ((col.gameObject.tag == "enemy") && attackReady)
        {
            Enemy enemyScript = col.gameObject.GetComponent<Enemy>();

            enemyScript.TakeDamage(attackDamage);
            attackReady = false;
            print("collision with " + col.gameObject.tag);
        }




    }

    public void StartOfAttack()
    {
        attackReady = true;

    }
    public void EndOfAttack()
    {
        attackReady = false;
    }

    void Bolt()
    {
        float x, y;
        float xvel;
        if (Input.GetKeyDown("q")&& mana>=50)
        {
            mana -= 50;
            x = transform.position.x;
            y = transform.position.y + 1;
            xvel = 6;
            helper.MakeBullet(boltPrefab, x, y, xvel, 0, 0);
        }

    }

    public void unlockFire()
    {
        if(canShoot)
        {
            if (Input.GetKeyDown("r"))
            {
                anim.SetTrigger("Fireball");
                if (mana >= 20)
                {

                    float x, y;
                    float xvel;
                    if (Input.GetKeyDown("r") && mana >= 20)
                    {
                        mana -= 20;
                        x = transform.position.x;
                        y = transform.position.y + 1;
                        xvel = 6;
                        helper.MakeBullet(prefab, x, y, xvel, 0, 90);
                    }
                }
            }

            if (mana < 100)
            {
                mana += Time.deltaTime * 10;
            }

            print("mana=" + mana);
        }
        else
        {

        }
    }
}