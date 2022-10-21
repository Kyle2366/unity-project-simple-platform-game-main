using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {


    }

    

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);

        
        if( col.gameObject.tag == "Player")
        {
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;

            // destroy after 0.3 seconds
            Object.Destroy(gameObject, 0.3f);

        }
        else
        {
        
        }
    }
}
