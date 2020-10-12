using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolHolder : MonoBehaviour
{
    public bool[] menuChapter;
    private static BoolHolder playerInstance;

    [SerializeField] public int dropdownValue;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }
}
