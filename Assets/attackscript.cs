using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackscript : MonoBehaviour
{
    int attackDamage = 70;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D col)
    {

        if ((col.gameObject.tag == "enemy"))
        {
            Enemy enemyScript = col.gameObject.GetComponent<Enemy>();

            enemyScript.TakeDamage(attackDamage);
            print("collision with " + col.gameObject.tag);
            Destroy(gameObject);
        }

    }
}