﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroApp : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Wait());
    }

    void Update()
    {
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Menu");
    }
}