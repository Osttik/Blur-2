using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManage : MonoBehaviour
{
    public GameObject Focus;
    public float Distance = 3f;
    public float Height = 2f;
    public float Danpening = 1f;


    private void Update()
    {
        Vector3 pointBeetwinFocusAndCamera = Focus.transform.position + Focus.transform.TransformDirection(new Vector3(0, Height, -Distance));
        transform.position = Vector3.Lerp(transform.position, pointBeetwinFocusAndCamera, Danpening * Time.deltaTime);
        transform.LookAt(Focus.transform);
    }
}
