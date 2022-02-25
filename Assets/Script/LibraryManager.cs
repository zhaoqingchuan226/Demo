using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//将dataManager中的数据加载到library界面中并且生成相应的卡牌
public class LibraryManager : MonoBehaviour
{
    public Transform libraryPanel;
    public GameObject cardLibraryPrefab;

    public PlayerData playerData;
    public CardStore cardStore;
    void Start()
    {
        StartCoroutine(WaitForNextFrame());
   
    }
    IEnumerator WaitForNextFrame()
    {
        yield return null;
        UpdateLibrary();
        yield break;
    }
    void Update()
    {
      
    }

    public void UpdateLibrary()
    {
        
        for (int i = 0; i < playerData.playerCards.Length; i++)
        {
           
            if (playerData.playerCards[i] > 0)
            {
                GameObject card = Instantiate(cardLibraryPrefab, libraryPanel);
                card.GetComponent<CardCounter>().SetCounter(playerData.playerCards[i]);
                card.GetComponent<CardDisplay>().card = cardStore.cards[i];
            }

        }

    }
}
