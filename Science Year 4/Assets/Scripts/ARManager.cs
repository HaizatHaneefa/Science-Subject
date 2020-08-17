using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ARManager : MonoBehaviour
{
    public ARClass arClass;

    [SerializeField] private Button[] ObjectSwitchers;
    [SerializeField] private Button moreOptions;

    [SerializeField] private GameObject[] Objects;
    [SerializeField] private GameObject GO;
    [SerializeField] private GameObject[] quizButton;
    public GameObject dropdown;
    public GameObject[] button;
    public GameObject[] infoPop;
    public GameObject[] cam;

    [SerializeField] private Sprite[] moreButtonImages;

    [SerializeField] private float rotationSpeed;

    public bool isSlide;
    public bool isOpen;
    bool[] isSelected;
    
    public Image imageBlocker;
    public Image backgroundImage;
    public GameObject fishGillsImage;
    public GameObject moreButton;

    int cur;

    void Start()
    {
        for (int i = 0; i < quizButton.Length; i++)
        {
            quizButton[i].SetActive(false);
        }

        dropdown.SetActive(false);

        imageBlocker.enabled = false;
        infoPop[0].SetActive(false);
        infoPop[1].SetActive(false);
        fishGillsImage.SetActive(false);

        isSelected = new bool[5];

        for (int i = 0; i < Objects.Length; i++)
        {
            Objects[i].SetActive(false);
        }

        for (int i = 0; i < cam.Length; i++)
        {
            cam[i].SetActive(false);
            cam[0].SetActive(true);
        }

        for (int i = 0; i < button.Length; i++)
        {
            button[i].SetActive(false);
        }
    }

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch0 = Input.GetTouch(0);

            if (touch0.phase == TouchPhase.Moved)
            {
                GO.transform.Rotate(/*touch0.deltaPosition.y * rotationSpeed */0f,
                    -touch0.deltaPosition.x * rotationSpeed, 0f, Space.World); // apply rotation to an object
            }
        }

        //if (backgroundImage.GetComponent<Animation>().isPlaying)
        //{
        //    moreOptions.GetComponent<Button>().interactable = false;
        //}
        //else if (!backgroundImage.GetComponent<Animation>().isPlaying)
        //{
        //    moreOptions.GetComponent<Button>().interactable = true;
        //}

        //if (isOpen)
        //{
        //    moreOptions.GetComponent<Image>().sprite = moreButtonImages[1];
        //}
        //else if (!isOpen)
        //{
        //    moreOptions.GetComponent<Image>().sprite = moreButtonImages[0];
        //}
    }

    public void Backerrr()
    {
        imageBlocker.enabled = false;
        infoPop[0].SetActive(false);
        infoPop[1].SetActive(false);

        dropdown.GetComponent<TMP_Dropdown>().value = 0;

        fishGillsImage.SetActive(false);
    }

    public void HandleInputData() // dropdown
    {
        if (dropdown.GetComponent<TMP_Dropdown>().value == 1 && cur == 1) // lungs
        {
            infoPop[1].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = arClass.d1.showInfo1;
            infoPop[1].SetActive(true);
            infoPop[1].GetComponent<Animation>().Play("MoreInfoPop");
            imageBlocker.enabled = true;
        }
        //else if (dropdown.GetComponent<TMP_Dropdown>().value == 2 && cur == 1)
        //{
        //    infoPop.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = arClass.d1.showInfo2;
        //    infoPop.SetActive(true);
        //    infoPop.GetComponent<Animation>().Play("MoreInfoPop");
        //    imageBlocker.enabled = true;
        //}
        //else if (dropdown.GetComponent<TMP_Dropdown>().value == 3 && cur == 1)
        //{
        //    infoPop.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = arClass.d1.showInfo3;
        //    infoPop.SetActive(true);
        //    infoPop.GetComponent<Animation>().Play("MoreInfoPop");
        //    imageBlocker.enabled = true;
        //}

        if (dropdown.GetComponent<TMP_Dropdown>().value == 1 && cur == 2) // gills
        {
            infoPop[1].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = arClass.d2.showInfo1;
            infoPop[1].SetActive(true);
            infoPop[1].GetComponent<Animation>().Play("MoreInfoPop");
            imageBlocker.enabled = true;
        }
        else if (dropdown.GetComponent<TMP_Dropdown>().value == 2 && cur == 2)
        {
            infoPop[0].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = arClass.d2.showInfo2;
            infoPop[0].SetActive(true);
            infoPop[0].GetComponent<Animation>().Play("MoreInfoPop");
            imageBlocker.enabled = true;
            fishGillsImage.SetActive(true);
        }
        //else if (dropdown.GetComponent<TMP_Dropdown>().value == 3 && cur == 2)
        //{
        //    infoPop.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = arClass.d2.showInfo3;
        //    infoPop.SetActive(true);
        //    infoPop.GetComponent<Animation>().Play("MoreInfoPop");
        //    imageBlocker.enabled = true;
        //}

        if (dropdown.GetComponent<TMP_Dropdown>().value == 1 && cur == 3) // spiracle
        {
            infoPop[1].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = arClass.d3.showInfo1;
            infoPop[1].SetActive(true);
            infoPop[1].GetComponent<Animation>().Play("MoreInfoPop");
            imageBlocker.enabled = true;
        }
        else if (dropdown.GetComponent<TMP_Dropdown>().value == 2 && cur == 3)
        {
            infoPop[1].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = arClass.d3.showInfo2;
            infoPop[1].SetActive(true);
            infoPop[1].GetComponent<Animation>().Play("MoreInfoPop");
            imageBlocker.enabled = true;
        }
        //else if (dropdown.GetComponent<TMP_Dropdown>().value == 3 && cur == 3)
        //{
        //    infoPop.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = arClass.d3.showInfo3;
        //    infoPop.SetActive(true);
        //    infoPop.GetComponent<Animation>().Play("MoreInfoPop");
        //    imageBlocker.enabled = true;
        //}
        
        if (dropdown.GetComponent<TMP_Dropdown>().value == 1 && cur == 4) // moist skin
        {
            infoPop[1].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = arClass.d4.showInfo1;
            infoPop[1].SetActive(true);
            infoPop[1].GetComponent<Animation>().Play("MoreInfoPop");
            imageBlocker.enabled = true;
        }
        else if (dropdown.GetComponent<TMP_Dropdown>().value == 2 && cur == 4)
        {
            infoPop[0].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = arClass.d4.showInfo2;
            infoPop[0].SetActive(true);
            infoPop[0].GetComponent<Animation>().Play("MoreInfoPop");
            imageBlocker.enabled = true;
        }
        //else if (dropdown.GetComponent<TMP_Dropdown>().value == 3 && cur == 4)
        //{
        //    infoPop.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = arClass.d4.showInfo3;
        //    infoPop.SetActive(true);
        //    infoPop.GetComponent<Animation>().Play("MoreInfoPop");
        //    imageBlocker.enabled = true;
        //}

        if (dropdown.GetComponent<TMP_Dropdown>().value == 1 && cur == 5) // moist skin
        {
            infoPop[1].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = arClass.d5.showInfo1;
            infoPop[1].SetActive(true);
            infoPop[1].GetComponent<Animation>().Play("MoreInfoPop");
            imageBlocker.enabled = true;
        }
        else if (dropdown.GetComponent<TMP_Dropdown>().value == 2 && cur == 5)
        {
            infoPop[1].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = arClass.d5.showInfo2;
            infoPop[1].SetActive(true);
            infoPop[1].GetComponent<Animation>().Play("MoreInfoPop");
            imageBlocker.enabled = true;
        }
    }

    public void _Lungs()
    {
        for (int i = 0; i < Objects.Length; i++)
        {
            Objects[i].SetActive(false);
            Objects[0].SetActive(true);

            GO = Objects[0];
            GO.transform.rotation = new Quaternion(0, 0, 0, 0); // reset rotation before and after chosen
        }

        for (int i = 0; i < isSelected.Length; i++)
        {
            isSelected[i] = false;
            isSelected[0] = true;
        }

        for (int i = 0; i < button.Length; i++)
        {
            button[i].SetActive(true);
        }

        dropdown.SetActive(true);

        dropdown.GetComponent<TMP_Dropdown>().options[1].text = arClass.d1.option1.ToString();
        //dropdown.GetComponent<TMP_Dropdown>().options[2].text = arClass.d1.option2.ToString();
        //dropdown.GetComponent<TMP_Dropdown>().options[3].text = arClass.d1.option3.ToString();

        dropdown.GetComponent<TMP_Dropdown>().value = 0;

        dropdown.GetComponent<TMP_Dropdown>().ClearOptions();

        List<string> m_DropOptions;
        m_DropOptions = new List<string> { "More info", "Quick Note 1" };

        dropdown.GetComponent<TMP_Dropdown>().AddOptions(m_DropOptions);

        cur = 1;

        StartCoroutine(DoStuff());

        isSlide = false;
        isOpen = false;

        DefaultCamera();
    }

    public void _Gills()
    {
        for (int i = 0; i < Objects.Length; i++)
        {
            Objects[i].SetActive(false);
            Objects[1].SetActive(true);

            GO = Objects[1];
            GO.transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        for (int i = 0; i < isSelected.Length; i++)
        {
            isSelected[i] = false;
            isSelected[1] = true;
        }

        for (int i = 0; i < button.Length; i++)
        {
            button[i].SetActive(true);
        }

        dropdown.SetActive(true);

        dropdown.GetComponent<TMP_Dropdown>().value = 0;

        dropdown.GetComponent<TMP_Dropdown>().ClearOptions();

        List<string> m_DropOptions;
        m_DropOptions = new List<string> { "More info", "Quick Note 1", "Quick Note 2" };

        dropdown.GetComponent<TMP_Dropdown>().AddOptions(m_DropOptions);

        dropdown.GetComponent<TMP_Dropdown>().options[1].text = arClass.d2.option1.ToString();
        dropdown.GetComponent<TMP_Dropdown>().options[2].text = arClass.d2.option2.ToString();
        //dropdown.GetComponent<TMP_Dropdown>().options[3].text = arClass.d2.option3.ToString();

        cur = 2;

        isSlide = false;
        isOpen = false;

        StartCoroutine(DoStuff());

        DefaultCamera();
    }

    public void _Spiracle()
    {
        for (int i = 0; i < Objects.Length; i++)
        {
            Objects[i].SetActive(false);
            Objects[2].SetActive(true);

            GO = Objects[2];
            GO.transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        for (int i = 0; i < isSelected.Length; i++)
        {
            isSelected[i] = false;
            isSelected[2] = true;
        }

        for (int i = 0; i < button.Length; i++)
        {
            button[i].SetActive(true);
        }

        dropdown.SetActive(true);

        dropdown.GetComponent<TMP_Dropdown>().value = 0;

        dropdown.GetComponent<TMP_Dropdown>().ClearOptions();

        List<string> m_DropOptions;
        m_DropOptions = new List<string> { "More info", "Quick Note 1", "Quick Note 2" };

        dropdown.GetComponent<TMP_Dropdown>().AddOptions(m_DropOptions);

        dropdown.GetComponent<TMP_Dropdown>().options[1].text = arClass.d3.option1.ToString();
        dropdown.GetComponent<TMP_Dropdown>().options[2].text = arClass.d3.option2.ToString();
        //dropdown.GetComponent<TMP_Dropdown>().options[3].text = arClass.d3.option3.ToString();
      
        cur = 3;

        isSlide = false;
        isOpen = false;

        StartCoroutine(DoStuff());

        DefaultCamera();
    }

    public void _MoistSkin()
    {
        for (int i = 0; i < Objects.Length; i++)
        {
            Objects[i].SetActive(false);
            Objects[3].SetActive(true);

            GO = Objects[3];
            GO.transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        for (int i = 0; i < isSelected.Length; i++)
        {
            isSelected[i] = false;
            isSelected[3] = true;
        }

        for (int i = 0; i < button.Length; i++)
        {
            button[i].SetActive(true);
        }

        dropdown.SetActive(true);

        dropdown.GetComponent<TMP_Dropdown>().value = 0;

        dropdown.GetComponent<TMP_Dropdown>().ClearOptions();

        List<string> m_DropOptions;
        m_DropOptions = new List<string> { "More info", "Quick Note 1", "Quick Note 2" };

        dropdown.GetComponent<TMP_Dropdown>().AddOptions(m_DropOptions);

        dropdown.GetComponent<TMP_Dropdown>().options[1].text = arClass.d4.option1.ToString();
        dropdown.GetComponent<TMP_Dropdown>().options[2].text = arClass.d4.option2.ToString();
        //dropdown.GetComponent<TMP_Dropdown>().options[3].text = arClass.d4.option3.ToString();

        cur = 4;

        isSlide = false;
        isOpen = false;

        StartCoroutine(DoStuff());

        DefaultCamera();
    }

    public void _LungsAndMoistSkin()
    {
        for (int i = 0; i < Objects.Length; i++)
        {
            Objects[i].SetActive(false);
            Objects[4].SetActive(true);

            GO = Objects[4];
            GO.transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        for (int i = 0; i < isSelected.Length; i++)
        {
            isSelected[i] = false;
            isSelected[4] = true;
        }

        for (int i = 0; i < button.Length; i++)
        {
            button[i].SetActive(true);
        }

        dropdown.SetActive(true);

        dropdown.GetComponent<TMP_Dropdown>().value = 0;

        dropdown.GetComponent<TMP_Dropdown>().ClearOptions();

        List<string> m_DropOptions;
        m_DropOptions = new List<string> { "More info", "Quick Note 1", "Quick Note 2" };

        dropdown.GetComponent<TMP_Dropdown>().AddOptions(m_DropOptions);

        dropdown.GetComponent<TMP_Dropdown>().options[1].text = arClass.d5.option1.ToString();
        dropdown.GetComponent<TMP_Dropdown>().options[2].text = arClass.d5.option2.ToString();
        //dropdown.GetComponent<TMP_Dropdown>().options[3].text = arClass.d4.option3.ToString();

        cur = 5;

        isSlide = false;
        isOpen = false;

        StartCoroutine(DoStuff());

        DefaultCamera();
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("Game-Chapter-4");
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void MoreOptions()
    {
        if (!isSlide)
        {
            isSlide = true;

            backgroundImage.GetComponent<Animation>().Play("MoveRight");

            isOpen = true;

            for (int i = 0; i < quizButton.Length; i++)
            {
                quizButton[i].SetActive(false);
            }

            moreButton.SetActive(false);
        }
        else if (isSlide)
        {
            StartCoroutine(MenuCollapse());
        }
    }

    IEnumerator MenuCollapse()
    {
        isSlide = false;

        backgroundImage.GetComponent<Animation>().Play("MoveLeft");

        isOpen = false;

        if (cur != 0)
        {
            StartCoroutine(DoStuff());
        }

        yield return new WaitForSeconds(0.3f);

        moreButton.SetActive(true);
    }

    public void CameraOne()
    {
        for (int i = 0; i < cam.Length; i++)
        {
            cam[i].SetActive(false);
            cam[0].SetActive(true);
        }
    }

    public void CameraTwo()
    {
        if (isSelected[0])
        {
            for (int i = 0; i < cam.Length; i++)
            {
                cam[i].SetActive(false);
                cam[1].SetActive(true);
            }
        }

        if (isSelected[1])
        {
            for (int i = 0; i < cam.Length; i++)
            {
                cam[i].SetActive(false);
                cam[3].SetActive(true);
            }
        }

        if (isSelected[2])
        {
            for (int i = 0; i < cam.Length; i++)
            {
                cam[i].SetActive(false);
                cam[5].SetActive(true);
            }
        }
    }

    public void GoToQuiz()
    {
        if (cur == 1) // lungs
        {
            SceneManager.LoadScene("Lungs-Question");
        }
        else if (cur == 2) // gills
        {
            SceneManager.LoadScene("Gills-Question");
        }
        else if (cur == 3) // spiracle
        {
            SceneManager.LoadScene("Spiracle-Question");
        }
        else if (cur == 4) // moist skin
        {
            SceneManager.LoadScene("Moist-Skin-Question");
        }
        else if (cur == 5) // moist skin
        {
            SceneManager.LoadScene("Lungs-And-Moist-Skin-Question");
        }
    }

    public void CameraThree()
    {
        if (isSelected[0])
        {
            for (int i = 0; i < cam.Length; i++)
            {
                cam[i].SetActive(false);
                cam[2].SetActive(true);
            }
        }

        if (isSelected[1])
        {
            for (int i = 0; i < cam.Length; i++)
            {
                cam[i].SetActive(false);
                cam[4].SetActive(true);
            }
        }

        if (isSelected[2])
        {
            for (int i = 0; i < cam.Length; i++)
            {
                cam[i].SetActive(false);
                cam[6].SetActive(true);
            }
        }
    }

    void DefaultCamera()
    {
        for (int i = 0; i < cam.Length; i++)
        {
            cam[i].SetActive(false);
            cam[0].SetActive(true);
        }
    }

    IEnumerator DoStuff()
    {
        backgroundImage.GetComponent<Animation>().Play("MoveLeft");

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < quizButton.Length; i++)
        {
            quizButton[i].SetActive(true);
        }

        moreButton.SetActive(true);
    }
}
