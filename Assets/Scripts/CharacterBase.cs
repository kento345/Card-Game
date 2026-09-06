using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
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
    protected int coin = 300;
    protected int betCoin = 0;
    protected int aceCount_ = 0;
    protected int num = 0;

    //カードマネージャのScript
    protected CardGameManager cardManager = null;

    public int CardCount() => cardCount;
    public int Number() => number;
    public int BetCoin() => betCoin;
    public int Coin() => coin;

    /// <summary>
    /// 数字計算
    /// </summary>
    /// <param name="data"></param>
    public virtual void AddCard(CardData data)
    {
        if(data == null)return;
        var card = data.NumberData();
        if (card == global::Number.Ace)
        {
            aceCount_++;
            num += 1;
        }
        else
        {
            num += (int)data.NumberData();

        }
        cardCount++;

        SetText();
    }

    public void CoinBet(int a)
    {
        betCoin += a;
    } 
    public void ResetCoinBet()
    {
        betCoin = 0;
    }

    private void Awake()
    {
        cardManager = manager.GetComponent<CardGameManager>();
        numText = numImage.GetComponentInChildren<Text>();
    }

    protected void Start()
    {
        Debug.Log("開始");
        //yield return new WaitForSeconds(1.0f);
        GameManager.Instance.stateChanged += OnStateChanged;
    }
    private void OnStateChanged(GameState state)
    {
        if (GameManager.Instance.Stated() == GameState.Dealing)
        {
            Debug.Log("配布");
            StartCoroutine(cardManager.ChangeNumvber(this.gameObject.transform.position, 2, this));
        }
    }

    public virtual void SetText()
    {
        int displayNumber = num;

        if (aceCount_ > 0 && num + 10 <= 21)
        {
            displayNumber += 10;
        }
        numImage.enabled = true;
        numText.text = displayNumber.ToString();
        number = displayNumber;

        if (cardCount == 2)
        {
            GameManager.Instance.StateUpdate(GameState.PlayerTurn);
        }
    }

    public virtual void Hit()
    {
        StartCoroutine(cardManager.ChangeNumvber(this.gameObject.transform.position, 1,this));
    }

    public virtual void Stand()
    {
        Debug.Log("キープ");
        GameManager.Instance.StateUpdate(GameState.DealerTurn);
    }

    public virtual void DoubleDown()
    {

    }

    public int CoinNum()
    {
        return betCoin;
    }

    protected void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.stateChanged -= OnStateChanged;
        }
    }
}
