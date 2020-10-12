using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Y5C5PlantAR : MonoBehaviour
{
    [SerializeField] private MoveSun managerSun;

    [SerializeField] private GameObject batangKayu, root, rootRoot, upArrow, downArrow, zoomImage, mainCam;
    [SerializeField] private GameObject quizButton, gameButton;

    [SerializeField] private Camera[] cam;

    [SerializeField] private Vector3 oriPos;
    [SerializeField] private Quaternion[] rot;
    [SerializeField] private ParticleSystem ps;

    int cur;

    [SerializeField] public bool isMoving;

    void Start()
    {
        rot = new Quaternion[2];

        rot[0] = new Quaternion(root.transform.rotation.x, root.transform.rotation.y, root.transform.rotation.z, 1);
        rot[1] = new Quaternion(batangKayu.transform.rotation.x, batangKayu.transform.rotation.y, batangKayu.transform.rotation.z, 1);

        quizButton.SetActive(false);

        oriPos = new Vector3(managerSun.gameObject.transform.position.x, managerSun.gameObject.transform.position.y,
            managerSun.gameObject.transform.position.z);

        for (int i = 0; i < cam.Length; i++)
        {
            cam[i].enabled = false;
        }

        ps.Stop();

        managerSun.enabled = false;

        managerSun.gameObject.SetActive(false);
        upArrow.SetActive(false);
        downArrow.SetActive(false);
        zoomImage.SetActive(false);
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.touchCount < 2)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = cam[3].ScreenPointToRay(Input.GetTouch(0).position);

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        Debug.Log("whateher");
                        hit.transform.parent.parent.parent.GetComponent<Animation>().Play("tah");
                    }
                }
            }
        }

        if (cur != 0)
        {
            quizButton.SetActive(true);
        }
    }

    public void _Light() // Later
    {
        isMoving = true;

        cur = 1;

        managerSun.gameObject.transform.position = oriPos;

        root.gameObject.transform.rotation = rot[0];
        batangKayu.gameObject.transform.rotation = rot[1];

        ps.Stop();
        ps.gameObject.SetActive(false);

        managerSun.gameObject.SetActive(true);
        managerSun.enabled = true;

        for (int i = 0; i < cam.Length; i++)
        {
            cam[i].enabled = false;
        }

        mainCam.SetActive(true);

        batangKayu.GetComponent<Animation>().Stop();
        root.GetComponent<Animation>().Stop();

        upArrow.SetActive(false);
        upArrow.GetComponent<Animation>().Stop();
        downArrow.SetActive(false);

        downArrow.GetComponent<Animation>().Stop();

        zoomImage.SetActive(false);
    }

    public void _Gravity()
    {
        isMoving = false;

        cur = 2;

        zoomImage.SetActive(true);

        for (int i = 0; i < cam.Length; i++)
        {
            cam[i].enabled = false;
            cam[1].enabled = true;
            cam[2].enabled = true;
        }

        mainCam.SetActive(false);

        ps.Stop();
        ps.gameObject.SetActive(false);

        managerSun.gameObject.SetActive(false);
        managerSun.enabled = false;

        batangKayu.GetComponent<Animation>().Play("plant-goes-up");
        root.GetComponent<Animation>().Play("root-goes-down");

        upArrow.SetActive(true);
        upArrow.GetComponent<Animation>().Play("arrow-2");

        downArrow.SetActive(true);
        downArrow.GetComponent<Animation>().Play("Arrow-1");
    }

    public void _Water()
    {
        zoomImage.SetActive(false);

        isMoving = false;

        cur = 3;

        managerSun.gameObject.transform.position = oriPos;
        root.gameObject.transform.rotation = rot[0];

        batangKayu.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);

        for (int i = 0; i < cam.Length; i++)
        {
            cam[i].enabled = false;
            cam[0].enabled = true;
        }

        mainCam.SetActive(false);

        ps.gameObject.SetActive(true);
        ps.Play();

        root.GetComponent<Animation>().Play("Root-To-Water");

        managerSun.gameObject.SetActive(false);
        managerSun.enabled = false;

        batangKayu.GetComponent<Animation>().Stop();
        //root.GetComponent<Animation>().Stop();

        upArrow.SetActive(false);
        upArrow.GetComponent<Animation>().Stop();
        downArrow.SetActive(false);

        downArrow.GetComponent<Animation>().Stop();
    }

    public void _Touch()
    {
        zoomImage.SetActive(false);

        isMoving = false;

        cur = 4;

        managerSun.gameObject.transform.position = oriPos;
        root.gameObject.transform.rotation = rot[0];
        batangKayu.gameObject.transform.rotation = rot[1];

        for (int i = 0; i < cam.Length; i++)
        {
            cam[i].enabled = false;
            cam[3].enabled = true;
        }

        mainCam.SetActive(false);

        ps.Stop();
        ps.gameObject.SetActive(false);

        managerSun.gameObject.SetActive(false);
        managerSun.enabled = false;

        batangKayu.GetComponent<Animation>().Stop();
        root.GetComponent<Animation>().Stop();

        upArrow.SetActive(false);
        upArrow.GetComponent<Animation>().Stop();
        downArrow.SetActive(false);

        downArrow.GetComponent<Animation>().Stop();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ToGame()
    {
        SceneManager.LoadScene("Plant-Game");
    }

    public void ToQuiz()
    {
        if (cur == 1) // light
        {
            SceneManager.LoadScene("Plant-Light-Question");
        }
        if (cur == 2) // gravity
        {
            SceneManager.LoadScene("Plant-Gravity");
        }
        if (cur == 3) // water
        {
            SceneManager.LoadScene("Plant-Water");
        }
        if (cur == 4) // touch
        {
            SceneManager.LoadScene("Plant-Touch");
        }
    }
}
