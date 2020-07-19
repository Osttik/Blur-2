using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(InputManager))]
public class PlayerControll : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameManager;
    private InputManager _inputManager;
    private Rigidbody _rigidbody;

    public CarCharacteristic Characteristic { get; set; }
    public Vector3 Speed { get; set; }

    [SerializeField]
    private List<WheelCollider> _throttleWheels;
    [SerializeField]
    private List<WheelCollider> _steerWheels;
    [SerializeField]
    private List<WheelCollider> _backWheels;
    [SerializeField]
    private List<GameObject> _rotatableMeshesOfWheels;
    [SerializeField]
    private List<GameObject> _rotatableMeshesOfWheelsBySteeringWheel;

    private void Start()
    {
        _inputManager = _gameManager.GetComponent<InputManager>();
        Characteristic = new CarCharacteristic();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        WheelManage();
    }

    private void WheelManage()
    {
        foreach (WheelCollider wheel in _throttleWheels)
        {
            wheel.motorTorque = Characteristic.MaxSpeed * Time.deltaTime * _inputManager.Throttle;
        }

        foreach (WheelCollider wheel in _steerWheels)
        {
            wheel.steerAngle = 25f * _inputManager.Steer;
        }

        foreach (WheelCollider wheel in _backWheels)
        {
            wheel.brakeTorque = _inputManager.Break;
        }

        foreach (GameObject wheelMash in _rotatableMeshesOfWheelsBySteeringWheel)
        {
            wheelMash.transform.localEulerAngles = new Vector3(wheelMash.transform.localEulerAngles.x, 25f * _inputManager.Steer, wheelMash.transform.localEulerAngles.z);
        }

        foreach (GameObject wheelMash in _rotatableMeshesOfWheels)
        {
            wheelMash.transform.Rotate(_rigidbody.velocity.magnitude, 0, 0);
        }
    }
}