using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationSettings : MonoBehaviour
{
    public static ApplicationSettings Instance;
    public int targetFramerate = 60;
    public KeyCode fastQuitKey = KeyCode.Escape;

    void Awake() {
        if (Instance) {
            Instance = this;
        } else if (Instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        Application.targetFrameRate = targetFramerate;
    }

    void Update() {
        #if UNITY_STANDALONE
        if (Input.GetKeyUp(fastQuitKey)) {
            Application.Quit();
        }
        #endif
    }
}