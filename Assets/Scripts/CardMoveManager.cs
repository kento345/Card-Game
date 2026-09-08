using DG.Tweening;
using UnityEngine;
public static class CardMove
{
    public static void CardMve(GameObject card, Vector3 targetPos,float duration)
    {
        card.transform.DOMove(targetPos, duration);
    }

    public static void CardRota(GameObject card, Quaternion targetRot, float duration)
    {
        card.transform.DORotate(targetRot.eulerAngles, duration);
    }
}