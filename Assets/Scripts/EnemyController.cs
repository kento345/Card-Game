using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.Hierarchy;
using UnityEngine;

public class EnemyController : CharacterBase
{
    [SerializeField] private CharacterBase player_;

    [SerializeField]
    private List<int> nums = new();
    [SerializeField]
    private GameObject c;

    private void Update()
    {
        if(GameManager.Instance.Stated() == GameState.DealerTurn)
        {
            if (number < 21 && number < player_.Number())
            {
                Hit();
                SetText();
            }
        }
    }

    public override void AddCard(CardData data) 
    {
        base.AddCard(data);

        nums.Add((int)data.NumberData());
    }

    public override void SetText()
    {
        if (nums.Count == 0) return;
        number = 0;
        foreach (var n in nums)
        {
            number += n;
        }

        int displayNumber = nums[0];

        if (aceCount_ > 0 && number + 10 <= 21)
        {
            number += 10;
        }

        if (nums[0] == 1 && number <= 21)
        {
            displayNumber = 11;
        }

        numImage.enabled = true;
        numText.text = (GameManager.Instance.Stated() == GameState.PlayerTurn?displayNumber : number).ToString();
    }
}