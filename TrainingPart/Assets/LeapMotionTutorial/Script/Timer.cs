﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

[Serializable]
public class TimerData
{
    public string playerMode = "mode";
    public int playerNumber;
    public string playerName = "Anonymous";
    public string playerDate = "20180901";


    public float timeEmpty_0;
    public float timeGrabPanel_1;
    public float timeEnlargePanel_2;
    public float timeShrinkPanel_3;
    public float timeRotatePanel_4;
    public float timeViewPanel_5;
    public float timeClosePanel_6;
    public float timeColorPanel_7;
    public float timeSizePanel_8;
    public float timeCollectPanel_9;
    public float timeBoxPanel_10;

    public TimerData(
        string mode,
        int number,
        string name,
        string date,
        float m_timeEmpty_0,
        float m_timeGrabPanel_1,
        float m_timeEnlargePanel_2,
        float m_timeShrinkPanel_3,
        float m_timeRotatePanel_4,
        float m_timeViewPanel_5,
        float m_timeClosePanel_6,
        float m_timeColorPanel_7,
        float m_timeSizePanel_8,
        float m_timeCollectPanel_9,
        float m_timeBoxPanel_10
    )
    {
        playerMode = mode;
        playerNumber = number;
        playerName = name;
        playerDate = date;

        timeEmpty_0 = m_timeEmpty_0;
        timeGrabPanel_1 = m_timeGrabPanel_1;
        timeEnlargePanel_2 = m_timeEnlargePanel_2;
        timeShrinkPanel_3 = m_timeShrinkPanel_3;
        timeRotatePanel_4 = m_timeRotatePanel_4;
        timeViewPanel_5 = m_timeViewPanel_5;
        timeClosePanel_6 = m_timeClosePanel_6;
        timeColorPanel_7 = m_timeColorPanel_7;
        timeSizePanel_8 = m_timeSizePanel_8;
        timeCollectPanel_9 = m_timeCollectPanel_9;
        timeBoxPanel_10 = m_timeBoxPanel_10;
    }
}

public class Timer : MonoBehaviour
{
    public string mode;
    public int number;
    public string name;
    public string date;

    [SerializeField]
    private string path;

    private int currentIndex = 0;
    private float currentTimer = 0f;
    private bool isTimer = false;

    private Dictionary<int, float> timerDictionary = new Dictionary<int, float>();
    //private Dictionary<int,string> nameDictionary = new Dictionary<int, string> ();
    // Use this for initialization
    void Start()
    {
        timerDictionary.Add(0, 0f);
        timerDictionary.Add(1, 0f);
        timerDictionary.Add(2, 0f);
        timerDictionary.Add(3, 0f);
        timerDictionary.Add(4, 0f);
        timerDictionary.Add(5, 0f);
        timerDictionary.Add(6, 0f);
        timerDictionary.Add(7, 0f);
        timerDictionary.Add(8, 0f);
        timerDictionary.Add(9, 0f);
        timerDictionary.Add(10, 0f);


        EnterPlane(0);

        /*
        JsonObject jo = // ************************ /
        string textPath = jo.GetString ("TextPath"); 
        JsonObject testObj = jo.GetObj("testObj");
        JsonArray testArray = jo.GetArray("testArray");
        //------

        //EnCode
        JsonObject newObj = new JsonObject ();
        newObj.SetString("TextPath",str);
        testObj = new JsonObj();
        newObj.SetObj("testObj",testObj);
        newObj.SetArray("testArray",testArray);

        string bigObjStr = newObj.ToString();
        string path = "D:/test/bigObjStr.json";
        FileManager.SaveToString(path,bigObjStr);
        */

        //NextPlane ();
        //ShowTime = GetComponent<Text>();//显示计时器时间
    }

    // Update is called once per frame
    void Update()
    {
        //currentTimer += Time.deltaTime;
        if (isTimer)
        {
            timerDictionary[currentIndex] += Time.deltaTime;

            //ShowTime.text = currentTimer.ToString("F2");//显示计时器时间

        }
    }

    public void EnterPlane(int index)
    {
        if (index < timerDictionary.Count && index >= 0)
        {
            isTimer = true;
            currentIndex = index;
        }
        else
        {
            isTimer = false;
        }
    }

    public void NextPlane()
    {
        EnterPlane(currentIndex + 1);
    }

    public void BackPlane()
    {
        EnterPlane(currentIndex - 1);
    }


    public void OnApplicationQuit()

    {
        Debug.Log("This is the end of game!");


        for (int i = 0; i < timerDictionary.Count; i++)
        {
            Debug.Log("进入循环!");
            //Debug.Log(timerDictionary[i]);
            if (timerDictionary[i] >= 1)
            {
                Debug.Log("进入判断");

                timerDictionary[i] = timerDictionary[i] - 1;
                Debug.Log(timerDictionary[i]);
                // Console.WriteLine(timerDictionary.Values);
                // Console.WriteLine("key" + key.ToString() + ":" + key.ToString());
            }

        }

        TimerData timerData = new TimerData(
            mode,
            number,
            name,
            date,
            timerDictionary[0],
            timerDictionary[1],
            timerDictionary[2],
            timerDictionary[3],
            timerDictionary[4],
            timerDictionary[5],
            timerDictionary[6],
            timerDictionary[7],
            timerDictionary[8],
            timerDictionary[9],
            timerDictionary[10]
        );

     
        using (StreamWriter stream = new StreamWriter(path, true))
        {
            string json = JsonUtility.ToJson(timerData , true);
            json += "\n";
            //stream.WriteLine("\n");
            stream.Write(json);
        }

    }

}


//遍历字典中的键值

/* foreach (var time in timerDictionary)

 {

     Console.WriteLine(time.Key);
     Console.WriteLine(time.Value);
     if (time.Value >= 1)
     {
         time.Value = time.Value - 1;
     }

     Console.WriteLine(time.Value);

 }*/

/** int[] keys = new int[timerDictionary.Count];
 timerDictionary.Keys.CopyTo(keys, 0);
 foreach (int key in keys)
 {
    // Console.WriteLine("key" + key.ToString() + ":" + key.ToString());
     //if (timerDictionary.ContainsKey(key))
        // Console.WriteLine(timerDictionary[key]);
     
    // else
         //throw new Exception(String.Format("key {0} was not found", key));
     if (timerDictionary[key] >= 1)
     {

        timerDictionary[key] = timerDictionary[key] - 1;
        Console.WriteLine("key" + key.ToString() + ":" + key.ToString());
     }**/
