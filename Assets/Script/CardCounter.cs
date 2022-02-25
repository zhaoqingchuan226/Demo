using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//用于在Library中显示卡牌的数量
public class CardCounter : MonoBehaviour
{
    public TextMeshProUGUI counter;
    public int count;

    public void SetCounter(int num)
    {
        count = num;
        counter.text=count.ToString();
    }
}
