using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpeedQuizManager : MonoBehaviour
{
    [SerializeField] private GameObject[] questions, buts;
    [SerializeField] private GameObject endPop, ps, b;

    public int cur;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        endPop.SetActive(false);
        ps.SetActive(false);

        for (int i = 0; i < questions.Length; i++)
        {
            questions[i].SetActive(false);
            questions[0].SetActive(true);
            questions[0].GetComponent<Animation>().Play("SuccessPop");
        }
    }


    public void Button()
    { 
        b = EventSystem.current.currentSelectedGameObject;

        if (b.tag == "True")
        {
            RightSFX();
            StartCoroutine(CheckAnswer());
        }
        else if (b.tag == "False")
        {
            WrongPressSFX();
            StartCoroutine(WrongAnswer());
        }
    }

    IEnumerator CheckAnswer()
    {
        for (int i = 0; i < buts.Length; i++)
        {
            buts[i].GetComponent<Button>().interactable = false;
        }

        b.GetComponent<Image>().color = Color.green;

        yield return new WaitForSeconds(1);

        b.GetComponent<Image>().color = Color.white;

        for (int i = 0; i < buts.Length; i++)
        {
            buts[i].GetComponent<Button>().interactable = true;
        }

        if (cur == 0)
        {
            questions[0].SetActive(false);
            questions[1].SetActive(true);
            questions[1].GetComponent<Animation>().Play("SuccessPop");
            cur = 1;
        }
        else if (cur == 1)
        {
            questions[1].SetActive(false);
            questions[2].SetActive(true);
            questions[2].GetComponent<Animation>().Play("SuccessPop");
            cur = 2;
        }
        else if (cur == 2)
        {
            questions[2].SetActive(false);
            questions[3].SetActive(true);
            questions[3].GetComponent<Animation>().Play("SuccessPop");
            cur = 3;
        }
        else if (cur == 3)
        {
            questions[3].SetActive(false);
            questions[4].SetActive(true);
            questions[4].GetComponent<Animation>().Play("SuccessPop");
            cur = 4;
        }
        else if (cur == 4)
        {
            questions[4].SetActive(false);
            questions[5].SetActive(true);
            questions[5].GetComponent<Animation>().Play("SuccessPop");
            cur = 5;
        }
        else if (cur == 5)
        {
            questions[5].SetActive(false);
            questions[6].SetActive(true);
            questions[6].GetComponent<Animation>().Play("SuccessPop");
            cur = 6;
        }
        else if (cur == 6)
        {
            questions[6].SetActive(false);
            questions[7].SetActive(true);
            questions[7].GetComponent<Animation>().Play("SuccessPop");
            cur = 7;
        }
        else if (cur == 7)
        {
            questions[7].SetActive(false);
            questions[8].SetActive(true);
            questions[8].GetComponent<Animation>().Play("SuccessPop");
            cur = 8;
        }
        else if (cur == 8)
        {
            questions[8].SetActive(false);
            questions[9].SetActive(true);
            questions[9].GetComponent<Animation>().Play("SuccessPop");
            cur = 9;
        }
        else if (cur == 9)
        {
            StartCoroutine(EndPop());
        }
    }

    IEnumerator EndPop()
    {
        endPop.SetActive(true);
        endPop.GetComponent<Animation>().Play("SuccessPop");

        yield return new WaitForSeconds(0.5f);

        ps.SetActive(true);
        ps.GetComponent<ParticleSystem>().Play();
    }

    IEnumerator WrongAnswer()
    {
        b.GetComponent<Image>().color = Color.red;

        for (int i = 0; i < buts.Length; i++)
        {
            buts[i].GetComponent<Button>().interactable = false;
        }

        yield return new WaitForSeconds(1f);

        b.GetComponent<Image>().color = Color.white;

        for (int i = 0; i < buts.Length; i++)
        {
            buts[i].GetComponent<Button>().interactable = true;
        }
    }

    public void ReturnAR()
    {
        BackSFX();
        SceneManager.LoadScene("Y6 - Speed AR");
    }

    public void Retry()
    {
        PressSFX();
        SceneManager.LoadScene("Y6 - Speed Quiz");
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
