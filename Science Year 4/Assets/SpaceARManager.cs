using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SpaceARManager : MonoBehaviour
{
    [SerializeField] private string[] dialogue, subtopicString;
    [SerializeField] private TextMeshProUGUI subtopicText, dialogueText;

    [SerializeField] private GameObject[] triangleObjects;
    [SerializeField] private GameObject squareObject, rectangleObject;

    [SerializeField] private Sprite[] buttonSprite;

    [SerializeField] private Image showImage;

    [SerializeField] private Button[] _lineButton, triangleButtons;
    [SerializeField] private Button nextBtn, prevBtn;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    int cur;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        showImage.gameObject.SetActive(false);
        subtopicText.transform.parent.gameObject.SetActive(false);
        squareObject.SetActive(false);
        rectangleObject.SetActive(false);

        for (int i = 0; i < triangleButtons.Length; i++)
        {
            triangleButtons[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < triangleObjects.Length; i++)
        {
            triangleObjects[i].SetActive(false);
        }

        dialogueText.enabled = false;

        dialogue = new string[4];
        dialogue[0] = "These lines are called parallel lines because they will not intersect of meet even if extended."; // parallel
        dialogue[1] = "These lines intersect and form an upright angle. Hence, they are called perpendicular lines."; // tahu dah kan?
        dialogue[2] = "Protractor is used to measure angles and the unit for angles is degree(°)";
        dialogue[3] = "Example: 50° is read as 50 degrees, 180° is read as 180 degrees";
    }

    public void _Next()
    {
        PressSFX();

        if (cur == 0)
        {
            prevBtn.gameObject.SetActive(true);
            showImage.gameObject.SetActive(true);

            _lineButton[0].gameObject.SetActive(false);
            _lineButton[0].GetComponent<Image>().sprite = buttonSprite[0];

            _lineButton[1].gameObject.SetActive(false);
            _lineButton[1].GetComponent<Image>().sprite = buttonSprite[0];


            dialogueText.enabled = true;
            dialogueText.text = dialogue[2].ToString();
        }
        else if (cur == 1)
        {
            dialogueText.text = dialogue[3].ToString();
        }
        else if (cur == 2)
        {
            showImage.gameObject.SetActive(false);

            subtopicText.transform.parent.gameObject.SetActive(true);
            subtopicText.text = "Triangle";

            for (int i = 0; i < triangleButtons.Length; i++)
            {
                triangleButtons[i].gameObject.SetActive(true);
                triangleButtons[i].GetComponent<Image>().sprite = buttonSprite[0];
            }

            dialogueText.transform.parent.GetComponent<Image>().enabled = false;
            dialogueText.enabled = false;
        }
        else if (cur == 3)
        {
            subtopicText.text = "Square";

            for (int i = 0; i < triangleObjects.Length; i++)
            {
                triangleObjects[i].SetActive(false);
            }

            for (int i = 0; i < triangleButtons.Length; i++)
            {
                triangleButtons[i].gameObject.SetActive(false);
                triangleButtons[i].GetComponent<Image>().sprite = buttonSprite[0];
            }

            squareObject.SetActive(true);
        }
        else if (cur == 4)
        {
            subtopicText.text = "Rectangle";

            squareObject.SetActive(false);
            rectangleObject.SetActive(true);

            nextBtn.gameObject.SetActive(false);
        }

        cur += 1;
    }

    public void _Previous()
    {
        BackSFX();

        if (cur == 5)
        {
            subtopicText.text = "Square";

            rectangleObject.SetActive(false);
            squareObject.SetActive(true);

            nextBtn.gameObject.SetActive(true);
        }
        else if (cur == 4)
        {
            subtopicText.text = "Triangle";

            for (int i = 0; i < triangleObjects.Length; i++)
            {
                triangleObjects[i].SetActive(false);
            }

            for (int i = 0; i < triangleButtons.Length; i++)
            {
                triangleButtons[i].gameObject.SetActive(true);
            }
        }
        else if (cur == 3)
        {
            showImage.gameObject.SetActive(true);

            subtopicText.transform.parent.gameObject.SetActive(false);

            for (int i = 0; i < triangleButtons.Length; i++)
            {
                triangleButtons[i].gameObject.SetActive(false);
            }

            dialogueText.transform.parent.GetComponent<Image>().enabled = true;
            dialogueText.enabled = true;

            dialogueText.text = dialogue[3].ToString();
        }
        else if (cur == 2)
        {
            dialogueText.text = dialogue[2].ToString();
        }
        else if (cur == 1)
        {
            prevBtn.gameObject.SetActive(false);
            showImage.gameObject.SetActive(false);

            _lineButton[0].gameObject.SetActive(true);
            _lineButton[1].gameObject.SetActive(true);

            dialogueText.enabled = false;
        }

        cur -= 1;
    }

    public void _Lines(int index)
    {
        PressSFX();

        if (index == 0)
        {
            dialogueText.enabled = true;
            dialogueText.text = dialogue[0].ToString();

            _lineButton[0].GetComponent<Image>().sprite = buttonSprite[1];
            _lineButton[1].GetComponent<Image>().sprite = buttonSprite[0];
        }
        else if (index == 1)
        {
            dialogueText.enabled = true;
            dialogueText.text = dialogue[1].ToString();

            _lineButton[0].GetComponent<Image>().sprite = buttonSprite[0];
            _lineButton[1].GetComponent<Image>().sprite = buttonSprite[1];
        }
    }

    public void _TriangleButtons(int index)
    {
        PressSFX();

        if (index == 0)
        {
            for (int i = 0; i < triangleObjects.Length; i++)
            {
                triangleObjects[i].SetActive(false);
                triangleObjects[0].SetActive(true);
            }

            triangleButtons[0].GetComponent<Image>().sprite = buttonSprite[1];
            triangleButtons[1].GetComponent<Image>().sprite = buttonSprite[0];
            triangleButtons[2].GetComponent<Image>().sprite = buttonSprite[0];
        }
        else if (index == 1)
        {
            for (int i = 0; i < triangleObjects.Length; i++)
            {
                triangleObjects[i].SetActive(false);
                triangleObjects[1].SetActive(true);
            }

            triangleButtons[0].GetComponent<Image>().sprite = buttonSprite[0];
            triangleButtons[1].GetComponent<Image>().sprite = buttonSprite[1];
            triangleButtons[2].GetComponent<Image>().sprite = buttonSprite[0];
        }
        else if (index == 2)
        {
            for (int i = 0; i < triangleObjects.Length; i++)
            {
                triangleObjects[i].SetActive(false);
                triangleObjects[2].SetActive(true);
            }

            triangleButtons[0].GetComponent<Image>().sprite = buttonSprite[0];
            triangleButtons[1].GetComponent<Image>().sprite = buttonSprite[0];
            triangleButtons[2].GetComponent<Image>().sprite = buttonSprite[1];
        }
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

    //void Update()
    //{
    //    // 3d model manipulation stuff goes here i suppose
    //}
}
