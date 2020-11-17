using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SingleTrigger : MonoBehaviour
{
    public bool locked = false;
    public UnityEvent triggers;

    public void Fire() {
        if (locked) return;
        locked = true;
        triggers.Invoke();
    }
}
