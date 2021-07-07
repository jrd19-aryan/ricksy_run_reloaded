using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changingcanvas : MonoBehaviour
{
    public GameObject canvasFrom;
    public GameObject canvasTo;
    public void OnCanvasChange()
    {
        canvasFrom.SetActive(false);
        canvasTo.SetActive(true);
    }
}
