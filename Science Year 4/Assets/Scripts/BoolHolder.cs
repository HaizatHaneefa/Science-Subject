using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolHolder : MonoBehaviour
{
    private static BoolHolder instance;

    [SerializeField] public static int dropdownValue;
    public static bool[] menuChapter;

    public static BoolHolder playerInstance
    {
        get { return playerInstance; }
    }

   
    void Awake()
    {
        NoDestroy();


        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }



    void NoDestroy()
    {
        
    }

    void Update()
    {
        
    }
}
