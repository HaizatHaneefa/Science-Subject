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
        //transform.GetChild(2).GetComponent<ParticleSystem>().Stop();
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
                gameObject.GetComponent<Image>().raycastTarget = false;
                gameObject.transform.parent.GetChild(2).gameObject.SetActive(true);
                gameObject.transform.parent.GetChild(2).GetComponent<Animation>().Play("GameOverPop");

                //   pop that day time shit
                //   revert button pos
                //mark bool as true

                Debug.Log("Yay!");

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

                    // change some shit

                    //manager.contButton.SetActive(true);

                    StartCoroutine(manager.DelayThatThang());
                }
            }
            else if (gameObject.CompareTag("Day") && button.CompareTag("Night") || gameObject.CompareTag("Night") && button.CompareTag("Day"))
            {
                //denied!
                Debug.Log("Nay!");
            }
        }
        else if (manager.round[5])
        {
            if (gameObject.CompareTag("Day") && button.CompareTag("Day") || gameObject.CompareTag("Night") && button.CompareTag("Night"))
            {
                gameObject.GetComponent<Image>().raycastTarget = false;
                gameObject.transform.parent.GetChild(2).gameObject.SetActive(true);
                gameObject.transform.parent.GetChild(2).GetComponent<Animation>().Play("GameOverPop");

                //   pop that day time shit
                //   revert button pos
                //mark bool as true

                Debug.Log("Yay!");

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

                    // change some shit

                    StartCoroutine(Delay());
                }
            }
            else if (gameObject.CompareTag("Day") && button.CompareTag("Night") || gameObject.CompareTag("Night") && button.CompareTag("Day"))
            {
                //denied!
                Debug.Log("Nay!");
            }
        }
        //else if (manager.round[1])
        //{
        //    if (gameObject.CompareTag("Day") && button.CompareTag("Day"))
        //    {
        //        gameObject.GetComponent<Image>().raycastTarget = false;
        //        gameObject.transform.parent.GetChild(2).gameObject.SetActive(true);
        //        gameObject.transform.parent.GetChild(2).GetComponent<Animation>().Play("GameOverPop");

        //        //   pop that day time shit
        //        //   revert button pos
        //        //mark bool as true

        //        Debug.Log("Yay!");

        //        if (manager.conditionBool[0])
        //        {
        //            manager.conditionBool[0] = false;
        //            manager.conditionBool[1] = true;
        //        }
        //        else if (manager.conditionBool[1])
        //        {
        //            manager.conditionBool[1] = false;
        //            manager.conditionBool[2] = true;
        //        }
        //        else if (manager.conditionBool[2])
        //        {
        //            manager.conditionBool[2] = false;
        //            manager.conditionBool[0] = true;

        //            // change some shit

        //            manager.contButton.SetActive(true);
        //        }
        //    }
        //    else if (gameObject.CompareTag("Day") && button.CompareTag("Night"))
        //    {
        //        //denied!
        //        Debug.Log("Nay!");
        //    }
        //}
        //else if (manager.round[2])
        //{
        //    if (gameObject.CompareTag("Day") && button.CompareTag("Day") || gameObject.CompareTag("Night") && button.CompareTag("Night"))
        //    {
        //        gameObject.GetComponent<Image>().raycastTarget = false;
        //        gameObject.transform.parent.GetChild(2).gameObject.SetActive(true);
        //        gameObject.transform.parent.GetChild(2).GetComponent<Animation>().Play("GameOverPop");

        //        //   pop that day time shit
        //        //   revert button pos
        //        //mark bool as true

        //        Debug.Log("Yay!");

        //        if (manager.conditionBool[0])
        //        {
        //            manager.conditionBool[0] = false;
        //            manager.conditionBool[1] = true;
        //        }
        //        else if (manager.conditionBool[1])
        //        {
        //            manager.conditionBool[1] = false;
        //            manager.conditionBool[2] = true;
        //        }
        //        else if (manager.conditionBool[2])
        //        {
        //            manager.conditionBool[2] = false;
        //            manager.conditionBool[0] = true;

        //            // change some shit

        //            manager.contButton.SetActive(true);
        //        }
        //    }
        //    else if (gameObject.CompareTag("Day") && button.CompareTag("Night") || gameObject.CompareTag("Night") && button.CompareTag("Day"))
        //    {
        //        //denied!
        //        Debug.Log("Nay!");
        //    }
        //}

        yield return new WaitForSeconds(1f);
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);

        manager.EndPop.SetActive(true);
        manager.EndPop.transform.GetChild(0).GetComponent<Animation>().Play("GameOverPop");
    }
}
