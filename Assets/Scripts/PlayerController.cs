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
        SetCard();
    }

    private void Update()
    {
        //SetCard();
    }

    void SetCard()
    {
        if (isStart)
        {
            StartCoroutine(cardManager.ChangeNumvber(this.gameObject.transform.position, 2, true));
            //cardManager.ChangeNumvber(this.gameObject.transform.position, 2, true);

            /*            for (int i = 0; i <= 1; i++)
                        {
                        }*/
            //isStart = false;
        }
    }
}
