using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(
    fileName = "New Card",
    menuName = "Card/Card"
)]
public class CardData : ScriptableObject
{
    [SerializeField] Suit suit_;
    [SerializeField] Number number_;
    [SerializeField] Sprite sprite_;
    bool isUsed = false;
}