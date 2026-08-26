using System.Collections;
using Unity.Hierarchy;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject manager;
    int ranM;
    int ranN;
    int curentNum;
    int i = 0;


    bool isStrt = false;

    CardGameManager cardManager;

    void Start()
    {
        cardManager = manager.GetComponent<CardGameManager>();
        isStrt = true;
        SetCard();

    }

    // Update is called once per frame
    void Update()
    {
        //SetCard();
    }
    void SetCard()
    {
        if (isStrt && i <= 1)
        {
            StartCoroutine(cardManager.ChangeNumvber(this.gameObject.transform.position, 2, false));
            //cardManager.ChangeNumvber(this.gameObject.transform.position, 2, false);

/*            for (int i = 0; i <= 1; i++)
            {
                //curentNum += ranN + 1;
            }*/
            //i++;
            isStrt = false;
        }
        isStrt = true;
    }

    public void IsStart(bool x)
    {
        isStrt = x;
    }
}
