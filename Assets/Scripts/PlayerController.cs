using System.Collections;
using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : CharacterBase
{
    IEnumerator Start()
    {
        yield return StartCoroutine(SetCard(2, true));
        numText.text = numberNum.ToString();
    }

    private void Update()
    {

        if (numberNum >= 21)
        {
            Debug.LogError("バースト");
        }
    }
}
