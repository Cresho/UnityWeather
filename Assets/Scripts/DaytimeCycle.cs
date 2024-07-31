using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaytimeCycle : MonoBehaviour
{
    private int hourCounter;
    private bool flag = true;
    public GameObject dirrLight;


    void Start()
    {
        hourCounter = 0;
        StartCoroutine(DaytimeCycleCor());
    }

    IEnumerator DaytimeCycleCor()
    {
        while(hourCounter < 12)
        {
            hourCounter++;
            if(hourCounter == 12)
            {
                flag = !flag;
                ChangeTime();
                hourCounter = 0;
            }
            yield return new WaitForSecondsRealtime(3600);
        }
    }

    public void ChangeTime()
    {
        dirrLight.SetActive(flag);
    }
}
