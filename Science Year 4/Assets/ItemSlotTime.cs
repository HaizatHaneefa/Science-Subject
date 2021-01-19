using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemSlotTime : MonoBehaviour, IDropHandler
{
    TimeQuizManager manager;

    GameObject button;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<TimeQuizManager>();
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
        Debug.Log("ww");

        if (manager.secondBool[0] && button.CompareTag("Animal 2") ||
            manager.secondBool[1] && button.CompareTag("Animal 1") ||
            manager.secondBool[2] && button.CompareTag("Animal 3") ||
            manager.secondBool[3] && button.CompareTag("Animal 1") ||
            manager.secondBool[4] && button.CompareTag("Animal 2"))
        {
            manager.RightSFX();

            transform.GetChild(1).GetComponent<Image>().enabled = true;
            transform.GetChild(1).GetComponent<Image>().sprite = manager.rightWrongSprite[1];
            transform.GetChild(1).GetComponent<Animation>().Play("GameOverPop");

            //transform.GetChild(1).GetComponent<ParticleSystem>().Play();

            if (manager.secondBool[0])
            {
                manager.secondBool[1] = true; 
                manager.secondBool[0] = false;
            }
            else if (manager.secondBool[1])
            {
                manager.secondBool[2] = true;
                manager.secondBool[1] = false;
            }
            else if (manager.secondBool[2])
            {
                manager.secondBool[3] = true;
                manager.secondBool[2] = false;
            }
            else if (manager.secondBool[3])
            {
                manager.secondBool[3] = false;
                manager.secondBool[4] = true;
            }
            else if (manager.secondBool[4])
            {
                // end
            }

            button.SetActive(false);

            yield return new WaitForSeconds(1f);

            manager.NextQuestion();

            transform.GetChild(1).GetComponent<Image>().enabled = false;

            //if (manager.secondBool[6])
            //{
            //    button.SetActive(false);
            //    //manager.endpop.SetActive(true);
            //    //manager.endpop.transform.GetChild(0).GetComponent<Animation>().Play("SuccessPop");
            //}
            //else if (!manager.secondBool[6])
            //{
            //    button.SetActive(true);
            //}

            //button.transform.position = button.GetComponent<MathTimeDragDrop>().startPos.position;

            //button.GetComponent<CanvasGroup>().alpha = 1f;
            //button.GetComponent<CanvasGroup>().blocksRaycasts = true;
            //button.GetComponent<Image>().sprite = button.GetComponent<DragDropConstellation>().sprite[0];

            //gameObject.GetComponent<Image>().raycastTarget = true;

            //button.GetComponent<RectTransform>().sizeDelta = new Vector2(850, 150);
            //button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        }
        //else if (manager.secondBool[0] && gameObject.CompareTag("False") && button.CompareTag("True") ||
        //   manager.secondBool[1] && gameObject.CompareTag("True") && button.CompareTag("False") ||
        //   manager.secondBool[2] && gameObject.CompareTag("True") && button.CompareTag("False") ||
        //   manager.secondBool[3] && gameObject.CompareTag("False") && button.CompareTag("True") ||
        //   manager.secondBool[4] && gameObject.CompareTag("True") && button.CompareTag("False") ||
        //   manager.secondBool[5] && gameObject.CompareTag("False") && button.CompareTag("True") ||
        //   manager.secondBool[6] && gameObject.CompareTag("False") && button.CompareTag("True"))
        //{
        //    manager.WrongPressSFX();

        //    transform.GetChild(0).GetComponent<Image>().enabled = true;
        //    transform.GetChild(0).GetComponent<Image>().sprite = manager.rightWrongSprite[0];
        //    transform.GetChild(0).GetComponent<Animation>().Play("GameOverPop");

        //    yield return new WaitForSeconds(1.5f);

        //    transform.GetChild(0).GetComponent<Image>().enabled = false;
        //}
    }
}
