using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class WorldMapManager : MonoBehaviour
{
    [SerializeField] private WorldMapData data;

    [SerializeField] public bool[] round;
    [SerializeField] public bool[] conditionBool;

    [SerializeField] public GameObject[] roundStuff;
    [SerializeField] public GameObject introPop, EndPop, contButton, moreInfo, transitionImage, nextButton;

    [SerializeField] private TextMeshProUGUI descriptionText, levelText, titleText;
    [SerializeField] private Image countryImage;

    int level;

    [SerializeField] public Sprite[] rightWrongSprite;

    [SerializeField] private Sprite[] countrySprite;

    [SerializeField] public AudioSource aSource;
    [SerializeField] public AudioClip[] clip;

    private void Start()
    {
        nextButton.SetActive(false);

        aSource = GetComponent<AudioSource>();

        transitionImage.SetActive(false);

        level = 1;
        levelText.enabled = false;

        introPop.transform.GetChild(0).GetComponent<Animation>().Play("Intro_Anim");

        EndPop.SetActive(false);
        contButton.SetActive(false);
        moreInfo.SetActive(false);

        data = GameObject.FindGameObjectWithTag("GameController").GetComponent<WorldMapData>();

        round = new bool[6];
        round[0] = true;

        conditionBool = new bool[3];
        conditionBool[0] = true;
    }

    private void Update()
    {
        transitionImage.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = level.ToString();
    }

    public void PlayGame()
    {
        PressSFX();
        introPop.SetActive(false);

        for (int i = 0; i < roundStuff.Length; i++)
        {
            roundStuff[i].SetActive(false);
            roundStuff[0].SetActive(true);
        }

        levelText.enabled = true;
    }

    public void MoreInfo(int index)
    {
        PressSFX();
        moreInfo.SetActive(true);
        moreInfo.transform.GetChild(0).GetComponent<Animation>().Play("Intro_Anim");

        if (index == 0)
        {
            descriptionText.text = data.d0.description.ToString();
            titleText.text = data.d0.title.ToString();

            countryImage.sprite = countrySprite[0];
        }
        else if (index == 1)
        {
            descriptionText.text = data.d1.description.ToString();
            titleText.text = data.d1.title.ToString();

            countryImage.sprite = countrySprite[1];
        }
        else if (index == 2)
        {
            descriptionText.text = data.d2.description.ToString();
            titleText.text = data.d2.title.ToString();

            countryImage.sprite = countrySprite[2];
        }
        else if (index == 3)
        {
            descriptionText.text = data.d3.description.ToString();
            titleText.text = data.d3.title.ToString();

            countryImage.sprite = countrySprite[3];
        }
        else if (index == 4)
        {
            descriptionText.text = data.d4.description.ToString();
            titleText.text = data.d4.title.ToString();

            countryImage.sprite = countrySprite[4];
        }
        else if (index == 5)
        {
            descriptionText.text = data.d5.description.ToString();
            titleText.text = data.d5.title.ToString();

            countryImage.sprite = countrySprite[5];
        }
        else if (index == 6)
        {
            descriptionText.text = data.d6.description.ToString();
            titleText.text = data.d6.title.ToString();

            countryImage.sprite = countrySprite[6];
        }
        else if (index == 7)
        {
            descriptionText.text = data.d7.description.ToString();
            titleText.text = data.d7.title.ToString();

            countryImage.sprite = countrySprite[7];
        }
        else if (index == 8)
        {
            descriptionText.text = data.d8.description.ToString();
            titleText.text = data.d8.title.ToString();

            countryImage.sprite = countrySprite[8];
        }
        else if (index == 9)
        {
            descriptionText.text = data.d9.description.ToString();
            titleText.text = data.d9.title.ToString();

            countryImage.sprite = countrySprite[9];
        }
        else if (index == 10)
        {
            descriptionText.text = data.d10.description.ToString();
            titleText.text = data.d10.title.ToString();

            countryImage.sprite = countrySprite[10];
        }
        else if (index == 11)
        {
            descriptionText.text = data.d11.description.ToString();
            titleText.text = data.d11.title.ToString();

            countryImage.sprite = countrySprite[11];
        }
        else if (index == 12)
        {
            descriptionText.text = data.d12.description.ToString();
            titleText.text = data.d12.title.ToString();

            countryImage.sprite = countrySprite[12];
        }
        else if (index == 13)
        {
            descriptionText.text = data.d13.description.ToString();
            titleText.text = data.d13.title.ToString();

            countryImage.sprite = countrySprite[13];
        }
        else if (index == 14)
        {
            descriptionText.text = data.d14.description.ToString();
            titleText.text = data.d14.title.ToString();

            countryImage.sprite = countrySprite[14];
        }
        else if (index == 15)
        {
            descriptionText.text = data.d15.description.ToString();
            titleText.text = data.d15.title.ToString();

            countryImage.sprite = countrySprite[15];
        }
        else if (index == 16)
        {
            descriptionText.text = data.d16.description.ToString();
            titleText.text = data.d16.title.ToString();

            countryImage.sprite = countrySprite[16];
        }
        else if (index == 17)
        {
            descriptionText.text = data.d17.description.ToString();
            titleText.text = data.d17.title.ToString();

            countryImage.sprite = countrySprite[17];
        }
    }

    public void CloseMoreInfo()
    {
        BackSFX();
        moreInfo.SetActive(false);
    }

    //public void GoNext()
    //{
    //    level += 1;
    //    levelText.text = "Level " + level;

    //    contButton.SetActive(false);

    //    if (round[0])
    //    {
    //        for (int i = 0; i < roundStuff.Length; i++)
    //        {
    //            roundStuff[i].SetActive(false);
    //            roundStuff[1].SetActive(true);
    //        }


    //        round[0] = false;
    //        round[1] = true;
    //    }
    //    else if (round[1])
    //    {
    //        for (int i = 0; i < roundStuff.Length; i++)
    //        {
    //            roundStuff[i].SetActive(false);
    //            roundStuff[2].SetActive(true);
    //        }

    //        round[1] = false;
    //        round[2] = true;
    //    }
    //    else if (round[2])
    //    {
    //        for (int i = 0; i < roundStuff.Length; i++)
    //        {
    //            roundStuff[i].SetActive(false);
    //            roundStuff[3].SetActive(true);
    //        }

    //        round[2] = false;
    //        round[3] = true;
    //    }
    //    else if (round[3])
    //    {
    //        for (int i = 0; i < roundStuff.Length; i++)
    //        {
    //            roundStuff[i].SetActive(false);
    //            roundStuff[4].SetActive(true);
    //        }

    //        round[3] = false;
    //        round[4] = true;
    //    }
    //    else if (round[4])
    //    {
    //        for (int i = 0; i < roundStuff.Length; i++)
    //        {
    //            roundStuff[i].SetActive(false);
    //            roundStuff[5].SetActive(true);
    //        }

    //        round[4] = false;
    //        round[5] = true;
    //    }
    //}

    public void NextQuestion() // advancing to questions
    {
        PressSFX();
        if (round[5])
        {
            EndGame();
        }
        else if (!round[5])
        {
            StartCoroutine(DelayThatThang());
            nextButton.SetActive(false);
        }
    }

    public IEnumerator DelayThatThang()
    {

        if (!round[5])
        {
            transitionImage.SetActive(true);
            transitionImage.GetComponent<Animation>().Play("Transition");

            level += 1;
            //weeshunnn();
        }

        yield return new WaitForSeconds(4f);

        if (!round[5])
        {
            levelText.text = "Level " + level;

            transitionImage.SetActive(false);
        }

        if (round[0])
        {
            for (int i = 0; i < roundStuff.Length; i++)
            {
                roundStuff[i].SetActive(false);
                roundStuff[1].SetActive(true);
            }


            round[0] = false;
            round[1] = true;
        }
        else if (round[1])
        {
            for (int i = 0; i < roundStuff.Length; i++)
            {
                roundStuff[i].SetActive(false);
                roundStuff[2].SetActive(true);
            }

            round[1] = false;
            round[2] = true;
        }
        else if (round[2])
        {
            for (int i = 0; i < roundStuff.Length; i++)
            {
                roundStuff[i].SetActive(false);
                roundStuff[3].SetActive(true);
            }

            round[2] = false;
            round[3] = true;
        }
        else if (round[3])
        {
            for (int i = 0; i < roundStuff.Length; i++)
            {
                roundStuff[i].SetActive(false);
                roundStuff[4].SetActive(true);
            }

            round[3] = false;
            round[4] = true;
        }
        else if (round[4])
        {
            for (int i = 0; i < roundStuff.Length; i++)
            {
                roundStuff[i].SetActive(false);
                roundStuff[5].SetActive(true);
            }

            round[4] = false;
            round[5] = true;
        }
    }

    void EndGame()
    {
        RightSFX();
        EndPop.SetActive(true);
        EndPop.transform.GetChild(0).GetComponent<Animation>().Play("GameOverPop");

        StartCoroutine(Star());
    }

    public void BackToAR()
    {
        BackSFX();
        SceneManager.LoadScene("Y5 - Earth Menu");
    }

    public void RestartGame()
    {
        PressSFX();
        SceneManager.LoadScene("Y5 - C World Map");
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

    //    public void weeshunnn()
    //    {
    //        aSource.clip = clip[5];
    //        aSource.Play();
    //    }

    IEnumerator Star()
    {
        yield return new WaitForSeconds(.5f);
        EndPop.transform.GetChild(4).GetComponent<ParticleSystem>().Play();

    }
}
