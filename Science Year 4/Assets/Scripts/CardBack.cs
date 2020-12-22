using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBack : MonoBehaviour
{
    [SerializeField] private float x, y, z;
    GameObject cardBack;
    bool cardBackisActive;
    float timer;

    private void Start()
    {
        cardBack = transform.GetChild(4).gameObject;
        cardBack.SetActive(false);
    }

    public void _EnableCardBack()
    {
        cardBack.SetActive(true);
    }

    public void _DisableCardBack()
    {
        cardBack.SetActive(false);
    }
    //private void Start()
    //{
    //    cardBack = transform.GetChild(4).gameObject;
    //    cardBack.SetActive(false);
    //}

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        StartFlip();
    //    }
    //}
    //public void StartFlip()
    //{
    //    StartCoroutine(CalculateFlip());
    //}

    //IEnumerator CalculateFlip()
    //{
    //    for (int i = 0; i < 180; i++)
    //    {
    //        yield return new WaitForSeconds(0.01f);
    //        transform.Rotate(Vector3.right * 10f);
    //        timer++;

    //        if (timer == 90 || timer == -90)
    //        {
    //            Flip();
    //        }
    //    }

    //    timer = 0;
    //}

    //void Flip()
    //{
    //    if (cardBackisActive)
    //    {
    //        cardBack.SetActive(false);
    //        cardBackisActive = false;
    //    }
    //    else if (!cardBackisActive)
    //    {
    //        cardBack.SetActive(true);
    //        cardBackisActive = true;
    //    }
    //}
}
