using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;



public class CardGameManager : MonoBehaviour
{
    [SerializeField] GameObject card;
    /*[SerializeField] Sprite[] Ssprite;
      [SerializeField] Sprite[] Dsprite;
      [SerializeField] Sprite[] Hsprite;
      [SerializeField] Sprite[] Ksprite;*/
    [SerializeField] List<Sprite> Ssprite;
    [SerializeField] List<Sprite> Dsprite;
    [SerializeField] List<Sprite> Hsprite;
    [SerializeField] List<Sprite> Ksprite;

    private List<Sprite> sprite;
    //private Sprite[] sprite;
    SpriteRenderer spriteRender;
    int Ecount = 0;
    int Pcount = 0;

    private Vector3 velocity = Vector3.zero;


    void Start()
    {
        spriteRender = card.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public virtual void EnemyChangeNumvber(int x, int y, GameObject obj)
    {
        SetCard(x,y);
        if (Ecount <= 1)
        {
            //var Epos = obj.transform.position;
            var Epos = transform.position;

            var rot = Quaternion.identity;
            if (Ecount == 1)
            {
                rot = Quaternion.Euler(0, 180, 0);
            }
            Instantiate(card,new Vector2(Epos.x + Ecount,Epos.y),rot);
            Ecount++;
        }
    }

    public void ChangeNumvber(int x,int y, GameObject obj)
    {
        SetCard(x,y);
        if (Pcount <= 1)
        {
            var Ppos = obj.transform.position;
            GameObject a = Instantiate(card, new Vector2(Ppos.x + Pcount, Ppos.y), Quaternion.identity);
            //a.transform.position = Vector3.SmoothDamp(transform.position, new Vector2(obj.transform.position.x + Pcount, obj.transform.position.y), ref velocity, 0.3f);
            Pcount++;
        }
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
            switch (y)
            {
                case 0:
                    spriteRender.sprite = sprite[0];
                    break;
                case 1:
                    spriteRender.sprite = sprite[1];
                    break;
                case 2:
                    spriteRender.sprite = sprite[2];
                    break;
                case 3:
                    spriteRender.sprite = sprite[3];
                    break;
                case 4:
                    spriteRender.sprite = sprite[4];
                    break;
                case 5:
                    spriteRender.sprite = sprite[5];
                    break;
                case 6:
                    spriteRender.sprite = sprite[6];
                    break;
                case 7:
                    spriteRender.sprite = sprite[7];
                    break;
                case 8:
                    spriteRender.sprite = sprite[8];
                    break;
                case 9:
                    spriteRender.sprite = sprite[9];
                    break;
                case 10:
                    spriteRender.sprite = sprite[10];
                    break;
                case 11:
                    spriteRender.sprite = sprite[11];
                    break;
                case 12:
                    spriteRender.sprite = sprite[12];
                    break;
            }
            sprite.Remove(sprite[y]);
        }
    }

}
