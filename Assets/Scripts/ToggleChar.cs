using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ToggleChar : MonoBehaviour, IPointerDownHandler
{
    public int cId;
    float scrollPos;

    public bool kVsS;

    GameObject clone;

    public Sprite[] cPortraits;

    public RollButton enablRef;

    void Start()
    {
        // Duplicate object and assign correct char ID
        if (cId == 0)
        {
            for (int i = 1; i < (kVsS ? 31 : 36); i++)
            {
                clone = Instantiate(gameObject, transform.parent);
                clone.GetComponent<ToggleChar>().cId = i;
            }
        }

        // Update sprite and position per character
        GetComponent<Image>().sprite = cPortraits[cId];

        // Disable survivors initially
        if (cId == 0 && !kVsS)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Allow for scrolling within mouse
        scrollPos -= 50 * Input.mouseScrollDelta.y;
        if (scrollPos > (kVsS ? 625 : 750)) scrollPos = (kVsS ? 625 : 750);
        if (scrollPos < 0) scrollPos = 0;

        updatePos();

        // transform.localPosition = new Vector2(466 - (Screen.width / 2) + (kId % 4) * 87, scrollPos + 125 - (kId / 4) * 125);
    }

    void updatePos()
    {
        transform.localPosition = new Vector2(-128 + (cId % 4) * 87, scrollPos + 125 - (cId / 4) * 125);

        if (cId == 0)
        {
            // Move parent object with screen width, but only through one object to optimize
            transform.parent.localPosition = new Vector2(406f - (Screen.width / 2f), 22);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Toggle ability to roll respective character
        if (!enablRef.going)
        {
            if (kVsS)
            {
                enablRef.kDisable[cId] = !enablRef.kDisable[cId];
            }
            else
            {
                enablRef.sDisable[cId] = !enablRef.sDisable[cId];
            }
        }
    }
}
