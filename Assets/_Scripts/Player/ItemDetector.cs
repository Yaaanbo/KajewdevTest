using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemDetector : MonoBehaviour
{
    [Header("View")]
    [Range(0, 360)] public float viewAngle;
    public float viewRadius;

    [Header("Masks")]
    [SerializeField] private LayerMask itemMask;
    [SerializeField] private LayerMask obstacleMask;

    [HideInInspector] public bool isItemInReach;

    private Transform detectedItem;

    //Events
    public Action<BaseItem> OnItemTakable;
    public Action OnItemIntakable;

    private void Update()
    {
        ItemCheckHandler();
        ItemInReachHandler();
    }

    private void ItemCheckHandler()
    {
        Collider[] itemCol = Physics.OverlapSphere(this.transform.position, viewRadius, itemMask);

        if (itemCol.Length != 0)
        {

            detectedItem = itemCol[0].transform;
            Vector3 dirToItem = (detectedItem.position - this.transform.position).normalized;

            if (Vector3.Angle(this.transform.forward, dirToItem) < viewAngle / 2)
            {
                float distToItem = Vector3.Distance(this.transform.position, detectedItem.position);

                if (!Physics.Raycast(this.transform.position, dirToItem, distToItem, obstacleMask))
                {
                    isItemInReach = true;

                    //Activate and update Interactable UI
                    OnItemTakable?.Invoke(detectedItem.transform.GetComponent<BaseItem>());
                }
                    
                else
                {
                    isItemInReach = false;

                    //Deactivate and update Interactable UI
                    OnItemIntakable?.Invoke();
                }
            }
            else
            {
                isItemInReach = false;

                //Deactivate and update Interactable UI
                OnItemIntakable?.Invoke();
            }

        }
        else if (isItemInReach)
        {
            isItemInReach = false;

            //Deactivate and update Interactable UI
            OnItemIntakable?.Invoke();
        }
    }

    private void ItemInReachHandler()
    {
        if (isItemInReach)
        {
            //Take Item
            if (Input.GetKeyDown(KeyCode.F))
                detectedItem.transform.GetComponent<BaseItem>().OnTaken();
        }
    }
}
