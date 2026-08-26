using System.Collections;
using Unity.Hierarchy;
using UnityEngine;

public class EnemyController : CharacterBase
{
    bool isStrt = false;

    void Start()
    {
        isStrt = true;
        SetCard(2,false);
    }

    public void IsStart(bool x)
    {
        isStrt = x;
    }
}
