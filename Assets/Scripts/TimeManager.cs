using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static DateTime localTime;

    public void Start()
    {
        localTime = DateTime.Now;
    }


    public static void GetLocalTime()
    {
        DateTime utcTime = DateTime.UtcNow;
        Debug.Log("UTC Time: " + utcTime.ToString("HH:mm:ss"));
        int timeZoneOffsetInSeconds = WeatherJSON.weatherInfo.timezone;

        TimeSpan offset = TimeSpan.FromSeconds(timeZoneOffsetInSeconds);

        localTime = utcTime.Add(offset);
        Debug.Log("Local Time: " + localTime.ToString("HH:mm:ss"));
    }
}
