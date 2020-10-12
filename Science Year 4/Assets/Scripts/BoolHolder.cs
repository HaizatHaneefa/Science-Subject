using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolHolder : MonoBehaviour
{
    private static BoolHolder _playerInstance;

    [SerializeField] public static int dropdownValue;
    public static bool[] menuChapter;

    public static BoolHolder playerInstance
    {
        get { return playerInstance; }
    }

   
    void Awake()
    {
        NoDestroy();   
    }

   

    void NoDestroy()
    {
        DontDestroyOnLoad(this);

        if (_playerInstance == null)
        {
            _playerInstance = this;
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
