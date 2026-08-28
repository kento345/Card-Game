using System.Collections;
using Unity.Hierarchy;
using UnityEngine;

public class EnemyController : CharacterBase
{
    int number_ = 0;

    IEnumerator Start()
    {
        yield return StartCoroutine(SetCard(2, false));
        numText.text = numberNum.ToString();
    }
}
