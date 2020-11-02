using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpeedFunFactManager : MonoBehaviour
{
    [SerializeField] private string[] dialogue;
    [SerializeField] private GameObject[] buts, arrows;
    [SerializeField] private TextMeshProUGUI explanationText;

    [SerializeField] private Sprite[] butSprite, imageSprite;
    int cur;

    [SerializeField] private Image exampleImage;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        explanationText.text = "";
        exampleImage.gameObject.SetActive(false);

        arrows[0].SetActive(false);
        arrows[1].SetActive(true);
    }

    public void _uniform()
    {
        PressSFX();

        exampleImage.gameObject.SetActive(true);

        if (cur == 0)
        {
            explanationText.text = dialogue[0].ToString();
            exampleImage.sprite = imageSprite[0];
        }
        else if (cur == 1)
        {
            explanationText.text = dialogue[2].ToString();
            exampleImage.sprite = imageSprite[1];
        }

        buts[0].GetComponent<Image>().sprite = butSprite[1];
        buts[1].GetComponent<Image>().sprite = butSprite[0];
    }

    public void _constant()
    {
        PressSFX();

        exampleImage.gameObject.SetActive(true);

        if (cur == 0)
        {
            explanationText.text = dialogue[1].ToString();
            exampleImage.sprite = imageSprite[2];
        }
        else if (cur == 1)
        {
            explanationText.text = dialogue[3].ToString();
            exampleImage.sprite = imageSprite[3];
        }

        buts[1].GetComponent<Image>().sprite = butSprite[1];
        buts[0].GetComponent<Image>().sprite = butSprite[0];
    }

    public void prev()
    {
        BackSFX();

        cur = 0;

        exampleImage.gameObject.SetActive(false);
        arrows[1].SetActive(true);
        arrows[0].SetActive(false);

        buts[0].GetComponent<Image>().sprite = butSprite[0];
        buts[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Uniform Speed";

        buts[1].GetComponent<Image>().sprite = butSprite[0];
        buts[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Constant/Steady Speed";

        explanationText.text = "";
    }

    public void next()
    {
        PressSFX();

        cur = 1;

        exampleImage.gameObject.SetActive(false);
        arrows[0].SetActive(true);
        arrows[1].SetActive(false);

        buts[0].GetComponent<Image>().sprite = butSprite[0];
        buts[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Light Speed";

        buts[1].GetComponent<Image>().sprite = butSprite[0];
        buts[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Sound Speed";

        explanationText.text = "";
    }

    public void Return()
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
