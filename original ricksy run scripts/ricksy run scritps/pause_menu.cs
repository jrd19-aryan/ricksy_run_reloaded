using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pause_menu : MonoBehaviour
{

    public GameObject pauseMenuUI;
   
    public void dotask()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
   
  


}
