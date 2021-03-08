using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SpiracleManager : MonoBehaviour
{
    [SerializeField] private Canvas[] canvas;

    [SerializeField] private GameObject spiracleGO;
    [SerializeField] private GameObject[] GOComponents;

    bool isViewing;
    bool isntVoom;
    bool[] camView;

    [SerializeField] private Button[] answerButtons;
    [SerializeField] private Button[] quizButtons;

    [SerializeField] private float rotationSpeed;

    [SerializeField] private Camera[] camAngles;

    [SerializeField] private TextMeshProUGUI infoText;

    [SerializeField] private Image fadeImage;

    int whodat;

    [SerializeField] AudioSource aSource;
    [SerializeField] AudioClip[] clip;

    void Start()
    {
        for (int i = 0; i < camAngles.Length; i++)
        {
            camAngles[i].enabled = false;
            camAngles[0].enabled = true;
        }

        spiracleGO.SetActive(false);

        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].enabled = false;
            canvas[0].enabled = true;
        }

        infoText.enabled = false;

        isntVoom = true;

        camView = new bool[3];
    }

    void Update()
    {
        if (isViewing)
        if (Input.touchCount == 1)
        {
            Touch touch0 = Input.GetTouch(0);

            if (touch0.phase == TouchPhase.Moved && isntVoom)
            {
                spiracleGO.transform.Rotate(0f, -touch0.deltaPosition.x * rotationSpeed, 0f); // apply rotation to an object
            }
        }
    }

    public void View3D()
    {
        PressSFX();
        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].enabled = false;
            canvas[1].enabled = true;
        }

        isViewing = true;

        spiracleGO.SetActive(true);
    }

    public void Quiz()
    {
        PressSFX();

        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].enabled = false;
            canvas[2].enabled = true;
        }
    }

    public void BackToSpiracles()
    {
        BackSFX();
        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].enabled = false;
            canvas[0].enabled = true;
        }
    }

    public void Back()
    {
        BackSFX();

        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].enabled = false;
            canvas[0].enabled = true;
        }

        isViewing = false;

        spiracleGO.SetActive(false);
        spiracleGO.transform.rotation = new Quaternion(0, 0, 0, 0);

        for (int i = 0; i < camAngles.Length; i++)
        {
            camAngles[i].enabled = false;
            camAngles[0].enabled = true;
        }

        infoText.enabled = false;
    }

    public void _P()
    {
        StartCoroutine(ShowP());
        WrongSFX();
    }

    public void _Q()
    {
        StartCoroutine(ShowQ());
        WrongSFX();

    }

    public void _R()
    {
        StartCoroutine(ShowR());
        WrongSFX();

    }

    public void _S()
    {
        // betul
        StartCoroutine(ShowS());
        RightSFX();
    }

    #region quiz buttons
    IEnumerator ShowP()
    {
        answerButtons[0].GetComponent<Transform>().GetChild(0).GetComponent<TextMeshProUGUI>().text = "Lungs";
        answerButtons[0].GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(2);

        answerButtons[0].GetComponent<Transform>().GetChild(0).GetComponent<TextMeshProUGUI>().text = "P";
        answerButtons[0].GetComponent<Image>().color = Color.white;
    }

    IEnumerator ShowQ()
    {
        answerButtons[1].GetComponent<Transform>().GetChild(0).GetComponent<TextMeshProUGUI>().text = "Bronchi";
        answerButtons[1].GetComponent<Image>().color = Color.red;

        yield return new WaitForSeconds(2);

        answerButtons[1].GetComponent<Transform>().GetChild(0).GetComponent<TextMeshProUGUI>().text = "Q";
        answerButtons[1].GetComponent<Image>().color = Color.white;
    }

    IEnumerator ShowR()
    {
        answerButtons[2].GetComponent<Transform>().GetChild(0).GetComponent<TextMeshProUGUI>().text = "Larynx";
        answerButtons[2].GetComponent<Image>().color = Color.red;

        yield return new WaitForSeconds(2);

        answerButtons[2].GetComponent<Transform>().GetChild(0).GetComponent<TextMeshProUGUI>().text = "R";
        answerButtons[2].GetComponent<Image>().color = Color.white;
    }

    IEnumerator ShowS()
    {
        answerButtons[3].GetComponent<Transform>().GetChild(0).GetComponent<TextMeshProUGUI>().text = "Trachea";

        quizButtons[3].GetComponent<Image>().color = Color.green;

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < quizButtons.Length; i++)
        {
            quizButtons[i].GetComponent<Button>().interactable = false;
        }
    }
    #endregion

    public void ReturnToAR()
    {
        BackSFX();
        SceneManager.LoadScene("AR-Aspect");
    }

    IEnumerator DelayInfoText()
    {
        yield return new WaitForSeconds(0.5f);

        if (whodat == 1)
        {
            infoText.text = "If you look closely, the small spots are actually holes. These holes are called the spiracles.They are attached to tracheas inside the body.";
            infoText.enabled = true;
        }
        else if (whodat == 2)
        {
            infoText.text = "Air gets into the insect’s body through the spiracles and goes to tracheas. The tracheas then absorb the oxygen from the air.";
            infoText.enabled = true;
        }
        else if (whodat == 0)
        {
            infoText.enabled = false;
        }
    }

    #region camera angles
    public void dotView1()
    {
        PressSFX();
        for (int i = 0; i < camView.Length; i++)
        {
            camView[i] = false;
            camView[0] = true;
        }

        StartCoroutine(ChangeView());
        StartCoroutine(DelayInfoText());

        whodat = 0;
    }

    public void dotView2()
    {
        PressSFX();
        for (int i = 0; i < camView.Length; i++)
        {
            camView[i] = false;
            camView[1] = true;
        }

        StartCoroutine(ChangeView());
        StartCoroutine(DelayInfoText());

        whodat = 1;
    }

    public void dotView3()
    {
        PressSFX();
        for (int i = 0; i < camView.Length; i++)
        {
            camView[i] = false;
            camView[2] = true;
        }

        StartCoroutine(ChangeView());
        StartCoroutine(DelayInfoText());

        whodat = 2;
    }

    IEnumerator ChangeView()
    {
        isntVoom = false;

        fadeImage.GetComponent<Animation>().Play("Fade");

        yield return new WaitForSeconds(0.5f);

        if (camView[0])
        {
            for (int i = 0; i < camAngles.Length; i++)
            {
                camAngles[i].enabled = false;
                camAngles[0].enabled = true;
            }

            isntVoom = true;
        }
        else if (camView[1])
        {
            for (int i = 0; i < camAngles.Length; i++)
            {
                camAngles[i].enabled = false;
                camAngles[1].enabled = true;
            }

            isntVoom = false;
        }
        else if (camView[2])
        {
            for (int i = 0; i < camAngles.Length; i++)
            {
                camAngles[i].enabled = false;
                camAngles[2].enabled = true;
            }

            isntVoom = false;
        }
    }
    #endregion


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
