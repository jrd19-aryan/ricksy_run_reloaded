using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class resumegame : MonoBehaviour
{
    public GameObject pauseMenuUI1;
   
    
    public void dotask()
    {
        pauseMenuUI1.SetActive(false);
        Time.timeScale = 1f;
    }

}
