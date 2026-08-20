using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject manager;
    [SerializeField] GameObject enemy;
    int ranM;
    int ranN;
    int curentNum;
    int count;

    bool isStart = false;

    CardGameManager cardManager;
    EnemyController enemyController;
    


    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isStart = true;
            if (enemyController != null)
            {
                enemyController.IsStart(true);
            }
        }
    }

    void Start()
    {
        cardManager = manager.GetComponent<CardGameManager>();
        enemyController = enemy.GetComponent<EnemyController>();
    }

    private void Update()
    {
        SetCard();
    }

    void SetCard()
    {
        if (isStart)
        {
            for (int i = 0; i <= 1; i++)
            {
                ranM = Random.Range(0, 4);
                ranN = Random.Range(0, 13);
                cardManager.ChangeNumvber(ranM, ranN, this.gameObject);
                curentNum += ranN + 1;
            }
            isStart = false;
        }
    }
}
