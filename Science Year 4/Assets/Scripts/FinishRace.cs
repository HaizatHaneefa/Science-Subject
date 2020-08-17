using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishRace : MonoBehaviour
{
    public FiveAnimalGameManager manager;

    private void Start()
    {
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            manager.pop.SetActive(true);
            manager.pop.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "You Failed!";
        }
        else if (collision.CompareTag("Player"))
        {
            manager.pop.SetActive(true);
            manager.pop.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Well done!";
        }

        Time.timeScale = 0f;
        manager.isPlaying = false;
        manager.timer = 3f;
    }
}
