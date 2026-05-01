using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject manager;
    int ranM;
    int ranN;
    int curentNum;
    int count;

    CardGameManager cardManager;

    void Start()
    {
        cardManager = manager.GetComponent<CardGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(count <= 2)
        {
            ranM = Random.Range(0, 4);
            ranN = Random.Range(0, 13);
            cardManager.ChangeNumvber(ranM, ranN, this.gameObject);
            //curentNum = ranN + 1;
            count++;
            Debug.Log(curentNum);
        }
    }

    public void SetCard(int N)
    {

    }

}
