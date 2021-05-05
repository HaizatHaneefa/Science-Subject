using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class EclipseARManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText, explanationText;

    [SerializeField] private Sprite[] butSprite, lunarSprites;

    [SerializeField] private Image stagesLunarImage;
    [SerializeField] private string[] dialogue, lunarExplain;

    [SerializeField] private string[] menudialogue, lunardialogue, solardialogue;

    [SerializeField] private Button moreExplanationButton, nextButton;

    [SerializeField] private GameObject popup, slider, sliderBut, blueborder, quizObject, sliderImage, backButton;

    [SerializeField] private GameObject[] canvas, lunarsolarButton, lunarbuttons;
    [SerializeField] private GameObject[] Objs, solarChoices, models;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    int[] cur;
    int baruInfo, solarint;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        stagesLunarImage.gameObject.SetActive(false);

        for (int i = 0; i < Objs.Length; i++)
        {
            Objs[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < models.Length; i++)
        {
            models[i].SetActive(false);
        }

        for (int i = 0; i < solarChoices.Length; i++)
        {
            solarChoices[i].SetActive(false);
        }

        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].gameObject.SetActive(false);
            canvas[0].gameObject.SetActive(true);
        }

        explanationText.text = dialogue[0];

        nextButton.gameObject.SetActive(false);
        popup.gameObject.SetActive(false);
        sliderBut.SetActive(false);
        blueborder.SetActive(false);
        quizObject.SetActive(false);
        moreExplanationButton.gameObject.SetActive(false);

        cur = new int[2];

        backButton.SetActive(false);
    }

    // -------------------------- solar and lunar eclipse explanation buttons --------------------------- //
    public void _LunarChoices(int index)
    {
        PressSFX();

        stagesLunarImage.gameObject.SetActive(true);

        if (index == 0)
        {
            explanationText.text = lunardialogue[2];

            stagesLunarImage.transform.GetChild(0).gameObject.SetActive(false);
            stagesLunarImage.transform.GetChild(1).gameObject.SetActive(false);

            for (int i = 0; i < lunarbuttons.Length; i++)
            {
                lunarbuttons[i].GetComponent<Image>().sprite = butSprite[0];
                lunarbuttons[0].GetComponent<Image>().sprite = butSprite[1];
            }

            stagesLunarImage.sprite = lunarSprites[0];
        }
        else if (index == 1)
        {
            stagesLunarImage.transform.GetChild(0).gameObject.SetActive(false);
            stagesLunarImage.transform.GetChild(1).gameObject.SetActive(false);

            explanationText.text = lunardialogue[3];

            for (int i = 0; i < lunarbuttons.Length; i++)
            {
                lunarbuttons[i].GetComponent<Image>().sprite = butSprite[0];
                lunarbuttons[1].GetComponent<Image>().sprite = butSprite[1];
            }

            stagesLunarImage.sprite = lunarSprites[1];
        }
        else if (index == 2)
        {
            explanationText.text = lunardialogue[4];

            stagesLunarImage.transform.GetChild(0).gameObject.SetActive(true);
            stagesLunarImage.transform.GetChild(1).gameObject.SetActive(true);

            for (int i = 0; i < lunarbuttons.Length; i++)
            {
                lunarbuttons[i].GetComponent<Image>().sprite = butSprite[0];
                lunarbuttons[2].GetComponent<Image>().sprite = butSprite[1];
            }

            stagesLunarImage.sprite = lunarSprites[2];
        }
    }

    public void _SolarChoices(int index)
    {
        PressSFX();

        if (index == 0)
        {
            for (int i = 0; i < solarChoices.Length; i++)
            {
                solarChoices[i].gameObject.SetActive(false);
                solarChoices[0].gameObject.SetActive(true);
            }

            solarChoices[0].GetComponent<Animation>().Play("SuccessPop");
        }
        else if (index == 1)
        {
            for (int i = 0; i < solarChoices.Length; i++)
            {
                solarChoices[i].gameObject.SetActive(false);
                solarChoices[1].gameObject.SetActive(true);
            }

            solarChoices[1].GetComponent<Animation>().Play("SuccessPop");
        }
        else if (index == 2)
        {
            for (int i = 0; i < solarChoices.Length; i++)
            {
                solarChoices[i].gameObject.SetActive(false);
                solarChoices[2].gameObject.SetActive(true);
            }

            solarChoices[2].GetComponent<Animation>().Play("SuccessPop");
        }
        else if (index == 3)
        {
            for (int i = 0; i < solarChoices.Length; i++)
            {
                solarChoices[i].gameObject.SetActive(false);
                solarChoices[3].gameObject.SetActive(true);
            }

            solarChoices[3].GetComponent<Animation>().Play("SuccessPop");
        }
        else if (index == 4)
        {
            for (int i = 0; i < solarChoices.Length; i++)
            {
                solarChoices[i].gameObject.SetActive(false);
                solarChoices[4].gameObject.SetActive(true);
            }

            solarChoices[4].GetComponent<Animation>().Play("SuccessPop");
        }
    }

    public void _LunarOrSolar(int index)
    {
        PressSFX();

        nextButton.gameObject.SetActive(true);

        moreExplanationButton.gameObject.SetActive(true);

        if (index == 0)
        {
            explanationText.text = lunardialogue[0];

            moreExplanationButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Stages Lunar";

            baruInfo = 1;

            lunarsolarButton[0].GetComponent<Image>().sprite = butSprite[1];
            lunarsolarButton[1].GetComponent<Image>().sprite = butSprite[0];

            for (int i = 0; i < models.Length; i++) // first object
            {
                models[i].SetActive(false);
                models[0].SetActive(true);
            }

        }
        else if (index == 1)
        {
            explanationText.text = solardialogue[0];

            moreExplanationButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Stages Solar";

            baruInfo = 2;
            solarint = 0;

            lunarsolarButton[0].GetComponent<Image>().sprite = butSprite[0];
            lunarsolarButton[1].GetComponent<Image>().sprite = butSprite[1];

            for (int i = 0; i < models.Length; i++) // second object
            {
                models[i].SetActive(false);
                models[1].SetActive(true);
            }

            stagesLunarImage.sprite = lunarSprites[1];
        }
    }

    public void _ContinueInfo()
    {
        PressSFX();

        blueborder.SetActive(false);

        explanationText.text = "";

        moreExplanationButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);

        backButton.SetActive(true);

        for (int i = 0; i < models.Length; i++) // second object
        {
            models[i].SetActive(false);
        }

        if (baruInfo == 1)
        {
            titleText.text = "Stages of Lunar Eclipse";

            for (int i = 0; i < canvas.Length; i++)
            {
                canvas[i].gameObject.SetActive(false);
                canvas[1].gameObject.SetActive(true);
            }
        }
        else if (baruInfo == 2)
        {
            titleText.text = "Stages of Solar Eclipse";

            for (int i = 0; i < canvas.Length; i++)
            {
                canvas[i].gameObject.SetActive(false);
                canvas[2].gameObject.SetActive(true);
            }

            sliderImage.SetActive(false);
        }
    }
    // -------------------------- end of solar and lunar eclipse explanation buttons --------------------------- //

    public void back()
    {
        BackSFX();

        stagesLunarImage.gameObject.SetActive(false);

        stagesLunarImage.transform.GetChild(0).gameObject.SetActive(false);
        stagesLunarImage.transform.GetChild(1).gameObject.SetActive(false);

        backButton.SetActive(false);

        explanationText.text = dialogue[0];

        moreExplanationButton.gameObject.SetActive(false);

        titleText.text = "Type of Eclipse";
        quizObject.SetActive(false);
        sliderImage.SetActive(true);

        for (int i = 0; i < models.Length; i++) // second object
        {
            models[i].SetActive(false);
        }

        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].gameObject.SetActive(false);
            canvas[0].gameObject.SetActive(true);
        }

        for (int i = 0; i < Objs.Length; i++)
        {
            Objs[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < lunarbuttons.Length; i++)
        {
            lunarbuttons[i].GetComponent<Image>().sprite = butSprite[0];
        }

        lunarsolarButton[0].GetComponent<Image>().sprite = butSprite[0];
        lunarsolarButton[1].GetComponent<Image>().sprite = butSprite[0];
    }

    public void NextButton()
    {
        PressSFX();

        if (baruInfo == 1)
        {
            explanationText.text = lunardialogue[1];
        }
        else if (baruInfo == 2)
        {
            if (solarint == 0)
            {
                explanationText.text = solardialogue[1];
            }
            else if (solarint == 1)
            {
                explanationText.text = solardialogue[2];
            }
            else if (solarint == 2)
            {
                return;
            }

            solarint += 1;
        }
    }

    public void MoreNext()
    {
        PressSFX();

        if (cur[0] == 0)
        {
            moreExplanationButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Solar Eclipse";

            titleText.text = "Stages of Lunar Eclipse";
        }
        else if (cur[0] == 1)
        {
            blueborder.SetActive(false);
        }
    }

    public void MoreInfo(int index)
    {
        PressSFX();

        if (index == 0)
        {
            popup.SetActive(true);
            popup.GetComponent<Animation>().Play("SuccessPop");

            popup.transform.GetChild(0).gameObject.SetActive(true);
            popup.transform.GetChild(1).gameObject.SetActive(false);

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
    // -------------- eclipse model ------------------- //
    public void OpenEclipseInfo()
    {
        GameObject go = EventSystem.current.currentSelectedGameObject;

        go.transform.parent.GetChild(1).gameObject.SetActive(true);
    }

    public void CloseEclipse()
    {
        GameObject go = EventSystem.current.currentSelectedGameObject;

        go.transform.parent.gameObject.SetActive(false);
    }

    // ---------------- end eclipse model ------------------- //

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
    // -------------------------- coroutines -------------------------- //
    IEnumerator Delay()
    {
        slider.GetComponent<Animation>().Play("HideSlide Anim");

        yield return new WaitForSeconds(.5f);

        sliderBut.SetActive(true);
    }
    // ---------------------------- end of coroutines ----------------------- //

    // ----------------------- generic button functions --------------------- //
    public void BackToMenu()
    {
        BackSFX();

        SceneManager.LoadScene("Menu");
    }

    public void ToQuiz()
    {
        PressSFX();

        SceneManager.LoadScene("Y6 - Eclipse Quiz");
    }
    // ------------------- end of generic button functions ------------------- //

    // ----------------------------- SFX -------------------------- //
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
    // ------------------------ end of SFX ---------------------------------------- //
}
