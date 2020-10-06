using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EarthAR : MonoBehaviour
{
    //[SerializeField] private TextMeshProUGUI firstText, secondText, thirdText, forthText;
    [SerializeField] private TextMeshProUGUI topicText;
    //[SerializeField] private 
    [SerializeField] private Sprite[] sprite;

    [SerializeField] private Button[] button;

    [SerializeField] private GameObject[] infoGroup, infotextGroup;
    [SerializeField] private GameObject nextButton, prevButton, quizButton;

    bool isNext;

    void Start()
    {
        prevButton.SetActive(false);
        quizButton.SetActive(false);

        for (int i = 0; i < infoGroup.Length; i++)
        {
            infoGroup[i].SetActive(false);
        }

        for (int i = 0; i < infotextGroup.Length; i++)
        {
            infotextGroup[i].SetActive(false);
        }

        topicText.text = "The Movement of the Earth";
    }

    void Update()
    {

    }

    public void _RotationEarth()
    {
        button[0].GetComponent<Image>().sprite = sprite[1];
        button[1].GetComponent<Image>().sprite = sprite[0];

        if (!isNext)
        {
            for (int i = 0; i < infoGroup.Length; i++)
            {
                infoGroup[i].SetActive(false);
                infoGroup[0].SetActive(true);
            }

            for (int i = 0; i < infotextGroup.Length; i++)
            {
                infotextGroup[i].SetActive(false);
                infotextGroup[0].SetActive(true);
            }

            foreach (Transform s in infotextGroup[1].transform)
            {
                s.gameObject.SetActive(false);
            }

            foreach (Transform s in infoGroup[1].transform)
            {
                s.transform.GetChild(0).GetComponent<Button>().interactable = true;
            }
        }
        else if (isNext)
        {
            for (int i = 0; i < infoGroup.Length; i++)
            {
                infoGroup[i].SetActive(false);
                infoGroup[2].SetActive(true);
            }

            for (int i = 0; i < infotextGroup.Length; i++)
            {
                infotextGroup[i].SetActive(false);
                infotextGroup[2].SetActive(true);
            }

            foreach (Transform s in infotextGroup[3].transform)
            {
                s.gameObject.SetActive(false);
            }

            foreach (Transform s in infoGroup[3].transform)
            {
                s.transform.GetChild(0).GetComponent<Button>().interactable = true;
            }
        }
    }

    public void _RevolutionGroup()
    {
        button[1].GetComponent<Image>().sprite = sprite[1];
        button[0].GetComponent<Image>().sprite = sprite[0];

        if (!isNext)
        {
            for (int i = 0; i < infoGroup.Length; i++)
            {
                infoGroup[i].SetActive(false);
                infoGroup[1].SetActive(true);
            }

            for (int i = 0; i < infotextGroup.Length; i++)
            {
                infotextGroup[i].SetActive(false);
                infotextGroup[1].SetActive(true);
            }

            foreach (Transform s in infotextGroup[0].transform)
            {
                s.gameObject.SetActive(false);
            }

            foreach (Transform s in infoGroup[0].transform)
            {
                s.transform.GetChild(0).GetComponent<Button>().interactable = true;
            }
        }
        else if (isNext)
        {
            for (int i = 0; i < infoGroup.Length; i++)
            {
                infoGroup[i].SetActive(false);
                infoGroup[3].SetActive(true);
            }

            for (int i = 0; i < infotextGroup.Length; i++)
            {
                infotextGroup[i].SetActive(false);
                infotextGroup[3].SetActive(true);
            }

            foreach (Transform s in infotextGroup[2].transform)
            {
                s.gameObject.SetActive(false);
            }

            foreach (Transform s in infoGroup[2].transform)
            {
                s.transform.GetChild(0).GetComponent<Button>().interactable = true;
            }
        }
    }

    public void NextPage()
    {
        isNext = true;

        button[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "The Occurence of Day and Night";
        button[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Position of the Sun & The Length of Shadow";

        button[0].GetComponent<Image>().sprite = sprite[0];
        button[1].GetComponent<Image>().sprite = sprite[0];

        for (int i = 0; i < infoGroup.Length; i++)
        {
            infoGroup[i].SetActive(false);
        }

        foreach (Transform s in infotextGroup[0].transform)
        {
            s.gameObject.SetActive(false);
        }

        foreach (Transform s in infotextGroup[1].transform)
        {
            s.gameObject.SetActive(false);
        }

        prevButton.SetActive(true);
        nextButton.SetActive(false);
        quizButton.SetActive(true);

        topicText.text = "Phenomenon of the Rotation of Earth";
    }

    public void PrevPage()
    {
        isNext = false;

        button[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Rotation of the Earth";
        button[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Revolution of the Earth";

        button[0].GetComponent<Image>().sprite = sprite[0];
        button[1].GetComponent<Image>().sprite = sprite[0];

        for (int i = 0; i < infoGroup.Length; i++)
        {
            infoGroup[i].SetActive(false);
        }

        foreach (Transform s in infotextGroup[2].transform)
        {
            s.gameObject.SetActive(false);
        }

        foreach (Transform s in infotextGroup[3].transform)
        {
            s.gameObject.SetActive(false);
        }

        prevButton.SetActive(false);
        nextButton.SetActive(true);
        quizButton.SetActive(false);

        topicText.text = "The Movement of the Earth";
    }

    public void ShowInfo(int index)
    {
        if (index == 0)
        {
            infotextGroup[0].transform.GetChild(0).gameObject.SetActive(true);
            infotextGroup[0].transform.GetChild(0).GetComponent<Animation>().Play("GameOverPop");

            infotextGroup[0].transform.GetChild(1).gameObject.SetActive(false);

            foreach (Transform s in infoGroup[0].transform)
            {
                s.transform.GetChild(0).GetComponent<Button>().interactable = false;
            }
        }
        else if (index == 1)
        {
            infotextGroup[0].transform.GetChild(1).gameObject.SetActive(true);
            infotextGroup[0].transform.GetChild(1).GetComponent<Animation>().Play("GameOverPop");

            infotextGroup[0].transform.GetChild(0).gameObject.SetActive(false);

            foreach (Transform s in infoGroup[0].transform)
            {
                s.transform.GetChild(0).GetComponent<Button>().interactable = false;
            }
        }
        //--
        if (index == 2)
        {
            infotextGroup[1].transform.GetChild(0).gameObject.SetActive(true);
            infotextGroup[1].transform.GetChild(0).GetComponent<Animation>().Play("GameOverPop");

            infotextGroup[1].transform.GetChild(1).gameObject.SetActive(false);

            foreach (Transform s in infoGroup[1].transform)
            {
                s.transform.GetChild(0).GetComponent<Button>().interactable = false;
            }
        }
        else if (index == 3)
        {
            infotextGroup[1].transform.GetChild(1).gameObject.SetActive(true);
            infotextGroup[1].transform.GetChild(1).GetComponent<Animation>().Play("GameOverPop");

            infotextGroup[1].transform.GetChild(0).gameObject.SetActive(false);

            foreach (Transform s in infoGroup[1].transform)
            {
                s.transform.GetChild(0).GetComponent<Button>().interactable = false;
            }
        }
        //--
        if (index == 4)
        {
            infotextGroup[2].transform.GetChild(0).gameObject.SetActive(true);
            infotextGroup[2].transform.GetChild(0).GetComponent<Animation>().Play("GameOverPop");

            infotextGroup[2].transform.GetChild(1).gameObject.SetActive(false);
            infotextGroup[2].transform.GetChild(2).gameObject.SetActive(false);
            infotextGroup[2].transform.GetChild(3).gameObject.SetActive(false);

            foreach (Transform s in infoGroup[2].transform)
            {
                s.transform.GetChild(0).GetComponent<Button>().interactable = false;
            }
        }
        else if (index == 5)
        {
            infotextGroup[2].transform.GetChild(0).gameObject.SetActive(false);
            infotextGroup[2].transform.GetChild(1).gameObject.SetActive(true);
            infotextGroup[2].transform.GetChild(1).GetComponent<Animation>().Play("GameOverPop");

            infotextGroup[2].transform.GetChild(2).gameObject.SetActive(false);
            infotextGroup[2].transform.GetChild(3).gameObject.SetActive(false);

            foreach (Transform s in infoGroup[2].transform)
            {
                s.transform.GetChild(0).GetComponent<Button>().interactable = false;
            }
        }
        else if (index == 6)
        {
            infotextGroup[2].transform.GetChild(0).gameObject.SetActive(false);
            infotextGroup[2].transform.GetChild(1).gameObject.SetActive(false);
            infotextGroup[2].transform.GetChild(2).gameObject.SetActive(true);
            infotextGroup[2].transform.GetChild(2).GetComponent<Animation>().Play("GameOverPop");

            infotextGroup[2].transform.GetChild(3).gameObject.SetActive(false);

            foreach (Transform s in infoGroup[2].transform)
            {
                s.transform.GetChild(0).GetComponent<Button>().interactable = false;
            }
        }
        else if (index == 7)
        {
            infotextGroup[2].transform.GetChild(0).gameObject.SetActive(false);
            infotextGroup[2].transform.GetChild(1).gameObject.SetActive(false);
            infotextGroup[2].transform.GetChild(2).gameObject.SetActive(false);
            infotextGroup[2].transform.GetChild(3).gameObject.SetActive(true);
            infotextGroup[2].transform.GetChild(3).GetComponent<Animation>().Play("GameOverPop");


            foreach (Transform s in infoGroup[2].transform)
            {
                s.transform.GetChild(0).GetComponent<Button>().interactable = false;
            }
        }
        // --
        if (index == 8)
        {
            infotextGroup[3].transform.GetChild(0).gameObject.SetActive(true);
            infotextGroup[3].transform.GetChild(0).GetComponent<Animation>().Play("GameOverPop");

            infotextGroup[3].transform.GetChild(1).gameObject.SetActive(false);
            infotextGroup[3].transform.GetChild(2).gameObject.SetActive(false);

            foreach (Transform s in infoGroup[3].transform)
            {
                s.transform.GetChild(0).GetComponent<Button>().interactable = false;
            }
        }
        else if (index == 9)
        {
            infotextGroup[3].transform.GetChild(0).gameObject.SetActive(false);
            infotextGroup[3].transform.GetChild(1).gameObject.SetActive(true);
            infotextGroup[3].transform.GetChild(1).GetComponent<Animation>().Play("GameOverPop");

            infotextGroup[3].transform.GetChild(2).gameObject.SetActive(false);

            foreach (Transform s in infoGroup[3].transform)
            {
                s.transform.GetChild(0).GetComponent<Button>().interactable = false;
            }
        }
        else if (index == 10)
        {
            infotextGroup[3].transform.GetChild(0).gameObject.SetActive(false);
            infotextGroup[3].transform.GetChild(1).gameObject.SetActive(false);
            infotextGroup[3].transform.GetChild(2).gameObject.SetActive(true);
            infotextGroup[3].transform.GetChild(2).GetComponent<Animation>().Play("GameOverPop");


            foreach (Transform s in infoGroup[3].transform)
            {
                s.transform.GetChild(0).GetComponent<Button>().interactable = false;
            }
        }
    }

    public void CloseMoreInfo(int index)
    {
        if (index == 0)
        {
            foreach (Transform s in infoGroup[0].transform)
            {
                s.transform.GetChild(0).GetComponent<Button>().interactable = true;
            }

            foreach (Transform s in infotextGroup[0].transform)
            {
                s.gameObject.SetActive(false);
            }
        }
        else if (index == 1)
        {
            foreach (Transform s in infoGroup[1].transform)
            {
                s.transform.GetChild(0).GetComponent<Button>().interactable = true;
            }

            foreach (Transform s in infotextGroup[1].transform)
            {
                s.gameObject.SetActive(false);
            }
        }
        else if (index == 2)
        {
            foreach (Transform s in infoGroup[2].transform)
            {
                s.transform.GetChild(0).GetComponent<Button>().interactable = true;
            }

            foreach (Transform s in infotextGroup[2].transform)
            {
                s.gameObject.SetActive(false);
            }
        }
        else if (index == 3)
        {
            foreach (Transform s in infoGroup[3].transform)
            {
                s.transform.GetChild(0).GetComponent<Button>().interactable = true;
            }

            foreach (Transform s in infotextGroup[3].transform)
            {
                s.gameObject.SetActive(false);
            }
        }
    }

    public void ToQuiz()
    {
        SceneManager.LoadScene(""); // to quiz
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(""); // to menu
    }
}
