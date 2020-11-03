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

    [SerializeField] private TextMeshProUGUI questiontext;

    [SerializeField] private GameObject[] questionGroup;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    int cur;

    List<GameObject> l = new List<GameObject>();

    void Start()
    {
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

    public void BackToMenu()
    {
        BackSFX();
        SceneManager.LoadScene("Menu");
    }

    IEnumerator GetReaction()
    {
        Image img = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();

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

        img.color = Color.white;

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
