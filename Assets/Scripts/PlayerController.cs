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
    


  /*  public void OnClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isStart = true;
            //SetCard();

        }
    }*/

    void Start()
    {
        cardManager = manager.GetComponent<CardGameManager>();
        enemyController = enemy.GetComponent<EnemyController>();
        isStart = true;
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
                cardManager.ChangeNumvber(this.gameObject.transform.position,i, true);
            }
            isStart = false;
        }
    }
}
