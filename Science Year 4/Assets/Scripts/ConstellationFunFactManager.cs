using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ConstellationFunFactManager : MonoBehaviour
{
    [SerializeField] private GameObject[] stuff;
    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;
    [SerializeField] private Button[] nextPrevBut;
    int cur;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        for (int i = 0; i < stuff.Length; i++)
        {
            stuff[i].SetActive(false);
            stuff[0].SetActive(true);
        }
    }

    private void Update()
    {
        if (cur == 0)
        {
            nextPrevBut[1].interactable = false;
        }
        if (cur == 6)
        {
            nextPrevBut[0].interactable = false;
        }

        if (cur != 0 && cur != 6)
        {
            nextPrevBut[0].interactable = true;
            nextPrevBut[1].interactable = true;
        }
    }

    // ---------------- button functions ---------------- //
    public void _Next()
    {
        if (cur == 6)
        {
            return;
        }

        PressSFX();

        cur += 1;
  
        for (int i = 0; i < stuff.Length; i++)
        {
            stuff[i].SetActive(false);
            stuff[cur].SetActive(true);
        }
    }
    
    public void _Prev()
    {
        if (cur == 0)
        {
            return;
        }

        BackSFX();

        cur -= 1;

        for (int i = 0; i < stuff.Length; i++)
        {
            stuff[i].SetActive(false);
            stuff[cur].SetActive(true);
        }
    }

    public void Menu()
    {
        BackSFX();
        SceneManager.LoadScene("Menu");
    }

    // ---------------- SFX ---------------- //
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
}
