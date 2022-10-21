using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flatPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                Vector2 myVector = new Vector2( 5 * Time.deltaTime, 0 * Time.deltaTime );
        transform.Translate( myVector );

    }


    private void OnTriggerEnter2D( Collider2D other )
    {
        Debug.Log("flat plat collide with " + other.gameObject.tag + "using ontriggerenter");
        Destroy( other.gameObject );
    }

    private void OnCollisionEnter2D( Collision2D collision )
    {
        Debug.Log("flat plat collide with " + collision.gameObject.tag);
        
    }

        private void OnCollisionExit2D( Collision2D collision )
    {
        Debug.Log("end of flat plat collide with " + collision.gameObject.tag);
        
    }

}
