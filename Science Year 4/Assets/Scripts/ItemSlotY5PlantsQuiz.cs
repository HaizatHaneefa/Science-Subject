using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlotY5PlantsQuiz : MonoBehaviour, IDropHandler
{
    Y5PlantQuiz manager;

    [SerializeField] private GameObject[] lastObjects;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Y5PlantQuiz>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (manager.thirdBool[0] && eventData.pointerDrag.CompareTag("Animal 2") || manager.thirdBool[1] && eventData.pointerDrag.CompareTag("Animal 1")
                || manager.thirdBool[2] && eventData.pointerDrag.CompareTag("Animal 1"))
            {
                manager.RightSFX();

                transform.GetChild(1).GetComponent<Image>().enabled = true;
                transform.GetChild(1).GetComponent<Image>().sprite = manager.rightWrongSprite[1];
                transform.GetChild(1).GetComponent<Animation>().Play("GameOverPop");

                StartCoroutine(ShowSprite());

                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

                transform.GetChild(0).GetComponent<ParticleSystem>().Play();

                if (manager.thirdBool[0])
                {
                    for (int i = 0; i < manager.thirdBool.Length; i++)
                    {
                        manager.thirdBool[i] = false;
                        manager.thirdBool[1] = true;
                    }

                    for (int i = 0; i < manager.thirdAnswers.Length; i++)
                    {
                        manager.thirdAnswers[i].SetActive(false);
                        manager.thirdAnswers[1].SetActive(true);
                    }

                    manager.thirdAnswers[1].GetComponent<Animation>().Play("Question-Year 5 Chap 4");

                    manager.hint1.text = "Have stem that stores water";
                    manager.hint2.text = "Have to survive in dry regions";
                }
                else if (manager.thirdBool[1])
                {
                    for (int i = 0; i < manager.thirdBool.Length; i++)
                    {
                        manager.thirdBool[i] = false;
                        manager.thirdBool[2] = true;
                    }

                    manager.thirdQuestion.transform.GetChild(4).gameObject.SetActive(false);
                    manager.thirdQuestion.transform.GetChild(5).gameObject.SetActive(true);

                    manager.thirdAnswers[2].GetComponent<Animation>().Play("Question-Year 5 Chap 4");

                    manager.hint1.text = "Have divided leaves";
                    manager.hint2.text = "Grow by the beaches";
                }
                else if (manager.thirdBool[2])
                {
                    StartCoroutine(EndGame());
                }
            }
            else if (manager.thirdBool[0] && eventData.pointerDrag.CompareTag("Animal 1") ||
                manager.thirdBool[0] && eventData.pointerDrag.CompareTag("Animal 3") ||
                manager.thirdBool[1] && eventData.pointerDrag.CompareTag("Animal 2") ||
                manager.thirdBool[1] && eventData.pointerDrag.CompareTag("Animal 3") ||
                manager.thirdBool[2] && eventData.pointerDrag.CompareTag("Animal 2") ||
                manager.thirdBool[2] && eventData.pointerDrag.CompareTag("Animal 3"))
            {
                manager.WrongPressSFX();

                transform.GetChild(1).GetComponent<Image>().enabled = true;
                transform.GetChild(1).GetComponent<Image>().sprite = manager.rightWrongSprite[0];
                transform.GetChild(1).GetComponent<Animation>().Play("GameOverPop");

                StartCoroutine(ShowSprite());
            }
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1f);

        manager.signBoard.SetActive(true);

        for (int i = 0; i < lastObjects.Length; i++)
        {
            lastObjects[i].SetActive(false);
        }
    }

    IEnumerator ShowSprite()
    {
        yield return new WaitForSeconds(1f);

        transform.GetChild(1).GetComponent<Image>().enabled = false;
    }
}
