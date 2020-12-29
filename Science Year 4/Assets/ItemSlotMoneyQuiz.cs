using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class ItemSlotMoneyQuiz : MonoBehaviour, IDropHandler
{
    MoneyQuizManager manager;
    MoneyQuizDragDrop otherManager;

    GameObject button;

    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<MoneyQuizManager>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        button = eventData.pointerDrag;

        if (eventData.pointerDrag != null)
        {
            StartCoroutine(PopNextQuestion(eventData));
        }
    }

    IEnumerator PopNextQuestion(PointerEventData eventData) // 01101
    {
        if (button.CompareTag("True"))
        {
            manager.RightSFX();
            manager.cur++;

            button.SetActive(false);
            // incrase int
            // skip one array
            // animation
            // all that shit
            // sfx
        }
        else if (button.CompareTag("False"))
        {
            manager.WrongPressSFX();
            button.GetComponent<MoneyQuizDragDrop>().OnEndDrag(eventData);
            // you are a dumbass
            // it is what it is buddy
            // reset
            // sfx
            // animation?
        }

        yield return new WaitForSeconds(1f);

        // idk what to put here. not yet anyway
    }

    //IEnumerator Delay()
    //{
    //    yield return new WaitForSeconds(1f);

    //    manager.continueButton.SetActive(true);
    //    manager.secondQuestion.SetActive(false);
    //}
}
