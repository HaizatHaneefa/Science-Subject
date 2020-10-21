using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlantKeyboard : MonoBehaviour
{
    GameObject gc;

    PlantsHangmanManager manager;

    private void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController");

        manager = gc.GetComponent<PlantsHangmanManager>();
    }

    public void Input()
    {
        if (manager.phase[0]) // CHLOROPHYLL
        {
            manager.PressSFX();
            if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "C")
            {
                foreach (GameObject but in manager.word1)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "C")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "R")
            {
                foreach (GameObject but in manager.word1)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "R")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "O")
            {
                foreach (GameObject but in manager.word1)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "O")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "P")
            {
                foreach (GameObject but in manager.word1)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "P")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Y")
            {
                foreach (GameObject but in manager.word1)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Y")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "H")
            {
                foreach (GameObject but in manager.word1)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "H")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "L")
            {
                foreach (GameObject but in manager.word1)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "L")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "C" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "R" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "P" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "Y" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "H" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "O" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "L")
                     {
                        manager.WrongPressSFX();
                        manager.hangmanCount = manager.hangmanCount - 1;

                        manager.test = true;

                        manager.HangmanImage();
                     }
        }

        if (manager.phase[1]) // WATER
        {
            manager.PressSFX();
            if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "A")
            {
                foreach (GameObject but in manager.word2)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "A")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "W")
            {
                foreach (GameObject but in manager.word2)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "W")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "T")
            {
                foreach (GameObject but in manager.word2)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "T")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "E")
            {
                foreach (GameObject but in manager.word2)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "E")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "R")
            {
                foreach (GameObject but in manager.word2)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "R")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "A" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "W" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "T" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "E" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "R")
                     {
                        manager.WrongPressSFX();
                        manager.hangmanCount = manager.hangmanCount - 1;

                        manager.test = true;

                        manager.HangmanImage();

                     }
        }

        if (manager.phase[2]) // SHOOTS
        {
            manager.PressSFX();
            if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
            {
                foreach (GameObject but in manager.word3)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "H")
            {
                foreach (GameObject but in manager.word3)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "H")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "O")
            {
                foreach (GameObject but in manager.word3)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "O")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "T")
            {
                foreach (GameObject but in manager.word3)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "T")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "S" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "H" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "O" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "T")
                    {
                        manager.WrongPressSFX();
                        manager.hangmanCount = manager.hangmanCount - 1;


                        manager.test = true;

                        manager.HangmanImage();
                    }
        }

        if (manager.phase[3]) // MIMOSA
        {
            manager.PressSFX();
            if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "M")
            {
                foreach (GameObject but in manager.word4)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "M")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "I")
            {
                foreach (GameObject but in manager.word4)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "I")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "O")
            {
                foreach (GameObject but in manager.word4)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "O")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
            {
                foreach (GameObject but in manager.word4)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "A")
            {
                foreach (GameObject but in manager.word4)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "A")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "M" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "I" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "O" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "S" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "A")
                     {
                        manager.WrongPressSFX();
                        manager.hangmanCount = manager.hangmanCount - 1;

                        manager.test = true;

                        manager.HangmanImage();
                     }
        }

        if (manager.phase[4]) // SUN
        {
            manager.PressSFX();
            if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
            {
                foreach (GameObject but in manager.word5)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "U")
            {
                foreach (GameObject but in manager.word5)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "U")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "N")
            {
                foreach (GameObject but in manager.word5)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "N")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "S" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "U" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "N")
                     {
                        manager.WrongPressSFX();
                        manager.hangmanCount = manager.hangmanCount - 1;

                        manager.test = true;

                        manager.HangmanImage();
                     }
        }

        if (manager.phase[5]) // GRAVITY
        {
            manager.PressSFX();
            if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "G")
            {
                foreach (GameObject but in manager.word6)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "G")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "R")
            {
                foreach (GameObject but in manager.word6)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "R")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "A")
            {
                foreach (GameObject but in manager.word6)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "A")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "V")
            {
                foreach (GameObject but in manager.word6)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "V")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "I")
            {
                foreach (GameObject but in manager.word6)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "I")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "T")
            {
                foreach (GameObject but in manager.word6)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "T")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Y")
            {
                foreach (GameObject but in manager.word6)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Y")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "G" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "R" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "A" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "V" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "I" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "T"||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "Y")
                     {
                        manager.WrongPressSFX();
                        manager.hangmanCount = manager.hangmanCount - 1;

                        manager.test = true;

                        manager.HangmanImage();
                     }
        }

        if (manager.phase[6]) // PHOTOSYNTHESIS
        {
            manager.PressSFX();
            if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "P")
            {
                foreach (GameObject but in manager.word7)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "P")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "H")
            {
                foreach (GameObject but in manager.word7)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "H")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "O")
            {
                foreach (GameObject but in manager.word7)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "O")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "T")
            {
                foreach (GameObject but in manager.word7)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "T")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
            {
                foreach (GameObject but in manager.word7)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Y")
            {
                foreach (GameObject but in manager.word7)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Y")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "N")
            {
                foreach (GameObject but in manager.word7)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "N")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "E")
            {
                foreach (GameObject but in manager.word7)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "E")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "I")
            {
                foreach (GameObject but in manager.word7)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "I")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "P" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "H" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "O" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "T" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "I" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "S" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "Y" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "N" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "E")
                     {
                        manager.WrongPressSFX();
                        manager.hangmanCount = manager.hangmanCount - 1;

                        manager.test = true;

                        manager.HangmanImage();
                    }
        }

        if (manager.phase[7]) // ROOTS
        {
            manager.PressSFX();
            if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "R")
            {
                foreach (GameObject but in manager.word8)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "R")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "O")
            {
                foreach (GameObject but in manager.word8)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "O")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "T")
            {
                foreach (GameObject but in manager.word8)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "T")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
            {
                foreach (GameObject but in manager.word8)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "R" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "O" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "T" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "S")
                     {
                        manager.WrongPressSFX();
                        manager.hangmanCount = manager.hangmanCount - 1;

                        manager.test = true;

                        manager.HangmanImage();
                     }
        }

        if (manager.phase[8]) // PHOTOTROPISM
        {
            manager.PressSFX();
            if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "P")
            {
                foreach (GameObject but in manager.word9)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "P")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "H")
            {
                foreach (GameObject but in manager.word9)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "H")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "O")
            {
                foreach (GameObject but in manager.word9)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "O")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "T")
            {
                foreach (GameObject but in manager.word9)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "T")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "R")
            {
                foreach (GameObject but in manager.word9)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "R")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "I")
            {
                foreach (GameObject but in manager.word9)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "I")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
            {
                foreach (GameObject but in manager.word9)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "M")
            {
                foreach (GameObject but in manager.word9)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "M")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "P" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "H" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "O" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "T" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "R" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "I" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "S" ||
                     transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "M")
                     {
                        manager.WrongPressSFX();
                        manager.hangmanCount = manager.hangmanCount - 1;

                        manager.test = true;

                        manager.HangmanImage();
                     }
        }

        if (manager.phase[9]) // HYDROTROPISM
        {
            manager.PressSFX();
            if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "H")
            {
                foreach (GameObject but in manager.word10)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "H")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Y")
            {
                foreach (GameObject but in manager.word10)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Y")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "D")
            {
                foreach (GameObject but in manager.word10)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "D")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "R")
            {
                foreach (GameObject but in manager.word10)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "R")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "O")
            {
                foreach (GameObject but in manager.word10)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "O")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "T")
            {
                foreach (GameObject but in manager.word10)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "T")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "P")
            {
                foreach (GameObject but in manager.word10)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "P")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "I")
            {
                foreach (GameObject but in manager.word10)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "I")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
            {
                foreach (GameObject but in manager.word10)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "M")
            {
                foreach (GameObject but in manager.word10)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "M")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }

            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "H" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "Y" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "D" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "R" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "O" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "T" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "P" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "I" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "S" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "M")
                    {
                        manager.WrongPressSFX();
                        manager.hangmanCount = manager.hangmanCount - 1;

                        manager.test = true;

                        manager.HangmanImage();
                    }
        }

        if (manager.phase[10]) // TOUCH
        {
            manager.PressSFX();
            if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "T")
            {
                foreach (GameObject but in manager.word11)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "T")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "O")
            {
                foreach (GameObject but in manager.word11)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "O")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "U")
            {
                foreach (GameObject but in manager.word11)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "U")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "C")
            {
                foreach (GameObject but in manager.word11)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "C")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "H")
            {
                foreach (GameObject but in manager.word11)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "H")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "T" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "O" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "U" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "C" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "H")
                    {
                        manager.WrongPressSFX();
                        manager.hangmanCount = manager.hangmanCount - 1;

                        manager.test = true;

                        manager.HangmanImage();
                    }
        }

        if (manager.phase[11]) // AUXIN
        {
            manager.PressSFX();
            if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "A")
            {
                foreach (GameObject but in manager.word12)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "A")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "U")
            {
                foreach (GameObject but in manager.word12)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "U")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "X")
            {
                foreach (GameObject but in manager.word12)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "X")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "I")
            {
                foreach (GameObject but in manager.word12)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "I")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "N")
            {
                foreach (GameObject but in manager.word12)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "N")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "A" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "U" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "X" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "I" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "N")
                    {
                        manager.WrongPressSFX();
                        manager.hangmanCount = manager.hangmanCount - 1;

                        manager.test = true;

                        manager.HangmanImage();
                    }
        }

        if (manager.phase[12]) // GEOTROPISM
        {
            manager.PressSFX();
            if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "G")
            {
                foreach (GameObject but in manager.word13)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "G")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "E")
            {
                foreach (GameObject but in manager.word13)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "E")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "O")
            {
                foreach (GameObject but in manager.word13)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "O")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "T")
            {
                foreach (GameObject but in manager.word13)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "T")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "R")
            {
                foreach (GameObject but in manager.word13)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "R")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "P")
            {
                foreach (GameObject but in manager.word13)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "P")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "I")
            {
                foreach (GameObject but in manager.word13)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "I")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
            {
                foreach (GameObject but in manager.word13)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "M")
            {
                foreach (GameObject but in manager.word13)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "M")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "G" ||
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "E" ||
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "O" ||
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "T" ||
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "R" ||
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "P" ||
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "I" ||
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "S" ||
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "M")
            {
                manager.WrongPressSFX();
                manager.hangmanCount = manager.hangmanCount - 1;

                manager.test = true;

                manager.HangmanImage();
            }
        }

        if (manager.phase[13]) // LEAVES
        {
            manager.PressSFX();
            if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "L")
            {
                foreach (GameObject but in manager.word14)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "L")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "E")
            {
                foreach (GameObject but in manager.word14)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "E")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "A")
            {
                foreach (GameObject but in manager.word14)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "A")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "V")
            {
                foreach (GameObject but in manager.word14)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "V")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
            {
                foreach (GameObject but in manager.word14)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "L" ||
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "E" ||
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "A" ||
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "V" ||
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "S")
            {
                manager.WrongPressSFX();
                manager.hangmanCount = manager.hangmanCount - 1;

                manager.test = true;

                manager.HangmanImage();
            }
        }

        if (manager.phase[14]) // STEM
        {
            manager.PressSFX();
            if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
            {
                foreach (GameObject but in manager.word15)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "T")
            {
                foreach (GameObject but in manager.word15)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "T")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "E")
            {
                foreach (GameObject but in manager.word15)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "E")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "M")
            {
                foreach (GameObject but in manager.word15)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "M")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "S" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "T" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "E" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "M")
                    {
                        manager.WrongPressSFX();
                        manager.hangmanCount = manager.hangmanCount - 1;

                        manager.test = true;

                        manager.HangmanImage();
                    }
        }

        if (manager.phase[15]) // PROTECT
        {
            manager.PressSFX();
            if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "P")
            {
                foreach (GameObject but in manager.word16)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "P")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "R")
            {
                foreach (GameObject but in manager.word16)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "R")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "O")
            {
                foreach (GameObject but in manager.word16)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "O")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "T")
            {
                foreach (GameObject but in manager.word16)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "T")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "E")
            {
                foreach (GameObject but in manager.word16)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "E")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "C")
            {
                foreach (GameObject but in manager.word16)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "C")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "P" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "R" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "O" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "T" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "E" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "C")
                    {
                        manager.WrongPressSFX();
                        manager.hangmanCount = manager.hangmanCount - 1;

                        manager.test = true;

                        manager.HangmanImage();
                    }
        }

        if (manager.phase[16]) // FOOD
        {
            manager.PressSFX();
            if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "F")
            {
                foreach (GameObject but in manager.word17)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "F")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "O")
            {
                foreach (GameObject but in manager.word17)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "O")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "D")
            {
                foreach (GameObject but in manager.word17)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "D")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "F" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "O" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "D")
                    {
                        manager.WrongPressSFX();
                        manager.hangmanCount = manager.hangmanCount - 1;

                        manager.test = true;

                        manager.HangmanImage();
                    }
        }

        if (manager.phase[17]) // ORCHID
        {
            manager.PressSFX();
            if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "O")
            {
                foreach (GameObject but in manager.word18)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "O")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "R")
            {
                foreach (GameObject but in manager.word18)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "R")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "C")
            {
                foreach (GameObject but in manager.word18)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "C")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "H")
            {
                foreach (GameObject but in manager.word18)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "H")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "I")
            {
                foreach (GameObject but in manager.word18)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "I")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "D")
            {
                foreach (GameObject but in manager.word18)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "D")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "O" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "R" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "C" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "H" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "I" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "D")
                    {
                        manager.WrongPressSFX();
                        manager.hangmanCount = manager.hangmanCount - 1;

                        manager.test = true;

                        manager.HangmanImage();
                    }
        }

        if (manager.phase[18]) // STIMULI
        {
            manager.PressSFX();
            if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
            {
                foreach (GameObject but in manager.word19)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "T")
            {
                foreach (GameObject but in manager.word19)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "T")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "I")
            {
                foreach (GameObject but in manager.word19)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "I")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "M")
            {
                foreach (GameObject but in manager.word19)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "M")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "U")
            {
                foreach (GameObject but in manager.word19)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "U")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "L")
            {
                foreach (GameObject but in manager.word19)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "L")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "S" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "T" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "I" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "M" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "U" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "L")
                    {
                        manager.WrongPressSFX();
                        manager.hangmanCount = manager.hangmanCount - 1;

                        manager.test = true;

                        manager.HangmanImage();
                    }
        }

        if (manager.phase[19]) // RESPONSE
        {
            manager.PressSFX();
            if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "R")
            {
                foreach (GameObject but in manager.word20)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "R")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "E")
            {
                foreach (GameObject but in manager.word20)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "E")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
            {
                foreach (GameObject but in manager.word20)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "S")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "P")
            {
                foreach (GameObject but in manager.word20)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "P")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "O")
            {
                foreach (GameObject but in manager.word20)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "O")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "N")
            {
                foreach (GameObject but in manager.word20)
                {
                    if (but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "N")
                    {
                        but.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
                    }
                }
            }
            else if (transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "R" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "E" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "S" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "P" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "O" ||
                    transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "N")
                    {
                        manager.WrongPressSFX();
                        manager.hangmanCount = manager.hangmanCount - 1;

                        manager.test = true;

                        manager.HangmanImage();
                    }
        }
    }
}
