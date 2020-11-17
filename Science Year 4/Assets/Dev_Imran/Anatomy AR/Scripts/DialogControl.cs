using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogControl : MonoBehaviour
{
    DialogSet dialog;

    void Awake() {
        dialog = GetComponent<DialogSet>();
    }

    void Start() {
        dialog.Show(0);
    }
}
