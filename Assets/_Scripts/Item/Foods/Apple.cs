using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : BaseItem
{
    [Header("Item Effect Attributes")]
    [SerializeField] private float healthBonusPercentage = 20f;

    public override void OnUse()
    {
        base.OnUse();
        ItemEffectManager.instance.AddHealthPercentage(healthBonusPercentage);
        Debug.Log("Apple has been eaten, health +" + healthBonusPercentage +"%");
    }
}
