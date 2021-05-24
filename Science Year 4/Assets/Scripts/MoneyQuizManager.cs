using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MoneyQuizManager : MonoBehaviour
{
    [SerializeField] private GameObject[] stuff;

    [SerializeField] public int cur;

    [SerializeField] public Sprite[] sprite;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    public List<GameObject> l = new List<GameObject>();
    public List<GameObject> ly = new List<GameObject>();

    [SerializeField] private TextMeshProUGUI instructionText;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("True"))
        {
            l.Add(go);
        }

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("False"))
        {
            l.Add(go);
        }

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Right"))
        {
            ly.Add(go);
        }

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Left"))
        {
            ly.Add(go);
        }

        for (int i = 0; i < stuff.Length; i++)
        {
            stuff[i].SetActive(false);
            stuff[cur].SetActive(true);
            stuff[cur].GetComponent<Animation>().Play("SuccessPop");
        }
    }

    // -------------------------- Functions ------------------------- //
    public void _Button()
    {
        StartCoroutine(Button());
    }

    public void ThisQuestion()
    {
        if (cur == 10)
        {
            instructionText.enabled = true;
        }
        else if (cur == 15)
        {
            stuff[15].GetComponent<Animation>().Play("EndGamePop-NEW");
            return;
        }

        for (int i = 0; i < stuff.Length; i++)
        {
            stuff[i].SetActive(false);
            stuff[cur].SetActive(true);
        }
    }

    // -------------------------- Coroutines ------------------------- //
    IEnumerator Button()
    {
        Image img = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();

        foreach (GameObject go in l)
        {
            go.GetComponent<Button>().interactable = false;
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

        yield return new WaitForSeconds(1f);

        foreach (GameObject go in l)
        {
            go.GetComponent<Button>().interactable = true;
        }

        img.color = Color.white;

        if (cur == 5)
        {
            for (int i = 0; i < stuff.Length; i++)
            {
                stuff[i].SetActive(false);
                stuff[5].SetActive(true);
            }

            instructionText.enabled = false;
        }
        else if (cur < 5)
        {
            if (img.gameObject.tag == "True")
            {
                for (int i = 0; i < stuff.Length; i++)
                {
                    stuff[i].SetActive(false);
                    stuff[cur].SetActive(true);
                    stuff[cur].GetComponent<Animation>().Play("SuccessPop");
                }
            }
        }
    }

    // -------------------------- Scene Loaders ------------------------- //
    public void _Retry()
    {
        PressSFX();
        SceneManager.LoadScene("Y4 - Money Quiz");
    }

    public void _BacktoAR()
    {
        BackSFX();
        SceneManager.LoadScene("Menu");
    }

    // -------------------------- SFX ------------------------- //
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
