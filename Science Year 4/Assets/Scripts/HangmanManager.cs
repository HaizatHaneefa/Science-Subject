using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HangmanManager : MonoBehaviour
{
    public data data;

    [SerializeField] private TextMeshProUGUI hintText1;
    [SerializeField] private TextMeshProUGUI hintText2;
    [SerializeField] private TextMeshProUGUI hintText3;
    [SerializeField] private TextMeshProUGUI levelText;

    [Header("Game 1")]
    public GameObject[] game1Holder;

    [Header("Game 2")]
    public GameObject[] game2Holder;

    [Header("Game 3")]
    public GameObject[] game3Holder;

    [Header("Game 4")]
    public GameObject[] game4Holder;

    [Header("Game 5")]
    public GameObject[] game5Holder;

    [Header("UI Pops")]
    [SerializeField] private GameObject instructionPop;
    [SerializeField] private GameObject gameoverPop;
    [SerializeField] private GameObject successPop;
    [SerializeField] private GameObject gameEndPop;
    [SerializeField] private GameObject scoreboardPop;
    [SerializeField] private GameObject[] thingsToRemoveEarly;

    [Header("Hangman Images")]
    [SerializeField] private Image[] hangman;

    [Header("Stars")]
    [SerializeField] private Image[] star;
    [SerializeField] private Image[] starR1;
    [SerializeField] private Image[] starR2;
    [SerializeField] private Image[] starR3;
    [SerializeField] private Image[] starR4;
    [SerializeField] private Image[] starR5;

    public Image imageblocker;

    [Header("Bools")]
    [SerializeField] private bool[] buttonBool;
    [SerializeField] private bool success;
    public bool[] game;
    bool gameEnd;
    public bool test;

    [Header("Integers")]
    [SerializeField] private int[] score;
    [SerializeField] private int cur;
    public int hangmanCount = 6;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        levelText.text = "";

        for (int i = 0; i < star.Length; i++)
        {
            star[i].enabled = false;
        }

        score = new int[5];

        for (int i = 0; i < score.Length; i++)
        {
            score[i] = 6;
        }

        for (int i = 0; i < thingsToRemoveEarly.Length; i++)
        {
            thingsToRemoveEarly[i].SetActive(false);
        }

        game = new bool[5];
        buttonBool = new bool[game1Holder.Length];

        game[0] = true;

        gameoverPop.SetActive(false);
        successPop.SetActive(false);
        instructionPop.SetActive(true);
        gameEndPop.SetActive(false);
        scoreboardPop.SetActive(false);

        imageblocker.enabled = true;

        for (int i = 0; i < buttonBool.Length; i++)
        {
            buttonBool[i] = false;
            buttonBool[0] = true;
        }

        #region disabling other answer blocks
        for (int i = 0; i < game1Holder.Length; i++)
        {
            game1Holder[i].SetActive(false);
        }

        for (int i = 0; i < game2Holder.Length; i++)
        {
            game2Holder[i].SetActive(false);
        }

        for (int i = 0; i < game3Holder.Length; i++)
        {
            game3Holder[i].SetActive(false);
        }

        for (int i = 0; i < game4Holder.Length; i++)
        {
            game4Holder[i].SetActive(false);
        }

        for (int i = 0; i < game5Holder.Length; i++)
        {
            game5Holder[i].SetActive(false);
        }
        #endregion

        #region disabling other answer texts
        for (int i = 0; i < game1Holder.Length; i++)
        {
            game1Holder[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        }

        for (int i = 0; i < game2Holder.Length; i++)
        {
            game2Holder[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        }

        for (int i = 0; i < game3Holder.Length; i++)
        {
            game3Holder[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        }

        for (int i = 0; i < game4Holder.Length; i++)
        {
            game4Holder[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        }

        for (int i = 0; i < game5Holder.Length; i++)
        {
            game5Holder[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        }
        #endregion
    }
    void Update()
    {
        Hangman();

        #region condition for next level
        if (game1Holder[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
            game1Holder[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
            game1Holder[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
            game1Holder[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
            game1Holder[4].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
            game1Holder[5].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
            game1Holder[6].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
            game1Holder[7].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
            game1Holder[8].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
            game1Holder[9].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled)
        {
            success = true;

            for (int i = 0; i < game1Holder.Length; i++)
            {
                game1Holder[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                game1Holder[i].SetActive(false);
            }
        }

        if (game2Holder[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
         game2Holder[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
         game2Holder[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
         game2Holder[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
         game2Holder[4].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
         game2Holder[5].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
         game2Holder[6].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
         game2Holder[7].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
         game2Holder[8].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled)
        {
            success = true;

            for (int i = 0; i < game2Holder.Length; i++)
            {
                game2Holder[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                game2Holder[i].SetActive(false);
            }
        }

        if (game3Holder[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
         game3Holder[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
         game3Holder[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
         game3Holder[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
         game3Holder[4].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
         game3Holder[5].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled)
        {
            success = true;

            for (int i = 0; i < game3Holder.Length; i++)
            {
                game3Holder[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                game3Holder[i].SetActive(false);
            }
        }

        if (game4Holder[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
         game4Holder[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
         game4Holder[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
         game4Holder[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
         game4Holder[4].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled)
        {
            success = true;

            for (int i = 0; i < game4Holder.Length; i++)
            {
                game4Holder[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                game4Holder[i].SetActive(false);
            }
        }

        if (game5Holder[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
         game5Holder[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
         game5Holder[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
         game5Holder[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled)
        {
            gameEnd = true;

            for (int i = 0; i < game5Holder.Length; i++)
            {
                game5Holder[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                game5Holder[i].SetActive(false);
            }
        }
        #endregion

        if (success)
        {
            Success();
        }

        if (gameEnd)
        {
            GameEnd();
        }

        if (game[cur] && score[cur] >= 4)
        {
            for (int i = 0; i < star.Length; i++)
            {
                star[i].enabled = true;
            }
        }
        else if (game[cur] && score[cur] >= 2 && score[cur] <= 3)
        {
            for (int i = 0; i < star.Length; i++)
            {
                star[i].enabled = true;
                star[2].enabled = false;
            }
        }
        else if (game[cur] && score[cur] == 1)
        {
            for (int i = 0; i < star.Length; i++)
            {
                star[i].enabled = true;
                star[2].enabled = false;
                star[1].enabled = false;
            }
        }

        #region scoreboard star calculator
        // round 1
        if (score[0] >= 4)
        {
            for (int i = 0; i < star.Length; i++)
            {
                starR1[i].enabled = true;
            }
        }
        else if (score[0] <= 3 && score[0] >= 2)
        {
            for (int i = 0; i < star.Length; i++)
            {
                starR1[i].enabled = true;
                starR1[2].enabled = false;
            }
        }
        else if (score[0] == 1)
        {
            for (int i = 0; i < star.Length; i++)
            {
                starR1[i].enabled = true;
                starR1[2].enabled = false;
                starR1[1].enabled = false;
            }
        }

        // round 2
        if (score[1] >= 4)
        {
            for (int i = 0; i < star.Length; i++)
            {
                starR2[i].enabled = true;
            }
        }
        else if (score[1] <= 3 && score[1] >= 2)
        {
            for (int i = 0; i < star.Length; i++)
            {
                starR2[i].enabled = true;
                starR2[2].enabled = false;
            }
        }
        else if (score[1] == 1)
        {
            for (int i = 0; i < star.Length; i++)
            {
                starR2[i].enabled = true;
                starR2[2].enabled = false;
                starR2[1].enabled = false;
            }
        }

        // round 3
        if (score[2] >= 4)
        {
            for (int i = 0; i < star.Length; i++)
            {
                starR3[i].enabled = true;
            }
        }
        else if (score[2] <= 3 && score[2] >= 2)
        {
            for (int i = 0; i < star.Length; i++)
            {
                starR3[i].enabled = true;
                starR3[2].enabled = false;
            }
        }
        else if (score[2] == 1)
        {
            for (int i = 0; i < star.Length; i++)
            {
                starR3[i].enabled = true;
                starR3[2].enabled = false;
                starR3[1].enabled = false;
            }
        }

        // round 4
        if (score[3] >= 4)
        {
            for (int i = 0; i < star.Length; i++)
            {
                starR4[i].enabled = true;
            }
        }
        else if (score[3] <= 3 && score[3] >= 2)
        {
            for (int i = 0; i < star.Length; i++)
            {
                starR4[i].enabled = true;
                starR4[2].enabled = false;
            }
        }
        else if (score[3] == 1)
        {
            for (int i = 0; i < star.Length; i++)
            {
                starR4[i].enabled = true;
                starR4[2].enabled = false;
                starR4[1].enabled = false;
            }
        }

        // round 5
        if (score[4] >= 4)
        {
            for (int i = 0; i < star.Length; i++)
            {
                starR5[i].enabled = true;
            }
        }
        else if (score[4] <= 3 && score[4] >= 2)
        {
            for (int i = 0; i < star.Length; i++)
            {
                starR5[i].enabled = true;
                starR5[2].enabled = false;
            }
        }
        else if (score[4] == 1)
        {
            for (int i = 0; i < star.Length; i++)
            {
                starR5[i].enabled = true;
                starR5[2].enabled = false;
                starR5[1].enabled = false;
            }
        }
        #endregion
    }

    #region button functions
    // when user fails the level
    public void Retry()
    {
        PressSFX();
        hangmanCount = 6;

        imageblocker.enabled = false;

        if (game[0])
        {
            gameoverPop.SetActive(false);

            for (int i = 0; i < game1Holder.Length; i++)
            {
                game1Holder[i].SetActive(true);
            }

            for (int i = 0; i < game1Holder.Length; i++)
            {
                game1Holder[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }

            score[cur] = 6;
        }
        else if (game[1])
        {
            gameoverPop.SetActive(false);

            for (int i = 0; i < game2Holder.Length; i++)
            {
                game2Holder[i].SetActive(true);
            }

            for (int i = 0; i < game2Holder.Length; i++)
            {
                game2Holder[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }

            score[cur] = 6;
        }
        else if (game[2])
        {
            gameoverPop.SetActive(false);

            for (int i = 0; i < game3Holder.Length; i++)
            {
                game3Holder[i].SetActive(true);
            }

            for (int i = 0; i < game3Holder.Length; i++)
            {
                game3Holder[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }

            score[cur] = 6;
        }
        else if (game[3])
        {
            gameoverPop.SetActive(false);

            for (int i = 0; i < game4Holder.Length; i++)
            {
                game4Holder[i].SetActive(true);
            }

            for (int i = 0; i < game4Holder.Length; i++)
            {
                game4Holder[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }

            score[cur] = 6;
        }
        else if (game[4])
        {
            gameoverPop.SetActive(false);

            for (int i = 0; i < game5Holder.Length; i++)
            {
                game5Holder[i].SetActive(true);
            }

            for (int i = 0; i < game5Holder.Length; i++)
            {
                game5Holder[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }

            score[cur] = 6;
        }
    }

    // going back to AR scene
    public void Quit()
    {
        BackSFX();
        SceneManager.LoadScene("AR-Aspect");
    }

    void GameEnd()
    {
        gameEndPop.SetActive(true);
        imageblocker.enabled = true;
        gameEnd = false;

        gameEndPop.GetComponent<Animation>().Play("GameEndPop");
    }
    // start playing the game
    public void StartGame()
    {
        PressSFX();
        for (int i = 0; i < thingsToRemoveEarly.Length; i++)
        {
            thingsToRemoveEarly[i].SetActive(true);
        }

        instructionPop.SetActive(false);
        imageblocker.enabled = false;

        hintText1.text = data.d1.hint1;
        hintText2.text = data.d1.hint2;
        hintText3.text = data.d1.hint3;

        for (int i = 0; i < game1Holder.Length; i++)
        {
            game1Holder[i].SetActive(true);
        }

        game1Holder[0].transform.parent.GetComponent<Animation>().Play("Q1");

        levelText.text = "Level 1";
    }

    // happens when user succesfully completed the current level
    void Success()
    {
        RightSFX();
        successPop.SetActive(true);
        imageblocker.enabled = true;

        successPop.GetComponent<Animation>().Play("SuccessPop");

        success = false;
    }

    public void ReturnToAR()
    {
        BackSFX();
        SceneManager.LoadScene("AR-Aspect");
    }

    public void Home()
    {
        BackSFX();
        SceneManager.LoadScene("Menu");
    }

    public void ReturnTopic()
    {
        BackSFX();
        SceneManager.LoadScene("Menu");
    }

    public void ShowScore()
    {
        PressSFX();
        gameEndPop.SetActive(false);
        scoreboardPop.SetActive(true);

        scoreboardPop.GetComponent<Animation>().Play("scoreboard_anim");
    }

    public void BackToGameEnd()
    {
        BackSFX();
        gameEndPop.SetActive(true);
        scoreboardPop.SetActive(false);

        gameEndPop.GetComponent<Animation>().Play("GameEndPop");
    }

    // level changer of the game
    public void GameChanger()
    {
        PressSFX();
        if (game[0])
        {
            for (int i = 0; i < game1Holder.Length; i++)
            {
                game1Holder[i].SetActive(false);
            }

            for (int i = 0; i < game2Holder.Length; i++)
            {
                game2Holder[i].SetActive(true);
            }

            for (int i = 0; i < game1Holder.Length; i++)
            {
                game1Holder[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }

            hangmanCount = 6;

            successPop.SetActive(false);

            success = false;

            imageblocker.enabled = false;

            for (int i = 0; i < game.Length; i++)
            {
                game[i] = false;
                game[1] = true;
            }

            hintText1.text = data.d2.hint1;
            hintText2.text = data.d2.hint2;
            hintText3.text = data.d2.hint3;

            cur = cur + 1;

            game2Holder[0].transform.parent.GetComponent<Animation>().Play("Q2");

            levelText.text = "Level 2";
        }
        else if (game[1])
        {
            for (int i = 0; i < game2Holder.Length; i++)
            {
                game2Holder[i].SetActive(false);
            }

            for (int i = 0; i < game3Holder.Length; i++)
            {
                game3Holder[i].SetActive(true);
            }

            for (int i = 0; i < game2Holder.Length; i++)
            {
                game2Holder[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }

            hangmanCount = 6;

            successPop.SetActive(false);

            success = false;

            imageblocker.enabled = false;

            for (int i = 0; i < game.Length; i++)
            {
                game[i] = false;
                game[2] = true;
            }

            hintText1.text = data.d3.hint1;
            hintText2.text = data.d3.hint2;
            hintText3.text = data.d3.hint3;

            cur = cur + 1;

            game3Holder[0].transform.parent.GetComponent<Animation>().Play("Q3");

            levelText.text = "Level 3";
        }
        else if (game[2])
        {
            for (int i = 0; i < game3Holder.Length; i++)
            {
                game3Holder[i].SetActive(false);
            }

            for (int i = 0; i < game4Holder.Length; i++)
            {
                game4Holder[i].SetActive(true);
            }

            for (int i = 0; i < game3Holder.Length; i++)
            {
                game3Holder[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }

            hangmanCount = 6;

            successPop.SetActive(false);

            success = false;

            imageblocker.enabled = false;

            for (int i = 0; i < game.Length; i++)
            {
                game[i] = false;
                game[3] = true;
            }

            hintText1.text = data.d4.hint1;
            hintText2.text = data.d4.hint2;
            hintText3.text = data.d4.hint3;

            cur = cur + 1;

            game4Holder[0].transform.parent.GetComponent<Animation>().Play("Q4");

            levelText.text = "Level 4";
        }
        else if (game[3])
        {
            for (int i = 0; i < game4Holder.Length; i++)
            {
                game4Holder[i].SetActive(false);
            }

            for (int i = 0; i < game5Holder.Length; i++)
            {
                game5Holder[i].SetActive(true);
            }

            for (int i = 0; i < game4Holder.Length; i++)
            {
                game4Holder[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }

            hangmanCount = 6;

            successPop.SetActive(false);

            success = false;

            imageblocker.enabled = false;

            for (int i = 0; i < game.Length; i++)
            {
                game[i] = false;
                game[4] = true;
            }

            hintText1.text = data.d5.hint1;
            hintText2.text = data.d5.hint2;
            hintText3.text = data.d5.hint3;

            cur = cur + 1;

            game5Holder[0].transform.parent.GetComponent<Animation>().Play("Q5");

            levelText.text = "Level 5";
        }
    }
    #endregion

    // case for user error when guessing
    void Hangman()
    {
        switch (hangmanCount)
        {
            case 6:
                for (int i = 0; i < hangman.Length; i++)
                {
                    hangman[i].enabled = true;
                }
                break;

            case 5:
                for (int i = 0; i < hangman.Length; i++)
                {
                    hangman[i].enabled = true;
                    hangman[5].enabled = false;
                }

                if (game[cur] && test)
                {
                    score[cur] = score[cur] - 1;

                    test = false;
                }
                break;

            case 4:
                for (int i = 0; i < hangman.Length; i++)
                {
                    hangman[i].enabled = true;
                    hangman[4].enabled = false;
                    hangman[5].enabled = false;
                }

                if (game[cur] && test)
                {
                    score[cur] = score[cur] - 1;
                    test = false;
                }
                break;

            case 3:
                for (int i = 0; i < hangman.Length; i++)
                {
                    hangman[i].enabled = true;
                    hangman[3].enabled = false;
                    hangman[4].enabled = false;
                    hangman[5].enabled = false;
                }

                if (game[cur] && test)
                {
                    score[cur] = score[cur] - 1;
                    test = false;
                }
                break;

            case 2:
                for (int i = 0; i < hangman.Length; i++)
                {
                    hangman[i].enabled = true;
                    hangman[2].enabled = false;
                    hangman[3].enabled = false;
                    hangman[4].enabled = false;
                    hangman[5].enabled = false;
                }

                if (game[cur] && test)
                {
                    score[cur] = score[cur] - 1;

                    test = false;
                }
                break;

            case 1:
                for (int i = 0; i < hangman.Length; i++)
                {
                    hangman[i].enabled = false;
                    hangman[0].enabled = true;
                }

                if (game[cur] && test)
                {
                    score[cur] = score[cur] - 1;

                    test = false;
                }
                break;

            case 0:
                for (int i = 0; i < hangman.Length; i++)
                {
                    hangman[i].enabled = false;
                }

                if (game[cur] && test)
                {
                    imageblocker.enabled = true;
                    gameoverPop.SetActive(true);
                    gameoverPop.GetComponent<Animation>().Play("GameOverPop");

                    test = false;

                    WrongSFX();
                }
                break;
        }
    }


    // ---------------------------------------  sound effects ---------------------------------------  //

    public void PressSFX()
    {
        aSource.clip = clip[0];
        aSource.Play();
    }

    public void WrongPressSFX()
    {
        aSource.clip = clip[4];
        aSource.Play();
    }

    public void BackSFX()
    {
        aSource.clip = clip[1];
        aSource.Play();
    }

    public void RightSFX()
    {
        aSource.clip = clip[2];
        aSource.Play();
    }

    public void WrongSFX()
    {
        aSource.clip = clip[3];
        aSource.Play();
    }
}
