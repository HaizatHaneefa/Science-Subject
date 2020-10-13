using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenuEarth : MonoBehaviour
{
    public void ToGameOne()
    {
        SceneManager.LoadScene("Y5 - C World Map"); // to game 1
    }

    public void ToGameTwo()
    {
        SceneManager.LoadScene("Y5 - Shadow Game"); // to game 2
    }

    public void ToQuiz()
    {
        SceneManager.LoadScene("Y5 - Earth Quiz"); // to AR
    }
}
