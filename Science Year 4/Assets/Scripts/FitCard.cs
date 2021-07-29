using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FitCard : MonoBehaviour
{
    public List<GameObject> items; // List that holds all my ten cards

    public Transform start;  //Location where to start adding my cards
    public Transform HandDeck; //The hand panel reference

    public float howManyAdded; // How many cards I added so far
    float gapFromOneItemToTheNextOne; //the gap I need between each card

    void Start()
    {
        howManyAdded = 0.0f;
        gapFromOneItemToTheNextOne = 1.0f;

        FitCards();
    }

    public void FitCards()
    {
        if (items.Count == 0) //if list is null, stop function
            return;

        GameObject cards = items[0]; //Reference to first image in my list

        cards.transform.position = start.position; //relocating my card to the Start Position
        cards.transform.position += new Vector3((howManyAdded * gapFromOneItemToTheNextOne), 0, 0); // Moving my card 1f to the right
        cards.transform.SetParent(HandDeck); //Setting ym card parent to be the Hand Panel

        items.RemoveAt(0);
        howManyAdded++;
    }
}
