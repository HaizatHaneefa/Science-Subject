using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class randomTurnBasedAttack : MonoBehaviour
{
    [SerializeField] private randomCharacterProfile[] characters;
    [SerializeField] private Button[] characterButtons;
    [SerializeField] private Image selectionCharacterImage;
    [SerializeField] private TextMeshProUGUI[] characterstatsText;
    [SerializeField] private Button selectButton;

    void Start()
    {
        selectButton.interactable = false;
        //for (int i = 0; i < characterButtons.Length; i++)
        //{
        //    characterButtons[i].image
        //}
    }

    void Update()
    {
        
    }

    public void _CharacterSelection(int index) // for character stats
    {
        selectButton.interactable = true;

        if (index == 0)
        {
            selectionCharacterImage.sprite = characters[0].artwork;

            characterstatsText[0].text = "Health: " + characters[0].health.ToString();
            characterstatsText[1].text = "Attack: " + characters[0].attack.ToString();
            characterstatsText[2].text = "Defense: " + characters[0].defense.ToString();
            characterstatsText[3].text = "Stamina: " + characters[0].stamina.ToString();
            characterstatsText[4].text = characters[0].characterName.ToString();
        }
        else if (index == 1)
        {
            selectionCharacterImage.sprite = characters[1].artwork;

            characterstatsText[0].text = "Health: " + characters[1].health.ToString();
            characterstatsText[1].text = "Attack: " + characters[1].attack.ToString();
            characterstatsText[2].text = "Defense: " + characters[1].defense.ToString();
            characterstatsText[3].text = "Stamina: " + characters[1].stamina.ToString();
            characterstatsText[4].text = characters[1].characterName.ToString();
        }
        else if (index == 2)
        {
            selectionCharacterImage.sprite = characters[2].artwork;

            characterstatsText[0].text = "Health: " + characters[2].health.ToString();
            characterstatsText[1].text = "Attack: " + characters[2].attack.ToString();
            characterstatsText[2].text = "Defense: " + characters[2].defense.ToString();
            characterstatsText[3].text = "Stamina: " + characters[2].stamina.ToString();
            characterstatsText[4].text = characters[2].characterName.ToString();
        }
    }


    public void _Attack()
    {
        // hits the enemy based on how much damage it costs
        
    }

    public void _ArmorUp()
    {
        // generates a shield based on how much defense the player has
    }

    public void _StaminaTUrn()
    {
        // how much the player can use per turn
    }
}
