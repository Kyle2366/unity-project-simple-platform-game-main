using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{

    public bool isOpen;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenChest()
    {
        if(!isOpen)
        {
            isOpen = true;
            Debug.Log("chest is now open.........");
            anim.SetBool("Open",isOpen);
        }
    }
}

