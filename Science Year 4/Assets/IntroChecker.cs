using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroChecker : MonoBehaviour
{
    public static IntroChecker instance;

    public bool checker;

    void Awake()
    {
        if (instance == null)
        {

        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
