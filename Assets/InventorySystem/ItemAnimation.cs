using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnimation : MonoBehaviour
{
    public float rotationY = .18f;
    [Range(0, 1)]
    public float moveY = .0005f;

    public float maxPosY { get; set; }
    public float minPosY { get; set; }
    // Start is called before the first frame update
    void Start()
    {
       maxPosY = transform.localPosition.y + .1f;
       minPosY = transform.localPosition.y - .1f;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(StayInWorld());
    }

    private IEnumerator StayInWorld()
    {
        yield return null;

        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + rotationY, 0);

        if (transform.localPosition.y >= maxPosY)
            moveY *= -1;
        if (transform.localPosition.y <= minPosY)
            moveY *= -1;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + moveY, transform.localPosition.z);
    }
}
