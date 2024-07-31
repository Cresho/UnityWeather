using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Subsystems;


[Serializable]
public class WeatherJSON
{
    public List<Result> result;
    public string status;
    public static string forecast;
    public static Result weatherInfo;


    public static void ProcessJson(string json)
    {
        Result weatherJ = JsonUtility.FromJson<Result>(json);
        Debug.Log(weatherJ.weather[0].main);
        forecast = weatherJ.weather[0].main;
        weatherInfo = weatherJ;
    }
}


