using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class score : MonoBehaviour
{
    public float time;
    public float clicks;
    public float scoreC;
    int counter;
    private int[] currscore;
    public Text printScore;

    public GameObject startbutton;
    public Text currentScoreText;
    public Text highScoreText1;
    public Text highScoreText2;
    public Text highScoreText3;
    public Text highScoreText4;
    public Text highScoreText5;
    private const string highScoreKey1 = "HighScore1";
    private const string highScoreKey2 = "HighScore2";
    private const string highScoreKey3 = "HighScore3";
    private const string highScoreKey4 = "HighScore4";
    private const string highScoreKey5 = "HighScore5";
    private int[] highscores;
    
    [SerializeField] private int currentScore = 0;

    GameObject lb1;
    GameObject lb2;
    GameObject lb3;
    GameObject lb4;
    GameObject lb5;
    GameObject cs1;
    /*GameObject cs2;
    GameObject cs3;
    GameObject cs4;
    GameObject cs5;
    GameObject cs6;*/

    void Start()
    {
        highscores = new int[5];
        DontDestroyOnLoad(gameObject);
        time = 0;
        clicks = 0;

        highscores[0] = PlayerPrefs.GetInt(highScoreKey5, 0);
        highscores[1] = PlayerPrefs.GetInt(highScoreKey4, 0);
        highscores[2] = PlayerPrefs.GetInt(highScoreKey3, 0);
        highscores[3] = PlayerPrefs.GetInt(highScoreKey2, 0);
        highscores[4] = PlayerPrefs.GetInt(highScoreKey1, 0);
      

        /*highScoreText5.text = highscores[0].ToString();
        highScoreText4.text = highscores[1].ToString();
        highScoreText3.text = highscores[2].ToString();
        highScoreText2.text = highscores[3].ToString();
        highScoreText1.text = highscores[4].ToString();*/

       

        counter = 0;
    }

   
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        //Debug.Log(sceneName);
        //Debug.Log(sceneName == "Level 3 Complete");
        
        scoreC = (6000 - time) / clicks;
        if(sceneName == "Menu")
        {
            time = 0;
            clicks = 0;
        }

        if (sceneName == "Level 3 Complete")
        {
            Debug.Log("yes");
            currentScore = Mathf.RoundToInt(scoreC);
            //currentScoreText.text = currentScore.ToString();

            /*if (currentScore > highScore)
            {                
                highScore = currentScore;
                highScoreText.text = highScore.ToString();
                PlayerPrefs.SetInt(highScoreKey, highScore);
                PlayerPrefs.Save();
            }*/
            if (counter == 0)
            {
                int i;
                int ind = -1;

                for (i = 0; i < 4; i++)
                {
                    if (currentScore > highscores[i])
                    {
                        highscores[i] = highscores[i + 1];
                        ind = i;
                    }
                }

                if (currentScore > highscores[4])
                {
                    highscores[4] = currentScore;
                    ind = -1;
                }

                if (ind != -1) highscores[ind] = currentScore;
                counter++;

                for (int j = 0; j <= 5; j++)
                {
                    currscore[j] = currentScore % 10;
                    currentScore = currentScore / 10;
                }
                /*for (int j = 0; j <= 5; j++)
                {
                    printScore.text = currscore[j].ToString();
                }*/
            }

            /*highScoreText5.text = highscores[0].ToString();
            highScoreText4.text = highscores[1].ToString();
            highScoreText3.text = highscores[2].ToString();
            highScoreText2.text = highscores[3].ToString();
            highScoreText1.text = highscores[4].ToString();*/

            PlayerPrefs.SetInt(highScoreKey5, highscores[0]);
            PlayerPrefs.SetInt(highScoreKey4, highscores[1]);
            PlayerPrefs.SetInt(highScoreKey3, highscores[2]);
            PlayerPrefs.SetInt(highScoreKey2, highscores[3]);
            PlayerPrefs.SetInt(highScoreKey1, highscores[4]);

            PlayerPrefs.Save();

            /*for (int j = 0; j <= 5; j++)
            {
                currscore[j]=currentScore % 10;
                currentScore /= 10;
            }*/
            /*for(int j=0;j<=5;j++)
            {
                printScore.text = currscore[j].ToString();
            }*/
          
            lb1 = GameObject.Find("lb1");
            lb2 = GameObject.Find("lb2");
            lb3 = GameObject.Find("lb3");
            lb4 = GameObject.Find("lb4");
            lb5 = GameObject.Find("lb5");

            cs1 = GameObject.Find("cs1");
            /*cs2 = GameObject.Find("cs2");
            cs3 = GameObject.Find("cs3");
            cs4 = GameObject.Find("cs4");
            cs5 = GameObject.Find("cs5");
            cs6 = GameObject.Find("cs6");*/

            lb1.GetComponent<Text>().text = highscores[4].ToString();
            lb2.GetComponent<Text>().text = highscores[3].ToString();
            lb3.GetComponent<Text>().text = highscores[2].ToString();
            lb4.GetComponent<Text>().text = highscores[1].ToString();
            lb5.GetComponent<Text>().text = highscores[0].ToString();

            /*cs1.GetComponent<Text>().text = currscore[0].ToString();
            cs2.GetComponent<Text>().text = currscore[1].ToString();
            cs3.GetComponent<Text>().text = currscore[2].ToString();
            cs4.GetComponent<Text>().text = currscore[3].ToString();
            cs5.GetComponent<Text>().text = currscore[4].ToString();
            cs6.GetComponent<Text>().text = currscore[5].ToString();*/

            cs1.GetComponent<Text>().text = currentScore.ToString();
        }
    }


}
