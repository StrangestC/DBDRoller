using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleKiller : MonoBehaviour
{
    public int kId;
    float scrollPos;

    GameObject clone;

    void Start()
    {
        if (kId == 0)
        {
            for (int i = 1; i < 31; i++)
            {
                clone = Instantiate(gameObject, transform.parent);
                clone.GetComponent<ToggleKiller>().kId = i;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        scrollPos -= 50 * Input.mouseScrollDelta.y;
        if (scrollPos > 625) scrollPos = 625;
        if (scrollPos < 0) scrollPos = 0;
        transform.localPosition = new Vector2(466 - (Screen.width / 2) + (kId % 4) * 87, scrollPos + 125 - (kId / 4) * 125);
    }
}
