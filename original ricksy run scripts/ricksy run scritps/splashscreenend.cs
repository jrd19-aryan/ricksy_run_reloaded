using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class splashscreenend : MonoBehaviour
{
    float timer;
    private void Start()
    {
        timer = 0;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer>5.5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 

        }
    }
}
