using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EclipseQuizManager : MonoBehaviour
{
    [SerializeField] private string[] questions;

    [SerializeField] private GameObject[] questionGroup;
    List<GameObject> l = new List<GameObject>();
    [SerializeField] public GameObject endpop, secondSection;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    public bool[] secondBool;

    [SerializeField] public Sprite[] rightWrongSprite;

    int cur;

    void Start()
    {
        endpop.SetActive(false);
        secondSection.SetActive(false);

        secondBool = new bool[2];
        secondBool[0] = true;

        aSource = GetComponent<AudioSource>();

        for (int i = 0; i < questionGroup.Length; i++)
        {
            questionGroup[i].SetActive(false);
            questionGroup[0].SetActive(true);
        }

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("True"))
        {
            l.Add(go);
        }

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("False"))
        {
            l.Add(go);
        }
    }

    public void Button()
    {
        StartCoroutine(GetReaction());
    }

    IEnumerator GetReaction()
    {
        Image img = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();

        GameObject[] gos = GameObject.FindGameObjectsWithTag("False");
        GameObject[] rightgos = GameObject.FindGameObjectsWithTag("True");

        for (int i = 0; i < gos.Length; i++)
        {
            gos[i].GetComponent<Button>().interactable = false;
        }

        for (int i = 0; i < rightgos.Length; i++)
        {
            rightgos[i].GetComponent<Button>().interactable = false;
        }

        if (img.gameObject.tag == "True")
        {
            RightSFX();
            img.color = Color.green;

            cur += 1;
        }
        else if (img.gameObject.tag == "False")
        {
            WrongPressSFX();
            img.color = Color.red;
        }

        foreach (GameObject go in l)
        {
            go.GetComponent<Button>().interactable = false;
        }

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < gos.Length; i++)
        {
            gos[i].GetComponent<Button>().interactable = true;
        }

        for (int i = 0; i < rightgos.Length; i++)
        {
            rightgos[i].GetComponent<Button>().interactable = true;
        }

        img.color = Color.white;

        if (cur == 10)
        {
            questionGroup[9].SetActive(false);

            secondSection.SetActive(true);
        }
        else if (cur != 10)
        {
            if (img.gameObject.tag == "True")
            {
                for (int i = 0; i < questionGroup.Length; i++)
                {
                    questionGroup[i].SetActive(false);
                    questionGroup[cur].SetActive(true);
                    questionGroup[cur].GetComponent<Animation>().Play("SuccessPop");
                }
            }

            foreach (GameObject go in l)
            {
                go.GetComponent<Button>().interactable = true;
            }
        }
    }

    // ---------------------- Scenes ------------------------------ //
    public void BackToMenu()
    {
        BackSFX();
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        BackSFX();
        SceneManager.LoadScene("Y6 - Eclipse Quiz");
    }

    // ------------------------------- SFX ----------------------------- //
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
