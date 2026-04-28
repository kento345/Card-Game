using UnityEngine;
using UnityEngine.InputSystem.Switch;

public class CardGameManager : MonoBehaviour
{
    
    [SerializeField] GameObject card;
    [SerializeField] Sprite[] sprite;
    SpriteRenderer spriteRender;

    int ran;
    int count;

    void Start()
    {
        spriteRender = card.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeNumvber();
    }

    public void ChangeNumvber()
    {
        ran = Random.Range(0, 13);
        switch (ran)
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

        if (count == 0)
        {
            Instantiate(card);
            count++;
        }
    }

}
