using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    [SerializeField] private Light dirLight;
    [SerializeField] private GameObject rain;
    [SerializeField] private GameObject rainPrefab;
    [SerializeField] private GameObject snow;
    [SerializeField] private GameObject[] terrain;
    [SerializeField] private GameObject[] clouds;
    [SerializeField] private CloudsGenerator cloudGenerator;
    [SerializeField] private Material daySkybox;
    [SerializeField] private Material nightSkybox;

    private GameObject oldRain;
    private bool isDay = true;

    private void Start()
    {
        terrain[0].SetActive(true);
        terrain[1].SetActive(false);
        terrain[2].SetActive(false);

        NoWeather();
    }

    private void NoWeather()
    {
        rain.SetActive(false);
        foreach(var cloud in clouds)
        {
            cloud.SetActive(false);
        }
        snow.SetActive(false);
        RenderSettings.fog = false;
        if(oldRain != null)
        {
            oldRain.Destroy();
        }
        
    }

    private void Update()
    {
        if(TimeManager.localTime.Hour < 8 || TimeManager.localTime.Hour > 20)
        {
            dirLight.intensity = .01f;
            RenderSettings.skybox = nightSkybox;
            isDay = false;
        }
        else if(dirLight.intensity != 2f ||  dirLight.intensity != .3f)
        {
            dirLight.intensity = 1f;
            RenderSettings.skybox = daySkybox;
            isDay = true;
        }

        if (WeatherJSON.weatherInfo != null)
        {
            if (WeatherJSON.weatherInfo.main.temp > 278.15f && WeatherJSON.weatherInfo.main.temp < 304f)
            {
                terrain[0].SetActive(true);
                terrain[1].SetActive(false);
                terrain[2].SetActive(false);
            }
            else if (WeatherJSON.weatherInfo.main.temp <= 278.15f)
            {
                terrain[0].SetActive(false);
                terrain[1].SetActive(true);
                terrain[2].SetActive(false);
            }
            else
            {
                terrain[0].SetActive(false);
                terrain[1].SetActive(false);
                terrain[2].SetActive(true);
            }


            if (WeatherJSON.weatherInfo.weather[0].main == "Clouds")
            {
                NoWeather();
                if (WeatherJSON.weatherInfo.weather[0].description == "Few clouds")
                {
                    clouds[0].SetActive(true);
                }
                else if (WeatherJSON.weatherInfo.weather[0].description == "Scattered clouds")
                {
                    clouds[1].SetActive(true);
                }
                else if (WeatherJSON.weatherInfo.weather[0].description == "Broken clouds")
                {
                    clouds[2].SetActive(true);
                }
                else
                {
                    clouds[3].SetActive(true);
                }
            }
            else if (WeatherJSON.weatherInfo.weather[0].main == "Clear")
            {
                NoWeather();
                if (isDay)
                {
                    dirLight.intensity = 2f;
                }                
            }
            else if (WeatherJSON.weatherInfo.weather[0].main == "Rain")
            {
                if(oldRain == null)
                {
                    NoWeather();
                    clouds[2].SetActive(true);
                    oldRain = Instantiate(rainPrefab, new Vector3(513, 400, 615), Quaternion.identity);
                    if(isDay)
                    {
                        dirLight.intensity = .3f;
                    }                    
                }
            }
            else if (WeatherJSON.weatherInfo.weather[0].main == "Snow")
            {
                if (!snow.active)
                {
                    NoWeather();
                    snow.SetActive(true);
                }
                
            }
            else if (WeatherJSON.weatherInfo.weather[0].main == "Mist")
            {
                RenderSettings.fog = true;
            }
        }

    }
}
