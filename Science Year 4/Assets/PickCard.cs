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
            k.GetComponent<PickCard>().enabled = false;
        }

        GetComponent<Animation>().Play("CardSelected");

        yield return new WaitForSeconds(.8f);

        manager.p2.Remove(gameObject);
        manager.p1.Add(gameObject);

        gameObject.transform.SetParent(manager.playerPos[0]);

        manager.ArrangeCards();
        manager.CheckForAnyPairs();

        manager.DisableButtons();

        yield return new WaitForSeconds(.5f);

        GetComponent<Animation>().Play("CardSelected2"); // this is conflicting if there is a pair in hand

        yield return new WaitForSeconds(1.2f);

        manager.Round();
    }

    void CheckCard()
    {

    }
}
