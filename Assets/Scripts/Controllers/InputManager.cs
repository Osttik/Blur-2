using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float Throttle { get; set; }
    public float Steer { get; set; }
    public float Break { get; set; }

    private void Start()
    {
        Throttle = 0;
        Steer = 0;
        Break = 0;
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
    }

    private void AlternativeKeyBoard()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Throttle < 1f)
            {
                Throttle += 0.5f * Time.deltaTime;
            }
            else
            {
                Throttle = 1f;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (Throttle > -1f)
            {
                Throttle -= 0.5f * Time.deltaTime;
            }
            else
            {
                Throttle = -1f;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (Steer > -1f)
            {
                Steer -= 1f * Time.deltaTime;
            }
            else
            {
                Steer = -1f;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (Steer < 1f)
            {
                Steer += 1f * Time.deltaTime;
            }
            else
            {
                Steer = 1f;
            }
        }
    }
}
