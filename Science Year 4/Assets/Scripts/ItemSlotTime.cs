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
        if (manager.secondBool[0] && button.CompareTag("Animal 3") ||
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

            button.SetActive(false);

            yield return new WaitForSeconds(1f);

            manager._DragNextQuestion();

            transform.GetChild(1).GetComponent<Image>().enabled = false;
        }
        else if (manager.secondBool[0] && button.tag != "Animal 3" ||
        manager.secondBool[1] && button.tag != "Animal 1" ||
        manager.secondBool[2] && button.tag != "Animal 3" ||
        manager.secondBool[3] && button.tag != "Animal 1" ||
        manager.secondBool[4] && button.tag != "Animal 2")
        {
            manager.WrongPressSFX();

            transform.GetChild(1).GetComponent<Image>().enabled = true;
            transform.GetChild(1).GetComponent<Image>().sprite = manager.rightWrongSprite[0];
            transform.GetChild(1).GetComponent<Animation>().Play("GameOverPop");

            yield return new WaitForSeconds(1f);

            transform.GetChild(1).GetComponent<Image>().enabled = false;
        }
    }
}
