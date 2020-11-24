using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] private card card;

    [SerializeField] private Image frontCardImage, artWorkImage, cardBack;
    [SerializeField] private TextMeshProUGUI cardName, description;

    void Start()
    {
        cardName.text = card.name;
        description.text = card.description;

        artWorkImage.sprite = card.artwork;
        frontCardImage.sprite = card.frontCard;
        cardBack.sprite = card.backCard;
    }

    void Update()
    {
        
    }
}
