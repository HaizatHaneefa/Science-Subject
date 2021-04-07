using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DataHandlingDrop : MonoBehaviour, IDropHandler
{
    [SerializeField] private DataHandlingGameManager manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<DataHandlingGameManager>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.tag == gameObject.tag)
            {
                manager.RightSFX();
                eventData.pointerDrag.transform.SetParent(gameObject.transform);
                eventData.pointerDrag.GetComponent<Image>().raycastTarget = false;

                manager.Spawn();
                return;
            }
            else if (eventData.pointerDrag.tag != gameObject.tag)
            {
                manager.WrongPressSFX();
            }

            eventData.pointerDrag.transform.position = manager.spawn.position;
        }
    }
}
