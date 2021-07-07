using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{

    private bool isInside;

    void FixedUpdate()
    {
        isInside = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "background")
        {
            isInside = true;
        }
    }

    private void Update()
    {
        
    }
}
