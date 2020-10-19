using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class SpeedARManager : MonoBehaviour
{
    [SerializeField] string[] dialogue;
    [SerializeField] Sprite[] buttonSprite;
    [SerializeField] GameObject[] buttons;
    [SerializeField] GameObject go, startButton, imageSlider, hideSliderButton;
    [SerializeField] TextMeshProUGUI descriptionText, definitionText;

    int cur;

    void Start()
    {
        go.SetActive(false);
        imageSlider.SetActive(false);
        hideSliderButton.SetActive(false);
        descriptionText.transform.parent.gameObject.SetActive(false);
        definitionText.transform.parent.gameObject.SetActive(false);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
    }

    public void StartAR()
    {
        descriptionText.transform.parent.gameObject.SetActive(true);
        definitionText.transform.parent.gameObject.SetActive(true);

        buttons[0].SetActive(true);
        buttons[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Unit of Speed";
        buttons[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 18;

        startButton.SetActive(false);
        go.SetActive(true);

        descriptionText.text = dialogue[0].ToString();
        definitionText.text = "Definition of Speed";

        imageSlider.SetActive(true);
    }

    public void HideSlider()
    {
        StartCoroutine(HideButton());
    }

    public void ShowSlider()
    {
        StartCoroutine(ShowButton());
    }

    public void NextButton()
    {
        if (cur == 0)
        {
            buttons[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Relationship between speed, distance and time";
            buttons[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 13;

            buttons[3].SetActive(true);
            imageSlider.SetActive(false);
             
            definitionText.text = "Unit of Speed";
            cur += 1;
        }
        else if (cur == 1)
        {
            buttons[1].SetActive(true);
            buttons[2].SetActive(true);
            buttons[3].SetActive(false);

            definitionText.text = "Relationship between speed, distance and time";

            imageSlider.SetActive(true);
            descriptionText.text = "";
            cur += 1;

        }
    }

    public void PrevButton()
    {
        if (cur == 2)
        {
            buttons[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Relationship between speed, distance and time";
            buttons[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 13;

            buttons[1].SetActive(false);
            buttons[2].SetActive(false);
            buttons[3].SetActive(true);

            buttons[1].GetComponent<Image>().sprite = buttonSprite[0];
            buttons[2].GetComponent<Image>().sprite = buttonSprite[0];

            imageSlider.SetActive(false);

            cur -= 1;

            definitionText.text = "Unit of Speed";
        }
        else if (cur == 1)
        {
            descriptionText.transform.parent.gameObject.SetActive(true);
            definitionText.transform.parent.gameObject.SetActive(true);

            buttons[0].SetActive(true);
            buttons[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Unit of Speed";
            buttons[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 18;

            buttons[3].SetActive(false);

            startButton.SetActive(false);
            go.SetActive(true);

            descriptionText.text = dialogue[0].ToString();
            definitionText.text = "Definition of Speed";

            imageSlider.SetActive(true);

            cur -= 1;
        }
    }

    public void TimeIsSet()
    {
        descriptionText.text = dialogue[1].ToString();
        descriptionText.fontSize = 15;

        buttons[1].GetComponent<Image>().sprite = buttonSprite[1];
        buttons[2].GetComponent<Image>().sprite = buttonSprite[0];
    }

    public void DistanceIsSet()
    {
        descriptionText.text = dialogue[2].ToString();
        descriptionText.fontSize = 15;


        buttons[1].GetComponent<Image>().sprite = buttonSprite[0];
        buttons[2].GetComponent<Image>().sprite = buttonSprite[1];
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ToQuiz()
    {
        SceneManager.LoadScene("Y6 - Speed Quiz"); // to quiz
    }

    IEnumerator HideButton()
    {
        imageSlider.GetComponent<Animation>().Play("HideSlide Anim");

        yield return new WaitForSeconds(0.5f);

        hideSliderButton.SetActive(true);
    }

    IEnumerator ShowButton()
    {
        hideSliderButton.SetActive(false);

        yield return new WaitForSeconds(0.1f);

        imageSlider.GetComponent<Animation>().Play("ShowSlide Anim");
    }
}
