using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] private card card;

    [SerializeField] private Image frontCardImage, cardBack;

    void Start()
    {
        frontCardImage = transform.GetChild(0).GetComponent<Image>();
        cardBack = transform.GetChild(4).GetComponent<Image>();
        frontCardImage.sprite = card.frontCard;
        cardBack.sprite = card.backCard;
    }
}
