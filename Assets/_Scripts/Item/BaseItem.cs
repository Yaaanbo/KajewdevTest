using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{
    //Scriptable Item
    [field : SerializeField] public ItemScriptable itemScriptable { get; private set; }

    public virtual void OnItemTaken()
    {
        this.gameObject.SetActive(false);
        InventoryManager.singleton.AddItem(this);
    }

    public virtual void OnItemUsed()
    {
        InventoryManager.singleton.RemoveItem(this);
    }
}
