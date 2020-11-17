using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ConstellationQuiz : MonoBehaviour
{
    [SerializeField] public bool[] secondBool;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    [SerializeField] public Sprite[] rightWrongSprite;
    [SerializeField] public GameObject endpop, secB;
    [SerializeField] private GameObject[] secA;

    int cur;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        secondBool = new bool[7];
        secondBool[0] = true;


        endpop.SetActive(false);
        secB.SetActive(false);

        for (int i = 0; i < secA.Length; i++)
        {
            secA[i].SetActive(false);
            secA[0].SetActive(true);
            secA[0].GetComponent<Animation>().Play("SuccessPop");
        }
    }

    // ---------------- button functions ---------------- //
    public void RightAnswer(int index)
    {
        cur = index;

        StartCoroutine(RightColor());
        StartCoroutine(DisableButtons());
    }

    public void WrongAnswer()
    {
        StartCoroutine(WrongColor());
        StartCoroutine(DisableButtons());
    }

    // ---------------- Coroutines ---------------- //
    IEnumerator RightColor()
    {
        RightSFX();
        Image img = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();

        img.color = Color.green;

        yield return new WaitForSeconds(1f);

        img.color = Color.white;

        if (cur != 10)
        {
            for (int i = 0; i < secA.Length; i++)
            {
                secA[i].SetActive(false);
                secA[cur].SetActive(true);
                secA[cur].GetComponent<Animation>().Play("SuccessPop");
            }
        }
        else if (cur == 10)
        {
            for (int i = 0; i < secA.Length; i++)
            {
                secA[i].SetActive(false);
            }

            secB.SetActive(true);
        }
    }

    // abbcacbcab
    IEnumerator WrongColor()
    {
        WrongPressSFX();

        Image img = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();

        img.color = Color.red;

        yield return new WaitForSeconds(1f);

        img.color = Color.white;
    }

    IEnumerator DisableButtons()
    {
        GameObject[] butList;

        butList = GameObject.FindGameObjectsWithTag("Right");

        for (int i = 0; i < butList.Length; i++)
        {
            butList[i].GetComponent<Button>().interactable = false;
        }

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < butList.Length; i++)
        {
            butList[i].GetComponent<Button>().interactable = true;
        }
    }

    // ---------------- SFX ---------------- //
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
