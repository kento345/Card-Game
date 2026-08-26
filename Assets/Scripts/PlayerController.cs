using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : CharacterBase
{
    bool isStart = false;

    void Start()
    {
        isStart = true;
        SetCard(2,true);
    }
}
