using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.SceneManagement;

public class myCarController : MonoBehaviour
{
    //[SerializeField] private NOS nos;
    [SerializeField] private CarController carController;
    //[SerializeField] private CarSelectionData carSelect;
    //[SerializeField] private MeshFilter carMesh;

    [SerializeField] private Camera mainCam, inCam, rearCam;

    [SerializeField] private GameObject[] car;
    [SerializeField] private GameObject selectedCar;
    [SerializeField] private Transform carSpwn;
    //[SerializeField] private 

    [SerializeField] Button pauseButton;

    [SerializeField] RawImage rearImage;

    [SerializeField] GameObject winButton, lostButton, startPop, startText, gameEndPop, pauseCanvas;
    public GameObject enemyMarkerGO;

    [SerializeField] private TextMeshProUGUI playerTimeText, lapText, speedmeterText, winLoseText;

    [SerializeField] public float minFOV, maxFOV, _timer, _nosBoost, realSpeed;

    [SerializeField] public bool isBoost, isReduce;

    [SerializeField] private float playerTime;
    //[SerializeField] private MeshFilter[] carMeshFilter;

    bool isCam;
    bool isRacing;
    bool isStarting;

    public int laps;
    public int enemyLaps;

    int timer;
    int[] placerNum;

    private void Start()
    {
        mainCam.GetComponent<CarFollowCamera>().enabled = true;

        //carSelect = GameObject.FindGameObjectWithTag("Respawn").GetComponent<CarSelectionData>();

        carController = GameObject.FindGameObjectWithTag("Car").GetComponent<CarController>();
        //speedmeterText.text = carController.testSpeed.ToString("F0");

        timer = 3;
        Time.timeScale = 0f;

        laps = 1;
        enemyLaps = 1;

        winButton.SetActive(false); // if win
        lostButton.SetActive(false); // if lose, i doubt it
        startText.SetActive(false); // timertext
        gameEndPop.SetActive(false); // gameend thing

        _nosBoost = 10f;

        inCam.enabled = false;
        rearImage.enabled = false;

        pauseCanvas.SetActive(false);

        isRacing = true;
    }

    private void Update()
    {
        if (isStarting)
        {
            playerTime += Time.deltaTime;

            int seconds = (int)(playerTime % 60);
            int minutes = (int)(playerTime / 60);

            string playertimerString = string.Format("{0:0}:{1:00}", minutes, seconds);
            playerTimeText.text = playertimerString; // time format for player

            lapText.text = laps + "/3";
            speedmeterText.text = carController.testSpeed.ToString("F0");

            //if (_timer >= 3.0f || _timer == 0)
            //{
            //    isBoost = false;
            //    _timer = 0f;
            //    mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, minFOV, Time.deltaTime);
            //}
        }
    }

    public void StartGame()
    {
        StartCoroutine(WaitToGetReady());
        startPop.SetActive(false);

        isStarting = true;
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
            SceneManager.LoadSceneAsync("Y6 - Speed Race");
        }
        else if (index == 2)
        {
            SceneManager.LoadSceneAsync("Menu"); // should be back to AR
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
            winButton.SetActive(true);
            winLoseText.text = "Win!"; 
            isRacing = false;
        }
    }

    IEnumerator EndTheGame()
    {
        gameEndPop.SetActive(true);
        gameEndPop.transform.GetChild(0).GetComponent<Animation>().Play("GameOverPop");

        yield return new WaitForSeconds(1f);

        Time.timeScale = 0f;
    }

    public void EnemyLaps()
    {
        if (enemyLaps < 3)
        {
            enemyLaps += 1;
        }
        else if (enemyLaps == 3)
        {
            StartCoroutine(EndTheGame());
            winLoseText.text = "Lose!";
            lostButton.SetActive(true);
        }
    }
}




//int _seconds = (int)(AITime % 60);
//int _minutes = (int)(AITime / 60);

//string AItimerString = string.Format("{0:0}:{1:00}", _minutes, _seconds);
//AITimeText.text = AItimerString; // time format for AI

//realSpeed = car.velocity.magnitude * 3.6f; // speed on meter
//carController.testSpeed = car.velocity.magnitude * 3.6f; // speed on meter

