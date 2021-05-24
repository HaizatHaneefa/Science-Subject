using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataHandlingQuizManager : MonoBehaviour
{
    [SerializeField] private GameObject[] scenes;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    [SerializeField] private List<GameObject> buttons;

    int cur;

    void Start()
    {
        CheckButtons();

        aSource = GetComponent<AudioSource>();

        for (int i = 0; i < scenes.Length; i++)
        {
            scenes[i].SetActive(false);
            scenes[cur].SetActive(true);
            scenes[cur].GetComponent<Animation>().Play("SuccessPop");
        }
    }

    public void _NextQuestion()
    {

        StartCoroutine(ColorChange());
    }

    IEnumerator ColorChange()
    {
        GameObject go = EventSystem.current.currentSelectedGameObject;

        foreach (GameObject obj in buttons)
        {
            obj.GetComponent<Button>().interactable = false;
        }

        if (go.tag == "True")
        {
            RightSFX();
            go.GetComponent<Image>().color = Color.green;
        }
        else if (go.tag == "False")
        {
            WrongPressSFX();
            go.GetComponent<Image>().color = Color.red;
        }

        yield return new WaitForSeconds(2f);
       
        cur += 1;

        foreach (GameObject obj in buttons)
        {
            obj.GetComponent<Button>().interactable = true;
        }

        if (go.tag == "True")
        {
            if (cur == 14)
            {
                for (int i = 0; i < scenes.Length; i++)
                {
                    scenes[i].SetActive(false);
                    scenes[cur].SetActive(true);
                    scenes[cur].GetComponent<Animation>().Play("EndGamePop-NEW");
                }
            }
            else if (cur != 14)
            {
                for (int i = 0; i < scenes.Length; i++)
                {
                    scenes[i].SetActive(false);
                    scenes[cur].SetActive(true);
                    scenes[cur].GetComponent<Animation>().Play("SuccessPop");
                }
            }
        }
      
        go.GetComponent<Image>().color = Color.white;
    }

    void CheckButtons()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("True"))
        {
            buttons.Add(obj);
        }

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("False"))
        {
            buttons.Add(obj);
        }
    }

    public void _Back()
    {
        BackSFX();
        SceneManager.LoadScene("Menu");
    }

    public void _Retry()
    {
        PressSFX();
        SceneManager.LoadScene("Y6 - Data Handling Quiz");
    }

    public void _BackAR()
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
