using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float Throttle { get; set; }
    public float Steer { get; set; }
    public float Break { get; set; }
    public bool UseItem { get; set; }

    private void Start()
    {
        Throttle = 0;
        Steer = 0;
        Break = 0;
        UseItem = false;
    }

    private void Update()
    {
        Throttle = Input.GetAxis("Vertical");
        Steer = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Space))
        {
            Break = 1f;
        }
        else
        {
            Break = 0;
        }

        UseItem = Input.GetKeyDown(KeyCode.K);
    }
}
