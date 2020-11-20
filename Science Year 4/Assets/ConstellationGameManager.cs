using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstellationGameManager : MonoBehaviour
{
    [SerializeField] private Transform[] playerPos;
    [SerializeField] private Transform storedeck;

    [SerializeField] private List<GameObject> p1, p2, p3;

    public List<GameObject> cards; // List that holds all my ten cards
    int cur, turn, otherturn, a1turn, a2turn;

    float gapbetween;

    void Start()
    {
        InvokeRepeating("DelegateCards", 0, 0.1f);
    }

    void Update()
    {
        
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

    void ArrangeCards()
    {
        int s = p1.Count;

        if (otherturn == s)
        {
            CancelInvoke("ArrangeCards");
            CheckForAnyPairs();
            //return;
        }
        else if (otherturn != s)
        {
            p1[otherturn].transform.SetParent(playerPos[0].transform);
            p1[otherturn].transform.position = new Vector3(playerPos[0].position.x + gapbetween, 0, 0);

            gapbetween += 40f;

            otherturn += 1;
        }
    }

    void AIOneArrangeCards()
    {
        int a1count = p2.Count;

        if (a1turn == a1count)
        {
            CancelInvoke("AIOneArrangeCards");
            CheckForAnyPairs();
            //return;
        }
        else if (a1turn != a1count)
        {
            p2[a1turn].transform.SetParent(playerPos[1].transform);
            p2[a1turn].transform.localPosition = new Vector3(0 + gapbetween, 0, 0);
            p2[a1turn].transform.localRotation = new Quaternion(0, 0, 0, 0);

            a1turn += 1;
        }
    }

    void AITwoArrangeCards()
    {
        int a1count = p3.Count;

        if (a2turn == a1count)
        {
            CancelInvoke("AITwoArrangeCards");
            CheckForAnyPairs();
            //return;
        }
        else if (a2turn != a1count)
        {
            p3[a2turn].transform.SetParent(playerPos[2].transform);
            p3[a2turn].transform.localPosition = new Vector3(0 - gapbetween, 0, 0);
            p3[a2turn].transform.localRotation = new Quaternion(0, 0, 0, 0);

            a2turn += 1;
        }
    }

    void CheckForAnyPairs()
    {
        Debug.Log("working");

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

            if (p1[i].CompareTag("Aquarius"))
            {
                gm.Add(p1[i]);
            }

            if (p1[i].CompareTag("Aquarius"))
            {
                hercu.Add(p1[i]);
            }

            if (p1[i].CompareTag("Aquarius"))
            {
                hyd.Add(p1[i]);
            }

            if (p1[i].CompareTag("Aquarius"))
            {
                lib.Add(p1[i]);
            }

            if (p1[i].CompareTag("Aquarius"))
            {
                ld.Add(p1[i]);
            }

            if (p1[i].CompareTag("Aquarius"))
            {
                ophiu.Add(p1[i]);
            }

            if (p1[i].CompareTag("Aquarius"))
            {
                orion.Add(p1[i]);
            }

            if (p1[i].CompareTag("Aquarius"))
            {
                scor.Add(p1[i]);
            }

            if (p1[i].CompareTag("Aquarius"))
            {
                sc.Add(p1[i]);
            }

            if (p1[i].CompareTag("Aquarius"))
            {
                taurus.Add(p1[i]);
            }
        }

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

            if (p2[i].CompareTag("Aquarius"))
            {
                gm.Add(p2[i]);
            }

            if (p2[i].CompareTag("Aquarius"))
            {
                hercu.Add(p2[i]);
            }

            if (p2[i].CompareTag("Aquarius"))
            {
                hyd.Add(p2[i]);
            }

            if (p2[i].CompareTag("Aquarius"))
            {
                lib.Add(p2[i]);
            }

            if (p2[i].CompareTag("Aquarius"))
            {
                ld.Add(p2[i]);
            }

            if (p2[i].CompareTag("Aquarius"))
            {
                ophiu.Add(p2[i]);
            }

            if (p2[i].CompareTag("Aquarius"))
            {
                orion.Add(p2[i]);
            }

            if (p2[i].CompareTag("Aquarius"))
            {
                scor.Add(p2[i]);
            }

            if (p2[i].CompareTag("Aquarius"))
            {
                sc.Add(p2[i]);
            }

            if (p2[i].CompareTag("Aquarius"))
            {
                taurus.Add(p2[i]);
            }
        }

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

            if (p3[i].CompareTag("Aquarius"))
            {
                gm.Add(p3[i]);
            }

            if (p3[i].CompareTag("Aquarius"))
            {
                hercu.Add(p3[i]);
            }

            if (p3[i].CompareTag("Aquarius"))
            {
                hyd.Add(p3[i]);
            }

            if (p3[i].CompareTag("Aquarius"))
            {
                lib.Add(p3[i]);
            }

            if (p3[i].CompareTag("Aquarius"))
            {
                ld.Add(p3[i]);
            }

            if (p3[i].CompareTag("Aquarius"))
            {
                ophiu.Add(p3[i]);
            }

            if (p3[i].CompareTag("Aquarius"))
            {
                orion.Add(p3[i]);
            }

            if (p3[i].CompareTag("Aquarius"))
            {
                scor.Add(p3[i]);
            }

            if (p3[i].CompareTag("Aquarius"))
            {
                sc.Add(p3[i]);
            }

            if (p3[i].CompareTag("Aquarius"))
            {
                taurus.Add(p3[i]);
            }
        }

        if (aq.Count == 2)
        {
            aq[0].transform.SetParent(storedeck);
            aq[1].transform.SetParent(storedeck);

            aq[0].transform.position = storedeck.position;
            aq[0].transform.rotation = storedeck.rotation;

            aq[1].transform.position = storedeck.position;
            aq[1].transform.rotation = storedeck.rotation;
        }
        else if (bd.Count == 2)
        {
            bd[0].transform.SetParent(storedeck);
            bd[1].transform.SetParent(storedeck);

            bd[0].transform.position = storedeck.position;
            bd[0].transform.rotation = storedeck.rotation;

            bd[1].transform.position = storedeck.position;
            bd[1].transform.rotation = storedeck.rotation;
        }
        else if (gm.Count == 2)
        {
            gm[0].transform.SetParent(storedeck);
            gm[1].transform.SetParent(storedeck);

            gm[0].transform.position = storedeck.position;
            gm[0].transform.rotation = storedeck.rotation;

            gm[1].transform.position = storedeck.position;
            gm[1].transform.rotation = storedeck.rotation;
        }
        else if (hercu.Count == 2)
        {
            hercu[0].transform.SetParent(storedeck);
            hercu[1].transform.SetParent(storedeck);

            hercu[0].transform.position = storedeck.position;
            hercu[0].transform.rotation = storedeck.rotation;

            hercu[1].transform.position = storedeck.position;
            hercu[1].transform.rotation = storedeck.rotation;
        }
        else if (hyd.Count == 2)
        {
            hyd[0].transform.SetParent(storedeck);
            hyd[1].transform.SetParent(storedeck);

            hyd[0].transform.position = storedeck.position;
            hyd[0].transform.rotation = storedeck.rotation;

            hyd[1].transform.position = storedeck.position;
            hyd[1].transform.rotation = storedeck.rotation;
        }
        else if (lib.Count == 2)
        {
            lib[0].transform.SetParent(storedeck);
            lib[1].transform.SetParent(storedeck);

            lib[0].transform.position = storedeck.position;
            lib[0].transform.rotation = storedeck.rotation;

            lib[1].transform.position = storedeck.position;
            lib[1].transform.rotation = storedeck.rotation;
        }
        else if (ld.Count == 2)
        {
            ld[0].transform.SetParent(storedeck);
            ld[1].transform.SetParent(storedeck);

            ld[0].transform.position = storedeck.position;
            ld[0].transform.rotation = storedeck.rotation;

            ld[1].transform.position = storedeck.position;
            ld[1].transform.rotation = storedeck.rotation;
        }
        else if (ophiu.Count == 2)
        {
            ophiu[0].transform.SetParent(storedeck);
            ophiu[1].transform.SetParent(storedeck);

            ophiu[0].transform.position = storedeck.position;
            ophiu[0].transform.rotation = storedeck.rotation;

            ophiu[1].transform.position = storedeck.position;
            ophiu[1].transform.rotation = storedeck.rotation;
        }
        else if (orion.Count == 2)
        {
            orion[0].transform.SetParent(storedeck);
            orion[1].transform.SetParent(storedeck);

            orion[0].transform.position = storedeck.position;
            orion[0].transform.rotation = storedeck.rotation;

            orion[1].transform.position = storedeck.position;
            orion[1].transform.rotation = storedeck.rotation;
        }
        else if (scor.Count == 2)
        {
            scor[0].transform.SetParent(storedeck);
            scor[1].transform.SetParent(storedeck);

            scor[0].transform.position = storedeck.position;
            scor[0].transform.rotation = storedeck.rotation;

            scor[1].transform.position = storedeck.position;
            scor[1].transform.rotation = storedeck.rotation;
        }
        else if (sc.Count == 2)
        {
            sc[0].transform.SetParent(storedeck);
            sc[1].transform.SetParent(storedeck);

            sc[0].transform.position = storedeck.position;
            sc[0].transform.rotation = storedeck.rotation;

            sc[1].transform.position = storedeck.position;
            sc[1].transform.rotation = storedeck.rotation;
        }
        else if (taurus.Count == 2)
        {
            taurus[0].transform.SetParent(storedeck);
            taurus[1].transform.SetParent(storedeck);

            taurus[0].transform.position = storedeck.position;
            taurus[0].transform.rotation = storedeck.rotation;

            taurus[1].transform.position = storedeck.position;
            taurus[1].transform.rotation = storedeck.rotation;
        }
    }
}
