using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstellationGameManager : MonoBehaviour
{
    [SerializeField] private Transform[] playerPos;
    [SerializeField] private List<GameObject> p1, p2, p3;

    public List<GameObject> cards; // List that holds all my ten cards
    int cur, turn, otherturn;

    float gapbetween;

    //[SerializeField] private GameObject[] handDeck;

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
            CancelInvoke();
        }
        else if (otherturn != s)
        {
            p1[otherturn].transform.SetParent(playerPos[0].transform);
            p1[otherturn].transform.position = new Vector3(playerPos[0].position.x + gapbetween, 0, 0);

            p2[otherturn].transform.SetParent(playerPos[1].transform);
            p2[otherturn].transform.localPosition = new Vector3(0 + gapbetween, 0, 0);
            p2[otherturn].transform.localRotation = new Quaternion(0, 0, 0, 0);

            p3[otherturn].transform.SetParent(playerPos[2].transform);
            p3[otherturn].transform.localPosition = new Vector3(0 - gapbetween, 0, 0);
            p3[otherturn].transform.localRotation = new Quaternion(0, 0, 0, 0);

            gapbetween += 40f;

            otherturn += 1;
        }
    }
}
