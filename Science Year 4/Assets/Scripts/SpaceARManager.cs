using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SpaceARManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI descriptionText, subtopicText;

    [SerializeField] private Sprite[] butSprite;

    [SerializeField] private GameObject[] buttons, objects, triButtons, prevNextBtn;
    [SerializeField] private GameObject exampleImage, moreInfo;

    [SerializeField] private string[] moreInfoDialogue;
    [SerializeField] private string[] dialogue;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    int cur;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        descriptionText.text = "";

        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(false);
        }

        for (int i = 0; i < triButtons.Length; i++)
        {
            triButtons[i].SetActive(false);
        }

        subtopicText.transform.parent.gameObject.SetActive(false);
        exampleImage.SetActive(false);
        moreInfo.SetActive(false);
        prevNextBtn[1].SetActive(false);

        moreInfoDialogue = new string[14];

        moreInfoDialogue[0] = "One of the angles is upright angle = 90 degrees";
        moreInfoDialogue[1] = "Two of the angles are perpendicular";
        moreInfoDialogue[2] = "The length of all three sides is the same";
        moreInfoDialogue[3] = "Each angle is 60 degrees";
        moreInfoDialogue[4] = "Two of the sides are of the same length";
        moreInfoDialogue[5] = "Two of the angles are of the same value";
        moreInfoDialogue[6] = "The two opposite sides are parallel";
        moreInfoDialogue[7] = "Has 4 right angles";
        moreInfoDialogue[8] = "The length of all 4 sides is the same";
        moreInfoDialogue[9] = "The two adjacent sides are perpendicular";
        moreInfoDialogue[10] = "Has 4 right angles";
        moreInfoDialogue[11] = "Opposite sides are of the same length";
        moreInfoDialogue[12] = "Two adjacent sides are perpendicular";
        moreInfoDialogue[13] = "Two opposite sides are parallel";
    }

    public void _PerpenOrParrallel(int index)
    {
        if (index == 0)
        {
            descriptionText.text = dialogue[0];

            buttons[0].GetComponent<Image>().sprite = butSprite[1];
            buttons[1].GetComponent<Image>().sprite = butSprite[0];
        }
        else if (index == 1)
        {
            descriptionText.text = dialogue[1];

            buttons[0].GetComponent<Image>().sprite = butSprite[0];
            buttons[1].GetComponent<Image>().sprite = butSprite[1];
        }
    }

    public void _Next()
    {
        PressSFX();

        if (cur == 0)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetActive(false);
                buttons[i].GetComponent<Image>().sprite = butSprite[0];
            }

            descriptionText.text = dialogue[2];

            prevNextBtn[1].SetActive(true);
            exampleImage.SetActive(true);
        }
        else if (cur == 1)
        {
            descriptionText.text = dialogue[3];
        }
        else if (cur == 2)
        {
            subtopicText.transform.parent.gameObject.SetActive(true);
            subtopicText.text = "Triangle";


            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(false);
            }

            for (int i = 0; i < triButtons.Length; i++)
            {
                triButtons[i].SetActive(true);
                triButtons[i].GetComponent<Image>().sprite = butSprite[0];
            }

            descriptionText.transform.parent.gameObject.SetActive(false);
            exampleImage.SetActive(false);
        }
        else if (cur == 3)
        {
            subtopicText.transform.parent.gameObject.SetActive(true);
            subtopicText.text = "Square";

            for (int i = 0; i < triButtons.Length; i++)
            {
                triButtons[i].SetActive(false);
                triButtons[i].GetComponent<Image>().sprite = butSprite[0];
            }

            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(false);
                objects[3].SetActive(true);
            }
        }
        else if (cur == 4)
        {
            subtopicText.transform.parent.gameObject.SetActive(true);
            subtopicText.text = "Rectangle";

            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(false);
                objects[4].SetActive(true);
            }

            prevNextBtn[0].SetActive(false);
        }

        cur += 1;
    }

    public void _Previous()
    {
        BackSFX();

        if (cur == 5)
        {
            subtopicText.transform.parent.gameObject.SetActive(true);
            subtopicText.text = "Square";

            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(false);
                objects[3].SetActive(true);
            }

            prevNextBtn[0].SetActive(true);
        }
        else if (cur == 4)
        {
            subtopicText.transform.parent.gameObject.SetActive(true);
            subtopicText.text = "Triangle";

            for (int i = 0; i < triButtons.Length; i++)
            {
                triButtons[i].SetActive(true);
            }

            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(false);
            }
        }
        else if (cur == 3)
        {
            subtopicText.transform.parent.gameObject.SetActive(false);

            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(false);
            }

            for (int i = 0; i < triButtons.Length; i++)
            {
                triButtons[i].SetActive(false);
            }

            exampleImage.SetActive(true);
            descriptionText.transform.parent.gameObject.SetActive(true);
            descriptionText.text = dialogue[3];
        }
        else if (cur == 2)
        {
            descriptionText.text = dialogue[2];
        }
        else if (cur == 1)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetActive(true);
            }

            descriptionText.text = "";

            prevNextBtn[1].SetActive(false);
            exampleImage.SetActive(false);
        }

        cur -= 1;
    }

    public void _Lines(int index)
    {
        PressSFX();
        Debug.Log("werr");
    }

    public void _TriangleButtons(int index)
    {
        PressSFX();

        for (int i = 0; i < triButtons.Length; i++)
        {
            triButtons[i].GetComponent<Image>().sprite = butSprite[0];
            triButtons[index].GetComponent<Image>().sprite = butSprite[1];
        }

        if (index == 0)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(false);
                objects[0].SetActive(true);
            }
        }
        else if (index == 1)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(false);
                objects[1].SetActive(true);
            }
        }
        else if (index == 2)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(false);
                objects[2].SetActive(true);
            }
        }
    }

    public void _PopInfo(int index)
    {
        moreInfo.SetActive(true);
        moreInfo.GetComponent<Animation>().Play("SuccessPop");

        if (index == 0)
        {
            moreInfo.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = moreInfoDialogue[0];
        }
        else if (index == 1)
        {
            moreInfo.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = moreInfoDialogue[1];
        }
        else if (index == 2)
        {
            moreInfo.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = moreInfoDialogue[2];
        }
        else if (index == 3)
        {
            moreInfo.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = moreInfoDialogue[3];
        }
        else if (index == 4)
        {
            moreInfo.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = moreInfoDialogue[4];
        }
        else if (index == 5)
        {
            moreInfo.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = moreInfoDialogue[5];
        }
        else if (index == 6)
        {
            moreInfo.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = moreInfoDialogue[6];
        }
        else if (index == 7)
        {
            moreInfo.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = moreInfoDialogue[7];
        }
        else if (index == 8)
        {
            moreInfo.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = moreInfoDialogue[8];
        }
        else if (index == 9)
        {
            moreInfo.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = moreInfoDialogue[9];
        }
        else if (index == 10)
        {
            moreInfo.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = moreInfoDialogue[10];
        }
        else if (index == 11)
        {
            moreInfo.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = moreInfoDialogue[11];
        }
        else if (index == 12)
        {
            moreInfo.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = moreInfoDialogue[12];
        }
        else if (index == 13)
        {
            moreInfo.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = moreInfoDialogue[13];
        }
    }

    public void _Close()
    {
        moreInfo.SetActive(false);
    }

    public void _Menu()
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
}
