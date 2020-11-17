using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenScale : MonoBehaviour
{
    public float duration = 0.3f;
    public Ease ease = Ease.OutBack;

    public void DOScale(float endValue) {
        transform.DOScale(endValue, duration).SetEase(ease);
    }
}
