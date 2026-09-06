using System.Collections;
using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : CharacterBase
{
    private void Update()
    {
        if (number > 21)
        {
            Debug.LogError("バースト");
        }
    }

}
