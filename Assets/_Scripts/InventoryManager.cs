using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager singleton;

    [Header("Item List")]
    [SerializeField] private List<ItemScriptable> collectedItem = new List<ItemScriptable>();
    private void Awake()
    {
        if (singleton == null)
            singleton = this;
        else
            Destroy(this);
    }

    public void AddItem(ItemScriptable _item)
    {
        collectedItem.Add(_item);
    }

    public void RemoveItem(ItemScriptable _item)
    {
        collectedItem.Remove(_item);
    }
}
