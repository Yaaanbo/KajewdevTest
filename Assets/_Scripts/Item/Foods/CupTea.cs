using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupTea : BaseItem
{
    [field: SerializeField] public float buffDuration { get; } = 3f;
    [field: SerializeField] public float speedMultiplier { get; } = 1.5f;

    public override void OnTaken()
    {
        base.OnTaken();
        Debug.Log("The tea has been taken");
    }

    public override void OnUse()
    {
        base.OnUse();
        StartCoroutine(ItemEffectManager.instance.IncreasePlayerSpeed(buffDuration, speedMultiplier));
        Debug.Log("The tea has been drunk");
    }
}
