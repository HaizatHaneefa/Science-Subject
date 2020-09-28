using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    [SerializeField] private NOS nos;
    [SerializeField] private CarMovemtnController carController;

    [SerializeField] public float _timer, _nosBoost;
    [SerializeField] public bool isBoost, isReduce;

    [SerializeField] private Camera mainCam, inCam, rearCam;
    bool isCam;

    [SerializeField] float minFOV, maxFOV;
    [SerializeField] Rigidbody car;

    [SerializeField] GameObject pauseCanvas;
    [SerializeField] Button pauseButton;

    [SerializeField] RawImage rearImage;

    //[SerializeField] GameObject line;
    //[SerializeField] public bool[] lap;
    [SerializeField] GameObject gameEndPop;
    [SerializeField] GameObject winButton, lostButton;

    public int laps;

    [SerializeField] private TextMeshProUGUI playerTimeText, AITimeText;

    bool isRacing;

    [SerializeField] public float playerTime, AITime;
    private void Start()
    {
        winButton.SetActive(false);
        lostButton.SetActive(false);

        //line.SetActive(false);
        gameEndPop.SetActive(false);

        carController = GameObject.FindGameObjectWithTag("Car").GetComponent<CarMovemtnController>();

        _nosBoost = 10f;

        inCam.enabled = false;
        rearImage.enabled = false;

        pauseCanvas.SetActive(false);

        isRacing = true;
    }

    private void Update()
    {
        playerTimeText.text = playerTime.ToString("F2");
        AITimeText.text = AITime.ToString("F2");

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
        if (laps < 2)
        {
            laps += 1;
        }
        else if (laps == 2)
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
