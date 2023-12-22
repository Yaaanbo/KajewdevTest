using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupTea : BaseItem
{
    public override void OnTaken()
    {
        base.OnTaken();
        Debug.Log("The tea has been taken");
    }

    public override void OnUse()
    {
        base.OnUse();
        Debug.Log("The tea has been drunk");
    }
}
