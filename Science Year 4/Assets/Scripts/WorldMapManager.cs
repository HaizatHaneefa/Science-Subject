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
    [SerializeField] public GameObject introPop, EndPop, contButton, moreInfo, transitionImage;

    [SerializeField] private TextMeshProUGUI descriptionText, levelText, titleText;
    [SerializeField] private Image countryImage;

    int level;

    [SerializeField] private Sprite[] countrySprite;

    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioClip[] sound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

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
        moreInfo.SetActive(false);
    }

    public void GoNext()
    {
        level += 1;
        levelText.text = "Level " + level;

        contButton.SetActive(false);

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

    public IEnumerator DelayThatThang()
    {
        yield return new WaitForSeconds(1.5f);

        transitionImage.SetActive(true);
        transitionImage.GetComponent<Animation>().Play("Transition");

        level += 1;

        yield return new WaitForSeconds(4f);

        levelText.text = "Level " + level;

        transitionImage.SetActive(false);

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

    public void BackToAR()
    {
        SceneManager.LoadScene("Y5 - Earth - AR");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Y5 C World Map");

    }
}
