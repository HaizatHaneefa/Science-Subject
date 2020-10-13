using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    BoolHolder boolHolderManager;

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
    int dropDownValue;
   
    void Awake()
    {
        boolHolderManager = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<BoolHolder>();

        blocker.SetActive(false);

        if (boolHolderManager.menuChapter[0])
        {
            for (int i = 0; i < itemsInBackground.Length; i++)
            {
                itemsInBackground[i].SetActive(false);
            }

            for (int i = 0; i < canvas.Length; i++)
            {
                canvas[i].enabled = false;
                canvas[1].enabled = true;
            }

            bar.SetActive(true);
            //canvas[1].GetComponent<Animation>().Play("Year4 Anim");
            arOrFunFactBackground.SetActive(false);

            if (boolHolderManager.menuChapter[1])
            {
                for (int i = 0; i < chapter.Length; i++)
                {
                    chapter[i].SetActive(false);
                    chapter[0].SetActive(true);
                }
            }
            else if (boolHolderManager.menuChapter[2])
            {
                for (int i = 0; i < chapter.Length; i++)
                {
                    chapter[i].SetActive(false);
                    chapter[1].SetActive(true);
                }
            }
            if (boolHolderManager.menuChapter[3])
            {
                for (int i = 0; i < chapter.Length; i++)
                {
                    chapter[i].SetActive(false);
                    chapter[2].SetActive(true);
                }
            }

            dropdown.value = boolHolderManager.dropdownValue;
        }
        else if (!boolHolderManager.menuChapter[0])
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

        //boolHolderManager.isOkay = true;
    }

    public void ToMenu()
    {
        boolHolderManager.menuChapter[0] = true;

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
        else if (dropdown.value == 3)
        {
            for (int i = 0; i < chapter.Length; i++)
            {
                chapter[i].SetActive(false);
                chapter[2].SetActive(true);
            }

            canvas[1].GetComponent<Animation>().Play("Year6 Anim");
        }
    }

    public void ChapterSelection(int level)
    {
        blocker.SetActive(true);

        l = level;

        if (l == 1) // anatomy
        {
            descriptionText.text = description[0].ToString();
        }
        else if (l == 2) // y4 animal
        {
            descriptionText.text = description[1].ToString();
        }
        else if (l == 3) // y4 plants
        {
            descriptionText.text = description[2].ToString();
        }
        else if (l == 4) // y5 animals
        {
            descriptionText.text = description[3].ToString();
        }
        else if (l == 5) // y5 plants
        {
            descriptionText.text = description[4].ToString();
        }
        else if (l == 6) // y5 earth
        {
            descriptionText.text = description[5].ToString();
        }
        else if (l == 7) // y6 speed
        {
            descriptionText.text = description[6].ToString();
        }

        arOrFunFactBackground.SetActive(true);
        arOrFunFactBackground.GetComponent<Animation>().Play("Menu_ConfirmPop");

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
            // anatomy
            //SceneManager.LoadScene("Y5 - C4 AR");

            //for (int i = 0; i < chapter.Length; i++)
            //{
            //    chapter[i].SetActive(false);
            //    chapter[0].SetActive(false);
            //}
            boolHolderManager.menuChapter[1] = true;
        }
        else if (l == 2)
        {
            // animal year 4
            SceneManager.LoadScene("AR-Aspect");

            //for (int i = 0; i < chapter.Length; i++)
            //{
            //    chapter[i].SetActive(false);
            //    chapter[0].SetActive(false);
            //}
            boolHolderManager.menuChapter[1] = true;
        }
        else if (l == 3)
        {
            // plants year 4
            SceneManager.LoadScene("Plants-AR");

            //for (int i = 0; i < chapter.Length; i++)
            //{
            //    chapter[i].SetActive(false);
            //    chapter[0].SetActive(false);
            //}
            boolHolderManager.menuChapter[1] = true;
        }
        else if (l == 4)
        {
            // animals year 5
            SceneManager.LoadScene("Y5 - C4 AR");

            //for (int i = 0; i < chapter.Length; i++)
            //{
            //    chapter[i].SetActive(false);
            //    chapter[1].SetActive(false);
            //}
            boolHolderManager.menuChapter[2] = true;
        }
        else if (l == 5)
        {
            // plants year 5
            SceneManager.LoadScene("Y5 - C5 AR");

            //for (int i = 0; i < chapter.Length; i++)
            //{
            //    chapter[i].SetActive(false);
            //    chapter[1].SetActive(false);
            //}
            boolHolderManager.menuChapter[2] = true;
        }
        else if (l == 6)
        {
            // earth year 5
            SceneManager.LoadScene("Y5 - Earth - AR");

            //for (int i = 0; i < chapter.Length; i++)
            //{
            //    chapter[i].SetActive(false);
            //    chapter[1].SetActive(false);
            //}
            boolHolderManager.menuChapter[2] = true;
        }
        else if (l == 7)
        {
            // speed year 6
            //SceneManager.LoadScene("Y5 - Earth - AR");

            //for (int i = 0; i < chapter.Length; i++)
            //{
            //    chapter[i].SetActive(false);
            //    chapter[2].SetActive(false);
            //}
            boolHolderManager.menuChapter[3] = true;
        }
    }

    public void YesFuncFact()
    {
        if (l == 1)
        {
            // anatomy
            //SceneManager.LoadScene("Y5 - C4 Fun facts"); // animals
            boolHolderManager.menuChapter[1] = true;

            boolHolderManager.dropdownValue = 1;
        }
        else if (l == 2)
        {
            // y4 animal
            SceneManager.LoadScene("Fun-Facts"); // animals
            boolHolderManager.menuChapter[1] = true;
            boolHolderManager.dropdownValue = 1;

        }
        else if (l == 3)
        {
            // y4 plants
            SceneManager.LoadScene("Plants-Fun-Facts"); // animals
            boolHolderManager.menuChapter[1] = true;
            boolHolderManager.dropdownValue = 1;

        }
        else if (l == 4)
        {
            // y5 animals
            SceneManager.LoadScene("Y5 - C4 Fun Facts"); // animals
            boolHolderManager.menuChapter[2] = true;
            boolHolderManager.dropdownValue = 2;

        }
        else if (l == 5)
        {
            // y5 plants
            SceneManager.LoadScene("Y5 - C5 Fun Facts"); // plants
            boolHolderManager.menuChapter[2] = true;
            boolHolderManager.dropdownValue = 2;

        }
        else if (l == 6)
        {
            // y5 earth
            SceneManager.LoadScene("Y5 - Earth Fun Fact"); // plants
            boolHolderManager.menuChapter[2] = true;
            boolHolderManager.dropdownValue = 2;

        }
        else if (l == 7)
        {
            // y6 speed
            //SceneManager.LoadScene("Plants-Fun-Facts"); // plants
            boolHolderManager.menuChapter[3] = true;
            boolHolderManager.dropdownValue = 3;

        }
    }
}
