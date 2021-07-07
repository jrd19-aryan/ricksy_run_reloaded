using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class restartLevelFromPause : MonoBehaviour
{

    public string lastlevel;
    public void restartlevel()
    {
        SceneManager.LoadScene(lastlevel);
        Time.timeScale = 1f;
    }
}
