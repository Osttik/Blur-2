using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiRollController : MonoBehaviour
{
    [SerializeField]
    private WheelCollider _wheelL;
    public WheelCollider WheelL { get { return _wheelL; } set { _wheelL = value; } }
    [SerializeField]
    private WheelCollider _wheelR;
    public WheelCollider WheelR { get { return _wheelR; } set { _wheelR = value; } }
    [SerializeField]
    private float _antiRoll = 5000f;
    public float AntiRoll { get { return _antiRoll; } set { _antiRoll = value; } }

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        WheelHit hit;
        float travelL = 1f;
        float travelR = 1f;

        bool groundedL = WheelL.GetGroundHit(out hit);
        if (groundedL)
            travelL = (-WheelL.transform.InverseTransformPoint(hit.point).y - WheelL.radius) / WheelL.suspensionDistance;

        bool groundedR = WheelR.GetGroundHit(out hit);
        if (groundedR)
            travelR = (-WheelR.transform.InverseTransformPoint(hit.point).y - WheelR.radius) / WheelR.suspensionDistance;

        float antiRollForce = (travelL - travelR) * AntiRoll;

        if (groundedL)
            _rigidbody.AddForceAtPosition(WheelL.transform.up * -antiRollForce, WheelL.transform.position);

        if (groundedR)
            _rigidbody.AddForceAtPosition(WheelR.transform.up * antiRollForce, WheelR.transform.position);
    }
}
