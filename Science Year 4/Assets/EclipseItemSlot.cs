using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class EclipseItemSlot : MonoBehaviour, IDropHandler
{
    EclipseQuizManager manager;

    [SerializeField] private string[] dialogue;

    GameObject button;

    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<EclipseQuizManager>();

        dialogue = new string[4];

        dialogue[0] = "The umbra of Earth's shadow always points directly towards the Moon";
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
        if (manager.secondBool[0] && gameObject.CompareTag("True") && button.CompareTag("True") ||
            manager.secondBool[1] && gameObject.CompareTag("False") && button.CompareTag("False"))
        {
            manager.RightSFX();

            transform.GetChild(0).GetComponent<Image>().enabled = true;
            transform.GetChild(0).GetComponent<Image>().sprite = manager.rightWrongSprite[1];
            transform.GetChild(0).GetComponent<Animation>().Play("GameOverPop");

            //transform.GetChild(2).GetComponent<ParticleSystem>().Play();

            if (manager.secondBool[0])
            {
                button.tag = "False";

                button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dialogue[0].ToString();
                button.GetComponent<Animation>().Play("GameOverPop");
            }
            //else if (manager.secondBool[1])
            //{
            //    // game over
            //}

            button.SetActive(false);

            yield return new WaitForSeconds(1f);

            if (manager.secondBool[1])
            {
                // end the quiz
                button.SetActive(false);
                manager.endpop.SetActive(true);
                manager.endpop.GetComponent<Animation>().Play("SuccessPop");
                transform.GetChild(0).GetComponent<Image>().enabled = false;
            }
            else  if (manager.secondBool[0])
            {
                transform.GetChild(0).GetComponent<Image>().enabled = false;

                button.SetActive(true);

                button.transform.position = button.GetComponent<EclipseDragDrop>().startPos.position;

                button.GetComponent<CanvasGroup>().alpha = 1f;
                button.GetComponent<CanvasGroup>().blocksRaycasts = true;

                gameObject.GetComponent<Image>().raycastTarget = true;

                button.GetComponent<RectTransform>().sizeDelta = new Vector2(750, 120);
                button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;

                manager.secondBool[1] = true;
                manager.secondBool[0] = false;
            }
        }
        else if (manager.secondBool[0] && gameObject.CompareTag("False") && button.CompareTag("True") ||
           manager.secondBool[1] && gameObject.CompareTag("True") && button.CompareTag("False"))
        {
            manager.WrongPressSFX();

            transform.GetChild(0).GetComponent<Image>().enabled = true;
            transform.GetChild(0).GetComponent<Image>().sprite = manager.rightWrongSprite[0];
            transform.GetChild(0).GetComponent<Animation>().Play("GameOverPop");

            yield return new WaitForSeconds(1f);

            transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
    }

    //IEnumerator Delay()
    //{
    //    yield return new WaitForSeconds(1f);

    //    manager.continueButton.SetActive(true);
    //    manager.secondQuestion.SetActive(false);
    //}
}
