using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;
using static System.Net.WebRequestMethods;

public class Data_Save : MonoBehaviour
{

    public string lv_name;
    public double Timer_data;
    public double min;
    public double sec;
    


    void Start()
    {
        if (lv_name == "lv_thank")
        {

            Timer_data = Time.realtimeSinceStartupAsDouble;

            min =Timer_data / 60;
            sec =Timer_data % 60;

            min = Math.Round(min);
            sec = Math.Round(sec);


            StartCoroutine(DataPost(int.Parse(min.ToString()), int.Parse(sec.ToString())));



        }

    }

    IEnumerator DataPost(int minuts, int seconds)
    {
        string uri = "https://api-node-7vk8.onrender.com/user";

        Datasave datasave = new Datasave()
        {
            name_player = PlayerPrefs.GetString("name"),
            score_player = GameController.export.guardarScore,
            total_deaths = GameController.export.guardarDeath,
            total_minuts = minuts,
            total_seconds = seconds,
        };
        

       var json = JsonUtility.ToJson(datasave);
        var bytes = Encoding.UTF8.GetBytes(json);

        using (var webRequest = new UnityWebRequest(uri, "POST"))
        {
            webRequest.uploadHandler = new UploadHandlerRaw(bytes);
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("accept", "application/json");
            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();
            if(webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                Debug.Log("Posted");
            }

            webRequest.Dispose();
        }

        
    }

    [Serializable]
    public class Datasave
    {
        public string name_player;
        public int score_player;
        public int total_deaths;
        public int total_minuts;
        public int total_seconds;
    }



}



