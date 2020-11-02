using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Experimental.GraphView;

public class EclipseARManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText, explanationText;

    [SerializeField] private Sprite[] butSprite;

    [SerializeField] private string[] dialogue, lunarExplain, popInfoExplain;

    [SerializeField] private Button[] clickables;
    [SerializeField] private Button moreExplanationButton, nextButton;

    [SerializeField] private GameObject[] moreInfo;
    [SerializeField] private GameObject popup, slider, sliderBut, blueborder;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    int[] cur;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        for (int i = 0; i < clickables.Length; i++)
        {
            clickables[i].gameObject.SetActive(true);
            clickables[2].gameObject.SetActive(false);
        }

        explanationText.text = dialogue[0];

        moreExplanationButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);

        moreInfo[0].gameObject.SetActive(false);
        moreInfo[1].gameObject.SetActive(false);
        popup.gameObject.SetActive(false);
        sliderBut.SetActive(false);
        blueborder.SetActive(false);

        cur = new int[2];
    }

    void Update()
    {
        
    }

    public void _penumbral()
    {
        PressSFX();

        clickables[0].GetComponent<Image>().sprite = butSprite[0];
        clickables[1].GetComponent<Image>().sprite = butSprite[0];
        clickables[2].GetComponent<Image>().sprite = butSprite[1];

        explanationText.text = lunarExplain[0];

        moreInfo[0].gameObject.SetActive(false);
        moreInfo[1].gameObject.SetActive(false);

        blueborder.SetActive(false);
    }

    public void _lunar()
    {
        PressSFX();

        if (cur[1] == 0)
        {
            clickables[0].GetComponent<Image>().sprite = butSprite[1];
            clickables[1].GetComponent<Image>().sprite = butSprite[0];
            clickables[2].GetComponent<Image>().sprite = butSprite[0];

            explanationText.text = dialogue[1];
            cur[0] = 0;

            nextButton.gameObject.SetActive(true);

            titleText.text = "Stages of Lunar Eclipse";
        }
        else if (cur[1] == 1)
        {
            explanationText.text = lunarExplain[1];


            clickables[0].GetComponent<Image>().sprite = butSprite[1];
            clickables[1].GetComponent<Image>().sprite = butSprite[0];
            clickables[2].GetComponent<Image>().sprite = butSprite[0];

            moreInfo[0].gameObject.SetActive(false);
            moreInfo[1].gameObject.SetActive(false);

            blueborder.SetActive(false);
        }
    }

    public void _solar()
    {
        PressSFX();

        if (cur[1] == 0) // default
        {
            clickables[0].GetComponent<Image>().sprite = butSprite[0];
            clickables[1].GetComponent<Image>().sprite = butSprite[1];
            clickables[2].GetComponent<Image>().sprite = butSprite[0];

            cur[0] = 1;

            nextButton.gameObject.SetActive(true);

            titleText.text = "Stages of Solar Eclipse";
            explanationText.text = dialogue[3];
        }
        else if (cur[1] == 1)
        {
            explanationText.text = lunarExplain[2];

            clickables[0].GetComponent<Image>().sprite = butSprite[0];
            clickables[1].GetComponent<Image>().sprite = butSprite[1];
            clickables[2].GetComponent<Image>().sprite = butSprite[0];

            moreInfo[0].gameObject.SetActive(true);
            moreInfo[1].gameObject.SetActive(true);

            blueborder.SetActive(false);
        }
    }

    public void back()
    {
        BackSFX();

        for (int i = 0; i < clickables.Length; i++)
        {
            clickables[i].gameObject.SetActive(true);
            clickables[i].GetComponent<Image>().sprite = butSprite[0];

            clickables[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Lunar";
            clickables[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Solar";

            clickables[2].gameObject.SetActive(false);
        }

        explanationText.text = dialogue[0];
        cur[1] = 0;
        cur[0] = 0;

        moreInfo[0].gameObject.SetActive(false);
        moreInfo[1].gameObject.SetActive(false);

        moreExplanationButton.gameObject.SetActive(false);

        titleText.text = "Type of Eclipse";
    }

    public void NextButton()
    {
        PressSFX();

        for (int i = 0; i < clickables.Length; i++)
        {
            clickables[i].gameObject.SetActive(false);
        }

        nextButton.gameObject.SetActive(false);

        blueborder.SetActive(true);

        if (cur[0] == 0)
        {
            moreExplanationButton.gameObject.SetActive(true);
            moreExplanationButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Stages Lunar";

            blueborder.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                "Why do lunar eclipses only occur at Full Moon?";

            explanationText.text = dialogue[2];
            cur[1] = 1;
        }
        else if (cur[0] == 1)
        {
            moreExplanationButton.gameObject.SetActive(true);
            moreExplanationButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Stages Solar";

            blueborder.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
               "Why do solar eclipses only occur during New Moon?";
            explanationText.text = dialogue[4];
        }
    }

    public void MoreNext()
    {
        PressSFX();

        moreExplanationButton.gameObject.SetActive(false);

        if (cur[0] == 0)
        {
            for (int i = 0; i < clickables.Length; i++)
            {
                clickables[i].gameObject.SetActive(true);
            }

            for (int i = 0; i < clickables.Length; i++)
            {
                clickables[i].gameObject.SetActive(true);
                clickables[i].GetComponent<Image>().sprite = butSprite[0];
                clickables[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Partial";
                clickables[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Total";
            }
        }
        else if (cur[0] == 1)
        {
            blueborder.SetActive(false);

            for (int i = 0; i < clickables.Length; i++)
            {
                clickables[i].gameObject.SetActive(false);
                // show the eclipse model
            }
        }
    }

    public void MoreInfo(int index)
    {
        PressSFX();

        if (index == 0)
        {
            popup.SetActive(true);
            popup.transform.GetChild(0).gameObject.SetActive(true);
            popup.transform.GetChild(1).gameObject.SetActive(false);

            popup.GetComponent<Animation>().Play("SuccessPop");
        }
        else if (index == 1)
        {
            popup.SetActive(true);
            popup.GetComponent<Animation>().Play("SuccessPop");

            popup.transform.GetChild(0).gameObject.SetActive(false);
            popup.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (index == 2)
        {
            popup.SetActive(false);
        }
    }

    public void SliderAnimation(int index)
    {
        SlideSFX();

        if (index == 0)
        {
            StartCoroutine(Delay());
        }
        else if (index == 1)
        {
            slider.GetComponent<Animation>().Play("ShowSlide Anim");
            sliderBut.SetActive(false);
        }
    }

    IEnumerator Delay()
    {
        slider.GetComponent<Animation>().Play("HideSlide Anim");

        yield return new WaitForSeconds(.5f);

        sliderBut.SetActive(true);
    }

    public void BackToMenu()
    {
        BackSFX();

        SceneManager.LoadScene("Menu");
    }

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

    public void SlideSFX() // wrong answer
    {
        aSource.clip = clip[5];
        aSource.Play();
    }
}
