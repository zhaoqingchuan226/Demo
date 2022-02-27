using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//这个脚本由按钮触发函数
public class OpenPackage : MonoSingleton<OpenPackage>
{
    // Start is called before the first frame update

    public int cardAmount = 5;
    public GameObject cardPrefab;
    public GameObject cardGroup;//用来排列卡牌的grid
    List<GameObject> cards = new List<GameObject>();

    void Start()
    {

    }



    public void OnClickOpen()//点击按钮开包，实例化卡牌  //这个函数先全部执行完毕，再执行CardDisplay的OnStart
    {

        //穷逼限制开包
        if (PlayerData.Instance.playerMoney < 5)
        {
            return;
        }
        else
        {
            PlayerData.Instance.playerMoney -= 5;
        }

        //每次开包前清除上次的开包记录
        ClearGroup();


        for (int i = 0; i < cardAmount; i++)
        {
            GameObject newcard = Instantiate(cardPrefab, cardGroup.transform);
            newcard.GetComponent<CardDisplay>().card = CardStore.Instance.RandomCard();
            cards.Add(newcard);

            Card card = newcard.GetComponent<CardDisplay>().card;


            cards.Add(newcard);




        }



        //把开出来的卡牌保存到玩家所拥有的卡牌池中(玩家信息)
        SaveCardData();

        //储存玩家信息至csv
        PlayerData.Instance.SavePlayerData();

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
        if (cards != null)
        {
            foreach (var openCard in cards)
            {
                Card card=openCard.GetComponent<CardDisplay>().card;
                if (PlayerData.Instance.playerCards.Count == 0)
                {
                    PlayerData.Instance.playerCards.Add(card);
                }
               
                else
                {
                    if (card.id <= PlayerData.Instance.playerCards[0].id)
                    {
                        PlayerData.Instance.playerCards.Insert(0,card);
                    }
                    else
                    {
                        for (int j = 1; j < PlayerData.Instance.playerCards.Count; j++)
                        {
                            if (card.id <= PlayerData.Instance.playerCards[j].id)
                            {
                                PlayerData.Instance.playerCards.Insert(j,card);
                                break;
                            }
                            else
                            {
                                if (j == PlayerData.Instance.playerCards.Count - 1)
                                {
                                    PlayerData.Instance.playerCards.Add(card);
                                    break;
                                }
                                continue;
                            }


                        }
                    }

                }

            }





        }
    }

}
