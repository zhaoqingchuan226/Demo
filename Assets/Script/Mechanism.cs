using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Phase
{
    Start,
    CreatCardAnimation,
    Calculate,
    TripletReward

}

public class Mechanism : MonoSingleton<Mechanism>
{
    public Button button;
    public Phase phase;

    public float animationTimer;
    bool buttonActive;
    public Transform[] transforms = new Transform[20];
    public GameObject cardPersonGame;
    public List<GameObject> cardList = new List<GameObject>();
    private void Awake()
    {
        phase = Phase.Start;
        buttonActive = true;
    }

    //点击“开始”按钮后
    public void OnClickStart()
    {

        buttonActive = false;
        button.gameObject.SetActive(buttonActive);
        phase = Phase.CreatCardAnimation;
    }

    private void Update()
    {
        if (phase == Phase.CreatCardAnimation)
        {
            CreatCardAnimation();
        }
        else if (phase == Phase.Calculate)
        {
            //计算
            Calculate();
            //赋值
            Assign();
        }
        else if (phase == Phase.TripletReward)
        {
            //三连奖励
            TripletReward();
        }
        else if (phase == Phase.Start && buttonActive == false)
        {
            buttonActive = true;
            button.gameObject.SetActive(true);
        }



    }
    //复制Library
    void LibraryCopy()
    {
    

    }
    //生成卡牌并且播放动画
    void CreatCardAnimation()
    {
        animationTimer += Time.deltaTime;
        if (animationTimer > 2f)
        {
            animationTimer = 0;
            Debug.Log("动画播放完毕");
            phase = Phase.Calculate;
        }
    }
    //计算
    void Calculate()
    {

    }
    //赋值
    void Assign()
    {
        Debug.Log("赋值完毕");
        phase = Phase.TripletReward;
    }
    //三连奖励
    void TripletReward()
    {
        Debug.Log("三连奖励完毕");
        phase = Phase.Start;
    }

}
