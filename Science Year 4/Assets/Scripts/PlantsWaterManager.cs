using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlantsWaterManager : MonoBehaviour
{
    public GameObject exampleImage;
    public GameObject[] questions;
    public GameObject congratsText;
    [SerializeField] private GameObject ps;

    public TextMeshProUGUI questionText;

    [SerializeField] private Button[] button;

    int cur;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    void Start()
    {
        congratsText.SetActive(false);
        ps.SetActive(false);

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
        StartCoroutine(ButtonChangeColor());
        StartCoroutine(transition());

        RightSFX();

        cur += 1;
    }

    public void _Q2Y()
    {
        StartCoroutine(ButtonChangeColor());
        StartCoroutine(ShowGeotropism());

        RightSFX();

        cur += 1;
    }

    public void _Q3Y()
    {
        StartCoroutine(ButtonChangeColor());
        StartCoroutine(End());

        RightSFX();

        cur += 1;
    }

    public void _QN()
    {
        WrongPressSFX();

        StartCoroutine(ChangeRedColor());
    }

    IEnumerator ShowGeotropism()
    {
        questions[1].GetComponent<Animation>().Play("Q1-Plants-Light-2");

        yield return new WaitForSeconds(1f);

        questionText.enabled = false;

        exampleImage.SetActive(true);

        for (int i = 0; i < questions.Length; i++)
        {
            questions[i].SetActive(false);
        }
    }

    IEnumerator End()
    {
        questions[2].GetComponent<Animation>().Play("Q1-Plants-Light-2");
       
        yield return new WaitForSeconds(1f);

        questionText.enabled = false;
        congratsText.SetActive(true);

        ps.SetActive(true);
        ps.GetComponent<ParticleSystem>().Play();

        for (int i = 0; i < questions.Length; i++)
        {
            questions[i].SetActive(false);
        }
    }

    IEnumerator transition()
    {
        questions[0].GetComponent<Animation>().Play("Q1-Plants-Light-2");

        yield return new WaitForSeconds(1f);

        questions[0].SetActive(false);
        questions[1].SetActive(true);
    }

    public void NextQuestion()
    {
        StartCoroutine(TWistedTransister());

        PressSFX();
    }

    IEnumerator TWistedTransister()
    {
        exampleImage.GetComponent<Animation>().Play("Q1-Plants-Photosynthesis");

        yield return new WaitForSeconds(1f);

        questionText.enabled = true;

        exampleImage.SetActive(false);

        for (int i = 0; i < questions.Length; i++)
        {
            questions[i].SetActive(false);
            questions[2].SetActive(true);
        }
    }

    public void BackToAR()
    {
        BackSFX();
        SceneManager.LoadScene("Plants-AR");
    }

    IEnumerator ChangeColor()
    {
        if (cur == 0)
        {
            button[0].GetComponent<Image>().color = Color.green;
        }
        else if (cur == 1)
        {
            button[1].GetComponent<Image>().color = Color.green;
        }
        else if (cur == 2)
        {
            button[2].GetComponent<Image>().color = Color.green;
        }

        yield return new WaitForSeconds(0.2f);

        for (int i = 0; i < button.Length; i++)
        {
            button[i].GetComponent<Image>().color = Color.white;
        }
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