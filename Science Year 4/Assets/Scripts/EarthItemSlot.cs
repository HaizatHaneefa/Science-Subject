using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class EarthItemSlot : MonoBehaviour, IDropHandler
{
    EarthQuiz manager;

    GameObject button;

    [SerializeField] string[] dialogue;

    private void Start()
    {
    }

    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<EarthQuiz>();

        dialogue = new string[5];

        dialogue[0] = "Earth is orbiting around the Sun. Earth’s orbit around sun is elliptical.";
        dialogue[1] = "The rotation of the Earth on its axis causes the position and length of the shadow to change.";
        dialogue[2] = "The Sun moves from west to east in the sky.";
        dialogue[3] = "At 5.00 p.m., the length of a shadow is the shortest.";
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
        if (manager.secondBool[0] && gameObject.CompareTag("False") && button.CompareTag("False") ||
            manager.secondBool[1] && gameObject.CompareTag("True") && button.CompareTag("True") ||
            manager.secondBool[2] && gameObject.CompareTag("True") && button.CompareTag("True") ||
            manager.secondBool[3] && gameObject.CompareTag("False") && button.CompareTag("False") ||
            manager.secondBool[4] && gameObject.CompareTag("False") && button.CompareTag("False"))
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
                button.GetComponent<Animation>().Play("GameOverPop");
            }
            else if (manager.secondBool[1])
            {
                manager.secondBool[2] = true;
                manager.secondBool[1] = false;
                button.tag = "True";

                button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dialogue[1].ToString();
                button.GetComponent<Animation>().Play("GameOverPop");
            }
            else if (manager.secondBool[2])
            {
                manager.secondBool[3] = true;
                manager.secondBool[2] = false;
                button.tag = "False";

                button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dialogue[2].ToString();
                button.GetComponent<Animation>().Play("GameOverPop");
            }
            else if (manager.secondBool[3])
            {
                manager.secondBool[4] = true;
                manager.secondBool[3] = false;
                button.tag = "False";

                button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dialogue[3].ToString();
                button.GetComponent<Animation>().Play("GameOverPop");
            }
            else if (manager.secondBool[4])
            {
                manager.secondBool[4] = false;
                manager.secondBool[5] = true;

                StartCoroutine(Delay());
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

            button.transform.position = button.GetComponent<DragDropEarth>().startPos.position;

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
           manager.secondBool[4] && gameObject.CompareTag("True") && button.CompareTag("False"))
        {
            manager.WrongPressSFX();
            transform.GetChild(0).GetComponent<Image>().enabled = true;
            transform.GetChild(0).GetComponent<Image>().sprite = manager.rightWrongSprite[0];
            transform.GetChild(0).GetComponent<Animation>().Play("GameOverPop");

            yield return new WaitForSeconds(1f);

            transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);

        manager.signBoard.SetActive(true);
    }
}
