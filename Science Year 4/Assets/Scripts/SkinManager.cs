using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private Canvas[] canvas;
    [SerializeField] private TextMeshProUGUI answerText;

    [SerializeField] private Button answerButton;
    [SerializeField] private Image answerImage;

    void Start()
    {
        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].enabled = false;
            canvas[0].enabled = true;
        }

        answerText.enabled = false;
        answerImage.enabled = false;
    }

    public void Next()
    {
        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].enabled = false;
            canvas[1].enabled = true;
        }
    }

    public void Back()
    {
        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].enabled = false;
            canvas[0].enabled = true;
        }
    }

    public void Answer()
    {
        StartCoroutine(ShowAnswer());
       
        answerButton.GetComponent<Button>().interactable = false;
    }

    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }

    IEnumerator ShowAnswer()
    {
        yield return new WaitForSeconds(.5f);

        answerText.enabled = true;
        answerText.GetComponent<Animation>().Play("FadeIn");

        yield return new WaitForSeconds(1.5f);

        answerImage.enabled = true;
        answerImage.GetComponent<Animation>().Play("FadeIn");
    }
}
