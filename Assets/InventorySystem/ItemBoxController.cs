using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxController : MonoBehaviour
{
    ItemAnimation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<ItemAnimation>();
    }

    private void OnCollisionEnter(Collision other) {
        anim.maxPosY = anim.transform.localPosition.y + .1f;
        anim.minPosY = anim.transform.localPosition.x - .1f;
    }
}
