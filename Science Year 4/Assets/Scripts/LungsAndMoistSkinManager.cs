using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LungsAndMoistSkinManager : MonoBehaviour
{
    [SerializeField] private GameObject[] questions, reference;
    [SerializeField] private GameObject example, questiontext;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    int number;

    void Start()
    {
        for (int i = 0; i < questions.Length; i++)
        {
            questions[i].SetActive(false);
            questions[0].SetActive(true);
        }

        example.SetActive(false);

        questions[0].GetComponent<Animation>().Play("FirstQuestion-LungsAndMoistSkin");
    }

    void Update()
    {
        for (int i = 0; i < reference.Length; i++)
        {
            reference[i].SetActive(false);
            reference[number].SetActive(true);
        }
    }

    public void NextReference()
    {
        if (number >= 2)
        {
            return;
        }

        PressSFX();
        number += 1;
    }

    public void PrevReference()
    {
        if (number <= 0)
        {
            return;
        }

        BackSFX();
        number -= 1;
    }

    #region first question

    public void _RightQ1()
    {
        StartCoroutine(_RightAnswer());
        RightSFX();
        questions[0].transform.GetChild(1).GetComponent<Image>().color = Color.green;
    }
    #endregion

    #region second question
    public void _RightQ2()
    {
        StartCoroutine(_RightAnswerQ2());
        RightSFX();
        questions[1].transform.GetChild(2).GetComponent<Image>().color = Color.green;
    }
    #endregion

    public void Wrong()
    {
        StartCoroutine(ChangeRedColor());
        WrongSFX();
    }

    IEnumerator _RightAnswer()
    {
        yield return new WaitForSeconds(1f);

        questions[0].SetActive(false);
        questions[1].SetActive(true);

        questions[1].GetComponent<Animation>().Play("FirstQuestion-LungsAndMoistSkin");
    }

    IEnumerator _RightAnswerQ2()
    {
        yield return new WaitForSeconds(1f);

        questiontext.SetActive(false);

        questions[1].SetActive(false);
        example.SetActive(true);

        example.GetComponent<Animation>().Play("Example_LAMS");
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

        //cur += 1;
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
