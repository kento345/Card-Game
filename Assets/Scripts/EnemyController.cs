using System.Collections;
using Unity.Hierarchy;
using UnityEngine;

public class EnemyController : CharacterBase
{
    void Start()
    {
        StartCoroutine(SetCard(2, false));
    }
}
