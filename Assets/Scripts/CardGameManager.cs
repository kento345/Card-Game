using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

enum FF
{
    h,s,c,d
};

enum AA
{
    One
}

public class CardList
{
    FF ff_;
}

[System.Serializable]
public class CardDataList : CardList
{
    [SerializeField]List<CardData> data_ = new();
}

public class CardGameManager : MonoBehaviour
{
    [SerializeField] GameObject Pcard;
    [SerializeField] GameObject Ecard;
    [SerializeField] List<Sprite> Ssprite;
    [SerializeField] List<Sprite> Dsprite;
    [SerializeField] List<Sprite> Hsprite;
    [SerializeField] List<Sprite> Ksprite;

    [SerializeField] List<CardDataList> cordsp;

    private List<Sprite> sprite;
    //private Sprite[] sprite;
    SpriteRenderer PspriteRender;
    //SpriteRenderer EspriteRender;
    int Ecount = 0;
    int Pcount = 0;
    //-----------------

    //private Vector3 velocity = Vector3.zero;


    void Start()
    {
        PspriteRender = Pcard.GetComponent<SpriteRenderer>();
        //EspriteRender = Ecard.GetComponent<SpriteRenderer>();
    }

    public virtual void EnemyChangeNumvber(int x, int y, GameObject obj)
    {
        SetCard(x,y);
        if (Ecount <= 1)
        {
            //var Epos = obj.transform.position;
            var Epos = transform.position;

            var a = SpownCard();
            if(Ecount == 1)
            {
                a.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            a.transform.position = transform.position;


            CardMove.CardMve(a, new Vector3(0, -10, 0), 2);
            Ecount++;
        }
    }

    public void ChangeNumvber(int x,int y, GameObject obj)
    {
        SetCard(x,y);
        if (Pcount <= 1)
        {
            //var Ppos = obj.transform.position;
            var Ppos = transform.position;
            GameObject a = Instantiate(Pcard, new Vector2(Ppos.x + Pcount, Ppos.y), Quaternion.identity);
            
            //a.transform.position = Vector3.SmoothDamp(transform.position, new Vector2(obj.transform.position.x + Pcount, obj.transform.position.y), ref velocity, 0.3f);
            Pcount++;
        }
    }

   GameObject SpownCard()
    {
        var num = CardNum();
        var g = Instantiate(Ecard, new Vector3(0, 0, 0), Quaternion.identity);

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

        g.GetComponent<SpriteRenderer>().sprite = sp;

        return g;
    }

    (int,int) CardNum()
    {
        return (Random.Range(0, 4), Random.Range(0, 13));
    }


    void SetCard(int x,int y)
    {
        switch (x)
        {
            case 0:
                sprite = Ssprite;
                break;
            case 1:
                sprite = Dsprite;
                break;
            case 2:
                sprite = Hsprite;
                break;
            case 3:
                sprite = Ksprite;
                break;
        }
        if (sprite != null)
        {
            if (!sprite.Contains(sprite[y])) { return; }

            PspriteRender.sprite = sprite[y];

            sprite.Remove(sprite[y]);
        }
    }
}
