using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnGUI()
    {
        // GUI.Label(new Rect(Screen.width/2-100,Screen.height/2,20,40),"你好");
        GUI.Label(new Rect( 990, 540,160,160), "Hello World!");
        
    }


    // Update is called once per frame
    void Update()
    {

    }
}
