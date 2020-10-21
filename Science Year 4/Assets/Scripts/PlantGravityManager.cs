using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlantGravityManager : MonoBehaviour
{
    public GameObject exampleImage;

    public GameObject[] questions;

    public TextMeshProUGUI questionText;

    public int cur;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        exampleImage.SetActive(false);

        for (int i = 0; i < questions.Length; i++)
        {
            questions[i].SetActive(false);
            questions[0].SetActive(true);
        }

        questions[0].GetComponent<Animation>().Play("Q1-Plants-Light");
    }

    public void _Q1Y()
    {
        StartCoroutine(transition());

        RightSFX();

        StartCoroutine(ButtonChangeColor());
    }

    public void _Q2Y()
    {
        StartCoroutine(transition());

        RightSFX();

        StartCoroutine(ButtonChangeColor());
    }

    public void _Q3Y()
    {
        StartCoroutine(ShowPhototropism());

        RightSFX();

        StartCoroutine(ButtonChangeColor());

    }

    public void _QN()
    {
        WrongPressSFX();
        StartCoroutine(ChangeRedColor());
    }

    IEnumerator ShowPhototropism()
    {
        questions[2].GetComponent<Animation>().Play("Q1-Plants-Light-2");

        yield return new WaitForSeconds(1f);

        exampleImage.SetActive(true);
        questionText.enabled = false;

        for (int i = 0; i < questions.Length; i++)
        {
            questions[i].SetActive(false);
        }
    }

    IEnumerator transition()
    {
        if (cur == 0)
        {
            questions[0].GetComponent<Animation>().Play("Q1-Plants-Light-2");

        }
        else if (cur == 1)
        {
            questions[1].GetComponent<Animation>().Play("Q1-Plants-Light-2");
        }

        yield return new WaitForSeconds(1f);

        if (cur == 0)
        {
            questions[0].SetActive(false);
            questions[1].SetActive(true);

            cur = 1;
        }
        else if (cur == 1)
        {
            questions[0].SetActive(false);
            questions[2].SetActive(true);
        }
    }

    public void BackToAR()
    {
        BackSFX();
        SceneManager.LoadScene("Plants-AR");
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
