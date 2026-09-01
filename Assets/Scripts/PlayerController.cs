using System.Collections;
using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : CharacterBase
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(SetCard(2));
    }

    private void Update()
    {
        if (number >= 21)
        {
            Debug.LogError("バースト");
        }
    }

}
