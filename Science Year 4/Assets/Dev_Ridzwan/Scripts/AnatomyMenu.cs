using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using TMPro;

public class AnatomyMenu : MonoBehaviour
{
    [SerializeField] RectTransform panel;
    [SerializeField] CanvasGroup[] subjects;

    public void Show() {
        panel.anchoredPosition = Vector2.zero;
        panel.gameObject.SetActive(true);
        float AnimTimeGap = 0.0f;
        for (int k = 0; k < subjects.Length; k++)
        {
            subjects[k].gameObject.SetActive(true);
            subjects[k].alpha = 0f;
            StartCoroutine(SubjectPopEffect(subjects[k], AnimTimeGap));
            AnimTimeGap += 0.2f;
        }
    }

    public void Hide(Action callback = null) 
    {
       panel.DOAnchorPos(Vector2.down * (Screen.height * 3 / 2), 0.75f, false).OnComplete(() =>
        {
            panel.gameObject.SetActive(false);
            callback?.Invoke();
        }); 
    }

    IEnumerator SubjectPopEffect(CanvasGroup fadeSubject, float time)
    {
        yield return new WaitForEndOfFrame();
        fadeSubject.transform.localScale = Vector3.zero;
        yield return new WaitForSeconds(time);
        fadeSubject.DOFade(1.0f, 0.3f).SetEase(Ease.InQuad);
        fadeSubject.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
    }
}
