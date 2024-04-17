using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using JetBrains.Annotations;
using System.Threading;

public class GameController : MonoBehaviour
{

    public int FullScore;
    public Text scoreText;

    public static GameController export;
    public GameObject gameover;
    public int guardarScore;
    public int guardarDeath;
    public string lvlname;
    public string NamePlayer;
    public int AllDeaths;
    public string guardarName;

    void Start()
    {  
        export = this;

       
        if (lvlname == "lv_01")
        {
            PlayerPrefs.SetInt("score", 0);
            PlayerPrefs.SetInt("death", 0);
            

        }
        else
        {
            guardarDeath = PlayerPrefs.GetInt("death");
            guardarScore = PlayerPrefs.GetInt("score");
            FullScore = PlayerPrefs.GetInt("score");
            scoreText.text = PlayerPrefs.GetInt("score").ToString();

        }

       
    }

    public void UpdateText()
    {


        scoreText.text = FullScore.ToString();
        PlayerPrefs.SetInt("score", FullScore);

    }

    public void ShowGameOver()
    {
        gameover.SetActive(true);
    }

    public void RestartLevel(string levelname)
    {
        SceneManager.LoadScene(levelname);
        PlayerPrefs.SetInt("score", guardarScore);
        PlayerPrefs.SetInt("death", guardarDeath);
  
    }

    public void PostNamePlayer(string a)
    {
        PlayerPrefs.SetString("name", a);

        
    }


    public void  UpdateDeaths(int Count)
    {
        guardarDeath = guardarDeath + Count;
        PlayerPrefs.SetInt("death", guardarDeath);

    }

  
}
