using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishRacePlantGame : MonoBehaviour
{
    public Y5PlantGame manager;

    [SerializeField] private GameObject ps;

    private void Start()
    {
        ps.SetActive(false);
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

            ps.SetActive(true);
            ps.GetComponent<ParticleSystem>().Play();
        }

        StartCoroutine(DelayFreeze());

        manager.isPlaying = false;
        manager.timer = 3f;
    }

    IEnumerator DelayFreeze()
    {
        yield return new WaitForSeconds(2f);

        Time.timeScale = 0f;
    }
}
