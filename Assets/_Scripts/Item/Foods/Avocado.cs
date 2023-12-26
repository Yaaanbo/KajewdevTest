using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avocado : BaseItem
{
    [Header("Item Effect Attributes")]
    [SerializeField] private int healAmountOfTimes;
    [SerializeField] private float healDelay;
    [SerializeField] private float hpToAdd;
    public override void OnUse()
    {
        base.OnUse();
        ItemEffectManager.instance.AddHealthOverTime(healAmountOfTimes, healDelay, hpToAdd);
        Debug.Log("The avocado has been eaten, Heal over time Activated every " + healDelay + " seconds for " + healAmountOfTimes * healDelay + " seconds");
    }
}
