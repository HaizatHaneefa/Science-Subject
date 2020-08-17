using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Image answerImage, tickImage;

    [SerializeField] AudioClip audioRight, audioWrong;
    [SerializeField] AudioSource audioSource;

    [SerializeField] private GameObject rightAnswerPop;

    [SerializeField] private Button[] button;

    bool choice;

    void Start()
    {
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
        choice = false;
        AutheDio();
    }

    void AutheDio()
    {
        audioSource.clip = audioWrong;
        audioSource.Play();
    }

    IEnumerator RightAnswer()
    {
        for (int i = 0; i < button.Length; i++)
        {
            button[i].interactable = false;
        }

        audioSource.clip = audioRight;
        StartCoroutine(ShowAnswer());

        audioSource.Play();

        yield return new WaitForSeconds(audioSource.clip.length);

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
        SceneManager.LoadScene("AR-Aspect");
    }
}
