using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePlay : MonoBehaviour
{
    public Breathe breathe;
    public void CanPlay()
    {
        breathe.canPlay = true;
    }
}
