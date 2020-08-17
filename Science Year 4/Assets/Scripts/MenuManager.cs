using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private Canvas[] canvas;
    [SerializeField] GameObject arOrFunFactBackground;

    int l;

    [SerializeField] private string[] description;

    [SerializeField] private TextMeshProUGUI descriptionText;

    [SerializeField] private GameObject[] chapter;
    [SerializeField] private GameObject[] itemsInBackground;
    [SerializeField] private GameObject blocker;
    [SerializeField] private GameObject bar;

    public TMP_Dropdown dropdown;

    void Start()
    {
        bar.SetActive(false);

        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].enabled = false;
        }

        for (int i = 0; i < chapter.Length; i++)
        {
            chapter[i].SetActive(false);
            chapter[0].SetActive(true);
        }

        arOrFunFactBackground.SetActive(false);
        blocker.SetActive(false);
    }

    public void ToMenu()
    {
        bar.SetActive(true);

        for (int i = 0; i < itemsInBackground.Length; i++)
        {
            itemsInBackground[i].SetActive(false);
        }


        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].enabled = false;
            canvas[0].enabled = true;
        }

        canvas[0].GetComponent<Animation>().Play("Menu Anim");
    }

    public void ToSubject()
    {
        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].enabled = false;
            canvas[0].enabled = true;
        }
    }

    public void ToTopic()
    {
        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].enabled = false;
            canvas[1].enabled = true;
        }

        canvas[1].GetComponent<Animation>().Play("Year4 Anim");
    }

    public void HandleInputData()
    {
        if (dropdown.value == 1)
        {
            for (int i = 0; i < chapter.Length; i++)
            {
                chapter[i].SetActive(false);
                chapter[0].SetActive(true);
            }

            canvas[1].GetComponent<Animation>().Play("Year4 Anim");
        }
        else if (dropdown.value == 2)
        {
            for (int i = 0; i < chapter.Length; i++)
            {
                chapter[i].SetActive(false);
                chapter[1].SetActive(true);
            }

            canvas[1].GetComponent<Animation>().Play("Year5 Anim");
        }
    }

    public void ChapterSelection(int level)
    {
        blocker.SetActive(true);

        l = level;

        if (l == 1)
        {
            descriptionText.text = description[0].ToString();
        }
        else if (l == 2)
        {
            descriptionText.text = description[1].ToString();
        }
        else if (l == 3)
        {
            descriptionText.text = description[2].ToString();
        }
        else if (l == 4)
        {
            descriptionText.text = description[3].ToString();
        }
        else if (l == 5)
        {
            descriptionText.text = description[4].ToString();
        }

        arOrFunFactBackground.SetActive(true);
        arOrFunFactBackground.GetComponent<Animation>().Play("Menu_ConfirmPop");
    }

    public void ChapterYearFiveSelection(int level)
    {
        l = level;

        if (l == 1)
        {
            descriptionText.text = description[5].ToString();
        }
        //else if (l == 2)
        //{
        //    descriptionText.text = description[1].ToString();
        //}
        //else if (l == 3)
        //{
        //    descriptionText.text = description[2].ToString();
        //}
        //else if (l == 4)
        //{
        //    descriptionText.text = description[3].ToString();
        //}
        //else if (l == 5)
        //{
        //    descriptionText.text = description[4].ToString();
        //}

        arOrFunFactBackground.SetActive(true);
        arOrFunFactBackground.GetComponent<Animation>().Play("Menu_ConfirmPop");
    }

    public void BackToTopic()
    {
        arOrFunFactBackground.SetActive(false);
        blocker.SetActive(false);
    }

    public void YesAR()
    {
        if (l == 1)
        {
            // chapter 1
            SceneManager.LoadScene("Y5 - C4 AR");
        }
        else if (l == 2)
        {
            // chapter 2
        }
        else if (l == 3)
        {
            // chpater 3
        }
        else if (l == 4)
        {
            SceneManager.LoadScene("AR-Aspect"); // animals
        }
        else if (l == 5)
        {
            SceneManager.LoadScene("Plants-AR"); // plants
        }
    }

    public void YesFuncFact()
    {
        if (l == 1)
        {
            // chapter 1
        }
        else if (l == 2)
        {
            // chapter 2
        }
        else if (l == 3)
        {
            // chpater 3
        }
        else if (l == 4)
        {
            SceneManager.LoadScene("Fun-Facts"); // animals
        }
    }
}
