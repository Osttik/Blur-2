using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningPowerItem : MonoBehaviour
{
    [SerializeField]
    private float _strenght = 100000f;
    public float Strenght { get { return _strenght; } set { _strenght = value; } }

    [SerializeField]
    private float _timeLife = 5f;
    public float TimeLife { get { return _timeLife; } set { _timeLife = value; } }

    public float FlightSpeed { get; set; } = 500f;

    private void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(0f, FlightSpeed, 0f);

        IEnumerator endOfLifeTimer = EndLifeTimeAfterTimeLifeExpires();

        StartCoroutine(endOfLifeTimer);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Car")
        {
            Vector3 bulletVelocity = GetComponent<Rigidbody>().velocity;
            Vector3 forceToObject = new Vector3(bulletVelocity.y, 0.25f, bulletVelocity.z);

            other.rigidbody.AddForce(forceToObject * Strenght);

            EndLife();
        }
    }

    private IEnumerator EndLifeTimeAfterTimeLifeExpires()
    {
        yield return new WaitForSeconds(TimeLife);
        EndLife();
    }

    public void EndLife()
    {
        Destroy(gameObject);
    }
}
