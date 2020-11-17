using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class DisableVuforia : MonoBehaviour
{
    public Animator boyPivotAnim;

    // Start is called before the first frame update
    void Start()
    {
        VuforiaBehaviour.Instance.enabled = true;
        boyPivotAnim.SetTrigger("EnterBoyState");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
