using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class PickCard : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;

    private CanvasGroup canvasGroup;

    [SerializeField] private Sprite[] sprite;
    ConstellationGameManager manager;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<ConstellationGameManager>();

        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.transform.parent.CompareTag("Left"))
        {
            if (manager.p2.Contains(gameObject))
            {
                manager.p2.Remove(gameObject);
                manager.p1.Add(gameObject);

                gameObject.transform.SetParent(manager.playerPos[0]);

                manager.ArrangeCards();
                manager.CheckForAnyPairs();

                manager.P3toP2();

               manager.DisableButtons();
            }
            else if (manager.p1.Contains(gameObject))
            {
                Debug.Log("dah letak dah bro");
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
}
