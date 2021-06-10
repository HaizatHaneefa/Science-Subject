using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemSlotTrueFalse : MonoBehaviour, IDropHandler
{
    YearFiveQuizManager manager;
    DragDropTwo dragScript;
    GameObject button;

    string[] dialogue;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<YearFiveQuizManager>();

        dialogue = new string[4];

        dialogue[0] = "Some animals have thick layer of fat to protect themselves from weather.";
        dialogue[1] = "Buffaloes wallow in mud to keep themselves cold during sunny days.";
        dialogue[2] = "Lizard break their tails to get food from enemies.";
        dialogue[3] = "To continue living in cold regions, bears hibernate for a few months.";
    }

    public void OnDrop(PointerEventData eventData)
    {
        button = eventData.pointerDrag;

        if (eventData.pointerDrag != null)
        {
            StartCoroutine(PopNextQuestion(eventData));
            //eventData = 
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
            manager.RightSFX();

            transform.GetChild(0).GetComponent<Image>().enabled = true;
            transform.GetChild(0).GetComponent<Image>().sprite = manager.rightWrongSprite[1];
            transform.GetChild(0).GetComponent<Animation>().Play("GameOverPop");

            transform.GetChild(2).GetComponent<ParticleSystem>().Play();

            if (manager.secondBool[0])
            {
                manager.secondBool[1] = true;
                manager.secondBool[0] = false;
                button.tag = "True";

                button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dialogue[0].ToString();
            }
            else if (manager.secondBool[1])
            {
                manager.secondBool[2] = true;
                manager.secondBool[1] = false;
                button.tag = "True";

                button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dialogue[1].ToString();
            }
            else if (manager.secondBool[2])
            {
                manager.secondBool[3] = true;
                manager.secondBool[2] = false;
                button.tag = "False";

                button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dialogue[2].ToString();
            }
            else if (manager.secondBool[3])
            {
                manager.secondBool[4] = true;
                manager.secondBool[3] = false;
                button.tag = "True";

                button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dialogue[3].ToString();
            }
            else if (manager.secondBool[4])
            {
                manager.secondBool[4] = false;
                manager.secondBool[5] = true;
            }

            button.SetActive(false);

            yield return new WaitForSeconds(1f);

            transform.GetChild(0).GetComponent<Image>().enabled = false;

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

            button.GetComponent<RectTransform>().sizeDelta = new Vector2(700, 160);
            button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        }
        else if (manager.secondBool[0] && gameObject.CompareTag("True") && button.CompareTag("False") ||
           manager.secondBool[1] && gameObject.CompareTag("False") && button.CompareTag("True") ||
           manager.secondBool[2] && gameObject.CompareTag("False") && button.CompareTag("True") ||
           manager.secondBool[3] && gameObject.CompareTag("True") && button.CompareTag("False") ||
           manager.secondBool[4] && gameObject.CompareTag("False") && button.CompareTag("True"))
        {
            manager.WrongPressSFX();

            transform.GetChild(0).GetComponent<Image>().enabled = true;
            transform.GetChild(0).GetComponent<Image>().sprite = manager.rightWrongSprite[0];
            transform.GetChild(0).GetComponent<Animation>().Play("GameOverPop");

            yield return new WaitForSeconds(1.5f);

            transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
    }
}
