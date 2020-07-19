using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningItem : MonoBehaviour, IItem
{
    [SerializeField]
    private float _charges = 3f;
    public float Charges { get { return _charges; } set { _charges = value; } }

    [SerializeField]
    private GameObject _chargeItem;
    public GameObject ChargeItem { get { return _chargeItem; } set { _chargeItem = value; } }

    public void Use(GameObject player)
    {
        if (Charges > 0)
        {
            Charges--;

            Vector3 playerRotation = player.transform.rotation.eulerAngles;
            playerRotation.x = 90;

            Instantiate(ChargeItem, player.transform.position, Quaternion.Euler(playerRotation));
        }
    }

    public bool CanBeUsed()
    {
        return true;
    }

    public bool IsFullyUsed()
    {
        return Charges > 0;
    }
}
