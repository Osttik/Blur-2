using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPhisicsControll : MonoBehaviour
{
    public Transform CenterOfMass;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        if (CenterOfMass)
        {
            _rigidbody.centerOfMass = CenterOfMass.position;
        }
    }
}
