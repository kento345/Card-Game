using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;


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

    public Suit SuitData() => suit_;
    public Number NumberData() => number_;
    public Sprite SpriteData() => sprite_;
}