using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlantsAR : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    float RotX, RotY, RotZ;

    [SerializeField] private GameObject GO;

    int cur;

    [SerializeField] private GameObject quizButton, gameButton;

    //void Start()
    //{
    //    quizButton.SetActive(false);
    //}

    //void Update()
    //{
        //if (Input.touchCount == 1)
        //{
        //    Touch touch0 = Input.GetTouch(0);

        //    if (touch0.phase == TouchPhase.Moved)
        //    {
        //        RotX += Input.GetTouch(0).deltaPosition.y * rotationSpeed;
        //        RotY += Input.GetTouch(0).deltaPosition.x * rotationSpeed;

        //        RotX = Mathf.Clamp(RotX, -30, 30);
        //        RotY = Mathf.Clamp(RotY, -30, 30);

        //        GO.transform.eulerAngles = new Vector3(RotX, -RotY, 0);
        //    }
        //}

        //if (cur != 0)
        //{
        //    quizButton.SetActive(true);
        //}
    //}

    //public void _Light()
    //{
    //    cur = 1;
    //}

    //public void _Gravity()
    //{
    //    cur = 2;
    //}

    //public void _Water()
    //{
    //    cur = 3;
    //}

    //public void _Touch()
    //{
    //    cur = 4;
    //}

    //public void BackToMenu()
    //{
    //    SceneManager.LoadScene("Menu");
    //}

    //public void ToQuiz()
    //{
    //    if (cur == 1) // light
    //    {
    //        SceneManager.LoadScene("Plant-Light-Question");
    //    }
    //    if (cur == 2) // gravity
    //    {
    //        SceneManager.LoadScene("Plant-Gravity");
    //    }
    //    if (cur == 3) // water
    //    {
    //        SceneManager.LoadScene("Plant-Water");
    //    }
    //    if (cur == 4) // touch
    //    {
    //        SceneManager.LoadScene("Plant-Touch");
    //    }
    //}

    //public void ToGame()
    //{
    //    SceneManager.LoadScene("Plant-Game");
    //}

    //public void ToMenu()
    //{
    //    SceneManager.LoadScene("Menu");
    //}
}
