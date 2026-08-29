using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Rendering;

/// <summary>
/// カードマーク
/// </summary>
public enum Suit
{
    Spade, Heart, Diamond, Club
};

/// <summary>
/// カード数字
/// </summary>
public enum Number
{
    Ace = 1,Two,Three,Four,Five,Six,Seven,
    Eight,Nine,Ten,Jack,Queen,King
};

/// <summary>
/// カードデータList
/// </summary>
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

    //カード生成数
    int playerCount = 0;
    int enemyCount = 0;

    //数字
    int playerNum = 0;
    int enemyNum = 0;
    int enemyNumFirst = 0;

    void Awake()
    {
        AddList();
    }

    /// <summary>
    /// カード生成後移動
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="count"></param>
    /// <param name="chara"></param>
    /// <returns></returns>
    public IEnumerator ChangeNumvber(Vector3 obj,int count,CharacterBase chara)
    {        
        //生成場所
        var pos = transform.position;
        for (int j = 0; j <= count - 1; j++)
        {
            //カード情報
            var data = DrawCard();
            //情報を元にカード生成
            var card = SpownCard(data);
            //カード情報を渡す
            chara.AddCard(data);
            if (data == null){yield break;}
            if (chara is EnemyController && chara.CardCount() == 2)
            {
                card.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            card.transform.position = transform.position;
            //移動
            CardMove.CardMve(card, new Vector3(pos.x + chara.CardCount()-1, obj.y, pos.z - chara.CardCount() + 1), 0.5f);
            yield return new WaitForSeconds(0.5f);
        }
    }

    /// <summary>
    /// カードの生成
    /// </summary>
    /// <returns></returns>
   GameObject SpownCard(CardData data)
   {
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
    CardData DrawCard()
    {
        //残っているカードを山札に追加
        List<CardDataList> availableLists = new();
        foreach (var list in cardList)
        {
            if (list != null &&list.data_ != null &&list.data_.Count > 0)
            {
                availableLists.Add(list);
            }
        }

        if (availableLists.Count == 0){return null;}

        // カードが残っているリストから選ぶ
        var listData = availableLists[Random.Range(0, availableLists.Count)];

        // そのリストからカードを1枚選ぶ
        int index = Random.Range(0, listData.data_.Count);

        var data = listData.data_[index];

        // 使用したカードを削除
        listData.data_.RemoveAt(index);

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

    public (int player, int firstEnemy, int enemy) Num()
    {
        return (playerNum,enemyNumFirst, enemyNum);
    }
}
