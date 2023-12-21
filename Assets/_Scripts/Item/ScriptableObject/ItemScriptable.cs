using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Item/Scriptable item")]
public class ItemScriptable : ScriptableObject
{
    [Header("Item details")]
    public string itemName;
    public Sprite itemSprite;

    [Header("Reference")]
    public GameObject itemPrefabs;
}
