using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Animator animSelf;

    void Start()
    {
        animSelf = GetComponent<Animator>();
    }

    void Update()
    {
        // When mouse is over button (please) set correct animation state
        // animSelf.SetBool("over", EventSystem.current.IsPointerOverGameObject());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        animSelf.SetBool("over", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animSelf.SetBool("over", false);
    }
}
