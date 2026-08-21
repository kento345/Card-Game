using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

enum Suit
{
    Spade, Heart, Diamond, Club
};

enum Number
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
    [SerializeField]List<CardData> data_ = new();
}

public class CardGameManager : MonoBehaviour
{
    [SerializeField] GameObject card;
    [SerializeField] List<Sprite> Ssprite;
    [SerializeField] List<Sprite> Dsprite;
    [SerializeField] List<Sprite> Hsprite;
    [SerializeField] List<Sprite> Ksprite;

    [SerializeField] List<CardDataList> cardData;

    SpriteRenderer spriteRender;
    //-----------------

    //private Vector3 velocity = Vector3.zero;


    void Start()
    {
        spriteRender = card.GetComponent<SpriteRenderer>();
    }

    public void ChangeNumvber(Vector3 obj,int i,bool player)
    {
        if (i <= 1)
        {
            var pos = transform.position;

            var a = SpownCard();
            if(!player && i == 1)
            {
                a.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            a.transform.position = transform.position;

            CardMove.CardMve(a, new Vector3(pos.x + i, obj.y, 0), 0.5f);
        }
    }

   GameObject SpownCard()
    {
        var num = CardNum();
        var t = Instantiate(card, new Vector3(0, 0, 0), Quaternion.identity);

        Sprite sp = Ssprite[num.Item2];
        switch (num.Item1)
        {
            case 0:
                sp = Ssprite[num.Item2];
                break;
            case 1:
                sp = Dsprite[num.Item2];
                break;
            case 2:
                sp = Hsprite[num.Item2];
                break;
            case 3:
                sp = Ksprite[num.Item2];
                break;
        }

        t.GetComponent<SpriteRenderer>().sprite = sp;

        return t;
    }

    (int,int) CardNum()
    {
        return (Random.Range(0, 4), Random.Range(0, 13));
    }
}
