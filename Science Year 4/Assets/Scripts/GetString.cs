using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetString : MonoBehaviour
{
    GameObject gc;

    HangmanManager manager;

    private void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController");

        manager = gc.GetComponent<HangmanManager>();
    }

    public void thisButton()
    {
        if (manager.game[0])
        {
            if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
            {
                foreach (GameObject but in manager.game1Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "A")
            {
                foreach (GameObject but in manager.game1Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "A")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }

            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "L")
            {
                foreach (GameObject but in manager.game1Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "L")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "M")
            {
                foreach (GameObject but in manager.game1Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "M")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "N")
            {
                foreach (GameObject but in manager.game1Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "N")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "D")
            {
                foreach (GameObject but in manager.game1Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "D")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "E")
            {
                foreach (GameObject but in manager.game1Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "E")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "R")
            {
                foreach (GameObject but in manager.game1Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "R")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "S" ||
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "A" ||
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "L" ||
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "M" ||
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "N" ||
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "D" ||
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "E" ||
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "R")

            {
                manager.hangmanCount = manager.hangmanCount - 1;

                manager.test = true;
            }
        }
        else if (manager.game[1])
        {
            if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
            {
                foreach (GameObject but in manager.game2Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "P")
            {
                foreach (GameObject but in manager.game2Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "P")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "I")
            {
                foreach (GameObject but in manager.game2Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "I")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "R")
            {
                foreach (GameObject but in manager.game2Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "R")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "A")
            {
                foreach (GameObject but in manager.game2Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "A")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "C")
            {
                foreach (GameObject but in manager.game2Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "C")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "L")
            {
                foreach (GameObject but in manager.game2Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "L")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "E")
            {
                foreach (GameObject but in manager.game2Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "E")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "S" ||
               transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "P" ||
               transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "I" ||
               transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "R" ||
               transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "A" ||
               transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "C" ||
               transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "L" ||
               transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "E" ||
               transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "R")
            {
                manager.hangmanCount = manager.hangmanCount - 1;

                manager.test = true;
            }
        }
        else if (manager.game[2])
        {
            if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "E")
            {
                foreach (GameObject but in manager.game3Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "E")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "X")
            {
                foreach (GameObject but in manager.game3Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "X")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "H")
            {
                foreach (GameObject but in manager.game3Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "H")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "A")
            {
                foreach (GameObject but in manager.game3Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "A")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "L")
            {
                foreach (GameObject but in manager.game3Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "L")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "E" ||
           transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "X" ||
           transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "H" ||
           transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "A" ||
           transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "L")
            {
                manager.hangmanCount = manager.hangmanCount - 1;

                manager.test = true;
            }
        }

        else if (manager.game[3])
        {
            if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
            {
                foreach (GameObject but in manager.game4Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "N")
            {
                foreach (GameObject but in manager.game4Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "N")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "A")
            {
                foreach (GameObject but in manager.game4Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "A")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "K")
            {
                foreach (GameObject but in manager.game4Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "K")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "E")
            {
                foreach (GameObject but in manager.game4Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "E")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "S" ||
         transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "N" ||
         transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "A" ||
         transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "K" ||
         transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "E")
            {
                manager.hangmanCount = manager.hangmanCount - 1;
                manager.test = true;
            }
        }
        else if (manager.game[4])
        {
            if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
            {
                foreach (GameObject but in manager.game5Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "K")
            {
                foreach (GameObject but in manager.game5Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "K")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "I")
            {
                foreach (GameObject but in manager.game5Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "I")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "N")
            {
                foreach (GameObject but in manager.game5Holder)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "N")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "S" ||
       transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "K" ||
       transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "I" ||
       transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "N")
            {
                manager.hangmanCount = manager.hangmanCount - 1;

                manager.test = true;
            }
        }
    }
}
