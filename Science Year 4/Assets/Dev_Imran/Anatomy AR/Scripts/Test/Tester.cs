using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
//using Vuforia;

public class Tester : MonoBehaviour
{
    public GameObject sphere;
    public GameObject sphereSpawn;
    public bool excreting;
    public List<GameObject> sphereClones = new List<GameObject>();

    // Start is called before the first frame update
    //private void Start()
    //{
    //    VuforiaBehaviour.Instance.enabled = false;
    //}

    public void ActivateUrination()
    {
        excreting = true;
        StartCoroutine("SpawnUrea");
    }

    public void DisableUrination()
    {
        excreting = false;
        StopAllCoroutines();
        GameObject[] arrayOfSphereClones = sphereClones.ToArray();
        foreach (GameObject sphereClones in arrayOfSphereClones)
        {
            Destroy(sphereClones);
        }
    }

    IEnumerator SpawnUrea()
    {
        while (excreting == true)
        {
            GameObject sphereClone = Instantiate(sphere, sphereSpawn.transform.position, Quaternion.identity) as GameObject;
            sphereClones.Add(sphereClone);
            // iTween.MoveTo(sphereClone, iTween.Hash("path", iTweenPath.GetPath("Urea"), "time", 5, "easetype", iTween.EaseType.easeInOutSine));
            yield return new WaitForSeconds(0.5f);
        }
    }
}
