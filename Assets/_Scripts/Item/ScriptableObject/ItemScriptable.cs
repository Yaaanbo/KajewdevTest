using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Item/Scriptable item")]
public class ItemScriptable : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
}
