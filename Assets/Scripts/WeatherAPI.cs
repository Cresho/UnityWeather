using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class WeatherAPI : MonoBehaviour
{
    private string url;

    private void Update()
    {
        url = "https://api.openweathermap.org/data/2.5/weather?lat=" + CoordinatesScript.latitude + "&lon=" + CoordinatesScript.longitude + "&appid=a72867307f7150ef72a7c5aaf3280f31";
        if (CoordinatesScript.valuesChanged)
        {
            StartCoroutine(GetRequest(url));
            CoordinatesScript.valuesChanged = false;
        }
    }

    IEnumerator GetRequest(string url)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if(request.result == UnityWebRequest.Result.Success)
        {
            string responseText = request.downloadHandler.text;
            Debug.Log(responseText);

            WeatherJSON.ProcessJson(responseText);
            TimeManager.GetLocalTime();
        }
        else
        {
            Debug.Log("Error: " + request.error);
        }
    }   
}
