using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Canvas[] canvas;
    [SerializeField] GameObject arOrFunFactBackground;

    int l;

    [SerializeField] private string[] description;

    [SerializeField] private TextMeshProUGUI descriptionText;

    [SerializeField] private GameObject[] chapter;
    [SerializeField] private GameObject[] itemsInBackground;
    [SerializeField] private GameObject blocker, normalPop, anatomyPop;
    [SerializeField] private GameObject bar;

    [SerializeField] public TMP_Dropdown dropdown;

    [SerializeField] private AudioClip[] clip;
    [SerializeField] private AudioSource aSource;

    int isSubject;

    void Awake()
    {
        //PlayerPrefs.DeleteAll();
        aSource = GetComponent<AudioSource>();

        Time.timeScale = 1;

        dropdown.gameObject.SetActive(false);

        blocker.SetActive(false);
        normalPop.SetActive(false);
        anatomyPop.SetActive(false);

        arOrFunFactBackground.SetActive(false);


        if (PlayerPrefs.GetInt("CheckMenu") == 1)
        {
            for (int i = 0; i < itemsInBackground.Length; i++)
            {
                itemsInBackground[i].SetActive(false);
            }

            for (int i = 0; i < canvas.Length; i++)
            {
                canvas[i].enabled = false;
                canvas[0].enabled = true;
                canvas[0].gameObject.GetComponent<Animation>().Play("Menu Anim");
            }

            for (int i = 0; i < chapter.Length; i++)
            {
                chapter[i].SetActive(false);
            }

            bar.SetActive(true);
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
        }
    }

    public void ToMenu()
    {
        SoundSelection();

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
        SoundSelection();

        dropdown.gameObject.SetActive(false);
        dropdown.value = 0;

        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].enabled = false;
            canvas[0].enabled = true;
        }
    }

    public void ToTopic(int index) // main menu function
    {
        SoundSelection();

        dropdown.gameObject.SetActive(true);

        if (index == 0) // science
        {
            for (int i = 0; i < canvas.Length; i++)
            {
                canvas[i].enabled = false;
                canvas[1].enabled = true;
            }

            for (int i = 0; i < chapter.Length; i++)
            {
                chapter[i].SetActive(false);
                chapter[0].SetActive(true);
            }

            isSubject = 0;
            canvas[1].GetComponent<Animation>().Play("Year4 Anim");
        }
        else if (index == 1) // math
        {
            isSubject = 1;
            for (int i = 0; i < canvas.Length; i++)
            {
                canvas[i].enabled = false;
                canvas[2].enabled = true;
            }

            for (int i = 0; i < chapter.Length; i++)
            {
                chapter[i].SetActive(false);
                chapter[3].SetActive(true);
            }

            canvas[2].GetComponent<Animation>().Play("Year4 Anim");
        }
    }

    public void HandleInputData() // dropdown
    {
        SoundSelection();

        if (isSubject == 0)
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
        else if (isSubject == 1)
        {
            // math dropdown
            if (dropdown.value == 1)
            {
                for (int i = 0; i < chapter.Length; i++)
                {
                    chapter[i].SetActive(false);
                    chapter[3].SetActive(true);
                }

                canvas[2].GetComponent<Animation>().Play("Year4 Anim");
            }
            else if (dropdown.value == 2)
            {
                for (int i = 0; i < chapter.Length; i++)
                {
                    chapter[i].SetActive(false);
                    chapter[4].SetActive(true);
                }

                canvas[2].GetComponent<Animation>().Play("Year5 Anim");
            }
            else if (dropdown.value == 3)
            {
                for (int i = 0; i < chapter.Length; i++)
                {
                    chapter[i].SetActive(false);
                    chapter[5].SetActive(true);
                }

                canvas[2].GetComponent<Animation>().Play("Year6 Anim");
            }
        }
    }

    public void ChapterSelection(int level)
    {
        GameObject go = EventSystem.current.currentSelectedGameObject.gameObject;
        go.GetComponent<Animation>().Play("Selected");

        SoundSelection();

        blocker.SetActive(true);

        l = level;

        if (l == 1)
        {
            normalPop.SetActive(false);
            anatomyPop.SetActive(true);
        }
        else if (l != 1)
        {
            normalPop.SetActive(true);
            anatomyPop.SetActive(false);
        }

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
        else if (l == 8) // y6 eclipse
        {
            descriptionText.text = description[7].ToString();
        }
        else if (l == 9)
        {
            descriptionText.text = description[8].ToString(); // y6 constellation
        }
        // ---------- //
        else if (l == 20) // math section | fractions
        {
            descriptionText.text = description[9].ToString();
        }
        else if (l == 21) // money
        {
            descriptionText.text = description[10].ToString();
        }
        else if (l == 22) // time
        {
            descriptionText.text = "y4 time";
        }
        else if (l == 23)
        {
            descriptionText.text = "y5 length";
        }
        else if (l == 24)
        {
            descriptionText.text = "y5 mass";
        }
        else if (l == 25)
        {
            descriptionText.text = "y5 volume of liquid";
        }
        else if (l == 26)
        {
            descriptionText.text = "y6 data handling";
        }
        else if (l == 27)
        {
            descriptionText.text = "y6 length";
        }
        else if (l == 28)
        {
            descriptionText.text = "y6 space";
        }

        if (l <= 9)
        {
            arOrFunFactBackground.SetActive(true);
            arOrFunFactBackground.GetComponent<Animation>().Play("Menu_ConfirmPop");
            arOrFunFactBackground.transform.GetChild(3).gameObject.SetActive(true);
            arOrFunFactBackground.transform.GetChild(4).gameObject.SetActive(false);
        }
        else if (l >= 9)
        {
            arOrFunFactBackground.SetActive(true);
            arOrFunFactBackground.GetComponent<Animation>().Play("Menu_ConfirmPop");
            arOrFunFactBackground.transform.GetChild(3).gameObject.SetActive(false);
            arOrFunFactBackground.transform.GetChild(4).gameObject.SetActive(true);
        }
    }

    public void BackToTopic()
    {
        BackSFX();

        arOrFunFactBackground.SetActive(false);
        blocker.SetActive(false);
    }

    public void YesAR()
    {
        SoundSelection();

        if (l == 1)
        {
            // anatomy
            SceneManager.LoadScene("Homepage");
        }
        else if (l == 2)
        {
            // animal year 4
            SceneManager.LoadScene("AR-Aspect");
        }
        else if (l == 3)
        {
            // plants year 4
            SceneManager.LoadScene("Plants-AR");
        }
        else if (l == 4)
        {
            // animals year 5
            SceneManager.LoadScene("Y5 - C4 AR");
        }
        else if (l == 5)
        {
            // plants year 5
            SceneManager.LoadScene("Y5 - C5 AR");
        }
        else if (l == 6)
        {
            // earth year 5
            SceneManager.LoadScene("Y5 - Earth - AR");
        }
        else if (l == 7)
        {
            // speed year 6
            SceneManager.LoadScene("Y6 - Speed AR");
        }
        else if (l == 8)
        {
            // eclipse year 6
            SceneManager.LoadScene("Y6 - Eclipse AR");
        }
        else if (l == 9)
        {
            // constellation year 6
            SceneManager.LoadScene("Y6 - Constellation AR");
        }
        // --------- //
        else if (l == 20) // start of math section
        {
            SceneManager.LoadScene("Y4 - Fractions AR");
        }
        else if (l == 21) // money
        {
            //SceneManager.LoadScene("Y4 - Fractions AR"); /
        }
        else if (l == 22) // time
        {
            SceneManager.LoadScene("Y4 - Time AR");
        }
        else if (l == 23) 
        {
            SceneManager.LoadScene("Y5 - Length AR");
        }
        else if (l == 24) 
        {
            SceneManager.LoadScene("Y5 - Mass AR");
        }
        else if (l == 25) 
        {
            SceneManager.LoadScene("Y5 - Volume Liquid AR");
        }
        else if (l == 26) 
        {
            //SceneManager.LoadScene("Y4 - Fractions AR");
        }
        else if (l == 27) 
        {
            //SceneManager.LoadScene("Y4 - Fractions AR");
        }
        else if (l == 28) 
        {
            //SceneManager.LoadScene("Y4 - Fractions AR");
        }
        else if (l == 29) 
        {
            //SceneManager.LoadScene("Y4 - Fractions AR");
        }
    }

    public void YesFuncFact()
    {
        SoundSelection();

        if (l == 1)
        {
            // anatomy
            SceneManager.LoadScene(""); // anatomy
        }
        else if (l == 2)
        {
            // y4 animal
            SceneManager.LoadScene("Fun-Facts"); // animals
        }
        else if (l == 3)
        {
            // y4 plants
            SceneManager.LoadScene("Plants-Fun-Facts"); // animals
        }
        else if (l == 4)
        {
            // y5 animals
            SceneManager.LoadScene("Y5 - C4 Fun Facts"); // animals
        }
        else if (l == 5)
        {
            // y5 plants
            SceneManager.LoadScene("Y5 - C5 Fun Facts"); // plants
        }
        else if (l == 6)
        {
            // y5 earth
            SceneManager.LoadScene("Y5 - Earth Fun Fact"); // plants
        }
        else if (l == 7)
        {
            // y6 speed
            SceneManager.LoadScene("Y6 - Speed Fun Fact"); // speed fun fact
        }
        else if (l == 8)
        {
            // y6 eclipse
            SceneManager.LoadScene("Y6 - Eclipse Fun Fact"); // eclipse fun fact
        }
        else if (l == 9)
        {
            // y6 constellation
            SceneManager.LoadScene("Y6 - Constellation Fun Fact"); // constellation fun fact
        }
        else if (l == 20)
        {
            SceneManager.LoadScene("Y4 - Fractions Fun Fact"); // constellation fun fact
        }
    }

    public void YesGame()
    {
        SoundSelection();

        if (l == 1)
        {
            // anatomy
            SceneManager.LoadScene(""); // anatomy
        }
        else if (l == 2)
        {
            // y4 animal
            SceneManager.LoadScene("Game-Chapter-4"); // animals
        }
        else if (l == 3)
        {
            // y4 plants
            SceneManager.LoadScene("Plant-Game"); // animals
        }
        else if (l == 4)
        {
            // y5 animals
            SceneManager.LoadScene("Y5 - C4 Game"); // animals
        }
        else if (l == 5)
        {
            // y5 plants
            SceneManager.LoadScene("Y5 - C5 Game"); // plants
        }
        else if (l == 6)
        {
            // y5 earth
            SceneManager.LoadScene("Y5 - Earth Menu"); // plants
        }
        else if (l == 7)
        {
            // y6 speed
            SceneManager.LoadScene("Loading Scene"); // to the car game thingy
        }
        else if (l == 8)
        {
            // y6 eclipse
            //SceneManager.LoadScene("Y6 - Speed Race"); // eclipse fun fact
            SceneManager.LoadScene("Y6 - Eclipse Game");
        }
        else if (l == 9)
        {
            // y6 constellation
            SceneManager.LoadScene("Y6 - Constellation Game");
        }
        else if (l == 20) // start of math
        {
            SceneManager.LoadScene("Y4 - Fractions Game");
        }
        else if (l == 21) // money
        {
            SceneManager.LoadScene("Y4 - Money Game");
        }
        else if (l == 22) // time
        {
            SceneManager.LoadScene("Y4 - Time Game"); // time
        }
        else if (l == 23) // something else here
        {
            //SceneManager.LoadScene("Y4 - Money Game"); // length
        }
    }

    void SoundSelection()
    {
        aSource.clip = clip[0];
        aSource.Play();
    }

    void BackSFX()
    {
        aSource.clip = clip[1];
        aSource.Play();
    }
}
