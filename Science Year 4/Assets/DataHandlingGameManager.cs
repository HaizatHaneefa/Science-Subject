using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataHandlingGameManager : MonoBehaviour
{
    [SerializeField] public Transform spawn;
    [SerializeField] private DataHandlingItems[] items;
    [SerializeField] private GameObject obj;
    [SerializeField] private Canvas canvas;

    [SerializeField] public List<GameObject> shapeList;

    [SerializeField] private GameObject endpop;

    void Start()
    {
        endpop.SetActive(false);
        Spawn();
    }

    public void Spawn()
    {
        if (shapeList.Count == 10)
        {
            endpop.SetActive(true);
            return;

        }
        int cur;
        cur = Random.Range(0, items.Length);

        GameObject go = Instantiate(obj, spawn.position, Quaternion.identity);
        go.transform.localScale = new Vector2(1, 1);

        go.tag = items[cur].type;

        go.GetComponent<Image>().sprite = items[cur].artwork;
        go.transform.SetParent(canvas.transform);

        shapeList.Add(go);
    }

    public void _Back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void _Reset()
    {
        SceneManager.LoadScene("Y6 - Data Handling Game");
    }

    void Update()
    {
        
    }
}
