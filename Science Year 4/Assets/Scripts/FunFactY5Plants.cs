using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class FunFactY5Plants : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI explainText;

    [SerializeField] private string[] explanation;

    [SerializeField] private Image exampleImage;

    [SerializeField] private Sprite[] sprite;
    [SerializeField] private Sprite[] buttonSprite;

    [SerializeField] private Button[] button;

    [SerializeField] public AudioSource aSource;
    [SerializeField] public AudioClip[] clip;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        explainText.enabled = false;
        exampleImage.enabled = false;

        button[2].gameObject.SetActive(false);
        button[3].gameObject.SetActive(false);
    }

    public void _Catnip()
    {
        PressSFX();
        explainText.enabled = true;
        explainText.text = explanation[0].ToString();

        exampleImage.enabled = true;
        exampleImage.sprite = sprite[0];

        button[0].GetComponent<Image>().sprite = buttonSprite[1];
        button[1].GetComponent<Image>().sprite = buttonSprite[0];

        button[2].gameObject.SetActive(false);
        button[3].gameObject.SetActive(false);
    }

    public void _Desert()
    {
        PressSFX();
        explainText.enabled = true;
        explainText.text = explanation[1].ToString();

        exampleImage.enabled = true;
        exampleImage.sprite = sprite[1];


        button[0].GetComponent<Image>().sprite = buttonSprite[0];
        button[1].GetComponent<Image>().sprite = buttonSprite[1];

        button[2].gameObject.SetActive(true);
        button[3].gameObject.SetActive(true);
    }

    public void BackToMenu()
    {
        BackSFX();
        SceneManager.LoadScene("Menu"); // back to menu
    }

    public void Next()
    {
        PressSFX();
        explainText.text = explanation[2].ToString();
    }

    public void Prev()
    {
        BackSFX();
        explainText.text = explanation[1].ToString();
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
