using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlotMoneyQuiz : MonoBehaviour, IDropHandler
{
    MoneyQuizManager manager;

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
        foreach (GameObject go in manager.ly)
        {
            go.GetComponent<MoneyQuizDragDrop>().enabled = false;
        }

        if (button.CompareTag("Right"))
        {
            manager.RightSFX();

            button.SetActive(false);

            transform.GetChild(1).GetComponent<Image>().enabled = true;
            transform.GetChild(1).GetComponent<Image>().sprite = manager.sprite[0];
            transform.GetChild(1).GetComponent<Animation>().Play("MoneyQuizChecker");
        }
        else if (button.CompareTag("Left"))
        {
            manager.WrongPressSFX();
            button.GetComponent<MoneyQuizDragDrop>().OnEndDrag(eventData);

            transform.GetChild(1).GetComponent<Image>().enabled = true;
            transform.GetChild(1).GetComponent<Image>().sprite = manager.sprite[1];
            transform.GetChild(1).GetComponent<Animation>().Play("MoneyQuizChecker");
        }

        yield return new WaitForSeconds(1.4f);

        foreach (GameObject go in manager.ly)
        {
            go.GetComponent<MoneyQuizDragDrop>().enabled = true;
        }

        if (button.CompareTag("Right"))
        {
            manager.cur++;

            manager.ThisQuestion();
        }
        else if (button.CompareTag("Left"))
        {
            transform.GetChild(1).GetComponent<Image>().enabled = false;
        }
    }
}
