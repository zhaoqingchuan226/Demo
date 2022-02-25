using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class PlayerData : MonoBehaviour
{
    public CardStore cardStore;//原始卡数据
    public int playerMoney;
    public int[] playerCards;//索引代表原始卡牌id，值代表玩家拥有的该id的卡牌的张数

    public TextAsset playerDataCSV;

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
        LoadPlayerData();
    }


    void Update()
    {
     
    }

    public void LoadPlayerData()
    {


        playerCards = new int[cardStore.cards.Count];
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
                int num = int.Parse(elements[2]);
                playerCards[id] = num;
            }
        }
    }

    public void SavePlayerData()//储存玩家信息至csv
    {
        //路径
        string path = Application.dataPath + "/Data/PlayerData.csv";

        List<string> datas = new List<string>();
        datas.Add("money," + playerMoney.ToString());
        for (int i = 0; i < playerCards.Length; i++)
        {
            if (playerCards[i] != 0)
            {
                datas.Add("card," + i.ToString() + "," + playerCards[i].ToString());
            }

        }

        //储存datas到路径，生成csv
        File.WriteAllLines(path, datas);
    }

    //Initiate按钮触发。玩家数据初始化
    public void InitiatePlayerData()
    {
        string path = Application.dataPath + "/Data/PlayerData.csv";
        List<string> datas = new List<string>();
        datas.Add("money,14");
        //储存datas到路径，生成csv
        File.WriteAllLines(path, datas);
        playerMoney = 14;
        for (int i = 0; i < cardStore.cards.Count; i++)
        {
            playerCards[i] = 0;
        }


    }
}
