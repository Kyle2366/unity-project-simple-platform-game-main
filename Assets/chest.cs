using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class chest : MonoBehaviour
{

    public bool isInRange;
    public UnityEvent interactAction;
    public KeyCode interactKey;
    public playercombat pc;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        isInRange = false;
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange)
        {
            if(Input.GetKeyDown("e"))
            {
                anim.SetBool("Open", true);
                pc.canShoot = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("player"))
        {
            isInRange = true;
            Debug.Log("Player now in range");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            isInRange = false;
            Debug.Log("Player now not in range");
        }
    }
}
