using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ConstellationItemSlot : MonoBehaviour, IDropHandler
{
    ConstellationQuiz manager;

    GameObject button;

    string[] dialogue;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<ConstellationQuiz>();

        dialogue = new string[7];

        dialogue[0] = "Constellation help people find directions and recognise seasons";
        dialogue[1] = "There are 89 constellations in space";
        dialogue[2] = "People in the Northern Hemisphere see the same constellations as the people in the Southern Hemisphere";
        dialogue[3] = "Constellations may be only visible during certain seasons due to the Earth's orbit around the Sun";
        dialogue[4] = "Ursa Major is 'Great Bear' in Latin and is one of the brightest constellations";
        dialogue[5] = "Southern Cross is formed of four stars which makes it a kite-shaped constellation";
        dialogue[6] = "Southern Cross is formed of four stars which makes it a kite-shaped constellation";
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
        if (manager.secondBool[0] && gameObject.CompareTag("True") && button.CompareTag("True") ||
            manager.secondBool[1] && gameObject.CompareTag("False") && button.CompareTag("False") ||
            manager.secondBool[2] && gameObject.CompareTag("False") && button.CompareTag("False") ||
            manager.secondBool[3] && gameObject.CompareTag("True") && button.CompareTag("True") ||
            manager.secondBool[4] && gameObject.CompareTag("False") && button.CompareTag("False") ||
            manager.secondBool[5] && gameObject.CompareTag("True") && button.CompareTag("True") ||
            manager.secondBool[6] && gameObject.CompareTag("True") && button.CompareTag("True"))
        {
            manager.RightSFX();

            transform.GetChild(0).GetComponent<Image>().enabled = true;
            transform.GetChild(0).GetComponent<Image>().sprite = manager.rightWrongSprite[1];
            transform.GetChild(0).GetComponent<Animation>().Play("GameOverPop");

            transform.GetChild(1).GetComponent<ParticleSystem>().Play();

            if (manager.secondBool[0])
            {
                manager.secondBool[1] = true;
                manager.secondBool[0] = false;
                button.tag = "False";

                button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dialogue[0].ToString();
            }
            else if (manager.secondBool[1])
            {
                manager.secondBool[2] = true;
                manager.secondBool[1] = false;
                button.tag = "False";

                button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dialogue[1].ToString();
            }
            else if (manager.secondBool[2])
            {
                manager.secondBool[3] = true;
                manager.secondBool[2] = false;
                button.tag = "True";

                button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dialogue[2].ToString();
            }
            else if (manager.secondBool[3])
            {
                manager.secondBool[4] = true;
                manager.secondBool[3] = false;
                button.tag = "False";

                button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dialogue[3].ToString();
            }
            else if (manager.secondBool[4])
            {
                manager.secondBool[4] = true;
                manager.secondBool[3] = false;
                button.tag = "True";

                button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dialogue[3].ToString();
            }
            else if (manager.secondBool[5])
            {
                manager.secondBool[4] = true;
                manager.secondBool[3] = false;
                button.tag = "True";

                button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dialogue[3].ToString();
            }
            else if (manager.secondBool[6])
            {
                // end of the line
            }

            button.SetActive(false);

            yield return new WaitForSeconds(1f);

            transform.GetChild(0).GetComponent<Image>().enabled = false;

            if (manager.secondBool[6])
            {
                button.SetActive(false);
            }
            else if (!manager.secondBool[6])
            {
                button.SetActive(true);
            }

            button.transform.position = button.GetComponent<DragDropConstellation>().startPos.position;

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
           manager.secondBool[4] && gameObject.CompareTag("False") && button.CompareTag("True") ||
           manager.secondBool[5] && gameObject.CompareTag("True") && button.CompareTag("False") ||
           manager.secondBool[6] && gameObject.CompareTag("True") && button.CompareTag("False"))
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
