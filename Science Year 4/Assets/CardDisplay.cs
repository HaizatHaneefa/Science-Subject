using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] private card card;

    [SerializeField] private Image artworkImage;
    [SerializeField] private TextMeshProUGUI cardName, description;

    void Start()
    {
        cardName.text = card.name;
        description.text = card.description;

        artworkImage.sprite = card.artwork;
    }

    void Update()
    {
        
    }
}
