using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBase : MonoBehaviour
{
    //ゲームマネジャー
    [SerializeField]
    protected GameObject manager = null;

    [SerializeField]
    protected Image numImage = null;
    protected Text numText = null;

    //出た数字の合計
    protected int cardCount = 0;
    protected int number = 0;
    protected int Coin = 300;
    protected int betCoin = 0;

    //カードマネージャのScript
    protected CardGameManager cardManager = null;

    public int CardCount() => cardCount;
    public int Number() => number;
    public int BetCoin() => betCoin;

    /// <summary>
    /// 数字計算
    /// </summary>
    /// <param name="data"></param>
    public virtual void AddCard(CardData data)
    {
        if(data == null)return;

        cardCount++;
        number += (int)data.NumberData();

        SetText();
    }

    public void CoinBet(int a)
    {
        betCoin += a;
    } 

    private void Awake()
    {
        cardManager = manager.GetComponent<CardGameManager>();
        numText = numImage.GetComponentInChildren<Text>();
    }

    protected IEnumerator SetCard(int count)
    {
        yield return StartCoroutine(cardManager.ChangeNumvber(this.gameObject.transform.position, count, this));
    }
    
    public virtual void SetText()
    {
        numImage.enabled = true;
        numText.text = number.ToString();
    }

    public virtual void Hit()
    {
        StartCoroutine(cardManager.ChangeNumvber(this.gameObject.transform.position, 1,this));
    } 
}
