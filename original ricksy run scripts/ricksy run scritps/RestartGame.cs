using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void restartgame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
