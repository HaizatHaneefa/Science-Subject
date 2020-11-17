using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuwisBgmSpawner : MonoBehaviour
{
    public GameObject infiniteBgmObject;

    GameObject spawnedBgm;

    void Start()
    {
        if(!GameObject.Find("Infinite BGM(Clone)"))
        {
            spawnedBgm = Instantiate(infiniteBgmObject);
            DontDestroyOnLoad(spawnedBgm);
        }
    }
}
