using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{
    [Header("Scriptable item")]
    [SerializeField] protected ItemScriptable item;

    [Header("Item Rotatin")]
    [SerializeField] protected float rotationSpeed = 100f;

    private void Update()
    {
        RotateItem();
    }

    public virtual void OnTaken()
    {
        this.gameObject.SetActive(false);
        InventoryManager.singleton.AddItem(this.item);
    }

    public virtual void OnUse()
    {
        InventoryManager.singleton.RemoveItem(this.item);
    }

    private void RotateItem()
    {
        Vector3 rotDir = Vector3.up * rotationSpeed * Time.deltaTime;
        this.transform.Rotate(rotDir);
    }
}
