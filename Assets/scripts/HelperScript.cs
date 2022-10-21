using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;


public class HelperScript : MonoBehaviour
{
    Rigidbody2D rb;
    LayerMask groundlayerMask;
    float rayLength = 0.2f;
    RaycastHit2D hit;
    PlayerScript playerScript;

    SpriteRenderer sr;
    void Start()
    {
        groundlayerMask = LayerMask.GetMask("ground");
        sr = gameObject.GetComponent<SpriteRenderer>();
        
    }
    public void FlipObjectTest(GameObject obj, bool faceLeft)
    {

    }

    public void SetColor( Color color )
    {
        sr.color = color;
    }

    public void FlipObject( GameObject obj, int objectDirection )
    {
        

        if( objectDirection == -1 )
        {
            //obj.transform.localRotation = Quaternion.Euler(0, 180, 0);
            sr.flipX = true;
    
        }
        else
        {
            //obj.transform.localRotation = Quaternion.Euler(0, 0, 0);
            sr.flipX = false;

        }

    
        
    }

    public int GetObjectDir( GameObject obj )
    {
        float ang = obj.transform.eulerAngles.y;
        if( ang == 180 )
        {
            return Left;
        }
        else
            return Right;
    }


    public void MakeBullet( GameObject prefab,  float xpos, float ypos, float xvel, float yvel, float zrot )
    {
        Vector3 rotation = new Vector3(0, 0, zrot);

        // instantiate the object at xpos,ypos
        GameObject instance = Instantiate(prefab, new Vector3(xpos,ypos,0), Quaternion.Euler(rotation) );
        
        // set the velocity of the instantiated object
        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3( xvel, yvel, 0 );

        // set the direction of the instance based on the x velocity
        FlipObject( instance, xvel<0?Left:Right);
    }

    public bool ColCheck()
    {
        hit = Physics2D.Raycast(transform.position, -Vector2.up, rayLength, groundlayerMask);

        Debug.DrawRay(transform.position, -Vector2.up * rayLength, (hit.collider != null) ? Color.green : Color.white);

        return hit.collider != null;
    }
}
