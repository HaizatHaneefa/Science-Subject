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
        cardName = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        description = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        artWorkImage = transform.GetChild(1).GetChild(0).GetComponent<Image>();
        frontCardImage = transform.GetChild(0).GetComponent<Image>();
        cardBack = transform.GetChild(4).GetComponent<Image>();

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
