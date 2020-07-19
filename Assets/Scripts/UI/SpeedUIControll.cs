using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUIControll : MonoBehaviour
{
    [SerializeField]
    private Text _speedText;
    public Text SpeedText { get { return _speedText; } }

    [SerializeField]
    private GameObject _objectToShowSpeed;
    public GameObject ObjectToShowSpeed { get { return _objectToShowSpeed; } }

    private SpeedControll _speedControll;

    private void Start()
    {
        _speedControll = ObjectToShowSpeed.GetComponent<SpeedControll>();
    }

    private void Update()
    {
        _speedText.text = _speedControll.Speed.ToString();//Math.Round(_speedControll.Speed.ToString() * 2, MidpointRounding.AwayFromZero) / 10;
    }
}
