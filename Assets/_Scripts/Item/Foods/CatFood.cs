using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFood : BaseItem
{
    [Header("Item Effect Attributes")]
    [SerializeField] private float slowDuration;
    [SerializeField] private float speedDivisor;
    public override void OnUse()
    {
        base.OnUse();
        ItemEffectManager.instance.DecreaseRunSpeed(slowDuration, speedDivisor);
        Debug.Log("You ate a cat food! Now you cannot run for " + slowDuration + " seconds");
    }
}
