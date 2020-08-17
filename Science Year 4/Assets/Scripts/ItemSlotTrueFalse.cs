using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemSlotTrueFalse : MonoBehaviour, IDropHandler
{
    YearFiveQuizManager manager;

    GameObject button;

    string[] dialogue;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<YearFiveQuizManager>();

        manager.exampleImage.enabled = false;
        manager.secondExplanation.enabled = false;

        dialogue = new string[4];

        dialogue[0] = "Some animals have thick layer of fat to protect themselves from weather.";
        dialogue[1] = "Buffaloes wallow in mud to keep themselves col during sunny days.";
        dialogue[2] = "Lizard break their tails to get food from enemies.";
        dialogue[3] = "To continue living in cold regions, bears hibernate for a few months.";
    }

    public void OnDrop(PointerEventData eventData)
    {
        button = eventData.pointerDrag;

        if (eventData.pointerDrag != null)
        {
            StartCoroutine(PopNextQuestion(eventData));
        }
    }

    IEnumerator PopNextQuestion(PointerEventData eventData)
    {
        if (manager.secondBool[0] && gameObject.CompareTag("False") && button.CompareTag("False") ||
            manager.secondBool[1] && gameObject.CompareTag("True") && button.CompareTag("True") ||
            manager.secondBool[2] && gameObject.CompareTag("True") && button.CompareTag("True") ||
            manager.secondBool[3] && gameObject.CompareTag("False") && button.CompareTag("False") ||
            manager.secondBool[4] && gameObject.CompareTag("True") && button.CompareTag("True"))
        {
            if (manager.secondBool[0])
            {
                manager.secondBool[1] = true;
                manager.secondBool[0] = false;
                button.tag = "True";

                button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dialogue[0].ToString();

                manager.exampleImage.GetComponent<Animation>().Play("SuccessPop");
                manager.exampleImage.sprite = manager.spriteImage[0];
                manager.secondExplanation.enabled = true;
                manager.secondExplanation.text = "example 1";
            }
            else if (manager.secondBool[1])
            {
                manager.secondBool[2] = true;
                manager.secondBool[1] = false;
                button.tag = "True";

                button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dialogue[1].ToString();

                manager.exampleImage.GetComponent<Animation>().Play("SuccessPop");
                manager.exampleImage.sprite = manager.spriteImage[1];
                manager.secondExplanation.text = "example 2";
            }
            else if (manager.secondBool[2])
            {
                manager.secondBool[3] = true;
                manager.secondBool[2] = false;
                button.tag = "False";

                button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dialogue[2].ToString();

                manager.exampleImage.GetComponent<Animation>().Play("SuccessPop");
                manager.exampleImage.sprite = manager.spriteImage[2];
                manager.secondExplanation.text = "example 3";
            }
            else if (manager.secondBool[3])
            {
                manager.secondBool[4] = true;
                manager.secondBool[3] = false;
                button.tag = "True";

                button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dialogue[3].ToString();

                manager.exampleImage.GetComponent<Animation>().Play("SuccessPop");
                manager.exampleImage.sprite = manager.spriteImage[3];
                manager.secondExplanation.text = "example 4";
            }
            else if (manager.secondBool[4])
            {
                manager.secondBool[4] = false;
                manager.secondBool[5] = true;

                manager.exampleImage.GetComponent<Animation>().Play("SuccessPop");
                manager.exampleImage.sprite = manager.spriteImage[4];
                manager.secondExplanation.text = "example 5";
            }

            button.SetActive(false);

            manager.exampleImage.enabled = true;

            yield return new WaitForSeconds(1f);

            if (manager.secondBool[5])
            {
                button.SetActive(false);
            }
            else if (!manager.secondBool[5])
            {
                button.SetActive(true);
            }

            button.transform.position = button.GetComponent<DragDropTwo>().startPos.position;

            button.GetComponent<CanvasGroup>().alpha = 1f;
            button.GetComponent<CanvasGroup>().blocksRaycasts = true;

            gameObject.GetComponent<Image>().raycastTarget = true;

            button.GetComponent<RectTransform>().sizeDelta = new Vector2(700, 60);
            button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        }
        else if (manager.secondBool[0] && gameObject.CompareTag("True") && button.CompareTag("False") ||
           manager.secondBool[1] && gameObject.CompareTag("False") && button.CompareTag("True") ||
           manager.secondBool[2] && gameObject.CompareTag("False") && button.CompareTag("True") ||
           manager.secondBool[3] && gameObject.CompareTag("True") && button.CompareTag("False") ||
           manager.secondBool[4] && gameObject.CompareTag("False") && button.CompareTag("True"))
        {
            transform.GetChild(0).GetComponent<Image>().enabled = true;
            transform.GetChild(0).GetComponent<Animation>().Play("GameOverPop");

            yield return new WaitForSeconds(1.5f);

            transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
    }
}
