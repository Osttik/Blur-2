using Assets.Scripts.Handlers;
using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowersController : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameManager;

    [SerializeField]
    private List<IItem> _powerItems = new List<IItem>();
    public List<IItem> PowerItems { get { return _powerItems; } private set { _powerItems = value; } }


    private InputManager _inputManager;
    private InputHandler _inputHandler;

    public int PowerItemsLimit { get; private set; } = 3;
    public int CurrentPowerItem { get; private set; } = 0;

    private void Start()
    {
        _inputManager = _gameManager.GetComponent<InputManager>();
        _inputHandler = new InputHandler();
        _inputHandler.OnButtonClick += UsePowerItem;
    }

    private void Update()
    {
        _inputHandler.Click(_inputManager.UseItem);
    }

    public void SetPowerItemsLimit(int limit)
    {
        PowerItemsLimit = limit;
    }

    public bool AddPowerItem(GameObject item)
    {
        if (PowerItems.Count <= PowerItemsLimit)
        {
            PowerItems.Add(item.GetComponent<IItem>());
            return true;
        }

        return false;
    }
    public void UsePowerItem()
    {
        UsePowerItem(CurrentPowerItem);
    }

    public void UsePowerItem(int powerItemId)
    {
        if (powerItemId < PowerItems.Count)
        {
            PowerItems[powerItemId].Use(transform.Find("BulletPosition").gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.transform.tag);
        if (other.transform.tag == "Item" && PowerItems.Count != PowerItemsLimit)
        {
            AddPowerItem(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
