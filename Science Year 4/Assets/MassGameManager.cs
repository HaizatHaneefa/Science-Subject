using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MassGameManager : MonoBehaviour
{
    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    [SerializeField] private int[] value;
    int cur, modeInt;

    [SerializeField] private List<int> sortValue;

    [SerializeField] private TextMeshProUGUI[] itemValue, valueCounter;
    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField] private Button checkButton;

    [SerializeField] private GameObject[] disableFirst;
    [SerializeField] private GameObject introPop, yayPop, endPop;

    string[] wakakka;

    float timer;

    bool isTiming;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        wakakka = new string[5];
        value = new int[5];

        for (int i = 0; i < valueCounter.Length; i++)
        {
            valueCounter[i].text = "";
        }

        for (int i = 0; i < disableFirst.Length; i++)
        {
            disableFirst[i].SetActive(false);
        }

        introPop.SetActive(true);
        yayPop.SetActive(false);
        endPop.SetActive(false);

        checkButton.interactable = false;
    }

    public void _Mode(int index)
    {
        PressSFX();

        introPop.SetActive(false);

        isTiming = true;

        for (int i = 0; i < disableFirst.Length; i++)
        {
            disableFirst[i].SetActive(true);
        }

        if (index == 0)
        {
            modeInt = 1;
        }
        else if (index == 1)
        {
            modeInt = 2;
        }

        GetValue();

        timer = 60f;
    }

    void GetValue()
    {
        for (int i = 0; i < value.Length; i++)
        {
            value[i] = Random.Range(10, 100);
            itemValue[i].text = value[i].ToString() + "g";

            sortValue.Add(value[i]);
        }

        sortValue.Sort();

        if (modeInt == 1)
        {
            return;
        }
        else if (modeInt == 2)
        {
            sortValue.Reverse();
        }
    }

    public void _ChooseValue()
    {
        PressSFX();

        if (cur == 5)
        {
            return;
        }

        GameObject go = EventSystem.current.currentSelectedGameObject;

        valueCounter[cur].text = go.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;

        cur += 1;
    }

    public void _CheckAnswer()
    {
        checkButton.interactable = false;

        for (int i = 0; i < wakakka.Length; i++)
        {
            wakakka[i] = sortValue[i].ToString() + "g";
        }

       if (wakakka[0] == valueCounter[0].text &&
       wakakka[1] == valueCounter[1].text &&
       wakakka[2] == valueCounter[2].text &&
       wakakka[3] == valueCounter[3].text &&
       wakakka[4] == valueCounter[4].text)
        {
            RightSFX();
            StartCoroutine(YayPop());
        }
        else
        {
            WrongPressSFX();
            for (int i = 0; i < valueCounter.Length; i++)
            {
                valueCounter[i].text = "";
            }

            cur = 0;

            Debug.Log("j");
        }
    }

    void NextQuestion()
    {
        cur = 0;

        checkButton.interactable = false;

        sortValue.Clear();

        for (int i = 0; i < value.Length; i++)
        {
            value[i] = Random.Range(10, 100);
            itemValue[i].text = value[i].ToString() + "g";

            sortValue.Add(value[i]);
        }

        for (int i = 0; i < valueCounter.Length; i++)
        {
            valueCounter[i].text = "";
        }

        sortValue.Sort();

        if (modeInt == 1)
        {
            return;
        }
        else if (modeInt == 2)
        {
            sortValue.Reverse();
        }
    }

    public void _Reset()
    {
        for (int i = 0; i < valueCounter.Length; i++)
        {
            valueCounter[i].text = "";
        }

        cur = 0;
    }

    void EndGame()
    {
        endPop.SetActive(true);

        timerText.text = "00:00";
    }

    IEnumerator YayPop()
    {
        yayPop.SetActive(true);
        yayPop.GetComponent<Animation>().Play("GameOverPop");

        yield return new WaitForSeconds(0.8f);

        NextQuestion();
        yayPop.SetActive(false);
    }

    public void _Back()
    {
        BackSFX();
        SceneManager.LoadScene("Menu");
    }

    public void _Retry()
    {
        PressSFX();
        SceneManager.LoadScene("Y5 - Mass Game");
    }

    void Update()
    {
        if (valueCounter[4].text != "")
        {
            checkButton.interactable = true;
        }

        if (isTiming)
        {
            timer -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(timer / 60F);
            int seconds = Mathf.FloorToInt(timer - minutes * 60);
            string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

            timerText.text = niceTime;
        }

        if (timer <= 0 && isTiming)
        {
            EndGame();
            isTiming = false;
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

    public void EndSFX() // wrong answer
    {
        aSource.clip = clip[5];
        aSource.Play();
    }
}
