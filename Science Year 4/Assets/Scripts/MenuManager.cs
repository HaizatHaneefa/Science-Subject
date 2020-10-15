using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

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
   
    void Awake()
    {
        Time.timeScale = 1;

        blocker.SetActive(false);

        if (PlayerPrefs.GetInt("CheckMenu") == 1)
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
            arOrFunFactBackground.SetActive(false);

            if (PlayerPrefs.GetInt("C4") == 1)
            {
                for (int i = 0; i < chapter.Length; i++)
                {
                    chapter[i].SetActive(false);
                    chapter[0].SetActive(true);
                }

                dropdown.value = 1;
            }
            else if (PlayerPrefs.GetInt("C5") == 1)
                {
                    for (int i = 0; i < chapter.Length; i++)
                {
                    chapter[i].SetActive(false);
                    chapter[1].SetActive(true);
                }

                dropdown.value = 2;
            }
            else if (PlayerPrefs.GetInt("C6") == 1)
            {
                for (int i = 0; i < chapter.Length; i++)
                {
                    chapter[i].SetActive(false);
                    chapter[2].SetActive(true);
                }

                dropdown.value = 3;
            }
        }
        else if (PlayerPrefs.GetInt("CheckMenu") == 0)
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
    }

    public void ToMenu()
    {
        PlayerPrefs.SetInt("CheckMenu", 1);

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

            PlayerPrefs.SetInt("C4", 1);
            PlayerPrefs.SetInt("C5", 0);
            PlayerPrefs.SetInt("C6", 0);
        }
        else if (l == 2)
        {
            // animal year 4
            SceneManager.LoadScene("AR-Aspect");

            PlayerPrefs.SetInt("C4", 1);
            PlayerPrefs.SetInt("C5", 0);
            PlayerPrefs.SetInt("C6", 0);
        }
        else if (l == 3)
        {
            // plants year 4
            SceneManager.LoadScene("Plants-AR");

            PlayerPrefs.SetInt("C4", 1);
            PlayerPrefs.SetInt("C5", 0);
            PlayerPrefs.SetInt("C6", 0);
        }
        else if (l == 4)
        {
            // animals year 5
            SceneManager.LoadScene("Y5 - C4 AR");

            PlayerPrefs.SetInt("C4", 0);
            PlayerPrefs.SetInt("C5", 1);
            PlayerPrefs.SetInt("C6", 0);
        }
        else if (l == 5)
        {
            // plants year 5
            SceneManager.LoadScene("Y5 - C5 AR");

            PlayerPrefs.SetInt("C4", 0);
            PlayerPrefs.SetInt("C5", 1);
            PlayerPrefs.SetInt("C6", 0);
        }
        else if (l == 6)
        {
            // earth year 5
            SceneManager.LoadScene("Y5 - Earth - AR");

            PlayerPrefs.SetInt("C4", 0);
            PlayerPrefs.SetInt("C5", 1);
            PlayerPrefs.SetInt("C6", 0);
        }
        else if (l == 7)
        {
            // speed year 6
            SceneManager.LoadScene("");

            PlayerPrefs.SetInt("C4", 0);
            PlayerPrefs.SetInt("C5", 0);
            PlayerPrefs.SetInt("C6", 1);
        }
    }

    public void YesFuncFact()
    {
        if (l == 1)
        {
            // anatomy
            SceneManager.LoadScene(""); // anatomy

            PlayerPrefs.SetInt("C4", 1);
            PlayerPrefs.SetInt("C5", 0);
            PlayerPrefs.SetInt("C6", 0);
        }
        else if (l == 2)
        {
            // y4 animal
            SceneManager.LoadScene("Fun-Facts"); // animals

            PlayerPrefs.SetInt("C4", 1);
            PlayerPrefs.SetInt("C5", 0);
            PlayerPrefs.SetInt("C6", 0);
        }
        else if (l == 3)
        {
            // y4 plants
            SceneManager.LoadScene("Plants-Fun-Facts"); // animals

            PlayerPrefs.SetInt("C4", 1);
            PlayerPrefs.SetInt("C5", 0);
            PlayerPrefs.SetInt("C6", 0);
        }
        else if (l == 4)
        {
            // y5 animals
            SceneManager.LoadScene("Y5 - C4 Fun Facts"); // animals

            PlayerPrefs.SetInt("C4", 0);
            PlayerPrefs.SetInt("C5", 1);
            PlayerPrefs.SetInt("C6", 0);
        }
        else if (l == 5)
        {
            // y5 plants
            SceneManager.LoadScene("Y5 - C5 Fun Facts"); // plants

            PlayerPrefs.SetInt("C4", 0);
            PlayerPrefs.SetInt("C5", 1);
            PlayerPrefs.SetInt("C6", 0);
        }
        else if (l == 6)
        {
            // y5 earth
            SceneManager.LoadScene("Y5 - Earth Fun Fact"); // plants

            PlayerPrefs.SetInt("C4", 0);
            PlayerPrefs.SetInt("C5", 1);
            PlayerPrefs.SetInt("C6", 0);
        }
        else if (l == 7)
        {
            // y6 speed
            SceneManager.LoadScene(""); // speed fun fact

            PlayerPrefs.SetInt("C4", 0);
            PlayerPrefs.SetInt("C5", 0);
            PlayerPrefs.SetInt("C6", 1);
        }
    }

    public void YesGame()
    {
        if (l == 1)
        {
            // anatomy
            SceneManager.LoadScene(""); // anatomy

            PlayerPrefs.SetInt("C4", 1);
            PlayerPrefs.SetInt("C5", 0);
            PlayerPrefs.SetInt("C6", 0);
        }
        else if (l == 2)
        {
            // y4 animal
            SceneManager.LoadScene("Game-Chapter-4"); // animals

            PlayerPrefs.SetInt("C4", 1);
            PlayerPrefs.SetInt("C5", 0);
            PlayerPrefs.SetInt("C6", 0);
        }
        else if (l == 3)
        {
            // y4 plants
            SceneManager.LoadScene("Plant-Game"); // animals

            PlayerPrefs.SetInt("C4", 1);
            PlayerPrefs.SetInt("C5", 0);
            PlayerPrefs.SetInt("C6", 0);
        }
        else if (l == 4)
        {
            // y5 animals
            SceneManager.LoadScene("Y5 - C4 Game"); // animals

            PlayerPrefs.SetInt("C4", 0);
            PlayerPrefs.SetInt("C5", 1);
            PlayerPrefs.SetInt("C6", 0);
        }
        else if (l == 5)
        {
            // y5 plants
            SceneManager.LoadScene("Y5 - C5 Game"); // plants

            PlayerPrefs.SetInt("C4", 0);
            PlayerPrefs.SetInt("C5", 1);
            PlayerPrefs.SetInt("C6", 0);
        }
        else if (l == 6)
        {
            // y5 earth
            SceneManager.LoadScene("Y5 - Earth Menu"); // plants

            PlayerPrefs.SetInt("C4", 0);
            PlayerPrefs.SetInt("C5", 1);
            PlayerPrefs.SetInt("C6", 0);
        }
        else if (l == 7)
        {
            // y6 speed
            SceneManager.LoadScene("Y6 - Speed Race"); // speed fun fact

            PlayerPrefs.SetInt("C4", 0);
            PlayerPrefs.SetInt("C5", 0);
            PlayerPrefs.SetInt("C6", 1);
        }
    }
}
