using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//所有原始卡的卡池
public class CardStore : MonoBehaviour
{
    public TextAsset cardData;
    public List<Card> cards = new List<Card>();//这是所有的原始卡牌
    void Awake()
    {
        LoadCardDataFromCSV();
        // Test();////用于展示卡组里面全部的卡牌
    }


    void Update()
    {

    }
    //从excel的csv文件中加载所有卡牌的数据到cards中
    void LoadCardDataFromCSV()
    {
        string[] dataRows = cardData.text.Split('\n', System.StringSplitOptions.RemoveEmptyEntries);
        foreach (var dataRow in dataRows)
        {
            string[] elements = dataRow.Split(',', System.StringSplitOptions.RemoveEmptyEntries);
            if (elements[0] == "id")
            {
                continue;
            }
            else
            {
                int id = int.Parse(elements[0]);
                string title = elements[1];
                string description = elements[2];
                int qualityLevel = int.Parse(elements[3]);


                Card.ActionType actionType;
                if (elements[4].Contains("动"))
                {
                    actionType = Card.ActionType.Dynamic;
                }
                else if (elements[4].Contains("静"))
                {
                    actionType = Card.ActionType.Static;
                }

                else
                {
                    actionType = Card.ActionType.Unknown;
                }

                string times =elements[5];



                    Card card = new Card(id, title, description, qualityLevel, actionType, times);
                cards.Add(card);
            }
        }
    }
    void Test()
    {
        foreach (var card in cards)
        {
            Debug.Log("读取到" + card.id.ToString() + card.title + card.qualityLevel.ToString());
        }
    }

    public Card RandomCard()//从原始卡牌中随机选择一张返回
    {
        return cards[Random.Range(0, cards.Count)];
    }

}

