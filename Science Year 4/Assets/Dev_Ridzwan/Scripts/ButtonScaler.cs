using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonScaler : MonoBehaviour
{
    EventTrigger trigger;
    public float ScaleTarget = 1.1f, TweenDuration=.3f;
    Vector3 currentScale;

    private void Awake()
    {
        trigger = GetComponent<EventTrigger>();
        if (trigger==null)
        {
            trigger=gameObject.AddComponent<EventTrigger>() as EventTrigger;
        }
    }

    private void Start()
    {
        currentScale = transform.localScale;
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry);

        EventTrigger.Entry exit = new EventTrigger.Entry();
        exit.eventID = EventTriggerType.PointerUp;
        exit.callback.AddListener((data) => { OnPointerUpDelegate((PointerEventData)data); });
        trigger.triggers.Add(exit);
    }

    public void OnPointerDownDelegate(PointerEventData data)
    {
        transform.DOScale(Vector3.one * ScaleTarget, TweenDuration / 2f);
       
    }
    public void OnPointerUpDelegate(PointerEventData data)
    {
        transform.DOScale(currentScale, TweenDuration / 2f);
    }
}
