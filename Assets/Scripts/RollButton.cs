using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RollButton : MonoBehaviour, IPointerDownHandler
{
    public int selected;
    int preSelected;

    public bool going;
    public bool[] kDisable = new bool[31];
    public bool[] sDisable = new bool[36];

    public GameObject dRef;
    public GameObject[] kModels, sModels;

    public void OnPointerDown(PointerEventData eventData)
    {
        // Start rolling when clicked
        if (!going)
        {
            StartCoroutine(SpinnySpinny());
        }
    }

    IEnumerator SpinnySpinny()
    {
        going = true;

        bool[] dDisable = (dRef.activeSelf ? kDisable : sDisable);
        GameObject[] dModels = (dRef.activeSelf ? kModels : sModels);

        // Count how many killers can be rolled
        int enablCount = 0;
        foreach (bool b in dDisable)
        {
            if (!b) enablCount++;
        }

        // Check each killer in the disabled list, if it is enabled then add it to the new array in the current index and move one further
        int n = 0;
        int[] dModelsEnb = new int[enablCount];
        for (int j = 0; j < 31; j++)
        {
            if (!dDisable[j])
            {
                dModelsEnb[n] = j;
                n++;
            }
        }

        // Roll 20 times with increasing time between
        for (int i = 20; i > 0; i--)
        {
            yield return new WaitForSeconds(3f / (2f * i));

            // Randomize killer and change model
            preSelected = selected;
            while (selected == preSelected || enablCount > 1) selected = dModelsEnb[Random.Range(0, dModelsEnb.Length)];
            if (dModels[preSelected] != null) dModels[preSelected].SetActive(false);
            if (dModels[selected] != null) dModels[selected].SetActive(true);

            // Move offscreen models onscreen
            /*if (dModels[selected].transform.position != Vector3.zero)
            {
                dModels[selected].transform.position = Vector3.zero;
            }*/
        }
        
        going = false;
    }
}
