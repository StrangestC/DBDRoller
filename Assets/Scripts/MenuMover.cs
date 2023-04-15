using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuMover : MonoBehaviour, IPointerDownHandler
{
    public int buttonID;

    public RollButton menuRef;
    public GameObject chElmnts, lElmnts;
    public GameObject[] kElmnts, sElmnts;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!menuRef.going)
        {
            if (buttonID <= 1)
            {
                // If ID is 0, enable character selection elements
                chElmnts.SetActive(buttonID == 0);

                // If ID is 1, enable loadout selection elements
                lElmnts.SetActive(buttonID == 1);
            }
            else if (buttonID == 2)
            {
                foreach (GameObject g in kElmnts)
                {
                    g.SetActive(!g.activeSelf);
                }
                foreach (GameObject g in sElmnts)
                {
                    g.SetActive(!g.activeSelf);
                }
            }
        }
    }
}
