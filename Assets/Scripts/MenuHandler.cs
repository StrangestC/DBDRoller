using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuHandler : MonoBehaviour, IPointerDownHandler
{
    public int selected;
    int preSelected;

    bool going;
    public bool[] kDisable = new bool[31];

    public GameObject[] kModels;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!going)
        {
            StartCoroutine(SpinnySpinny());
        }
    }

    IEnumerator SpinnySpinny()
    {
        going = true;
        for (int i = 20; i > 0; i--)
        {
            yield return new WaitForSeconds(3f / (2f * i));
            kModels[selected].SetActive(false);
            preSelected = selected;
            while (selected == preSelected) selected = Random.Range(0, 30);
            kModels[selected].SetActive(true);
        }
        going = false;
    }
}
