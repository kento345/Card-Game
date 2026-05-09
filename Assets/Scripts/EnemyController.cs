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
                ranM = Random.Range(0, 4);
                ranN = Random.Range(0, 13);
                cardManager.EnemyChangeNumvber(ranM, ranN, this.gameObject);
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
