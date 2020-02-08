using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EffectFlow : MonoBehaviour
{
    public float duration = 3;
    public float gap = 50;
    void Start()
    {
        Sequence mySequence = DOTween.Sequence();

        RectTransform rect = GetComponent<RectTransform>();
        float baseY = rect.anchoredPosition.y;

        mySequence.Append(rect.DOLocalMoveY(baseY-gap, duration/2).SetEase(Ease.InOutQuad));
        mySequence.Append(rect.DOLocalMoveY(baseY, duration/2).SetEase(Ease.InOutQuad));

        mySequence.SetLoops(-1);

    }
}
