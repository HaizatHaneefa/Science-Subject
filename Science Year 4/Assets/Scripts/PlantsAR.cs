using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlantsAR : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    float RotX, RotY, RotZ;

    [SerializeField] private GameObject GO;

    int cur;

    [SerializeField] private GameObject quizButton, gameButton;
}
