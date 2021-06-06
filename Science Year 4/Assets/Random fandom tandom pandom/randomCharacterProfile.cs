using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "character", menuName = "character")]
public class randomCharacterProfile : ScriptableObject
{
    public string characterName;
    public float health;
    public float attack;
    public float defense;
    public float stamina;
    public Sprite artwork;
}
