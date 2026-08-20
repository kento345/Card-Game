using UnityEngine;


[CreateAssetMenu(
    fileName = "New Card",
    menuName = "Card/Card"
)]
public class CardData : ScriptableObject
{
    [SerializeField] FF ff_;
    [SerializeField] AA aa_;
    [SerializeField] Sprite sprite_;
}