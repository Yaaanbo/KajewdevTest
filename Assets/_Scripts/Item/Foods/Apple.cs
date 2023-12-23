using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : BaseItem
{
    [SerializeField] private float healthBonus = 20f;
    public override void OnTaken()
    {
        base.OnTaken();
        Debug.Log("The apple has been taken");
    }

    public override void OnUse()
    {
        base.OnUse();
        ItemEffectManager.instance.AddHealth(healthBonus);
        Debug.Log("Apple has been eaten");
    }
}
