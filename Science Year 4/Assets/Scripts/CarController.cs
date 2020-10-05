using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    [SerializeField] private NOS nos;
    [SerializeField] private CarMovemtnController carController;

    [SerializeField] private Camera mainCam, inCam, rearCam;

    [SerializeField] Rigidbody car;

    [SerializeField] Button pauseButton;

    [SerializeField] RawImage rearImage;

    [SerializeField] GameObject winButton, lostButton, startPop, startText, gameEndPop, pauseCanvas;

    [SerializeField] private TextMeshProUGUI playerTimeText, AITimeText, lapText, speedmeterText;

    [SerializeField] public float playerTime, AITime, minFOV, maxFOV, _timer, _nosBoost, realSpeed;

    [SerializeField] public bool isBoost, isReduce;

    bool isCam;
    bool isRacing;

    public int laps;
    int timer;
    int[] placerNum;

    private void Start()
    {
        timer = 3;
        Time.timeScale = 0f;

        laps = 1;

        winButton.SetActive(false); // if win
        lostButton.SetActive(false); // if lose, i doubt it
        startText.SetActive(false); // timertext
        gameEndPop.SetActive(false); // gameend thing

        carController = GameObject.FindGameObjectWithTag("Car").GetComponent<CarMovemtnController>();

        _nosBoost = 10f;

        inCam.enabled = false;
        rearImage.enabled = false;

        pauseCanvas.SetActive(false);

        isRacing = true;
    }

    private void Update()
    {
        int seconds = (int)(playerTime % 60);
        int minutes = (int)(playerTime / 60);

        string playertimerString = string.Format("{0:0}:{1:00}", minutes, seconds);
        playerTimeText.text = playertimerString; // time format for player

        int _seconds = (int)(AITime % 60);
        int _minutes = (int)(AITime / 60);

        string AItimerString = string.Format("{0:0}:{1:00}", _minutes, _seconds);
        AITimeText.text = AItimerString; // time format for AI

        realSpeed = car.velocity.magnitude * 3.6f; // speed on meter

        lapText.text = laps + "/3";
        speedmeterText.text = realSpeed.ToString("F0");

        if (isRacing)
        {
            playerTime += Time.deltaTime;
        }

        AITime += Time.deltaTime;

        if (isBoost)
        {
            carController.rightFrontW.motorTorque = carController.motorForce + _nosBoost;

            _timer += Time.deltaTime;
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, maxFOV, Time.deltaTime);
        }
        else if (isReduce)
        {
            StartCoroutine(Reduce());
        }

        if (_timer >= 3.0f || _timer == 0)
        {
            isBoost = false;
            _timer = 0f;
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, minFOV, Time.deltaTime);
        }
    }

    public void StartGame()
    {
        StartCoroutine(WaitToGetReady());
        startPop.SetActive(false);
    }

    IEnumerator WaitToGetReady()
    {
        startText.SetActive(true);
        startText.GetComponent<TextMeshProUGUI>().text = "" + 3;

        yield return WaitToResumeGame();

        startText.GetComponent<TextMeshProUGUI>().text = "" + 2;
        yield return WaitToResumeGame();

        startText.GetComponent<TextMeshProUGUI>().text = "" + 1;
        yield return WaitToResumeGame();

        Time.timeScale = 1f;

        startText.SetActive(false);
    }

    IEnumerator WaitToResumeGame()
    {
        float start = Time.realtimeSinceStartup;

        while (Time.realtimeSinceStartup < start + 1f)
        {
            yield return 0;
        }
    }

    IEnumerator Reduce()
    {
        carController.rightFrontW.motorTorque = carController.motorForce - 100f;

        yield return new WaitForSeconds(0.5f);

        carController.rightFrontW.motorTorque = carController.motorForce + 100f;

        isReduce = false;
    }

    public void ChangeCamera()
    {
        if (!isCam)
        {
            mainCam.enabled = false;
            inCam.enabled = true;

            rearImage.enabled = true;

            isCam = true;
        }
        else if (isCam)
        {
            mainCam.enabled = true;
            inCam.enabled = false;

            rearImage.enabled = false;

            isCam = false;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;

        pauseCanvas.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }

    public void PauseButtons(int index)
    {
        if (index == 0)
        {
            Time.timeScale = 1;
            pauseCanvas.SetActive(false);
            pauseButton.gameObject.SetActive(true);
        }
        else if (index == 1)
        {
            Debug.Log("game restarted");
        }
        else if (index == 2)
        {
            Debug.Log("game quit");
        }
    }

    public void EndGame()
    {
        if (laps < 3)
        {
            laps += 1;
        }
        else if (laps == 3)
        {
            StartCoroutine(EndTheGame());
            isRacing = false;
        }
    }

    IEnumerator EndTheGame()
    {
        gameEndPop.SetActive(true);
        gameEndPop.transform.GetChild(0).GetComponent<Animation>().Play("GameOverPop");

        yield return new WaitForSeconds(0.01f);

        if (playerTime < AITime)
        {
            winButton.SetActive(true);
            lostButton.SetActive(false);
        }
        else if (playerTime > AITime)
        {
            winButton.SetActive(false);
            lostButton.SetActive(true);
        }

        yield return new WaitForSeconds(2f);

        Time.timeScale = 0f;
    }
}

