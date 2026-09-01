using System.Collections;
using Unity.Hierarchy;
using UnityEngine;

public class EnemyController : CharacterBase
{
    int firstNumber_ = 0;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(SetCard(2));
    }

    public override void AddCard(CardData data) 
    {
        base.AddCard(data);
        if(cardCount == 1)
        {
            firstNumber_ = (int)data.NumberData();
        }
    }

    public override void SetText()
    {
        numImage.enabled = true;
        numText.text = firstNumber_.ToString();
    }
}