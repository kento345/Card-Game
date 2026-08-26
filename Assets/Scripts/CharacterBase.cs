using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    [SerializeField]
    protected GameObject manager = null;

    CardGameManager cardManager = null;

    private void Awake()
    {
        cardManager = manager.GetComponent<CardGameManager>();
    }

    protected void SetCard(int a,bool p)
    {
        StartCoroutine(cardManager.ChangeNumvber(this.gameObject.transform.position, a, p));
    }
}
