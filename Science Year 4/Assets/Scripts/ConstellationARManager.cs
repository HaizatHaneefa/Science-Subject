using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ConstellationARManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI descriptiveText, descriptionText;

    [SerializeField] private Sprite[] sprite;

    [SerializeField] private Button[] button, otherButtons;

    [SerializeField] private Button genericbutton, nextButton, importanceButton, quizButton;

    [SerializeField] private string[] description;

    [SerializeField] private GameObject slider, arrowUp;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    int cur;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        nextButton.gameObject.SetActive(false);
        importanceButton.gameObject.SetActive(false);
        quizButton.gameObject.SetActive(false);
        arrowUp.SetActive(false);

        for (int i = 0; i < button.Length; i++)
        {
            button[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < otherButtons.Length; i++)
        {
            otherButtons[i].gameObject.SetActive(false);
        }
    }

    // ---------------- button functions ---------------- //
    public void _Orion()
    {
        PressSFX();
        for (int i = 0; i < button.Length; i++)
        {
            button[i].GetComponent<Image>().sprite = sprite[0];
            button[0].GetComponent<Image>().sprite = sprite[1];
        }

        descriptionText.text = description[0].ToString();
        nextButton.gameObject.SetActive(false);
    }

    public void _BigDipper()
    {
        PressSFX();
        for (int i = 0; i < button.Length; i++)
        {
            button[i].GetComponent<Image>().sprite = sprite[0];
            button[1].GetComponent<Image>().sprite = sprite[1];
        }

        descriptionText.text = description[1].ToString();
        nextButton.gameObject.SetActive(true);

        cur = 1;
    }

    public void _SouthernCross()
    {
        PressSFX();
        for (int i = 0; i < button.Length; i++)
        {
            button[i].GetComponent<Image>().sprite = sprite[0];
            button[2].GetComponent<Image>().sprite = sprite[1];
        }

        descriptionText.text = description[3].ToString();
        nextButton.gameObject.SetActive(true);

        cur = 2;
    }

    public void _Scorpius()
    {
        PressSFX();
        for (int i = 0; i < button.Length; i++)
        {
            button[i].GetComponent<Image>().sprite = sprite[0];
            button[3].GetComponent<Image>().sprite = sprite[1];
        }

        descriptionText.text = description[5].ToString();
        nextButton.gameObject.SetActive(true);

        cur = 3;
    }

    public void Next()
    {
        PressSFX();
        if (cur == 1)
        {
            descriptionText.text = description[2].ToString();
        }
        else if (cur == 2)
        {
            descriptionText.text = description[4].ToString();
        }
        else if (cur == 3)
        {
            descriptionText.text = description[6].ToString();
        }
    }

    public void ToLast()
    {
        PressSFX();
        for (int i = 0; i < otherButtons.Length; i++)
        {
            otherButtons[i].gameObject.SetActive(true);
        }

        for (int i = 0; i < button.Length; i++)
        {
            button[i].gameObject.SetActive(false);
        }

        slider.SetActive(false);
        importanceButton.gameObject.SetActive(false);
        quizButton.gameObject.SetActive(true);

        descriptiveText.text = "The importance of constellations";
    }

    public void SliderAnim(int index)
    {
        PressSFX();
        if (index == 0)
        {
            StartCoroutine(AnimHide());
        }
        else if (index == 1)
        {
            slider.GetComponent<Animation>().Play("ShowSlide Anim");
            arrowUp.SetActive(false);
        }
    }

    public void ToShape()
    {
        PressSFX();
        genericbutton.gameObject.SetActive(false);
        importanceButton.gameObject.SetActive(true);

        for (int i = 0; i < button.Length; i++)
        {
            button[i].gameObject.SetActive(true);
        }

        descriptiveText.text = "Various shapes of Constellations";
    }

    public void ToMenu()
    {
        BackSFX();
        SceneManager.LoadScene("Menu");
    }

    public void ToQUiz()
    {
        PressSFX();
        SceneManager.LoadScene("Y6 - Constellation Quiz");
    }
    // ---------------- NUMERATORS ---------------- //
    IEnumerator AnimHide()
    {
        slider.GetComponent<Animation>().Play("HideSlide Anim");

        yield return new WaitForSeconds(0.5f);

        arrowUp.SetActive(true);
    }

    // ---------------- SFX ---------------- // 
    public void PressSFX() // button press yes
    {
        aSource.clip = clip[0];
        aSource.Play();
    }

    public void WrongPressSFX() // button press no
    {
        aSource.clip = clip[4];
        aSource.Play();
    }

    public void BackSFX() // back button press
    {
        aSource.clip = clip[1];
        aSource.Play();
    }

    public void RightSFX() // right answer
    {
        aSource.clip = clip[2];
        aSource.Play();
    }

    public void WrongSFX() // wrong answer
    {
        aSource.clip = clip[3];
        aSource.Play();
    }
}
