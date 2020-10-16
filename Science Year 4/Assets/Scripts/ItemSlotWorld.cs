using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class ItemSlotWorld : MonoBehaviour, IDropHandler
{
    WorldMapManager manager;

    public GameObject button;

    private void Start()
    {
        gameObject.transform.parent.GetChild(2).gameObject.SetActive(false);
    }

    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<WorldMapManager>();
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
        if (manager.round[0] || manager.round[1] || manager.round[2] || manager.round[3] || manager.round[4])
        {
            if (gameObject.CompareTag("Day") && button.CompareTag("Day") || gameObject.CompareTag("Night") && button.CompareTag("Night"))
            {
                // put image in circle
                if (gameObject.CompareTag("Day"))
                {
                    // put sun image
                    gameObject.transform.GetChild(0).GetComponent<Image>().enabled = true;
                    gameObject.transform.GetChild(0).GetComponent<Image>().sprite = manager.rightWrongSprite[0];

                }
                else if (gameObject.CompareTag("Night"))
                {
                    // put night image
                    gameObject.transform.GetChild(0).GetComponent<Image>().enabled = true;
                    gameObject.transform.GetChild(0).GetComponent<Image>().sprite = manager.rightWrongSprite[1];
                }

                gameObject.GetComponent<Image>().raycastTarget = false;
                gameObject.transform.parent.GetChild(2).gameObject.SetActive(true);
                gameObject.transform.parent.GetChild(2).GetComponent<Animation>().Play("GameOverPop");

                manager.audioSource.clip = manager.sound[0];
                manager.audioSource.Play();

                if (manager.conditionBool[0])
                {
                    manager.conditionBool[0] = false;
                    manager.conditionBool[1] = true;
                }
                else if (manager.conditionBool[1])
                {
                    manager.conditionBool[1] = false;
                    manager.conditionBool[2] = true;
                }
                else if (manager.conditionBool[2])
                {
                    manager.conditionBool[2] = false;
                    manager.conditionBool[0] = true;

                    manager.nextButton.SetActive(true);
                }
            }
            else if (gameObject.CompareTag("Day") && button.CompareTag("Night") || gameObject.CompareTag("Night") && button.CompareTag("Day"))
            {
                manager.audioSource.clip = manager.sound[1];
                manager.audioSource.Play();
            }
        }
        else if (manager.round[5])
        {
            if (gameObject.CompareTag("Day") && button.CompareTag("Day") || gameObject.CompareTag("Night") && button.CompareTag("Night"))
            {
                gameObject.GetComponent<Image>().raycastTarget = false;
                gameObject.transform.parent.GetChild(2).gameObject.SetActive(true);
                gameObject.transform.parent.GetChild(2).GetComponent<Animation>().Play("GameOverPop");

                // put image in circle
                if (gameObject.CompareTag("Day"))
                {
                    // put sun image
                    gameObject.transform.GetChild(0).GetComponent<Image>().enabled = true;
                    gameObject.transform.GetChild(0).GetComponent<Image>().sprite = manager.rightWrongSprite[0];

                }
                else if (gameObject.CompareTag("Night"))
                {
                    // put night image
                    gameObject.transform.GetChild(0).GetComponent<Image>().enabled = true;
                    gameObject.transform.GetChild(0).GetComponent<Image>().sprite = manager.rightWrongSprite[1];
                }

                manager.audioSource.clip = manager.sound[0];
                manager.audioSource.Play();

                if (manager.conditionBool[0])
                {
                    manager.conditionBool[0] = false;
                    manager.conditionBool[1] = true;
                }
                else if (manager.conditionBool[1])
                {
                    manager.conditionBool[1] = false;
                    manager.conditionBool[2] = true;
                }
                else if (manager.conditionBool[2])
                {
                    manager.conditionBool[2] = false;
                    manager.conditionBool[0] = true;

                    StartCoroutine(Delay());
                }
            }
            else if (gameObject.CompareTag("Day") && button.CompareTag("Night") || gameObject.CompareTag("Night") && button.CompareTag("Day"))
            {

                manager.audioSource.clip = manager.sound[1];
                manager.audioSource.Play();
            }
        }

        yield return new WaitForSeconds(1f);
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);

        manager.EndPop.SetActive(true);
        manager.EndPop.transform.GetChild(0).GetComponent<Animation>().Play("GameOverPop");
    }
}
