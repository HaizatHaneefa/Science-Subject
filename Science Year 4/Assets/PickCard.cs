using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PickCard : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    ConstellationGameManager manager;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<ConstellationGameManager>();
    }

    private void Update()
    {
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
                StartCoroutine(CardSelected());
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
    }

    IEnumerator CardSelected()
    {
        foreach (GameObject k in manager.p2)
        {
            k.GetComponent<Button>().enabled = false;
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(true);
        }

        GetComponent<Animation>().Play("CardSelected");

        yield return new WaitForSeconds(.7f);

        manager.p2.Remove(gameObject);
        manager.p1.Add(gameObject);

        gameObject.transform.SetParent(manager.playerPos[0]);

        manager.ArrangeCards();
        manager.CheckForAnyPairs();

        manager.DisableButtons();

        yield return new WaitForSeconds(.5f);

        GetComponent<CanvasGroup>().alpha = 1;
        GetComponent<Animation>().Play("CardSelected2");

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }

        foreach (GameObject k in manager.p2)
        {
            k.GetComponent<Button>().enabled = true;
        }

        manager.Round();
    }
}
