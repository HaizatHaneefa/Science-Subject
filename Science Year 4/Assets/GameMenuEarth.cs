using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenuEarth : MonoBehaviour
{
    public void ToGameOne()
    {
        SceneManager.LoadScene(""); // to game 1
    }

    public void ToGameTwo()
    {
        SceneManager.LoadScene(""); // to game 2
    }

    public void ToAR()
    {
        SceneManager.LoadScene(""); // to AR
    }
}
