using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightSystem : MonoBehaviour
{
    [SerializeField] Light sun;
    [SerializeField] Light moon;
    
    [Header("Day/Night cycle Controls")]

    [SerializeField] float secondsInFullDay = 120f;
    

    [SerializeField] float celestialBodiesPos = 90;
    
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
        var rotationX = (currentTime * 360f) - celestialBodiesPos;
        var rotationX1 = (currentTime * 360f) + celestialBodiesPos;
        sun.transform.localRotation = Quaternion.Euler(rotationX, 170, 0);
        if ((180 - rotationX) < 0)
            moon.transform.localRotation = Quaternion.Euler(360 + ((180 - rotationX) * -1), 170, 0);
        else
            moon.transform.localRotation = Quaternion.Euler(360 - ((180 + rotationX) * -1), 170, 0);
    }
}
