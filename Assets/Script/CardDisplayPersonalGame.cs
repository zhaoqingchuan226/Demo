using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//此脚本挂载在card prefab上
//用于将Card中的数据赋予给UI
public class CardDisplayPersonalGame : MonoBehaviour
{

    public TextMeshPro titleText;
    public Material mat;
    // public TextMeshProUGUI TimeText;
    // public TextMeshProUGUI descriptionText;

    // public Image BackgourndImage;
    // public Image QualityImage;

    public Card card;
    void Start()
    {
        ShowCard();
    }

    void ShowCard()//将Card中的数据赋予给UI
    {
        titleText.text = card.title;
        mat.SetColor("_Color", card.actionColor);//不一定对
        // TimeText.text = card.times;
        // descriptionText.text = card.description;
        // BackgourndImage.color = card.actionColor;
        // QualityImage.color = card.qualityColor;
    }

}
