using Unity.Hierarchy;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject manager;
    int ranM;
    int ranN;
    int curentNum;

    bool isStrt = false;

    CardGameManager cardManager;

    void Start()
    {
        cardManager = manager.GetComponent<CardGameManager>();
        isStrt = true;
    }

    // Update is called once per frame
    void Update()
    {
        SetCard();
    }
    void SetCard()
    {
        if (isStrt)
        {
            for (int i = 0; i <= 1; i++)
            {
                cardManager.ChangeNumvber(this.gameObject.transform.position,i,false);
                curentNum += ranN + 1;
            }
            isStrt = false;
        }
    }

    public void IsStart(bool x)
    {
        isStrt = x;
    }
}
