using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item", menuName = "Items")]
public class MoneyList /*: MonoBehaviour*/ : ScriptableObject
{
    public string itemName;

    public Sprite artwork;

    public float value;
    public float change;
}
