using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedControll : MonoBehaviour
{
    public float Speed { get; set; }
    private Vector3 _lastPosition;

    private void Start()
    {
        Speed = 0;
        _lastPosition = transform.position;
    }

    private void FixedUpdate()
    {
        Speed = (transform.position - _lastPosition).magnitude / Time.deltaTime;
        _lastPosition = transform.position;
    }
}
