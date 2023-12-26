using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBone : BaseItem
{
    [Header("Item Effect Attributes")]
    [SerializeField] private int dotAmount;
    [SerializeField] private float dotDelay;
    [SerializeField] private float hpToSubtract;
    public override void OnUse()
    {
        base.OnUse();
        ItemEffectManager.instance.ApplyDamageOverTime(dotAmount, dotDelay, hpToSubtract);
        Debug.Log("The Fish Bone has been eaten, DOT Activated every " + dotDelay +" seconds for " + dotAmount * dotDelay +" seconds");
    }
}
