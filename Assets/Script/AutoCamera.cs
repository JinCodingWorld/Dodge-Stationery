using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCamera : MonoBehaviour
{
    Transform p;
    void Start()
    {
        p = GameObject.Find("Player").transform;
    }

    void Update()
    {
        transform.position = p.position + new Vector3(0, 4, -4);
    }
}
