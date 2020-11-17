using UnityEngine;

public class TargetFramerate : MonoBehaviour
{
    void Awake() {
        Application.targetFrameRate = 120;
    }
}
