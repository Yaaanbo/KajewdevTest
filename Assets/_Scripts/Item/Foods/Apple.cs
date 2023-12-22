using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : BaseItem
{
    public override void OnTaken()
    {
        base.OnTaken();
        Debug.Log("The apple has been taken");
    }

    public override void OnUse()
    {
        base.OnUse();
        Debug.Log("Apple has been eaten");
    }
}
