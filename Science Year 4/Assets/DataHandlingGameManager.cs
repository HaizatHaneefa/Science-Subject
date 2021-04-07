using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DataHandlingGameManager : MonoBehaviour
{
    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    [SerializeField] public Transform spawn;

    [SerializeField] private DataHandlingItems[] items;

    [SerializeField] private GameObject endpop;

    [SerializeField] private Canvas canvas;

    [SerializeField] public List<GameObject> shapeList;
    [SerializeField] private List<GameObject> shapes;

    [SerializeField] private TextMeshProUGUI countText;

    int shapeCur, count;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        endpop.SetActive(false);
        Spawn();

        count = 10;
    }

    public void Spawn()
    {
        count -= 1;

        if (shapeList.Count == 10)
        {
            endpop.SetActive(true);
            endpop.GetComponent<Animation>().Play("GameOverPop");

            return;
        }

        int cur;
        cur = Random.Range(0, items.Length);

        shapes[shapeCur].tag = items[cur].type;
        shapes[shapeCur].transform.SetParent(spawn.transform);
        shapes[shapeCur].transform.localPosition = new Vector3(0, 0, 0);
        shapes[shapeCur].GetComponent<Image>().sprite = items[cur].artwork;

        shapeList.Add(shapes[shapeCur]);

        shapeCur += 1;
    }

    public void _Back()
    {
        BackSFX();
        SceneManager.LoadScene("Menu");
    }

    public void _Reset()
    {
        PressSFX();
        SceneManager.LoadScene("Y6 - Data Handling Game");
    }

    private void Update()
    {
        countText.text = "Remaining shapes: " + count.ToString();

        if (count < 0)
        {
            count = 0;
        }
    }

    public void PressSFX() // button press yes
    {
        aSource.clip = clip[0];
        aSource.Play();
    }

    public void WrongPressSFX() // button press no
    {
        aSource.clip = clip[4];
        aSource.Play();
    }

    public void BackSFX() // back button press
    {
        aSource.clip = clip[1];
        aSource.Play();
    }

    public void RightSFX() // right answer
    {
        aSource.clip = clip[2];
        aSource.Play();
    }

    public void WrongSFX() // wrong answer
    {
        aSource.clip = clip[3];
        aSource.Play();
    }

    public void EndSFX() // wrong answer
    {
        aSource.clip = clip[5];
        aSource.Play();
    }
}
