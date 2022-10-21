using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform1 : MonoBehaviour
{

    int timer;
    int xSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        xSpeed = 3;
        timer=0;
    }

    // Update is called once per frame
    void Update()
    {
        movePlatform(); // really should be called in Fixedupdate


    }

    public void movePlatform()
    {

        // move the platform in the x direction
        Vector2 myVector = new Vector2( xSpeed * Time.deltaTime, 0 );
        transform.Translate( myVector );


        // counter to change direction
        timer++;
        if( timer > 400 )
        {
            timer=0;
            xSpeed = -xSpeed;
        }
    }            

    private void OnCollisionEnter2D( Collision2D collision )
    {
        Debug.Log("collide");
        //if( collision.WasWithPlayer())
        {
            
            collision.collider.transform.SetParent(transform);
            transform.SetParent(collision.transform, false);
            


        }
    }

    private void OnCollisionExit2D( Collision2D collision )
    {
        collision.collider.transform.SetParent(null);
    }


}
