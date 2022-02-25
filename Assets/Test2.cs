using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    void Start()
    {
        BattleManager.Instance.NightComing.AddListener(Hunt);
        BattleManager.Instance.NightComing.AddListener(Hunt);
        BattleManager.Instance.NightComing.AddListener(Kill);
    }

    public void Hunt(int i)
    {
        Debug.Log("天黑了我要出去打猎了" + i);
    }

    public void Kill(int i)
    {
        Debug.Log("天黑了我要出去口人了" + i);
    }

}
