using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DragShadow : MonoBehaviour
{
    [SerializeField] private Sprite[] objectSprite, shadowSprite, shadowTake, joyPadSprite;

    [SerializeField] private Canvas canvas;
    [SerializeField] private CanvasGroup canvasGroup;

    [SerializeField] private RectTransform rectTransform;

    [SerializeField] private Image shadowImage, theOtherShadowImage, shadowTakeImage;

    [SerializeField] private GameObject[] dashedLines;
    [SerializeField] private GameObject introPop, endPop;
    [SerializeField] private GameObject contButton, theOtherButton;
    [SerializeField] private GameObject secondItem, thirdItems, yayPop;

    [SerializeField] private Button[] joypadButton;

    bool[] round;

    [SerializeField] private AudioClip[] sound;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private TextMeshProUGUI levelText;

    private void Awake()
    {
        thirdItems.SetActive(false);
        levelText.enabled = false;

        audioSource = GetComponent<AudioSource>();

        introPop.SetActive(true);
        introPop.GetComponent<Animation>().Play("SuccessPop");

        endPop.SetActive(false);
        yayPop.SetActive(false);

        contButton.SetActive(false);
        theOtherButton.SetActive(false);

        round = new bool[3];
        round[0] = true;

        shadowTakeImage.sprite = shadowTake[0];

        for (int i = 0; i < dashedLines.Length; i++)
        {
            dashedLines[i].SetActive(false);
            dashedLines[0].SetActive(true);
        }

        canvasGroup = rectTransform.gameObject.GetComponent<CanvasGroup>();
    }

    public void Up()
    {
        if (round[0])
        {
            if (rectTransform.anchoredPosition.y >= -40f)
            {
                return;
            }

            rectTransform.anchoredPosition += new Vector2(0, 40);

            shadowImage.rectTransform.sizeDelta -= new Vector2(20, 20);
            theOtherShadowImage.rectTransform.sizeDelta -= new Vector2(20, 40);
        }
        else if (round[1])
        {
            if (rectTransform.anchoredPosition.x >= 76)
                return;

            if (rectTransform.anchoredPosition.x == 0)
            {
                rectTransform.anchoredPosition += new Vector2(76, 0);

                shadowImage.rectTransform.anchoredPosition += new Vector2(100, 0);
                //shadowImage.rectTransform.sizeDelta = new Vector2(100, 120);

                theOtherShadowImage.rectTransform.anchoredPosition += new Vector2(100, 0);
                theOtherShadowImage.sprite = shadowSprite[1];
            }
            else if (rectTransform.anchoredPosition.x == -76)
            {
                rectTransform.anchoredPosition += new Vector2(76, 0);

                shadowImage.rectTransform.anchoredPosition += new Vector2(100, 0);
                theOtherShadowImage.rectTransform.anchoredPosition += new Vector2(100, 0);
                theOtherShadowImage.sprite = shadowSprite[3];
            }
        }
        else if (round[2])
        {
            shadowTakeImage.sprite = shadowTake[1];

            shadowImage.rectTransform.anchoredPosition = new Vector2(-96, 0);

            theOtherShadowImage.rectTransform.anchoredPosition = new Vector2(-96, -229);
            theOtherShadowImage.sprite = shadowSprite[4];
        }
    }

    public void Down()
    {
        if (round[0])
        {
            if (rectTransform.anchoredPosition.y <= -160f)
            {
                return;
            }

            rectTransform.anchoredPosition -= new Vector2(0, 40);

            shadowImage.rectTransform.sizeDelta += new Vector2(20, 20);
            theOtherShadowImage.rectTransform.sizeDelta += new Vector2(20, 40);
        }
        else if (round[1])
        {
            if (rectTransform.anchoredPosition.x <= -76)
                return;

            if (rectTransform.anchoredPosition.x == 0)
            {
                rectTransform.anchoredPosition -= new Vector2(76, 0);

                shadowImage.rectTransform.anchoredPosition -= new Vector2(100, 0);
                theOtherShadowImage.rectTransform.anchoredPosition -= new Vector2(100, 0);
                theOtherShadowImage.sprite = shadowSprite[2];
            }
            else if (rectTransform.anchoredPosition.x == 76)
            {
                rectTransform.anchoredPosition -= new Vector2(76, 0);

                shadowImage.rectTransform.anchoredPosition -= new Vector2(100, 0);
                theOtherShadowImage.rectTransform.anchoredPosition -= new Vector2(100, 0);
                theOtherShadowImage.sprite = shadowSprite[3];
            }
        }
        else if (round[2])
        {
            shadowTakeImage.sprite = shadowTake[2];

            shadowImage.rectTransform.anchoredPosition = new Vector2(96, 0);

            theOtherShadowImage.rectTransform.anchoredPosition = new Vector2(96, -229);
            theOtherShadowImage.sprite = shadowSprite[5];
        }
    }

    public void Center()
    {
        if (round[2])
        {
            shadowTakeImage.sprite = shadowTake[0];

            shadowImage.rectTransform.anchoredPosition = new Vector2(0, 0);

            theOtherShadowImage.rectTransform.anchoredPosition = new Vector2(0, -229);
            theOtherShadowImage.sprite = shadowSprite[3];
        }
    }

    public void Confirm()
    {
        if (round[0])
        {
            if (rectTransform.anchoredPosition.y == -80f)
            {
                yayPop.SetActive(true);
                yayPop.GetComponent<Animation>().Play("SuccessPop");

                CorrectSound();
            }
            else if (rectTransform.anchoredPosition.y != -80f)
            {
                IncorrectSound();
            }

            //levelText.text = "Level 2";
        }
        else if (round[1])
        {
            if (rectTransform.anchoredPosition.x == 76)
            {
                yayPop.SetActive(true);
                yayPop.GetComponent<Animation>().Play("SuccessPop");

                CorrectSound();
            }
            else if (rectTransform.anchoredPosition.x != 76)
            {
                IncorrectSound();
            }

            //levelText.text = "Level 2";
        }
        else if (round[2])
        {
            if (shadowImage.rectTransform.anchoredPosition == new Vector2(-96, 0))
            {
                endPop.SetActive(true);
                endPop.GetComponent<Animation>().Play("SuccessPop");

                CorrectSound();
                //levelText.text = "";
            }
            else if (shadowImage.rectTransform.anchoredPosition != new Vector2(-96, 0))
            {
                IncorrectSound();
            }
        }
    }

    public void Play()
    {
        introPop.SetActive(false);
        levelText.enabled = true;
        levelText.text = "Level 1";
    }

    public void Restart()
    {
        SceneManager.LoadScene("Y5 - Shadow Game");
    }

    public void BackToAR()
    {
        SceneManager.LoadScene("Y5 - Earth - AR"); // back to AR
    }

    public void Continue()
    {
        if (round[0])
        {
            round[0] = false;
            round[1] = true;

            rectTransform.gameObject.GetComponent<Image>().sprite = objectSprite[0];
            rectTransform.anchoredPosition = new Vector2(0, -36);

            yayPop.SetActive(false);

            theOtherShadowImage.rectTransform.sizeDelta = new Vector2(200, 110);

            shadowImage.sprite = shadowSprite[0];
            shadowImage.rectTransform.sizeDelta = new Vector2(100, 120);


            for (int i = 0; i < dashedLines.Length; i++)
            {
                dashedLines[i].SetActive(false);
                dashedLines[1].SetActive(true);
            }

            levelText.text = "Level 2";

            joypadButton[0].GetComponent<Image>().sprite = joyPadSprite[2];
            joypadButton[1].GetComponent<Image>().sprite = joyPadSprite[1];
        }
        else if (round[1])
        {
            round[1] = false;
            round[2] = true;

            for (int i = 0; i < dashedLines.Length; i++)
            {
                dashedLines[i].SetActive(false);
                dashedLines[2].SetActive(true);
            }

            yayPop.SetActive(false);
            theOtherButton.SetActive(true);

            shadowImage.rectTransform.sizeDelta = new Vector2(100, 100);
            shadowImage.rectTransform.anchoredPosition = new Vector2(0, 0);

            rectTransform.anchoredPosition = new Vector2(0, -70);

            theOtherShadowImage.rectTransform.sizeDelta = new Vector2(200, 145);
            theOtherShadowImage.rectTransform.anchoredPosition = new Vector2(0, -229);
            theOtherShadowImage.sprite = shadowSprite[3];

            levelText.text = "Level 3";

            thirdItems.SetActive(true);
            secondItem.SetActive(false);
        }
    }

    void CorrectSound()
    {
        audioSource.clip = sound[0];
        audioSource.Play();
    }

    void IncorrectSound()
    {
        audioSource.clip = sound[1];
        audioSource.Play();
    }
}
