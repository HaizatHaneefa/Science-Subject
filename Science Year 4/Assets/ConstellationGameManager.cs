using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstellationGameManager : MonoBehaviour
{
    [SerializeField] public Transform[] playerPos;
    [SerializeField] private Transform storedeck;

    [SerializeField] public List<GameObject> p1, p2, p3, storedeckList, cards;

    int cur, turn, otherturn, a1turn, a2turn;

    float gapbetween;

    [SerializeField] public bool isTurn;
    [SerializeField] private Vector3[] a, b, c;

    void Start()
    {
        InvokeRepeating("DelegateCards", 0, 0.1f);
    }

    void DelegateCards()
    {
        if (cards.Count == 0)
        {
            CancelInvoke();
            InvokeRepeating("ArrangeCards", 0, 0.1f);
            InvokeRepeating("AIOneArrangeCards", 0, 0.1f);
            InvokeRepeating("AITwoArrangeCards", 0, 0.1f);
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

    public void ArrangeCards()
    {
        if (!isTurn)
        {
            int s = p1.Count;

            if (otherturn == s)
            {
                CancelInvoke("ArrangeCards");
                CheckForAnyPairs();
            }
            else if (otherturn != s)
            {
                p1[otherturn].transform.SetParent(playerPos[0].transform);
                p1[otherturn].transform.position = new Vector3(playerPos[0].position.x + gapbetween, 0, 0);

                gapbetween += 40f;

                a[otherturn] = p1[otherturn].transform.position;

                otherturn += 1;
            }
        }
        else if (isTurn)
        {
            int t = 0;

            foreach (GameObject k in p1)
            {
                k.transform.position = a[t];
                k.transform.rotation = k.transform.parent.rotation;

                t += 1;
            }
        }
    }

    void AIOneArrangeCards()
    {
        if (!isTurn)
        {
            int a1count = p2.Count;

            if (a1turn == a1count)
            {
                CancelInvoke("AIOneArrangeCards");
                t1();
            }
            else if (a1turn != a1count)
            {
                p2[a1turn].transform.SetParent(playerPos[1].transform);
                p2[a1turn].transform.localPosition = new Vector3(0 + gapbetween, 0, 0);
                p2[a1turn].transform.localRotation = new Quaternion(0, 0, 0, 0);

                b[a1turn] = p2[a1turn].transform.position;
                a1turn += 1;
            }
        }
        else if (isTurn)
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
        if (!isTurn)
        {
            int a1count = p3.Count;

            if (a2turn == a1count)
            {
                CancelInvoke("AITwoArran3geCards");
                t2();
            }
            else if (a2turn != a1count)
            {
                p3[a2turn].transform.SetParent(playerPos[2].transform);
                p3[a2turn].transform.localPosition = new Vector3(0 - gapbetween, 0, 0);
                p3[a2turn].transform.localRotation = new Quaternion(0, 0, 0, 0);

                c[a2turn] = p3[a2turn].transform.position;

                a2turn += 1;
            }
        }
        else if (isTurn)
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
            bd[1].transform.SetParent(storedeck);

            storedeckList.Add(bd[0]);
            p1.Remove(bd[0]);
            storedeckList.Add(bd[1]);

            bd[0].transform.position = storedeck.position;
            bd[0].transform.rotation = storedeck.rotation;

            bd[1].transform.position = storedeck.position;
            bd[1].transform.rotation = storedeck.rotation;
        }
         if (gm.Count == 2)
        {
            gm[0].transform.SetParent(storedeck);
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

        isTurn = true;
    }

    void t2()
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
    }

    void t1()
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

            if (p2[i].CompareTag("Hercules"))
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
    }
    #endregion

    public void P3toP2()
    {
        int t = Random.Range(0, p3.Count);

        p3[t].transform.SetParent(playerPos[1]);

        p2.Add(p3[t]);
        p3.Remove(p3[t]);

        AIOneArrangeCards();
        t1();

        DisableButtons();

        P1toP3();
    }

    public void P1toP3()
    {
        int t = Random.Range(0, p1.Count);

        p1[t].transform.SetParent(playerPos[2]);
        p3.Add(p1[t]);
        p1.Remove(p1[t]);

        AITwoArrangeCards();
        t2();

        DisableButtons();
    }

    public void DisableButtons()
    {
        foreach (GameObject go in p1)
        {
            go.GetComponent<Button>().enabled = false;
        }

        foreach (GameObject go in p3)
        {
            go.GetComponent<Button>().enabled = false;
        }

        foreach (GameObject go in p2)
        {
            go.GetComponent<Button>().enabled = true;
        }
    }
}
