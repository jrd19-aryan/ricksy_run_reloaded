using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingarrows : MonoBehaviour
{
    
    public void movingright()
    {
       GameObject.FindWithTag("Player").GetComponent<playerscr>().moveHorizontal = 1;
    }
    public void movingleft()
    {
        GameObject.FindWithTag("Player").GetComponent<playerscr>().moveHorizontal = -1;
    }

}
