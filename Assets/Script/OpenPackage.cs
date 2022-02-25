using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//这个脚本由按钮触发函数
public class OpenPackage : MonoBehaviour
{
    // Start is called before the first frame update
    CardStore cardStore;
    public int cardAmount = 5;
    public GameObject cardPrefab;
    public GameObject cardGroup;//用来排列卡牌
    List<GameObject> cards = new List<GameObject>();
    public PlayerData playerData;
    void Start()
    {
        cardStore = GetComponent<CardStore>();
    }



    public void OnClickOpen()//点击按钮开包，实例化卡牌  //这个函数先全部执行完毕，再执行CardDisplay的OnStart
    {
        //穷逼限制开包
        if (playerData.playerMoney < 5)
        {
            return;
        }
        else
        {
            playerData.playerMoney -= 5;
        }

        //每次开包前清除上次的开包记录
        ClearGroup();
        for (int i = 0; i < cardAmount; i++)
        {
            GameObject newcard = Instantiate(cardPrefab, cardGroup.transform);
            newcard.GetComponent<CardDisplay>().card = cardStore.RandomCard();
            cards.Add(newcard);
        }
        //把开出来的卡牌保存到玩家所拥有的卡牌池中
        SaveCardData();

        //储存玩家信息至csv
        playerData.SavePlayerData();
    }
    public void ClearGroup()
    {
        foreach (var card in cards)
        {
            Destroy(card);
        }
        cards.Clear();
    }

    void SaveCardData()//把开出来的卡牌保存到玩家所拥有的卡牌池中
    {
        foreach (var card in cards)
        {
            int id = card.GetComponent<CardDisplay>().card.id;
            playerData.playerCards[id] += 1;
        }

    }
}
