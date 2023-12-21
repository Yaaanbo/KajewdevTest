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
    public Action OnItemTakable;
    public Action OnItemIntakable;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FindItemCoroutine());
    }

    private void Update()
    {
        ItemInReachHandler();
    }

    private IEnumerator FindItemCoroutine()
    {
        WaitForSeconds waitTime = new WaitForSeconds(.05f);

        while (true)
        {
            yield return waitTime;
            CheckItem();
        }
    }

    private void CheckItem()
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
                    isItemInReach = true;
                else
                    isItemInReach = false;

            }
            else
                isItemInReach = false;

        }
        else if (isItemInReach)
            isItemInReach = false;
    }

    private void ItemInReachHandler()
    {
        if (isItemInReach)
        {
            //Activate Interactable UI
            OnItemTakable?.Invoke();

            //Take Item
            if (Input.GetKeyDown(KeyCode.F))
                detectedItem.transform.GetComponent<ItemBehaviour>().OnTaken();
        }
        else
        {
            //Deactivate Interactable UI
            OnItemIntakable?.Invoke();
        }
    }
}
