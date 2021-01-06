using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightSystem : MonoBehaviour
{
    [SerializeField] Light sun;
    [SerializeField] Light moon;
    [SerializeField] float secondsInFullDay = 120f;
    
    [Range(0, 1)] 
    [SerializeField] float currentTime = 0;

    [SerializeField] float timeMiltiplier = 1f;

    // Update is called once per frame
    void Update()
    {
        RotateLight();

        currentTime += (Time.deltaTime / secondsInFullDay) * timeMiltiplier;

        if (currentTime >= 1)
        {
            currentTime = 0;
        }
    }

    private void RotateLight()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTime * 360f) - 90, 170, 0);
        moon.transform.localRotation = Quaternion.Euler((currentTime * 360f) + 90, 170, 0);
    }
}
