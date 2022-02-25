using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BattleManager : MonoSingleton<BattleManager>
{
    public UnityEvent<int> NightComing = new UnityEvent<int>();

    public void OnClickNight()
    {
        NightComing.Invoke(2);
    }
}
