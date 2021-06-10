﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTrack : MonoBehaviour
{
    FiveAnimalGameManager manager;

    [SerializeField] Canvas canvas;
    [SerializeField] Image image;

    [SerializeField] Transform pos;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<FiveAnimalGameManager>();
    }

    void Spawn()
    {
        Image i = Instantiate(image, pos.transform) as Image;

        i.transform.position = pos.position;

        i.transform.SetParent(canvas.transform.GetChild(3));
    }

    private void Update()
    {
        if (manager.isReady && !IsInvoking("Spawn"))
        {
            InvokeRepeating("Spawn", 0f, 13f);
        }
    }
}
