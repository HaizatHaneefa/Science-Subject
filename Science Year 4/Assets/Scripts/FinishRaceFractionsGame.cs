﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishRaceFractionsGame : MonoBehaviour
{
    public Y4FractionsGame manager;

    [SerializeField] private GameObject ps;

    private void Start()
    {
        ps.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            manager.pop.SetActive(true);
            manager.pop.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "You Failed!";
        }
        else if (collision.CompareTag("Player"))
        {
            manager.pop.SetActive(true);
            manager.pop.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Well done!";

            ps.SetActive(true);
            ps.GetComponent<ParticleSystem>().Play();
        }

        Time.timeScale = 0f;
        manager.isPlaying = false;
        manager.timer = 3f;
    }
}