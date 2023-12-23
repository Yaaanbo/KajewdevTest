using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager singleton;

    [Header("Item List")]
    [SerializeField] private List<BaseItem> collectedItem = new List<BaseItem>();

    //UI Events
    public Action<List<BaseItem>> OpenInventoryUI;

    private void Awake()
    {
        if (singleton == null)
            singleton = this;
        else
            Destroy(this);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
            OpenInventoryUI?.Invoke(collectedItem);
    }

    public void AddItem(BaseItem _item)
    {
        collectedItem.Add(_item);
    }

    public void RemoveItem(BaseItem _item)
    {
        collectedItem.Remove(_item);
    }
}
