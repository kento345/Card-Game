using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBase : MonoBehaviour
{
    //ゲームマネジャー
    [SerializeField]
    protected GameObject manager = null;

    [SerializeField]
    protected Text numText = null;

    //出た数字の合計
    protected int numberNum = 0;

    //カードマネージャのScript
    CardGameManager cardManager = null;

    private void Awake()
    {
        cardManager = manager.GetComponent<CardGameManager>();
    }

    protected IEnumerator SetCard(int a,bool p)
    {
        yield return StartCoroutine(cardManager.ChangeNumvber(this.gameObject.transform.position, a, p));
        numberNum = p ? cardManager.Num().player : cardManager.Num().enemy;
    }

    public virtual void Hit(bool p)
    {
        StartCoroutine(cardManager.ChangeNumvber(this.gameObject.transform.position, 1, p));
    } 
}
