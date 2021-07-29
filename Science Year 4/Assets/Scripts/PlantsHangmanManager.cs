using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

public class PlantsHangmanManager : MonoBehaviour
{
    PlantsClass plantClass;

    public GameObject[] word1;
    public GameObject[] word2;
    public GameObject[] word3;
    public GameObject[] word4;
    public GameObject[] word5;
    public GameObject[] word6;
    public GameObject[] word7;
    public GameObject[] word8;
    public GameObject[] word9;
    public GameObject[] word10;
    public GameObject[] word11;
    public GameObject[] word12;
    public GameObject[] word13;
    public GameObject[] word14;
    public GameObject[] word15;
    public GameObject[] word16;
    public GameObject[] word17;
    public GameObject[] word18;
    public GameObject[] word19;
    public GameObject[] word20;
    public GameObject[] thingsToRemoveEarly;

    public GameObject successPop;
    public GameObject introPop;
    public GameObject gameoverPop;
    public GameObject gameEndPop;
    public GameObject scoreboardPop;

    public bool[] phase;

    public Image[] hangman;
    public Image[] star;
    public Image[] starR1;
    public Image[] starR2;
    public Image[] starR3;
    public Image[] starR4;
    public Image[] starR5;

    public Image imageblocker;

    public bool test;
    bool success;

    public int hangmanCount = 6;
    public int score;
    public int[] scoreRound;
    int round;
    int levelSelector;
    int level;

