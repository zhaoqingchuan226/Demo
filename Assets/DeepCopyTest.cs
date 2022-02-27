using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeepCopyTest : MonoBehaviour
{
    public Card card;
    void Start()
    {
        card = new Card(1, "好卡", "好卡", 1, Card.ActionType.Dynamic, "早");
        Card card2 = new Card(card);
       
        card2.id = 2;
        Debug.Log(card.id);
    }


}
