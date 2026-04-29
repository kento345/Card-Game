using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject manager;
    int ranM;
    int ranN;
    int count;

    CardGameManager cardManager;

    void Start()
    {
        cardManager = manager.GetComponent<CardGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (count <= 2)
        {
            ranM = Random.Range(0, 4);
            ranN = Random.Range(0, 13);
            cardManager.DealerChangeNumvber(ranM, ranN, this.gameObject);
            count++;
        }
    }
}