    int[] intArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19};
   
    public TextMeshProUGUI hintText;
    [SerializeField] private TextMeshProUGUI levelText;
    public List<int> intList;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    private void Start()
    {
        aSource = GetComponent<AudioSource>();

        for (int i = 0; i < thingsToRemoveEarly.Length; i++)
        {
            thingsToRemoveEarly[i].SetActive(false);
        }

        level = 1;
        levelText.text = "";

        imageblocker.enabled = true;

        plantClass = GetComponent<PlantsClass>();

        successPop.SetActive(false);
        gameoverPop.SetActive(false);
        gameEndPop.SetActive(false);
        scoreboardPop.SetActive(false);
        introPop.SetActive(true);

        introPop.GetComponent<Animation>().Play("Intro_Anim");

        phase = new bool[20];

        scoreRound = new int[5];
         
        score = 6;

        for (int i = 0; i < hangman.Length; i++)
        {
            hangman[i].enabled = false;
        }

        round = 1;

        intList.AddRange(intArray);
    }

    private void LateUpdate()
    {
        #region success condition
        if (word1[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
            word1[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
            word1[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
            word1[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
            word1[4].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
            word1[5].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
            word1[6].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
            word1[7].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
            word1[8].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
            word1[9].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
            word1[10].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled)
            {
                success = true;

                for (int i = 0; i < word1.Length; i++)
                {
                    word1[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                    word1[i].SetActive(false);
                }
            }
        else if (word2[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word2[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word2[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word2[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word2[4].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled)
                {
                    success = true;

                    for (int i = 0; i < word2.Length; i++)
                    {
                        word2[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                        word2[i].SetActive(false);
                    }
                }
        else if (word3[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word3[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word3[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word3[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word3[4].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word3[5].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled)
                {
                    success = true;

                    for (int i = 0; i < word3.Length; i++)
                    {
                        word3[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                        word3[i].SetActive(false);
                    }
                }
        else if (word4[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word4[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word4[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word4[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word4[4].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word4[5].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled)
                {
                    success = true;

                    for (int i = 0; i < word4.Length; i++)
                    {
                        word4[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                        word4[i].SetActive(false);
                    }
                }
        else if (word5[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word5[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word5[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled)
                {
                    success = true;

                    for (int i = 0; i < word5.Length; i++)
                    {
                        word5[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                        word5[i].SetActive(false);
                    }
                }
        else if (word6[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word6[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word6[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word6[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word6[4].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word6[5].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word6[6].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled)
                {
                    success = true;

                    for (int i = 0; i < word6.Length; i++)
                    {
                        word6[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                        word6[i].SetActive(false);
                    }
                }
        else if (word7[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word7[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word7[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word7[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word7[4].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word7[5].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word7[6].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word7[7].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word7[8].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word7[9].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word7[10].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word7[11].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word7[12].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word7[13].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled)
                {
                    success = true;

                    for (int i = 0; i < word7.Length; i++)
                    {
                        word7[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                        word7[i].SetActive(false);
                    }
                }
        else if (word8[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word8[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word8[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word8[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word8[4].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled)
                {
                    success = true;

                    for (int i = 0; i < word8.Length; i++)
                    {
                        word8[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                        word8[i].SetActive(false);
                    }
                }
        else if (word9[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word9[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word9[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word9[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word9[4].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word9[5].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word9[6].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word9[7].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word9[8].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word9[9].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word9[10].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled)
                {
                    success = true;

                    for (int i = 0; i < word9.Length; i++)
                    {
                        word9[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                        word9[i].SetActive(false);
                    }
                }
        else if (word10[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word10[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word10[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word10[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word10[4].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word10[5].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word10[6].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word10[7].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word10[8].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word10[9].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word10[10].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled)
                {
                    success = true;

                    for (int i = 0; i < word10.Length; i++)
                    {
                        word10[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                        word10[i].SetActive(false);
                    }
                }
        else if (word11[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word11[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word11[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word11[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word11[4].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled)
                {
                    success = true;

                    for (int i = 0; i < word11.Length; i++)
                    {
                        word11[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                        word11[i].SetActive(false);
                    }
                }
        else if (word12[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word12[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word12[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word12[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word12[4].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled)
                {
                    success = true;

                    for (int i = 0; i < word12.Length; i++)
                    {
                        word12[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                        word12[i].SetActive(false);
                    }
                }
        else if (word13[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word13[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word13[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word13[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word13[4].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word13[5].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word13[6].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word13[7].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word13[8].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word13[9].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled)
                {
                    success = true;

                    for (int i = 0; i < word13.Length; i++)
                    {
                        word13[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                        word13[i].SetActive(false);
                    }
                }
        else if (word14[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word14[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word14[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word14[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word14[4].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word14[5].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled)
                {
                    success = true;

                    for (int i = 0; i < word14.Length; i++)
                    {
                        word14[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                        word14[i].SetActive(false);
                    }
                }
        else if (word15[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word15[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word15[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word15[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled)
                {
                    success = true;

                    for (int i = 0; i < word15.Length; i++)
                    {
                        word15[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                        word15[i].SetActive(false);
                    }
                }
        else if (word16[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word16[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word16[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word16[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word16[4].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word16[5].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word16[6].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled)
                {
                    success = true;

                    for (int i = 0; i < word16.Length; i++)
                    {
                        word16[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                        word16[i].SetActive(false);
                    }
                }
        else if (word17[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word17[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word17[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word17[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled)
                {
                    success = true;

                    for (int i = 0; i < word17.Length; i++)
                    {
                        word17[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                        word17[i].SetActive(false);
                    }
                }
        else if (word18[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word18[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word18[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word18[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word18[4].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word18[5].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled)
                {
                   success = true;

                    for (int i = 0; i < word18.Length; i++)
                    {
                        word18[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                        word18[i].SetActive(false);
                    }
                }
        else if (word19[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word19[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word19[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word19[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word19[4].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word19[5].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word19[6].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled)
                {
                    success = true;

                    for (int i = 0; i < word19.Length; i++)
                    {
                        word19[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                        word19[i].SetActive(false);
                    }
                }
        else if (word20[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word20[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word20[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word20[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word20[4].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word20[5].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word20[6].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled &&
                word20[7].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled)
                {
                    success = true;

                    for (int i = 0; i < word20.Length; i++)
                    {
                        word20[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                        word20[i].SetActive(false);
                    }
                }
        #endregion

        if (success)
        {
            Success();
        }

        if (phase[levelSelector] && score >= 4)
        {
            for (int i = 0; i < star.Length; i++)
            {
                star[i].enabled = true;
            }
        }
        else if (phase[levelSelector] && score >= 2 && score <= 3)
        {
            for (int i = 0; i < star.Length; i++)
            {
                star[i].enabled = true;
                star[2].enabled = false;
            }
        }
        else if (phase[levelSelector] && score == 1)
        {
            for (int i = 0; i < star.Length; i++)
            {
                star[i].enabled = true;
                star[2].enabled = false;
                star[1].enabled = false;
            }
        }

        if (scoreRound[0] >= 4)
        {
            for (int i = 0; i < starR1.Length; i++)
            {
                starR1[i].enabled = true;
            }
        }
        else if (scoreRound[0] <= 3 && scoreRound[0] >= 2)
        {
            for (int i = 0; i < starR1.Length; i++)
            {
                starR1[i].enabled = true;
                starR1[2].enabled = false;
            }
        }
        else if (scoreRound[0] == 1)
        {
            for (int i = 0; i < starR1.Length; i++)
            {
                starR1[i].enabled = true;
                starR1[2].enabled = false;
                starR1[1].enabled = false;
            }
        }

        // round 2
        if (scoreRound[1] >= 4)
        {
            for (int i = 0; i < starR2.Length; i++)
            {
                starR2[i].enabled = true;
            }
        }
        else if (scoreRound[1] <= 3 && scoreRound[1] >= 2)
        {
            for (int i = 0; i < starR2.Length; i++)
            {
                starR2[i].enabled = true;
                starR2[2].enabled = false;
            }
        }
        else if (scoreRound[1] == 1)
        {
            for (int i = 0; i < starR2.Length; i++)
            {
                starR2[i].enabled = true;
                starR2[2].enabled = false;
                starR2[1].enabled = false;
            }
        }

        // round 3
        if (scoreRound[2] >= 4)
        {
            for (int i = 0; i < starR3.Length; i++)
            {
                starR3[i].enabled = true;
            }
        }
        else if (scoreRound[2] <= 3 && scoreRound[1] >= 2)
        {
            for (int i = 0; i < starR3.Length; i++)
            {
                starR3[i].enabled = true;
                starR3[2].enabled = false;
            }
        }
        else if (scoreRound[2] == 1)
        {
            for (int i = 0; i < starR3.Length; i++)
            {
                starR3[i].enabled = true;
                starR3[2].enabled = false;
                starR3[1].enabled = false;
            }
        }

        // round 4
        if (scoreRound[3] >= 4)
        {
            for (int i = 0; i < starR4.Length; i++)
            {
                starR4[i].enabled = true;
            }
        }
        else if (scoreRound[3] <= 3 && scoreRound[1] >= 2)
        {
            for (int i = 0; i < starR4.Length; i++)
            {
                starR4[i].enabled = true;
                starR4[2].enabled = false;
            }
        }
        else if (scoreRound[3] == 1)
        {
            for (int i = 0; i < starR4.Length; i++)
            {
                starR4[i].enabled = true;
                starR4[2].enabled = false;
                starR4[1].enabled = false;
            }
        }

        // round 5
        if (scoreRound[4] >= 4)
        {
            for (int i = 0; i < starR5.Length; i++)
            {
                starR5[i].enabled = true;
            }
        }
        else if (scoreRound[4] <= 3 && scoreRound[1] >= 2)
        {
            for (int i = 0; i < starR5.Length; i++)
            {
                starR5[i].enabled = true;
                starR5[2].enabled = false;
            }
        }
        else if (scoreRound[4] == 1)
        {
            for (int i = 0; i < starR5.Length; i++)
            {
                starR5[i].enabled = true;
                starR5[2].enabled = false;
                starR5[1].enabled = false;
            }
        }
    }

    void Success()
    {
        RightSFX();
        success = false;
        imageblocker.enabled = true;

        if (round == 5)
        {
            gameEndPop.SetActive(true);
            gameEndPop.GetComponent<Animation>().Play("GameEndPop");

            scoreRound[4] = score;
        }
        else if (round != 5)
        {
            successPop.SetActive(true);
            successPop.GetComponent<CanvasGroup>().alpha = 0;
            successPop.GetComponent<Animation>().Play("SuccessPop");

            if (round == 1)
            {
                scoreRound[0] = score;
            }
            else if (round == 2)
            {
                scoreRound[1] = score;
            }
            else if (round == 3)
            {
                scoreRound[2] = score;
            }
            else if (round == 4)
            {
                scoreRound[3] = score;
            }
        }
    }

    public void ShowScore()
    {
        PressSFX();
        gameEndPop.SetActive(false);
        scoreboardPop.SetActive(true);

        scoreboardPop.GetComponent<Animation>().Play("scoreboard_anim");
    }

    public void ReturnToAR()
    {
        BackSFX();
        SceneManager.LoadScene("Plants-AR");
    }

    public void Home()
    {
        PressSFX();
        SceneManager.LoadScene("Menu");
    }

    public void BackToGameEnd()
    {
        BackSFX();
        gameEndPop.SetActive(true);
        scoreboardPop.SetActive(false);

        gameEndPop.GetComponent<Animation>().Play("GameEndPop");
    }

    public void StartGame()
    {
        for (int i = 0; i < thingsToRemoveEarly.Length; i++)
        {
            thingsToRemoveEarly[i].SetActive(true);
        }

        imageblocker.enabled = false;
        introPop.SetActive(false);

        levelSelector = Random.Range(0, intList.Count);

        LevelSelector();
    }

    void LevelSelector()
    {
        PressSFX();

        levelText.text = "Level " + level;
        level += 1;

        levelSelector = Random.Range(0, intList.Count);

        levelSelector = intList[levelSelector];

        intList.RemoveAt(levelSelector);

        score = 6;

        hangmanCount = 6;
        HangmanImage();

        if (levelSelector == 0)
        {
            for (int i = 0; i < word1.Length; i++)
            {
                word1[i].SetActive(true);
                word1[0].transform.parent.GetComponent<Animation>().Play("Plants-Q1");
            }

            for (int i = 0; i < phase.Length; i++)
            {
                phase[i] = false;
                phase[0] = true;
            }


            hintText.text = plantClass.d1.hint1;
        }
        else if (levelSelector == 1)
        {
            for (int i = 0; i < word2.Length; i++)
            {
                word2[i].SetActive(true);
                word2[0].transform.parent.GetComponent<Animation>().Play("Plants-Q1");
            }

            for (int i = 0; i < phase.Length; i++)
            {
                phase[i] = false;
                phase[1] = true;
            }

            hintText.text = plantClass.d1.hint2;
        }
        else if (levelSelector == 2)
        {
            for (int i = 0; i < word3.Length; i++)
            {
                word3[i].SetActive(true);
                word3[0].transform.parent.GetComponent<Animation>().Play("Plants-Q1");

            }

            for (int i = 0; i < phase.Length; i++)
            {
                phase[i] = false;
                phase[2] = true;
            }

            hintText.text = plantClass.d1.hint3;
        }
        else if (levelSelector == 3)
        {
            for (int i = 0; i < word4.Length; i++)
            {
                word4[i].SetActive(true);
                word4[0].transform.parent.GetComponent<Animation>().Play("Plants-Q1");

            }

            for (int i = 0; i < phase.Length; i++)
            {
                phase[i] = false;
                phase[3] = true;
            }

            hintText.text = plantClass.d1.hint4;
        }
        else if (levelSelector == 4)
        {
            for (int i = 0; i < word5.Length; i++)
            {
                word5[i].SetActive(true);
                word5[0].transform.parent.GetComponent<Animation>().Play("Plants-Q1");
            }

            for (int i = 0; i < phase.Length; i++)
            {
                phase[i] = false;
                phase[4] = true;
            }

            hintText.text = plantClass.d1.hint5;
        }
        else if (levelSelector == 5)
        {
            for (int i = 0; i < word6.Length; i++)
            {
                word6[i].SetActive(true);
                word6[0].transform.parent.GetComponent<Animation>().Play("Plants-Q1");
            }

            for (int i = 0; i < phase.Length; i++)
            {
                phase[i] = false;
                phase[5] = true;
            }

            hintText.text = plantClass.d1.hint6;
        }
        else if (levelSelector == 6)
        {
            for (int i = 0; i < word7.Length; i++)
            {
                word7[i].SetActive(true);
                word7[0].transform.parent.GetComponent<Animation>().Play("Plants-Q1");
            }

            for (int i = 0; i < phase.Length; i++)
            {
                phase[i] = false;
                phase[6] = true;
            }

            hintText.text = plantClass.d1.hint7;
        }
        else if (levelSelector == 7)
        {
            for (int i = 0; i < word8.Length; i++)
            {
                word8[i].SetActive(true);
                word8[0].transform.parent.GetComponent<Animation>().Play("Plants-Q1");
            }

            for (int i = 0; i < phase.Length; i++)
            {
                phase[i] = false;
                phase[7] = true;
            }

            hintText.text = plantClass.d1.hint8;
        }
        else if (levelSelector == 8)
        {
            for (int i = 0; i < word9.Length; i++)
            {
                word9[i].SetActive(true);
                word9[0].transform.parent.GetComponent<Animation>().Play("Plants-Q1");
            }

            for (int i = 0; i < phase.Length; i++)
            {
                phase[i] = false;
                phase[8] = true;
            }

            hintText.text = plantClass.d1.hint9;
        }
        else if (levelSelector == 9)
        {
            for (int i = 0; i < word10.Length; i++)
            {
                word10[i].SetActive(true);
                word10[0].transform.parent.GetComponent<Animation>().Play("Plants-Q1");
            }

            for (int i = 0; i < phase.Length; i++)
            {
                phase[i] = false;
                phase[9] = true;
            }

            hintText.text = plantClass.d1.hint10;
        }
        else if (levelSelector == 10)
        {
            for (int i = 0; i < word11.Length; i++)
            {
                word11[i].SetActive(true);
                word11[0].transform.parent.GetComponent<Animation>().Play("Plants-Q1");
            }

            for (int i = 0; i < phase.Length; i++)
            {
                phase[i] = false;
                phase[10] = true;
            }

            hintText.text = plantClass.d1.hint11;
        }
        else if (levelSelector == 11)
        {
            for (int i = 0; i < word12.Length; i++)
            {
                word12[i].SetActive(true);
                word12[0].transform.parent.GetComponent<Animation>().Play("Plants-Q1");
            }

            for (int i = 0; i < phase.Length; i++)
            {
                phase[i] = false;
                phase[11] = true;
            }

            hintText.text = plantClass.d1.hint12;
        }
        else if (levelSelector == 12)
        {
            for (int i = 0; i < word13.Length; i++)
            {
                word13[i].SetActive(true);
                word13[0].transform.parent.GetComponent<Animation>().Play("Plants-Q1");
            }

            for (int i = 0; i < phase.Length; i++)
            {
                phase[i] = false;
                phase[12] = true;
            }

            hintText.text = plantClass.d1.hint13;
        }
        else if (levelSelector == 13)
        {
            for (int i = 0; i < word14.Length; i++)
            {
                word14[i].SetActive(true);
                word14[0].transform.parent.GetComponent<Animation>().Play("Plants-Q1");
            }

            for (int i = 0; i < phase.Length; i++)
            {
                phase[i] = false;
                phase[13] = true;
            }

            hintText.text = plantClass.d1.hint14;
        }
        else if (levelSelector == 14)
        {
            for (int i = 0; i < word15.Length; i++)
            {
                word15[i].SetActive(true);
                word15[0].transform.parent.GetComponent<Animation>().Play("Plants-Q1");
            }

            for (int i = 0; i < phase.Length; i++)
            {
                phase[i] = false;
                phase[14] = true;
            }

            hintText.text = plantClass.d1.hint15;
        }
        else if (levelSelector == 15)
        {
            for (int i = 0; i < word16.Length; i++)
            {
                word16[i].SetActive(true);
                word16[0].transform.parent.GetComponent<Animation>().Play("Plants-Q1");
            }

            for (int i = 0; i < phase.Length; i++)
            {
                phase[i] = false;
                phase[15] = true;
            }

            hintText.text = plantClass.d1.hint16;
        }
        else if (levelSelector == 16)
        {
            for (int i = 0; i < word17.Length; i++)
            {
                word17[i].SetActive(true);
                word17[0].transform.parent.GetComponent<Animation>().Play("Plants-Q1");
            }

            for (int i = 0; i < phase.Length; i++)
            {
                phase[i] = false;
                phase[16] = true;
            }

            hintText.text = plantClass.d1.hint17;
        }
        else if (levelSelector == 17)
        {
            for (int i = 0; i < word18.Length; i++)
            {
                word18[i].SetActive(true);
                word18[0].transform.parent.GetComponent<Animation>().Play("Plants-Q1");
            }

            for (int i = 0; i < phase.Length; i++)
            {
                phase[i] = false;
                phase[17] = true;
            }

            hintText.text = plantClass.d1.hint18;
        }
        else if (levelSelector == 18)
        {
            for (int i = 0; i < word19.Length; i++)
            {
                word19[i].SetActive(true);
                word19[0].transform.parent.GetComponent<Animation>().Play("Plants-Q1");
            }

            for (int i = 0; i < phase.Length; i++)
            {
                phase[i] = false;
                phase[18] = true;
            }

            hintText.text = plantClass.d1.hint19;
        }
        else if (levelSelector == 19)
        {
            for (int i = 0; i < word20.Length; i++)
            {
                word20[i].SetActive(true);
                word20[0].transform.parent.GetComponent<Animation>().Play("Plants-Q1");
            }

            for (int i = 0; i < phase.Length; i++)
            {
                phase[i] = false;
                phase[19] = true;
            }

            hintText.text = plantClass.d1.hint20;
        }
    }

    public void GameChanger()
    {
        PressSFX();
        levelSelector = Random.Range(0, phase.Length);

        LevelSelector();

        hangmanCount = 6;

        successPop.SetActive(false);

        imageblocker.enabled = false;

        round += 1;
    }

    public void Retry()
    {
        PressSFX();
        hangmanCount = 6;
        HangmanImage();

        score = 6;

        gameoverPop.SetActive(false);

        imageblocker.enabled = false;

        if (phase[0])
        {
            gameoverPop.SetActive(false);

            for (int i = 0; i < word1.Length; i++)
            {
                word1[i].SetActive(true);
                word1[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }
        }
        else if (phase[1])
        {
            for (int i = 0; i < word2.Length; i++)
            {
                word2[i].SetActive(true);
                word2[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }
        }
        else if (phase[2])
        {
            for (int i = 0; i < word3.Length; i++)
            {
                word3[i].SetActive(true);
                word3[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }
        }
        else if (phase[3])
        {
            for (int i = 0; i < word4.Length; i++)
            {
                word4[i].SetActive(true);
                word4[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }
        }
        else if (phase[4])
        {
            for (int i = 0; i < word5.Length; i++)
            {
                word5[i].SetActive(true);
                word5[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }
        }
        else if (phase[5])
        {
            for (int i = 0; i < word6.Length; i++)
            {
                word6[i].SetActive(true);
                word6[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }
        }
        else if (phase[6])
        {
            for (int i = 0; i < word7.Length; i++)
            {
                word7[i].SetActive(true);
                word7[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }
        }
        else if (phase[7])
        {
            for (int i = 0; i < word8.Length; i++)
            {
                word8[i].SetActive(true);
                word8[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }
        }
        else if (phase[8])
        {
            for (int i = 0; i < word9.Length; i++)
            {
                word9[i].SetActive(true);
                word9[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }
        }
        else if (phase[9])
        {
            for (int i = 0; i < word10.Length; i++)
            {
                word10[i].SetActive(true);
                word10[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }
        }
        else if (phase[10])
        {
            for (int i = 0; i < word11.Length; i++)
            {
                word11[i].SetActive(true);
                word11[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }
        }
        else if (phase[11])
        {
            for (int i = 0; i < word12.Length; i++)
            {
                word12[i].SetActive(true);
                word12[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }
        }
        else if (phase[12])
        {
            for (int i = 0; i < word13.Length; i++)
            {
                word13[i].SetActive(true);
                word13[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }
        }
        else if (phase[13])
        {
            for (int i = 0; i < word14.Length; i++)
            {
                word14[i].SetActive(true);
                word14[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }
        }
        else if (phase[14])
        {
            for (int i = 0; i < word15.Length; i++)
            {
                word15[i].SetActive(true);
                word15[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }
        }
        else if (phase[15])
        {
            for (int i = 0; i < word16.Length; i++)
            {
                word16[i].SetActive(true);
                word16[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }
        }
        else if (phase[16])
        {
            for (int i = 0; i < word17.Length; i++)
            {
                word17[i].SetActive(true);
                word17[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }
        }
        else if (phase[17])
        {
            for (int i = 0; i < word18.Length; i++)
            {
                word18[i].SetActive(true);
                word18[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }
        }
        else if (phase[18])
        {
            for (int i = 0; i < word19.Length; i++)
            {
                word19[i].SetActive(true);
                word19[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }
        }
        else if (phase[19])
        {
            for (int i = 0; i < word20.Length; i++)
            {
                word20[i].SetActive(true);
                word20[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }
        }
    }

    public void HangmanImage()
    {
        switch (hangmanCount)
        {
            case 6:
                for (int i = 0; i < hangman.Length; i++)
                {
                    hangman[i].enabled = true;
                }

                if (phase[levelSelector] && test)
                {
                    score = score - 1;
                    test = false;
                }
                break;

            case 5:
                for (int i = 0; i < hangman.Length; i++)
                {
                    hangman[i].enabled = true;
                    hangman[5].enabled = false;
                }

                if (phase[levelSelector] && test)
                {
                    score = score - 1;
                    test = false;
                }
                break;

            case 4:
                for (int i = 0; i < hangman.Length; i++)
                {
                    hangman[i].enabled = true;
                    hangman[5].enabled = false;
                    hangman[4].enabled = false;
                }

                if (phase[levelSelector] && test)
                {
                    score = score - 1;
                    test = false;
                }
                break;

            case 3:
                for (int i = 0; i < hangman.Length; i++)
                {
                    hangman[i].enabled = true;
                    hangman[5].enabled = false;
                    hangman[4].enabled = false;
                    hangman[3].enabled = false;
                }

                if (phase[levelSelector] && test)
                {
                    score = score - 1;
                    test = false;
                }
                break;

            case 2:
                for (int i = 0; i < hangman.Length; i++)
                {
                    hangman[i].enabled = true;
                    hangman[5].enabled = false;
                    hangman[4].enabled = false;
                    hangman[3].enabled = false;
                    hangman[2].enabled = false;
                }

                if (phase[levelSelector] && test)
                {
                    score = score - 1;
                    test = false;
                }
                break;

            case 1:
                 for (int i = 0; i < hangman.Length; i++)
                {
                    hangman[i].enabled = true;
                    hangman[5].enabled = false;
                    hangman[4].enabled = false;
                    hangman[3].enabled = false;
                    hangman[2].enabled = false;
                    hangman[1].enabled = false;
                }

                if (phase[levelSelector] && test)
                {
                    score = score - 1;
                    test = false;
                }
                break;

            case 0:
                for (int i = 0; i < hangman.Length; i++)
                {
                    hangman[i].enabled = false;
                }

                if (phase[levelSelector] && test)
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
