using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Close : MonoBehaviour
{

    bool a;
    bool isFirst = true;

  
    public void SetActiveTrue_False(bool b)
    {
        if (isFirst)
        {
            isFirst = false;
            a = b;
        }

        if (a == true)
        {
            gameObject.SetActive(false);
            a = false;
        }
        else if (a == false)
        {
            gameObject.SetActive(true);
            a = true;
        }


    }


}
