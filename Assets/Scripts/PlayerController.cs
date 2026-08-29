using System.Collections;
using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : CharacterBase
{
    IEnumerator Start()
    {
        yield return StartCoroutine(SetCard(2));
        SetText();
    }

    private void Update()
    {

        if (number >= 21)
        {
            Debug.LogError("バースト");
        }
    }
}
