using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    YearFiveQuizManager manager;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<YearFiveQuizManager>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (manager.thirdBool[0] && eventData.pointerDrag.CompareTag("Animal 2") || manager.thirdBool[1] && eventData.pointerDrag.CompareTag("Animal 1")
                || manager.thirdBool[2] && eventData.pointerDrag.CompareTag("Animal 3"))
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                
                manager.RightSFX();

                Image z = transform.GetChild(1).GetComponent<Image>();
                z.enabled = true;
                z.sprite = manager.rightWrongSprite[1];
                z.gameObject.GetComponent<Animation>().Play("GameOverPop");

                transform.GetChild(0).GetComponent<ParticleSystem>().Play();

                StartCoroutine(Teding());

                if (manager.thirdBool[0])
                {
                    for (int i = 0; i < manager.thirdBool.Length; i++)
                    {
                        manager.thirdBool[i] = false;
                        manager.thirdBool[1] = true;
                    }

                    manager.thirdQuestion.transform.GetChild(3).gameObject.SetActive(false);
                    manager.thirdQuestion.transform.GetChild(4).gameObject.SetActive(true);

                    manager.thirdQuestion.GetComponent<Animation>().Play("Question-Year 5 Chap 4");
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

                    manager.thirdQuestion.GetComponent<Animation>().Play("Question-Year 5 Chap 4");
                }
                else if (manager.thirdBool[2])
                {
                    for (int i = 0; i < manager.thirdBool.Length; i++)
                    {
                        manager.thirdBool[i] = false;
                    }

                    manager.thirdQuestion.transform.GetChild(5).gameObject.SetActive(false);

                    manager.signBoard.SetActive(true);

                    for (int i = 0; i < manager.thingstoDisableEnd.Length; i++)
                    {
                        manager.thingstoDisableEnd[i].SetActive(false);
                    }
                }
            }
            else if (manager.thirdBool[0] && eventData.pointerDrag.CompareTag("Animal 1") ||
                manager.thirdBool[0] && eventData.pointerDrag.CompareTag("Animal 3") ||
                manager.thirdBool[1] && eventData.pointerDrag.CompareTag("Animal 2") ||
                manager.thirdBool[1] && eventData.pointerDrag.CompareTag("Animal 3") ||
                manager.thirdBool[2] && eventData.pointerDrag.CompareTag("Animal 1") ||
                manager.thirdBool[2] && eventData.pointerDrag.CompareTag("Animal 2"))
            {
                eventData.pointerDrag.SetActive(false);

                manager.WrongPressSFX();

                Image j = transform.GetChild(1).GetComponent<Image>();
                j.GetComponent<Image>().enabled = true;
                j.GetComponent<Image>().sprite = manager.rightWrongSprite[0];
                j.gameObject.GetComponent<Animation>().Play("GameOverPop");

                StartCoroutine(Teding());
            }
        }
    }

    IEnumerator Teding()
    {
        yield return new WaitForSeconds(1f);

        transform.GetChild(1).GetComponent<Image>().enabled = false;
    }
}
