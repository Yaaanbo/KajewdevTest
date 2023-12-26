using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupTea : BaseItem
{
    [Header("Item Effect Attributes")]
    [SerializeField] private float buffDuration = 3f;
    [SerializeField] private float speedMultiplier = 1.5f;

    public override void OnUse()
    {
        base.OnUse();
        ItemEffectManager.instance.IncreaseRunSpeed(buffDuration, speedMultiplier);
        Debug.Log("The tea has been drunk");
    }
}
