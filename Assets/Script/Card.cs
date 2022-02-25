using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Card
{
    public int id;
    public string title = "卡名";//卡名
    public string description = "描述的内容";

 
    public string times;

    //卡牌等级和等级颜色
    public int qualityLevel = 1;
    public Color qualityColor = new Color(210f / 255f, 210f / 255f, 210f / 255f, 1);

    //行动的动静状态和行动颜色
    public enum ActionType
    {
        Dynamic,
        Static,
        Unknown
    }
    public ActionType actionType = ActionType.Dynamic;
    public Color actionColor = new Color(239f / 255f, 101f / 255f, 96f / 255f, 1);

    public Card(int id1, string title1, string description1, int qualityLevel1, ActionType actiontype1, string times1)
    {
        this.id = id1;
        this.title = title1;
        this.description = description1;
        this.qualityLevel = qualityLevel1;
        this.actionType = actiontype1;
        this.times = times1;
        switch (this.qualityLevel)//灰绿蓝紫橙
        {
            case 1:
                this.qualityColor = new Color(210f / 255f, 210f / 255f, 210f / 255f, 1);
                break;
            case 2:
                this.qualityColor = new Color(175f / 255f, 239f / 255f, 96f / 255f, 1);
                break;
            case 3:
                this.qualityColor = new Color(35f / 255f, 130f / 255f, 236f / 255f, 1);
                break;
            case 4:
                this.qualityColor = new Color(179f / 255f, 33f / 255f, 180f / 255f, 1);
                break;
            case 5:
                this.qualityColor = new Color(255f / 255f, 194f / 255f, 50f / 255f, 1);
                break;
        }

        if (this.actionType == ActionType.Dynamic)//红
        {
            this.actionColor = new Color(239f / 255f, 101f / 255f, 96f / 255f, 1);
        }
        else if (this.actionType == ActionType.Static)//蓝
        {
            this.actionColor = new Color(110f / 255f, 195f / 255f, 255f / 255f, 1);
        }
        else
        {
            this.actionColor = new Color(90f / 255f, 90f / 255f, 90f / 255f, 1);
        }


      

    }
}
