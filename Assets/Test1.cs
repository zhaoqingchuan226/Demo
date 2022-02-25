using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3 : MonoBehaviour
{
  
    void Start()
    {
        BattleManager.Instance.NightComing.AddListener(Run);
    }

    public void Run(int i)
    {
        Debug.Log("天黑了我要回家了"+i);
    }

   
}
