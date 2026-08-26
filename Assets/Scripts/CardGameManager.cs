using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public enum Suit
{
    Spade, Heart, Diamond, Club
};

public enum Number
{
    Ace,Two,Three,Four,Five,Six,Seven,
    Eight,Nine,Ten,Jack,Queen,King
};

public class CardList
{
    Suit suit_;
    Number number_;
    //bool isUsed;
}

[System.Serializable]
public class CardDataList
{
    [SerializeField] public List<CardData> data_ = new();
}

public class CardGameManager : MonoBehaviour
{
    /// <summary>
    /// カードデータ
    /// </summary>
    [SerializeField] List<CardDataList> cardDatas;

    /// <summary>
    /// カードPrefab
    /// </summary>
    [SerializeField] GameObject card;

    /// <summary>
    /// 使用カードデータ
    /// </summary>
    private List<CardDataList> cardList = new();
    //-----------------

    void Start()
    {
        AddList();
    }

    /// <summary>
    /// カード生成後移動
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="i"></param>
    /// <param name="player"></param>
    public IEnumerator ChangeNumvber(Vector3 obj,int i,bool player)
    {
        var pos = transform.position;

        var a = SpownCard();
        if (!player && i == 1)
        {
            a.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        a.transform.position = transform.position;

        CardMove.CardMve(a, new Vector3(pos.x + i, obj.y, 0), 0.5f);

        yield return new WaitForSeconds(1);
    }

    /// <summary>
    /// カードの生成
    /// </summary>
    /// <returns></returns>
    GameObject SpownCard()
   {
        var data = CardNum();
        if(data == null) { return null; }
        var t = Instantiate(card, new Vector3(0, 0, 0), Quaternion.identity);
        t.GetComponent<SpriteRenderer>().sprite = data.SpriteData();

        //cardList.Remove();
        return t;
   }

    /// <summary>
    /// 使用するカード情報をランダム
    /// </summary>
    /// <returns></returns>
    CardData CardNum()
    {
        var list = cardList[Random.Range(0,cardList.Count)];
        int index = Random.Range(0, list.data_.Count);
        var data = list.data_[index];
        list.data_.RemoveAt(index);
        return data;
    }

    /// <summary>
    /// 使用Listに情報追加
    /// </summary>
    public void AddList()
    {
        foreach(var data in cardDatas)
        {
            cardList.Add(data);
        }
    }
}
