using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ConstellationGameManager : MonoBehaviour
{
    [SerializeField] public Transform[] playerPos;
    [SerializeField] private Transform storedeck;

    [SerializeField] public List<GameObject> p1, p2, p3, storedeckList, cards;
    [SerializeField] private GameObject transitionImage, endgamePop, introPop, pausePop, pauseButton, tutorialImage, discardPile, startPile;

    int cur, turn, otherturn, a1turn, a2turn;

    float gapbetween;

    [SerializeField] public bool[] isTurn;
    bool isStarting, playerTurn, hasEndBool, firstTimeBool;
    public bool[] round;

    [SerializeField] private Vector3[] a, b, c;

    //[SerializeField] private Image[] roundMarkerImage;
    [SerializeField] public AudioSource aSource;
    [SerializeField] public AudioClip[] clip;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        introPop.GetComponent<Animation>().Play("EndGamePop-NEW");

        transitionImage.SetActive(false);
        endgamePop.SetActive(false);
        pausePop.SetActive(false);
        pauseButton.SetActive(false);
        tutorialImage.SetActive(false);
        discardPile.SetActive(false);
        startPile.SetActive(false);

        firstTimeBool = true;

        round = new bool[3];
        isTurn = new bool[3];

        foreach (GameObject k in cards)
        {
            k.transform.GetChild(4).gameObject.SetActive(true);
            k.GetComponent<PickCard>().enabled = false;
        }

        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].SetActive(false);
        }

        //for (int i = 0; i < roundMarkerImage.Length; i++)
        //{
        //    roundMarkerImage[i].gameObject.SetActive(false);
        //}
    }

    public void StartTheGame()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        discardPile.SetActive(true);
        startPile.SetActive(true);
        introPop.GetComponent<Animation>().Play("FadeOut");

        yield return new WaitForSeconds(.8f);

        introPop.SetActive(false);

        //for (int i = 0; i < roundMarkerImage.Length; i++)
        //{
        //    roundMarkerImage[i].gameObject.SetActive(true);
        //}

        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].SetActive(true);
        }

        pauseButton.SetActive(true);

        InvokeRepeating("DelegateCards", 0, 0.1f);
    }

    IEnumerator StartTransition() // after cards dealth, use this
    {
        transitionImage.SetActive(true);
        transitionImage.GetComponent<Animation>().Play("TransitionCards");

        //roundMarkerImage[0].color = Color.red;

        yield return new WaitForSeconds(2.5f);

        transitionImage.SetActive(false);
    }

    private void Update()
    {
        if (isStarting)
        {
            _ShowCardBack();
            _HideCardBack();

            if (p1.Count == 0)
            {
                hasEndBool = true;
            }
            else if (p2.Count == 0)
            {
                hasEndBool = true;
            }
            else if (p3.Count == 0)
            {
                hasEndBool = true;
            }
        }

        if (playerTurn)
        {
            playerTurn = false;

            foreach (GameObject k in p2)
            {
                k.GetComponent<PickCard>().enabled = true;
            }
        }
    }

    void DelegateCards()
    {
        if (cards.Count == 0)
        {
            CancelInvoke("DelegateCards");
            InvokeRepeating("ArrangeCards", 0, .2f);
            InvokeRepeating("AIOneArrangeCards", 0, .2f);
            InvokeRepeating("AITwoArrangeCards", 0, .2f);
        }
        else if (cards.Count != 0)
        {
            cur = cards.Count;

            int a = Random.Range(0, cur);
            if (turn == 0)
            {
                p1.Add(cards[a]);
            }
            else if (turn == 1)
            {
                p2.Add(cards[a]);
            }
            else if (turn == 2)
            {
                p3.Add(cards[a]);
            }

            cards.Remove(cards[a]);

            if (turn == 0)
            {
                turn = 1;
            }
            else if (turn == 1)
            {
                turn = 2;
            }
            else if (turn == 2)
            {
                turn = 0;
            }
        }
    }

    public void Pause()
    {
        StartCoroutine(PauseGame());
    }

    IEnumerator PauseGame()
    {
        pausePop.SetActive(true);
        pausePop.GetComponent<Animation>().Play("EndGamePop-NEW");

        pauseButton.SetActive(false);

        yield return new WaitForSeconds(1.5f);

        Time.timeScale = 0;
    }

    public void Unpause()
    {
        pauseButton.SetActive(true);

        Time.timeScale = 1;

        pausePop.SetActive(false);
    }

    public void ArrangeCards()
    {
        if (!isTurn[0])
        {
            int s = p1.Count;

            if (otherturn == s)
            {
                CancelInvoke("ArrangeCards");
                CheckForAnyPairs();
                return;
            }
            else if (otherturn < s)
            {
                p1[otherturn].transform.SetParent(playerPos[0].transform);
                p1[otherturn].transform.position = new Vector3((playerPos[0].position.x - 140f) + gapbetween, 0, 0);

                gapbetween += 30f; // not sure yet

                a[otherturn] = p1[otherturn].transform.position;

                otherturn += 1;
            }
        }
        else if (isTurn[0])
        {
            int t = 0;

            foreach (GameObject k in p1)
            {
                k.transform.position = a[t];
                k.transform.rotation = k.transform.parent.rotation;

                t += 1;
            }

            DisableButtons();
        }
    }

    void AIOneArrangeCards()
    {
        if (!isTurn[1])
        {
            int a1count = p2.Count;

            if (a1turn == a1count)
            {
                CancelInvoke("AIOneArrangeCards");

                T1();
                return;
            }
            else if (a1turn < a1count)
            {
                p2[a1turn].transform.SetParent(playerPos[1].transform);

                p2[a1turn].transform.localPosition = new Vector3((playerPos[1].position.x - 140f) + gapbetween, 0, 0);
                p2[a1turn].transform.localRotation = new Quaternion(0, 0, 0, 0);

                b[a1turn] = p2[a1turn].transform.position;
                a1turn += 1;
            }
        }
        else if (isTurn[1])
        {
            int t = 0;

            foreach (GameObject k in p2)
            {
                k.transform.position = b[t];
                k.transform.rotation = k.transform.parent.rotation;

                t += 1;
            }
        }
    }

    void AITwoArrangeCards()
    {
        if (!isTurn[2])
        {
            int a1count = p3.Count;

            if (a2turn ==  a1count)
            {
                CancelInvoke("AITwoArrangeCards");
                T2();
                return;
            }
            else if (a2turn < a1count)
            {
                p3[a2turn].transform.SetParent(playerPos[2].transform);

                p3[a2turn].transform.localPosition = new Vector3((0 - 140f) + gapbetween, 0, 0);
                p3[a2turn].transform.localRotation = new Quaternion(0, 0, 0, 0);

                c[a2turn] = p3[a2turn].transform.position;

                a2turn += 1;
            }
        }
        else if (isTurn[2])
        {
            int t = 0;

            foreach (GameObject k in p3)
            {
                k.transform.position = c[t];
                k.transform.rotation = k.transform.parent.rotation;

                t += 1;
            }
        }
    }

    #region it is what it is
    public void CheckForAnyPairs()
    {
        List<GameObject> aq = new List<GameObject>();
        List<GameObject> bd = new List<GameObject>();
        List<GameObject> gm = new List<GameObject>();
        List<GameObject> hercu = new List<GameObject>();
        List<GameObject> hyd = new List<GameObject>();
        List<GameObject> lib = new List<GameObject>();
        List<GameObject> ld = new List<GameObject>();
        List<GameObject> ophiu = new List<GameObject>();
        List<GameObject> orion = new List<GameObject>();
        List<GameObject> scor = new List<GameObject>();
        List<GameObject> sc = new List<GameObject>();
        List<GameObject> taurus = new List<GameObject>();

        for (int i = 0; i < p1.Count; i++)
        {
            if (p1[i].CompareTag("Aquarius"))
            {
                aq.Add(p1[i]);
            }

            if (p1[i].CompareTag("Big Dipper"))
            {
                bd.Add(p1[i]);
            }

            if (p1[i].CompareTag("Gemini"))
            {
                gm.Add(p1[i]);
            }

            if (p1[i].CompareTag("Hercules"))
            {
                hercu.Add(p1[i]);
            }

            if (p1[i].CompareTag("Hydra"))
            {
                hyd.Add(p1[i]);
            }

            if (p1[i].CompareTag("Libra"))
            {
                lib.Add(p1[i]);
            }

            if (p1[i].CompareTag("Little Dipper"))
            {
                ld.Add(p1[i]);
            }

            if (p1[i].CompareTag("Ophiuchus"))
            {
                ophiu.Add(p1[i]);
            }

            if (p1[i].CompareTag("Orion"))
            {
                orion.Add(p1[i]);
            }

            if (p1[i].CompareTag("Scorpius"))
            {
                scor.Add(p1[i]);
            }

            if (p1[i].CompareTag("Southern Cross"))
            {
                sc.Add(p1[i]);
            }

            if (p1[i].CompareTag("Taurus"))
            {
                taurus.Add(p1[i]);
            }
        }

        if (aq.Count == 2)
        {
            aq[0].transform.SetParent(storedeck);
            aq[0].SetActive(false);
            aq[1].transform.SetParent(storedeck);

            storedeckList.Add(aq[0]);
            p1.Remove(aq[0]);
            storedeckList.Add(aq[1]);
            p1.Remove(aq[1]);

            aq[0].transform.position = storedeck.position;
            aq[0].transform.rotation = storedeck.rotation;

            aq[1].transform.position = storedeck.position;
            aq[1].transform.rotation = storedeck.rotation;
        }
         if (bd.Count == 2)
        {
            bd[0].transform.SetParent(storedeck);
            bd[0].SetActive(false);
            bd[1].transform.SetParent(storedeck);

            storedeckList.Add(bd[0]);
            p1.Remove(bd[0]);
            storedeckList.Add(bd[1]);
            p1.Remove(bd[1]);

            bd[0].transform.position = storedeck.position;
            bd[0].transform.rotation = storedeck.rotation;

            bd[1].transform.position = storedeck.position;
            bd[1].transform.rotation = storedeck.rotation;
        }
         if (gm.Count == 2)
        {
            gm[0].transform.SetParent(storedeck);
            gm[0].SetActive(false);
            gm[1].transform.SetParent(storedeck);

            storedeckList.Add(gm[0]);
            p1.Remove(gm[0]);
            storedeckList.Add(gm[1]);
            p1.Remove(gm[1]);

            gm[0].transform.position = storedeck.position;
            gm[0].transform.rotation = storedeck.rotation;

            gm[1].transform.position = storedeck.position;
            gm[1].transform.rotation = storedeck.rotation;
        }
        if (hercu.Count == 2)
        {
            hercu[0].transform.SetParent(storedeck);
            hercu[0].SetActive(false);
            hercu[1].transform.SetParent(storedeck);

            storedeckList.Add(hercu[0]);
            p1.Remove(hercu[0]);
            storedeckList.Add(hercu[1]);
            p1.Remove(hercu[1]);

            hercu[0].transform.position = storedeck.position;
            hercu[0].transform.rotation = storedeck.rotation;

            hercu[1].transform.position = storedeck.position;
            hercu[1].transform.rotation = storedeck.rotation;
        }
         if (hyd.Count == 2)
        {
            hyd[0].transform.SetParent(storedeck);
            hyd[0].SetActive(false);
            hyd[1].transform.SetParent(storedeck);

            storedeckList.Add(hyd[0]);
            p1.Remove(hyd[0]);
            storedeckList.Add(hyd[1]);
            p1.Remove(hyd[1]);

            hyd[0].transform.position = storedeck.position;
            hyd[0].transform.rotation = storedeck.rotation;

            hyd[1].transform.position = storedeck.position;
            hyd[1].transform.rotation = storedeck.rotation;
        }
         if (lib.Count == 2)
        {
            lib[0].transform.SetParent(storedeck);
            lib[0].SetActive(false);
            lib[1].transform.SetParent(storedeck);

            storedeckList.Add(lib[0]);
            p1.Remove(lib[0]);
            storedeckList.Add(lib[1]);
            p1.Remove(lib[1]);

            lib[0].transform.position = storedeck.position;
            lib[0].transform.rotation = storedeck.rotation;

            lib[1].transform.position = storedeck.position;
            lib[1].transform.rotation = storedeck.rotation;
        }
         if (ld.Count == 2)
        {
            ld[0].transform.SetParent(storedeck);
            ld[0].SetActive(false);
            ld[1].transform.SetParent(storedeck);

            storedeckList.Add(ld[0]);
            p1.Remove(ld[0]);
            storedeckList.Add(ld[1]);
            p1.Remove(ld[1]);

            ld[0].transform.position = storedeck.position;
            ld[0].transform.rotation = storedeck.rotation;

            ld[1].transform.position = storedeck.position;
            ld[1].transform.rotation = storedeck.rotation;
        }
         if (ophiu.Count == 2)
        {
            ophiu[0].transform.SetParent(storedeck);
            ophiu[0].SetActive(false);
            ophiu[1].transform.SetParent(storedeck);

            storedeckList.Add(ophiu[0]);
            p1.Remove(ophiu[0]);
            storedeckList.Add(ophiu[1]);
            p1.Remove(ophiu[1]);

            ophiu[0].transform.position = storedeck.position;
            ophiu[0].transform.rotation = storedeck.rotation;

            ophiu[1].transform.position = storedeck.position;
            ophiu[1].transform.rotation = storedeck.rotation;
        }
         if (orion.Count == 2)
        {
            orion[0].transform.SetParent(storedeck);
            orion[0].SetActive(false);
            orion[1].transform.SetParent(storedeck);

            storedeckList.Add(orion[0]);
            p1.Remove(orion[0]);
            storedeckList.Add(orion[1]);
            p1.Remove(orion[1]);
          
            orion[0].transform.position = storedeck.position;
            orion[0].transform.rotation = storedeck.rotation;

            orion[1].transform.position = storedeck.position;
            orion[1].transform.rotation = storedeck.rotation;
        }
         if (scor.Count == 2)
        {
            scor[0].transform.SetParent(storedeck);
            scor[0].SetActive(false);
            scor[1].transform.SetParent(storedeck);

            storedeckList.Add(scor[0]);
            p1.Remove(scor[0]);
            storedeckList.Add(scor[1]);
            p1.Remove(scor[1]);

            scor[0].transform.position = storedeck.position;
            scor[0].transform.rotation = storedeck.rotation;

            scor[1].transform.position = storedeck.position;
            scor[1].transform.rotation = storedeck.rotation;
        }
         if (sc.Count == 2)
        {
            sc[0].transform.SetParent(storedeck);
            sc[0].SetActive(false);
            sc[1].transform.SetParent(storedeck);

            storedeckList.Add(sc[0]);
            p1.Remove(sc[0]);
            storedeckList.Add(sc[1]);
            p1.Remove(sc[1]);

            sc[0].transform.position = storedeck.position;
            sc[0].transform.rotation = storedeck.rotation;

            sc[1].transform.position = storedeck.position;
            sc[1].transform.rotation = storedeck.rotation;
        }
         if (taurus.Count == 2)
        {
            taurus[0].transform.SetParent(storedeck);
            taurus[0].SetActive(false);
            taurus[1].transform.SetParent(storedeck);

            storedeckList.Add(taurus[0]);
            p1.Remove(taurus[0]);
            storedeckList.Add(taurus[1]);
            p1.Remove(taurus[1]);

            taurus[0].transform.position = storedeck.position;
            taurus[0].transform.rotation = storedeck.rotation;

            taurus[1].transform.position = storedeck.position;
            taurus[1].transform.rotation = storedeck.rotation;
        }


        if (firstTimeBool)
        {
            StartCoroutine(PopTutorial());
            return;
        }

        if (!isTurn[0])
        {
            round[0] = true;
            StartCoroutine(StartTransition());
        }

        isTurn[0] = true;

        ArrangeCards();

        isStarting = true;
        playerTurn = true;
    }

    void T2()
    { 
        List<GameObject> aq = new List<GameObject>();
        List<GameObject> bd = new List<GameObject>();
        List<GameObject> gm = new List<GameObject>();
        List<GameObject> hercu = new List<GameObject>();
        List<GameObject> hyd = new List<GameObject>();
        List<GameObject> lib = new List<GameObject>();
        List<GameObject> ld = new List<GameObject>();
        List<GameObject> ophiu = new List<GameObject>();
        List<GameObject> orion = new List<GameObject>();
        List<GameObject> scor = new List<GameObject>();
        List<GameObject> sc= new List<GameObject>();
        List<GameObject> taurus = new List<GameObject>();

        for (int i = 0; i < p3.Count; i++)
        {
            if (p3[i].CompareTag("Aquarius"))
            {
                aq.Add(p3[i]);
            }

            if (p3[i].CompareTag("Big Dipper"))
            {
                bd.Add(p3[i]);
            }

            if (p3[i].CompareTag("Gemini"))
            {
                gm.Add(p3[i]);
            }

            if (p3[i].CompareTag("Hercules"))
            {
                hercu.Add(p3[i]);
            }

            if (p3[i].CompareTag("Hydra"))
            {
                hyd.Add(p3[i]);
            }

            if (p3[i].CompareTag("Libra"))
            {
                lib.Add(p3[i]);
            }

            if (p3[i].CompareTag("Little Dipper"))
            {
                ld.Add(p3[i]);
            }

            if (p3[i].CompareTag("Ophiuchus"))
            {
                ophiu.Add(p3[i]);
            }

            if (p3[i].CompareTag("Orion"))
            {
                orion.Add(p3[i]);
            }

            if (p3[i].CompareTag("Scorpius"))
            {
                scor.Add(p3[i]);
            }

            if (p3[i].CompareTag("Southern Cross"))
            {
                sc.Add(p3[i]);
            }

            if (p3[i].CompareTag("Taurus"))
            {
                taurus.Add(p3[i]);
            }
        }

        if (aq.Count == 2)
        {
            aq[0].transform.SetParent(storedeck);
            aq[0].SetActive(false);
            aq[1].transform.SetParent(storedeck);

            storedeckList.Add(aq[0]);
            p3.Remove(aq[0]);
            storedeckList.Add(aq[1]);
            p3.Remove(aq[1]);

            aq[0].transform.position = storedeck.position;
            aq[0].transform.rotation = storedeck.rotation;

            aq[1].transform.position = storedeck.position;
            aq[1].transform.rotation = storedeck.rotation;
        }
         if (bd.Count == 2)
        {
            bd[0].transform.SetParent(storedeck);
            bd[0].SetActive(false);
            bd[1].transform.SetParent(storedeck);

            storedeckList.Add(bd[0]);
            p3.Remove(bd[0]);
            storedeckList.Add(bd[1]);
            p3.Remove(bd[1]);

            bd[0].transform.position = storedeck.position;
            bd[0].transform.rotation = storedeck.rotation;

            bd[1].transform.position = storedeck.position;
            bd[1].transform.rotation = storedeck.rotation;
        }
         if (gm.Count == 2)
        {
            gm[0].transform.SetParent(storedeck);
            gm[0].SetActive(false);
            gm[1].transform.SetParent(storedeck);

            storedeckList.Add(gm[0]);
            p3.Remove(gm[0]);
            storedeckList.Add(gm[1]);
            p3.Remove(gm[1]);

            gm[0].transform.position = storedeck.position;
            gm[0].transform.rotation = storedeck.rotation;

            gm[1].transform.position = storedeck.position;
            gm[1].transform.rotation = storedeck.rotation;
        }
         if (hercu.Count == 2)
        {
            hercu[0].transform.SetParent(storedeck);
            hercu[0].SetActive(false);
            hercu[1].transform.SetParent(storedeck);

            storedeckList.Add(hercu[0]);
            p3.Remove(hercu[0]);
            storedeckList.Add(hercu[1]);
            p3.Remove(hercu[1]);

            hercu[0].transform.position = storedeck.position;
            hercu[0].transform.rotation = storedeck.rotation;

            hercu[1].transform.position = storedeck.position;
            hercu[1].transform.rotation = storedeck.rotation;
        }
         if (hyd.Count == 2)
        {
            hyd[0].transform.SetParent(storedeck);
            hyd[0].SetActive(false);
            hyd[1].transform.SetParent(storedeck);

            storedeckList.Add(hyd[0]);
            p3.Remove(hyd[0]);
            storedeckList.Add(hyd[1]);
            p3.Remove(hyd[1]);

            hyd[0].transform.position = storedeck.position;
            hyd[0].transform.rotation = storedeck.rotation;

            hyd[1].transform.position = storedeck.position;
            hyd[1].transform.rotation = storedeck.rotation;
        }
         if (lib.Count == 2)
        {
            lib[0].transform.SetParent(storedeck);
            lib[0].SetActive(false);
            lib[1].transform.SetParent(storedeck);

            storedeckList.Add(lib[0]);
            p3.Remove(lib[0]);
            storedeckList.Add(lib[1]);
            p3.Remove(lib[1]);

            lib[0].transform.position = storedeck.position;
            lib[0].transform.rotation = storedeck.rotation;

            lib[1].transform.position = storedeck.position;
            lib[1].transform.rotation = storedeck.rotation;
        }
         if (ld.Count == 2)
        {
            ld[0].transform.SetParent(storedeck);
            ld[0].SetActive(false);
            ld[1].transform.SetParent(storedeck);

            storedeckList.Add(ld[0]);
            p3.Remove(ld[0]);
            storedeckList.Add(ld[1]);
            p3.Remove(ld[1]);

            ld[0].transform.position = storedeck.position;
            ld[0].transform.rotation = storedeck.rotation;

            ld[1].transform.position = storedeck.position;
            ld[1].transform.rotation = storedeck.rotation;
        }
         if (ophiu.Count == 2)
        {
            ophiu[0].transform.SetParent(storedeck);
            ophiu[0].SetActive(false);
            ophiu[1].transform.SetParent(storedeck);

            storedeckList.Add(ophiu[0]);
            p3.Remove(ophiu[0]);
            storedeckList.Add(ophiu[1]);
            p3.Remove(ophiu[1]);

            ophiu[0].transform.position = storedeck.position;
            ophiu[0].transform.rotation = storedeck.rotation;

            ophiu[1].transform.position = storedeck.position;
            ophiu[1].transform.rotation = storedeck.rotation;
        }
         if (orion.Count == 2)
        {
            orion[0].transform.SetParent(storedeck);
            orion[0].SetActive(false);
            orion[1].transform.SetParent(storedeck);

            storedeckList.Add(orion[0]);
            p3.Remove(orion[0]);
            storedeckList.Add(orion[1]);
            p3.Remove(orion[1]);

            orion[0].transform.position = storedeck.position;
            orion[0].transform.rotation = storedeck.rotation;

            orion[1].transform.position = storedeck.position;
            orion[1].transform.rotation = storedeck.rotation;
        }
         if (scor.Count == 2)
        {
            scor[0].transform.SetParent(storedeck);
            scor[0].SetActive(false);
            scor[1].transform.SetParent(storedeck);

            storedeckList.Add(scor[0]);
            p3.Remove(scor[0]);
            storedeckList.Add(scor[1]);
            p3.Remove(scor[1]);

            scor[0].transform.position = storedeck.position;
            scor[0].transform.rotation = storedeck.rotation;

            scor[1].transform.position = storedeck.position;
            scor[1].transform.rotation = storedeck.rotation;
        }
         if (sc.Count == 2)
        {
            sc[0].transform.SetParent(storedeck);
            sc[0].SetActive(false);
            sc[1].transform.SetParent(storedeck);

            storedeckList.Add(sc[0]);
            p3.Remove(sc[0]);
            storedeckList.Add(sc[1]);
            p3.Remove(sc[1]);

            sc[0].transform.position = storedeck.position;
            sc[0].transform.rotation = storedeck.rotation;

            sc[1].transform.position = storedeck.position;
            sc[1].transform.rotation = storedeck.rotation;
        }
         if (taurus.Count == 2)
        {
            taurus[0].transform.SetParent(storedeck);
            taurus[0].SetActive(false);
            taurus[1].transform.SetParent(storedeck);

            storedeckList.Add(taurus[0]);
            p3.Remove(taurus[0]);
            storedeckList.Add(taurus[1]);
            p3.Remove(taurus[1]);

            taurus[0].transform.position = storedeck.position;
            taurus[0].transform.rotation = storedeck.rotation;

            taurus[1].transform.position = storedeck.position;
            taurus[1].transform.rotation = storedeck.rotation;
        }

        isTurn[2] = true;

        AITwoArrangeCards();
    } // player 3

    void T1() // player 2
    {
        List<GameObject> aq = new List<GameObject>();
        List<GameObject> bd = new List<GameObject>();
        List<GameObject> gm = new List<GameObject>();
        List<GameObject> hercu = new List<GameObject>();
        List<GameObject> hyd = new List<GameObject>();
        List<GameObject> lib = new List<GameObject>();
        List<GameObject> ld = new List<GameObject>();
        List<GameObject> ophiu = new List<GameObject>();
        List<GameObject> orion = new List<GameObject>();
        List<GameObject> scor = new List<GameObject>();
        List<GameObject> sc = new List<GameObject>();
        List<GameObject> taurus = new List<GameObject>();

        for (int i = 0; i < p2.Count; i++)
        {
            if (p2[i].CompareTag("Aquarius"))
            {
                aq.Add(p2[i]);
            }

            if (p2[i].CompareTag("Big Dipper"))
            {
                bd.Add(p2[i]);
            }

            if (p2[i].CompareTag("Gemini"))
            {
                gm.Add(p2[i]);
            }

            if (p2[i].CompareTag("Hercules"))
            {
                hercu.Add(p2[i]);
            }

            if (p2[i].CompareTag("Hydra"))
            {
                hyd.Add(p2[i]);
            }

            if (p2[i].CompareTag("Libra"))
            {
                lib.Add(p2[i]);
            }

            if (p2[i].CompareTag("Little Dipper"))
            {
                ld.Add(p2[i]);
            }

            if (p2[i].CompareTag("Ophiuchus"))
            {
                ophiu.Add(p2[i]);
            }

            if (p2[i].CompareTag("Orion"))
            {
                orion.Add(p2[i]);
            }

            if (p2[i].CompareTag("Scorpius"))
            {
                scor.Add(p2[i]);
            }

            if (p2[i].CompareTag("Southern Cross"))
            {
                sc.Add(p2[i]);
            }

            if (p2[i].CompareTag("Taurus"))
            {
                taurus.Add(p2[i]);
            }
        }

        if (aq.Count == 2)
        {
            aq[0].transform.SetParent(storedeck);
            aq[0].SetActive(false);
            aq[1].transform.SetParent(storedeck);

            storedeckList.Add(aq[0]);
            p2.Remove(aq[0]);
            storedeckList.Add(aq[1]);
            p2.Remove(aq[1]);

            aq[0].transform.position = storedeck.position;
            aq[0].transform.rotation = storedeck.rotation;

            aq[1].transform.position = storedeck.position;
            aq[1].transform.rotation = storedeck.rotation;
        }
         if (bd.Count == 2)
        {
            bd[0].transform.SetParent(storedeck);
            bd[0].SetActive(false);
            bd[1].transform.SetParent(storedeck);

            storedeckList.Add(bd[0]);
            p2.Remove(bd[0]);
            storedeckList.Add(bd[1]);
            p2.Remove(bd[1]);

            bd[0].transform.position = storedeck.position;
            bd[0].transform.rotation = storedeck.rotation;

            bd[1].transform.position = storedeck.position;
            bd[1].transform.rotation = storedeck.rotation;
        }
         if (gm.Count == 2)
        {
            gm[0].transform.SetParent(storedeck);
            gm[0].SetActive(false);
            gm[1].transform.SetParent(storedeck);

            storedeckList.Add(gm[0]);
            p2.Remove(gm[0]);
            storedeckList.Add(gm[1]);
            p2.Remove(gm[1]);

            gm[0].transform.position = storedeck.position;
            gm[0].transform.rotation = storedeck.rotation;

            gm[1].transform.position = storedeck.position;
            gm[1].transform.rotation = storedeck.rotation;
        }
         if (hercu.Count == 2)
        {
            hercu[0].transform.SetParent(storedeck);
            hercu[0].SetActive(false);
            hercu[1].transform.SetParent(storedeck);

            storedeckList.Add(hercu[0]);
            p2.Remove(hercu[0]);
            storedeckList.Add(hercu[1]);
            p2.Remove(hercu[1]);

            hercu[0].transform.position = storedeck.position;
            hercu[0].transform.rotation = storedeck.rotation;

            hercu[1].transform.position = storedeck.position;
            hercu[1].transform.rotation = storedeck.rotation;
        }
         if (hyd.Count == 2)
        {
            hyd[0].transform.SetParent(storedeck);
            hyd[0].SetActive(false);
            hyd[1].transform.SetParent(storedeck);

            storedeckList.Add(hyd[0]);
            p2.Remove(hyd[0]);
            storedeckList.Add(hyd[1]);
            p2.Remove(hyd[1]);

            hyd[0].transform.position = storedeck.position;
            hyd[0].transform.rotation = storedeck.rotation;

            hyd[1].transform.position = storedeck.position;
            hyd[1].transform.rotation = storedeck.rotation;
        }
         if (lib.Count == 2)
        {
            lib[0].transform.SetParent(storedeck);
            lib[0].SetActive(false);
            lib[1].transform.SetParent(storedeck);

            storedeckList.Add(lib[0]);
            p2.Remove(lib[0]);
            storedeckList.Add(lib[1]);
            p2.Remove(lib[1]);

            lib[0].transform.position = storedeck.position;
            lib[0].transform.rotation = storedeck.rotation;

            lib[1].transform.position = storedeck.position;
            lib[1].transform.rotation = storedeck.rotation;
        }
         if (ld.Count == 2)
        {
            ld[0].transform.SetParent(storedeck);
            ld[0].SetActive(false);
            ld[1].transform.SetParent(storedeck);

            storedeckList.Add(ld[0]);
            p2.Remove(ld[0]);
            storedeckList.Add(ld[1]);
            p2.Remove(ld[1]);

            ld[0].transform.position = storedeck.position;
            ld[0].transform.rotation = storedeck.rotation;

            ld[1].transform.position = storedeck.position;
            ld[1].transform.rotation = storedeck.rotation;
        }
         if (ophiu.Count == 2)
        {
            ophiu[0].transform.SetParent(storedeck);
            ophiu[0].SetActive(false);
            ophiu[1].transform.SetParent(storedeck);

            storedeckList.Add(ophiu[0]);
            p2.Remove(ophiu[0]);
            storedeckList.Add(ophiu[1]);
            p2.Remove(ophiu[1]);

            ophiu[0].transform.position = storedeck.position;
            ophiu[0].transform.rotation = storedeck.rotation;

            ophiu[1].transform.position = storedeck.position;
            ophiu[1].transform.rotation = storedeck.rotation;
        }
         if (orion.Count == 2)
        {
            orion[0].transform.SetParent(storedeck);
            orion[0].SetActive(false);
            orion[1].transform.SetParent(storedeck);

            storedeckList.Add(orion[0]);
            p2.Remove(orion[0]);
            storedeckList.Add(orion[1]);
            p2.Remove(orion[1]);

            orion[0].transform.position = storedeck.position;
            orion[0].transform.rotation = storedeck.rotation;

            orion[1].transform.position = storedeck.position;
            orion[1].transform.rotation = storedeck.rotation;
        }
         if (scor.Count == 2)
        {
            scor[0].transform.SetParent(storedeck);
            scor[0].SetActive(false);
            scor[1].transform.SetParent(storedeck);

            storedeckList.Add(scor[0]);
            p2.Remove(scor[0]);
            storedeckList.Add(scor[1]);
            p2.Remove(scor[1]);

            scor[0].transform.position = storedeck.position;
            scor[0].transform.rotation = storedeck.rotation;

            scor[1].transform.position = storedeck.position;
            scor[1].transform.rotation = storedeck.rotation;
        }
         if (sc.Count == 2)
        {
            sc[0].transform.SetParent(storedeck);
            sc[0].SetActive(false);
            sc[1].transform.SetParent(storedeck);

            storedeckList.Add(sc[0]);
            p2.Remove(sc[0]);
            storedeckList.Add(sc[1]);
            p2.Remove(sc[1]);

            sc[0].transform.position = storedeck.position;
            sc[0].transform.rotation = storedeck.rotation;

            sc[1].transform.position = storedeck.position;
            sc[1].transform.rotation = storedeck.rotation;
        }
         if (taurus.Count == 2)
        {
            taurus[0].transform.SetParent(storedeck);
            taurus[0].SetActive(false);
            taurus[1].transform.SetParent(storedeck);

            storedeckList.Add(taurus[0]);
            p2.Remove(taurus[0]);
            storedeckList.Add(taurus[1]);
            p2.Remove(taurus[1]);

            taurus[0].transform.position = storedeck.position;
            taurus[0].transform.rotation = storedeck.rotation;

            taurus[1].transform.position = storedeck.position;
            taurus[1].transform.rotation = storedeck.rotation;
        }

        isTurn[1] = true;

        AIOneArrangeCards();
    }
    #endregion

    public void P3toP2()
    {
        StartCoroutine(P2Delay());
    }

    IEnumerator P2Delay()
    {
        DisableButtons();

        yield return new WaitForSeconds(.5f);

        int t = Random.Range(0, p3.Count);

        p3[t].GetComponent<Animation>().Play("CardSelected");

        yield return new WaitForSeconds(1f);

        p3[t].transform.SetParent(playerPos[1]);

        p2.Add(p3[t]);
        p3.Remove(p3[t]);

        yield return new WaitForSeconds(.1f);

        if (p2.Count > 0)
        {
            p2[p2.Count - 1].GetComponent<Animation>().Play("CardSelected2"); // on group only, not in store
        }
        else if (p2.Count == 0)
        {
            EndGame();
        }

        T1();

        yield return new WaitForSeconds(1f); // 1

        Round();
    }

    public void P1toP3()
    {
        StartCoroutine(P3Delay());
    }

    IEnumerator P3Delay()
    {
        DisableButtons();

        yield return new WaitForSeconds(.5f);

        int t = Random.Range(0, p1.Count);

        p1[t].GetComponent<Animation>().Play("CardSelected3");

        yield return new WaitForSeconds(1f); // 1.5

        p1[t].transform.SetParent(playerPos[2]);

        p3.Add(p1[t]);
        p1.Remove(p1[t]);

        if (p3.Count > 0)
        {
            p3[p3.Count - 1].GetComponent<Animation>().Play("CardSelected2"); // conflicted when list is 0
        }
        else if (p3.Count == 0)
        {
            EndGame();
        }

        T2();

        yield return new WaitForSeconds(1f); // 1

        Round();
    }

    public void Round()
    {
        if (hasEndBool)
        {
            EndGame();
            return;
        }


        if (round[0])
        {
            round[0] = false;
            round[1] = true;
            round[2] = false;

            transitionImage.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Player 2 turn";
            StartCoroutine(EndingRounds());
        }
        else if (round[1])
        {
            round[0] = false;
            round[1] = false;
            round[2] = true;

            transitionImage.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Player 3 turn";
            StartCoroutine(EndingRounds());
        }
        else if (round[2])
        {
            round[0] = true;
            round[1] = false;
            round[2] = false;

            transitionImage.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Your turn";
            StartCoroutine(EndingRounds());

            playerTurn = true;
        }
    }

    IEnumerator PopTutorial()
    {
        tutorialImage.SetActive(true);
        tutorialImage.GetComponent<Animation>().Play("StartTutorial");

        yield return new WaitForSeconds(2f);

        firstTimeBool = false;
        tutorialImage.SetActive(false);
        //StartCoroutine(CheckForAnyPairs());
        CheckForAnyPairs();
    }

    IEnumerator EndingRounds()
    {
        if (hasEndBool)
        {
            EndGame();
            yield return null;
        }

        transitionImage.SetActive(true);
        transitionImage.GetComponent<Animation>().Play("TransitionCards");

        yield return new WaitForSeconds(2.5f);

        if (round[0])
        {
            //for (int i = 0; i < roundMarkerImage.Length; i++)
            //{
            //    roundMarkerImage[i].color = Color.white;
            //    roundMarkerImage[0].color = Color.red;
            //}
        }
        else if (round[1])
        {
            //for (int i = 0; i < roundMarkerImage.Length; i++)
            //{
            //    roundMarkerImage[i].color = Color.white;
            //    roundMarkerImage[1].color = Color.red;
            //}

            P3toP2();
        }
        else if (round[2])
        {
            //for (int i = 0; i < roundMarkerImage.Length; i++)
            //{
            //    roundMarkerImage[i].color = Color.white;
            //    roundMarkerImage[2].color = Color.red;
            //}

            P1toP3();
        }

        transitionImage.SetActive(false);
    }

    public void DisableButtons()
    {
        foreach (GameObject go in p1)
        {
            go.GetComponent<PickCard>().enabled = false;
        }

        foreach (GameObject go in p3)
        {
            go.GetComponent<PickCard>().enabled = false;
        }
    }

    void _ShowCardBack()
    {
        foreach (GameObject k in p2)
        {
            k.transform.GetChild(4).gameObject.SetActive(true);
        }

        foreach (GameObject k in p3)
        {
            k.transform.GetChild(4).gameObject.SetActive(true);
        }
    }

    void _HideCardBack()
    {
        foreach (GameObject k in p1)
        {
            k.transform.GetChild(4).gameObject.SetActive(false);
        }

        foreach (GameObject k in storedeckList)
        {
            k.transform.GetChild(4).gameObject.SetActive(false);
        }
    }

    void EndGame()
    {
        endgamePop.SetActive(true);
        endgamePop.GetComponent<Animation>().Play("EndGamePop-NEW");
    }

    // ------------ Functions -------------- //

    // ------------ Coroutines -------------- //

    // ------------ Scene Loaders -------------- //
    public void _BacktoAR()
    {
        SceneManager.LoadScene("Menu");
    }

    public void _PlayAgain()
    {
        SceneManager.LoadScene("Y6 - Constellation Game");
    }

    // ------------ SFX -------------- //
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
