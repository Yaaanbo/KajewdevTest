using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour, IUsable
{
    [SerializeField] private ItemScriptable item;

    public void OnTaken()
    {
        this.gameObject.SetActive(false);
        InventoryManager.singleton.AddItem(this.item);
    }

    public void OnUse()
    {
        Debug.Log("Item used");
        InventoryManager.singleton.RemoveItem(this.item);
    }
}
