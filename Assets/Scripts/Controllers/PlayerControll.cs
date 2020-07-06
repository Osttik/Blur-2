using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(InputManager))]
public class PlayerControll : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameManager;
    private InputManager _inputManager;

    public CarCharacteristic Characteristic { get; set; }
    public Vector3 Speed { get; set; }

    [SerializeField]
    private List<WheelCollider> _throttleWheels;
    [SerializeField]
    private List<WheelCollider> _steerWheels;

    private void Start()
    {
        _inputManager = _gameManager.GetComponent<InputManager>();
        Characteristic = new CarCharacteristic();
    }

    private void FixedUpdate()
    {
        foreach (WheelCollider wheel in _throttleWheels)
        {
            wheel.motorTorque = Characteristic.MaxSpeed * Time.deltaTime * _inputManager.Throttle;
            wheel.brakeTorque = _inputManager.Break;
        }

        foreach (WheelCollider wheel in _steerWheels)
        {
            wheel.steerAngle = 20f * _inputManager.Steer;
        }
    }
}