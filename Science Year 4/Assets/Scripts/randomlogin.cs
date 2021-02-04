using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class randomlogin : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI id, pass;
    [SerializeField] string fieldID, fieldPass;

    [SerializeField] Button cButton, registerButton;
    [SerializeField] InputField passwordField;

    [SerializeField] private TMP_InputField PasswordInput;

    void Start()
    {

    }

    void Update()
    {
        fieldPass = PasswordInput.text;
    }

    public void _Confirm()
    { 
    
    }

    public void _Register()
    { 
    
    }
}
