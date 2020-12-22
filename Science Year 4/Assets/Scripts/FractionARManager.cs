using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class FractionARManager : MonoBehaviour
{
    public int cur, descriptionCur;
    [SerializeField] private Sprite[] butSprite;
    [SerializeField] private GameObject[] buts1, buts2, scene1, scene2, scene3, scene4;
    [SerializeField] private GameObject nextArrow, backArrow, nextScene, backScene;

    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private string[] description;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        for (int i = 0; i < scene1.Length; i++)
        {
            scene1[i].SetActive(false);
        }

        for (int i = 0; i < scene2.Length; i++)
        {
            scene2[i].SetActive(false);
        }

        for (int i = 0; i < scene3.Length; i++)
        {
            scene3[i].SetActive(false);
        }

        for (int i = 0; i < scene4.Length; i++)
        {
            scene4[i].SetActive(false);
        }

        for (int i = 0; i < buts2.Length; i++)
        {
            buts2[i].SetActive(false);
        }
    }

    void Update()
    {
        if (cur == 0)
        {
            backScene.SetActive(false);
        }
        else if (cur != 0)
        {
            backScene.SetActive(true);
        }

        if (cur == 3)
        {
            nextScene.SetActive(false);
        }
        else if (cur != 3)
        {
            nextScene.SetActive(true);
        }

        if (descriptionCur == 0)
        {
            backArrow.SetActive(false);
        }
        else if (descriptionCur != 0)
        {
            backArrow.SetActive(true);
        }

        if (descriptionCur == 4)
        {
            nextArrow.SetActive(false);
        }
        else if (descriptionCur != 4)
        {
            nextArrow.SetActive(true);
        }
    }

    // --------------- First scene ------------------------ //
    public void _Proper()
    {
        PressSFX();
        for (int i = 0; i < scene1.Length; i++)
        {
            scene1[i].SetActive(false);
            scene1[0].SetActive(true);
        }

        for (int i = 0; i < buts1.Length; i++)
        {
            buts1[i].GetComponent<Image>().sprite = butSprite[0];
            buts1[0].GetComponent<Image>().sprite = butSprite[1];
            buts1[0].GetComponent<Button>().enabled = false;
            buts1[1].GetComponent<Button>().enabled = true;
            buts1[2].GetComponent<Button>().enabled = true;
        }
    }

    public void _Mixed()
    {
        PressSFX();
        for (int i = 0; i < scene1.Length; i++)
        {
            scene1[i].SetActive(false);
            scene1[1].SetActive(true);
        }

        for (int i = 0; i < buts1.Length; i++)
        {
            buts1[i].GetComponent<Image>().sprite = butSprite[0];
            buts1[1].GetComponent<Image>().sprite = butSprite[1];
            buts1[0].GetComponent<Button>().enabled = true;
            buts1[1].GetComponent<Button>().enabled = false;
            buts1[2].GetComponent<Button>().enabled = true;
        }
    }

    public void _Improper()
    {
        PressSFX();
        for (int i = 0; i < scene1.Length; i++)
        {
            scene1[i].SetActive(false);
            scene1[2].SetActive(true);
        }

        for (int i = 0; i < buts1.Length; i++)
        {
            buts1[i].GetComponent<Image>().sprite = butSprite[0];
            buts1[2].GetComponent<Image>().sprite = butSprite[1];
            buts1[0].GetComponent<Button>().enabled = true;
            buts1[1].GetComponent<Button>().enabled = true;
            buts1[2].GetComponent<Button>().enabled = false;
        }
    }

    // --------------- Second scene ------------------------ //
    public void _ImpropertoMixed()
    {
        PressSFX();
        for (int i = 0; i < scene2.Length; i++)
        {
            scene2[i].SetActive(false);
            scene2[0].SetActive(true);
        }

        buts2[0].GetComponent<Image>().sprite = butSprite[1];
        buts2[0].GetComponent<Button>().enabled = false;

        buts2[1].GetComponent<Image>().sprite = butSprite[0];
        buts2[2].GetComponent<Image>().sprite = butSprite[0];

        buts2[1].GetComponent<Button>().enabled = true;
        buts2[2].GetComponent<Button>().enabled = true;
    }

    public void _MixednumbertoImproper()
    {
        PressSFX();
        for (int i = 0; i < scene2.Length; i++)
        {
            scene2[i].SetActive(false);
            scene2[1].SetActive(true);
        }

        buts2[0].GetComponent<Image>().sprite = butSprite[0];
        buts2[1].GetComponent<Image>().sprite = butSprite[1];
        buts2[1].GetComponent<Button>().enabled = false;
        buts2[2].GetComponent<Image>().sprite = butSprite[0];

        buts2[1].GetComponent<Button>().enabled = true;
        buts2[2].GetComponent<Button>().enabled = true;
    }

    public void _WholenumbertoFraction()
    {
        PressSFX();
        for (int i = 0; i < scene2.Length; i++)
        {
            scene2[i].SetActive(false);
            scene2[2].SetActive(true);
        }

        buts2[0].GetComponent<Image>().sprite = butSprite[0];
        buts2[1].GetComponent<Image>().sprite = butSprite[0];
        buts2[2].GetComponent<Image>().sprite = butSprite[1];
        buts2[2].GetComponent<Button>().enabled = false;
        buts2[0].GetComponent<Button>().enabled = true;
        buts2[1].GetComponent<Button>().enabled = true;
    }

    // --------------- Third scene ------------------------ //
    public void _AdditionTwoFractions()
    {
        PressSFX();
        scene3[3].SetActive(true);

        scene3[2].SetActive(true);
        scene3[2].GetComponent<Animation>().Play("ShowSlide Anim");

        scene3[1].GetComponent<Button>().enabled = false;
        scene3[1].GetComponent<Image>().sprite = butSprite[1];
    }

    // --------------- Forth scene ------------------------ //
    public void _SubtractionTwoFractions()
    {
        PressSFX();
        scene4[3].SetActive(true);

        scene4[2].SetActive(true);
        scene4[2].GetComponent<Animation>().Play("ShowSlide Anim");

        descriptionCur = 0;
        descriptionText.text = description[0].ToString();

        scene4[1].GetComponent<Button>().enabled = false;
        scene4[1].GetComponent<Image>().sprite = butSprite[1];
    }

    public void _Next()
    {
        PressSFX();
        // go second scene
        if (cur == 0)
        {
            for (int i = 0; i < scene1.Length; i++)
            {
                scene1[i].SetActive(false);
            }

            for (int i = 0; i < buts2.Length; i++)
            {
                buts2[i].SetActive(true);
                buts2[i].GetComponent<Image>().sprite = butSprite[0];
                buts2[i].GetComponent<Button>().enabled = true;
            }

            for (int i = 0; i < buts1.Length; i++)
            {
                buts1[i].SetActive(false);
                buts1[i].GetComponent<Button>().enabled = true;
            }
        }
        else if (cur == 1) // go third scene
        {
            // do something here
            for (int i = 0; i < scene3.Length; i++)
            {
                scene3[i].SetActive(true);
                scene3[2].SetActive(false);
                scene3[3].SetActive(false);
                scene3[1].GetComponent<Button>().enabled = true;
                scene3[1].GetComponent<Image>().sprite = butSprite[0];
            }

            for (int i = 0; i < buts2.Length; i++)
            {
                buts2[i].SetActive(false);
                buts2[i].GetComponent<Button>().enabled = true;
            }

            for (int i = 0; i < scene2.Length; i++)
            {
                scene2[i].SetActive(false);
            }
        }
        else if (cur == 2) // go forthe scene
        {
            for (int i = 0; i < scene4.Length; i++)
            {
                scene4[i].SetActive(true);
                scene4[2].SetActive(false);
                scene4[3].SetActive(false);

                scene4[1].GetComponent<Button>().enabled = true;
                scene4[1].GetComponent<Image>().sprite = butSprite[0];
            }

            for (int i = 0; i < scene3.Length; i++)
            {
                scene3[i].SetActive(false);
            }
        }

        cur += 1;
    }

    public void _Back()
    {
        BackSFX();
        // go second scene
        if (cur == 3)
        {
            for (int i = 0; i < scene3.Length; i++)
            {
                scene3[i].SetActive(true);
                scene3[2].SetActive(false);
                scene3[3].SetActive(false);

                scene3[1].GetComponent<Button>().enabled = true;
                scene3[1].GetComponent<Image>().sprite = butSprite[0];
            }

            for (int i = 0; i < scene4.Length; i++)
            {
                scene4[i].SetActive(false);
                scene4[1].GetComponent<Button>().enabled = true;
                scene4[1].GetComponent<Image>().sprite = butSprite[0];
            }
        }
        else if (cur == 2)
        {
            for (int i = 0; i < scene3.Length; i++)
            {
                scene3[i].SetActive(false);
            }

            for (int i = 0; i < buts2.Length; i++)
            {
                buts2[i].SetActive(true);
                buts2[i].GetComponent<Image>().sprite = butSprite[0];
                buts2[i].GetComponent<Button>().enabled = true;
            }

            for (int i = 0; i < scene2.Length; i++)
            {
                scene2[i].SetActive(false);
            }
        }
        else if (cur == 1) // go third scene
        {
            for (int i = 0; i < scene1.Length; i++)
            {
                scene1[i].SetActive(false);
            }

            for (int i = 0; i < buts2.Length; i++)
            {
                buts2[i].SetActive(false);
                buts2[i].GetComponent<Image>().sprite = butSprite[0];
                buts2[i].GetComponent<Button>().enabled = true;
            }

            for (int i = 0; i < buts1.Length; i++)
            {
                buts1[i].SetActive(true);
                buts1[i].GetComponent<Image>().sprite = butSprite[0];
            }

            for (int i = 0; i < scene2.Length; i++)
            {
                scene2[i].SetActive(false);
            }
        }

        cur -= 1;
    }

    public void _NextRead()
    {
        PressSFX();
        if (descriptionCur == 0)
        {
            descriptionText.text = description[1].ToString();
        }
        else if (descriptionCur == 1)
        {
            descriptionText.text = description[2].ToString();
        }
        else if (descriptionCur == 2)
        {
            descriptionText.text = description[3].ToString();
        }
        else if (descriptionCur == 3)
        {
            descriptionText.text = description[4].ToString();
        }
        else if (descriptionCur == 4)
        {
            descriptionText.text = description[5].ToString();
        }

        descriptionCur += 1;
    }

    public void _BackRead()
    {
        PressSFX();
        if (descriptionCur == 4)
        {
            descriptionText.text = description[4].ToString();
        }
        else if (descriptionCur == 3)
        {
            descriptionText.text = description[3].ToString();
        }
        else if (descriptionCur == 2)
        {
            descriptionText.text = description[2].ToString();
        }
        else if (descriptionCur == 1)
        {
            descriptionText.text = description[1].ToString();
        }
        else if (descriptionCur == 0)
        {
            descriptionText.text = description[0].ToString();
        }

        descriptionCur -= 1;
    }

    public void _Quiz()
    {
        PressSFX();
        SceneManager.LoadScene("Y4 - Fractions Quiz");
    }

    public void _BackToMenu()
    {
        BackSFX();
        SceneManager.LoadScene("Menu");
    }

    // ---------------------------- SFX ------------------------------ //
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
