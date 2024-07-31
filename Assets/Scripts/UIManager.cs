using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject uiCam;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject map;
    [SerializeField] private GameObject mapAttr;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private CameraMovement cameraMovement;
    [SerializeField] private PhysicsRaycaster raycaster;


    [SerializeField] private TextMeshProUGUI lonLat;
    [SerializeField] private TextMeshProUGUI weatherInfo;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI temperature;
    [SerializeField] private TextMeshProUGUI region;

    private bool flag = true;


    void Start()
    {
        uiCam.SetActive(false);
        map.SetActive(false);
        mapAttr.SetActive(false);
        
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.M))
        {
            if (flag)
            {
                uiCam.SetActive(true);
                map.SetActive(true);
                mapAttr.SetActive(true);
                //player.SetActive(false);
                playerMovement.enabled = false;
                cameraMovement.enabled = false;
                raycaster.enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                flag = false;
            }
            else
            {
                uiCam.SetActive(false);
                map.SetActive(false);
                mapAttr.SetActive(false);
                //player.SetActive(true);
                playerMovement.enabled = true;
                cameraMovement.enabled = true;
                raycaster.enabled = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                flag = true;
            }
            
        }

        if(WeatherJSON.weatherInfo != null)
        {
            lonLat.text = "Longitude: " + CoordinatesScript.longitude + "\nLatitude: " + CoordinatesScript.latitude;
            weatherInfo.text = WeatherJSON.weatherInfo.weather[0].main.ToString();
            description.text = WeatherJSON.weatherInfo.weather[0].description.ToString();
            temperature.text = Math.Ceiling(WeatherJSON.weatherInfo.main.temp - 275.15f).ToString() + " °C";
            region.text = WeatherJSON.weatherInfo.name.ToString();

            
        }
    }

    
}
