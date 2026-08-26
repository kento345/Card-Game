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
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SetCard());
    }
    IEnumerator SetCard()
    {
        if (isStrt && i <= 1)
        {
            cardManager.ChangeNumvber(this.gameObject.transform.position, i, false);
            /*for (int i = 0; i <= 1; i++)
            {
                curentNum += ranN + 1;
            }*/
            i++;
            isStrt = false;
            yield return new WaitUntil(() => !isStrt);
        }
        isStrt = true;
    }

    public void IsStart(bool x)
    {
        isStrt = x;
    }
}
