using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Switch;



public class CardGameManager : MonoBehaviour
{
    [SerializeField] GameObject card;
    [SerializeField] Sprite[] Ssprite;
    [SerializeField] Sprite[] Dsprite;
    [SerializeField] Sprite[] Hsprite;
    [SerializeField] Sprite[] Ksprite;
    private Sprite[] sprite;
    SpriteRenderer spriteRender;
    int Ecount = 0;
    int Pcount = 0;


    void Start()
    {
        spriteRender = card.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void DealerChangeNumvber(int x,int y,GameObject obj)
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
        }
        if (Ecount <= 1)
        {
            var Dpos = obj.transform.position;
            var rot = Quaternion.identity;
            if (Ecount == 1)
            {
                rot = Quaternion.Euler(0, 180, 0);
            }
            Instantiate(card,new Vector2(Dpos.x + Ecount,Dpos.y),rot);
            Ecount++;
        }
    }

    public void ChangeNumvber(int x,int y,GameObject obj)
    {
/*        if (count <= 1)
        {
            ranM = Random.Range(0, 4);
            ranN = Random.Range(0, 13);
        }*/
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
        }
        if (Pcount <= 1)
        {
            var Ppos = obj.transform.position;
            Instantiate(card, new Vector2(Ppos.x + Pcount, Ppos.y), Quaternion.identity);
            Pcount++;
        }
    }

}
