using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        carController = GameObject.FindGameObjectWithTag("Car").GetComponent<CarMovemtnController>();

        _nosBoost = 10f;

        inCam.enabled = false;

        rearImage.enabled = false;

        //pauseCanvas.GetComponent<Image>().enabled = false;
        pauseCanvas.SetActive(false);
    }

    private void Update()
    {
        Debug.Log(carController.leftFrontW.motorTorque);

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
        Debug.Log("qqqq");

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
}
