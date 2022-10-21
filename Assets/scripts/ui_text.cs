using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ui_text : MonoBehaviour
{

    private Text txtComponent; 
    private string debugString;
    

    public static void Debug(string str )
    {
        //FindObjectOfType<ui_text>().DebugString(str);
    }

    // Start is called before the first frame update
    void Start()
    {

        debugString="";

        txtComponent = GetComponent<Text>();
        
        
    }


    void LateUpdate()
    {
        txtComponent.text = debugString;
        debugString="";

    }

    
    
    public void DebugString( string str )
    {
        debugString = debugString + str + "\n";
    }

}
