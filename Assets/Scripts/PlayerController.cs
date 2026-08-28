using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : CharacterBase
{
    void Start()
    {
        StartCoroutine(SetCard(2, true));
    }

    private void Update()
    {
        if(numberNum >= 21)
        {
            Debug.LogError("バースト");
        }
    }
}
