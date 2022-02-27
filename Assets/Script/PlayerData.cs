using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class PlayerData : MonoSingleton<PlayerData>
{

    public int playerMoney;

    public List<Card> playerCards = new List<Card>();//索引代表原始卡牌id，值代表玩家拥有的该id的卡牌的张数

    public TextAsset playerDataCSV;
    public List<string> datas = new List<string>();
    public string Date = "第一周";
    public string Name = "王大宝";
    public int physicalHealth = 10;
    public int spiritualHealth = 10;
    public int workAbility = 10;
    public int KPI = 0;
    public int ranking = 1;

    [System.Serializable]
    public class InterpersonalRelationship
    {
        public int colleague1 = 100;
        public int colleague2 = 100;
        public int colleague3 = 100;
        public int colleague4 = 100;
        public int leader = 100;
        public int Boss = 100;
    }

    public InterpersonalRelationship interpersonalRelationship = default;

    void Start()
    {
        playerCards.Clear();
        datas.Clear();

        LoadPlayerData();

    }


    void Update()
    {

    }

    public void LoadPlayerData()
    {


        string[] dataRows = playerDataCSV.text.Split('\n', System.StringSplitOptions.RemoveEmptyEntries);
        foreach (var dataRow in dataRows)
        {
            string[] elements = dataRow.Split(',', System.StringSplitOptions.RemoveEmptyEntries);
            if (elements[0] == "money")
            {
                playerMoney = int.Parse(elements[1]);
            }
            else if (elements[0] == "card")
            {
                int id = int.Parse(elements[1]);
                string title = elements[2];
                string description = elements[3];
                int qualityLevel = int.Parse(elements[4]);


                Card.ActionType actionType;
                if (elements[5].Contains("动"))
                {
                    actionType = Card.ActionType.Dynamic;
                }
                else if (elements[5].Contains("静"))
                {
                    actionType = Card.ActionType.Static;
                }

                else
                {
                    actionType = Card.ActionType.Unknown;
                }

                string times = elements[6];
                Card card = new Card(id, title, description, qualityLevel, actionType, times);
                playerCards.Add(card);
            }
        }
    }

    public void SavePlayerData()//储存玩家信息至csv
    {
        //路径
        string path = Application.dataPath + "/Data/PlayerData.csv";
        datas.Clear();
        datas.Add("money," + playerMoney.ToString());
        datas.Add("money," + playerMoney.ToString());
        datas.Add("money," + playerMoney.ToString());
        datas.Add("#,id,title,description,qualitylevel,actionType,time");
       
        foreach (var playerCard in playerCards)
        {
            string actionType;
            if (playerCard.actionType == Card.ActionType.Dynamic)
            {
                actionType = "动";
            }
            else if (playerCard.actionType == Card.ActionType.Static)
            {
                actionType = "静";
            }
            else
            {
                actionType = "未知";
            }
            string str = "card," + playerCard.id.ToString() + "," + playerCard.title + "," + playerCard.description + "," + playerCard.qualityLevel.ToString() + "," + actionType + "," + playerCard.times;


            datas.Add(str);

        }
        // foreach (var playerCard in playerCards)
        // {

        //     datas.Add("1");
        // }


        //储存datas到路径，生成csv
        File.WriteAllLines(path, datas);
        File.WriteAllLines(path, datas);
    }

    //Initiate按钮触发。玩家数据初始化
    public void InitiatePlayerData()
    {
        string path = Application.dataPath + "/Data/PlayerData.csv";
        List<string> datas = new List<string>();
        datas.Add("money,100");
        //储存datas到路径，生成csv
        File.WriteAllLines(path, datas);
        playerMoney = 100;
        playerCards.Clear();

    }
   


}
