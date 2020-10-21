using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Image answerImage, tickImage;

    [SerializeField] private GameObject rightAnswerPop;

    [SerializeField] private Button[] button;

    bool choice;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
        rightAnswerPop.SetActive(false);

        answerImage.enabled = false;
        tickImage.enabled = false;
    }

    public void _SnakeAnswer() // 7a
    {
        choice = true;
        StartCoroutine(RightAnswer());
    }

    public void _WrongAnswer()
    {
        StartCoroutine(ChangeRedColor());

        choice = false;
        WrongSFX();
    }


    IEnumerator RightAnswer()
    {
        RightSFX();
        for (int i = 0; i < button.Length; i++)
        {
            button[i].interactable = false;
        }

        StartCoroutine(ShowAnswer());
        StartCoroutine(ButtonChangeColor());

        yield return new WaitForSeconds(aSource.clip.length);

        if (choice)
        {
            rightAnswerPop.SetActive(true);

            rightAnswerPop.GetComponent<Animation>().Play("Lungs_AnswerPop");
        }
        else if (!choice)
        {
            rightAnswerPop.GetComponent<Animation>().Stop();
        }
    }

    IEnumerator ShowAnswer()
    {
        answerImage.enabled = true;
        answerImage.GetComponent<Animation>().Play("ShowAnswer-7a");

        yield return new WaitForSeconds(.5f);

        tickImage.enabled = true;
    }

    public void ReturnToAR()
    {
        BackSFX();
        SceneManager.LoadScene("AR-Aspect");
    }

    IEnumerator ButtonChangeColor()
    {
        List<GameObject> disable = new List<GameObject>();

        disable.AddRange(GameObject.FindGameObjectsWithTag("False"));

        foreach (GameObject but in disable)
        {
            but.GetComponent<Button>().enabled = false;
        }

        Image i = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();
        i.color = Color.green;

        yield return new WaitForSeconds(1f);

        i.color = Color.white;

        foreach (GameObject but in disable)
        {
            but.GetComponent<Button>().enabled = true;
        }
    }

    IEnumerator ChangeRedColor()
    {
        List<GameObject> disable = new List<GameObject>();

        disable.AddRange(GameObject.FindGameObjectsWithTag("False"));

        foreach (GameObject but in disable)
        {
            but.GetComponent<Button>().enabled = false;
        }

        Image img = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();

        img.color = Color.red;

        yield return new WaitForSeconds(1f);

        img.color = Color.white;

        foreach (GameObject but in disable)
        {
            but.GetComponent<Button>().enabled = true;
        }
    }

    void PressSFX()
    {
        aSource.clip = clip[0];
        aSource.Play();
    }

    void BackSFX()
    {
        aSource.clip = clip[1];
        aSource.Play();
    }

    void RightSFX()
    {
        aSource.clip = clip[2];
        aSource.Play();
    }

    void WrongSFX()
    {
        aSource.clip = clip[3];
        aSource.Play();
    }
}
