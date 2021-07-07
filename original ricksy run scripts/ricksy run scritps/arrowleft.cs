using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class arrowleft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    //public bool buttonPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject.FindWithTag("Player").GetComponent<playerscr>().moveHorizontal = -1;
        GameObject.FindWithTag("Player").GetComponent<playerscr>().leftright = 1;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameObject.FindWithTag("Player").GetComponent<playerscr>().moveHorizontal = 0;
        GameObject.FindWithTag("Player").GetComponent<playerscr>().leftright = 0;
    }
}