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

    //public class banana
    //{
    //    public float cost = 0.50f;
    //    public float change = 0.50f;
    //    public string name = "banana";
        
    //}

    //public banana q1 = new banana();

    //public class potato
    //{
    //    public float cost = 0.25f;
    //    public float change = 0.75f;
    //    public string name = "potato";
    //}

    //public potato q2 = new potato();

}
