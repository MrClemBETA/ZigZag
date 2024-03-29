﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject ball;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.GameRunning())
        {
            transform.position = ball.transform.position + offset;
        }
    }
}
