using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//将dataManager中的数据加载到library界面中并且生成相应的卡牌
public class LibraryManager : MonoBehaviour
{
    public Transform libraryPanel;
    public GameObject cardPrefab;



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
        foreach (var playerCard in PlayerData.Instance.playerCards)
        {
            GameObject card = Instantiate(cardPrefab, libraryPanel);
            card.GetComponent<CardDisplay>().card = playerCard;
        }


    }
}
