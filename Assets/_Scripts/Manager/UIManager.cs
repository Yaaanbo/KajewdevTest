using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Class Reference")]
    [SerializeField] private InventoryManager inventoryManager;

    [Header("Inventory UI")]
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private GameObject itemUIObj;
    [SerializeField] private Transform itemUIObjParent;

    private void OnEnable()
    {
        inventoryManager.OpenInventoryUI += (List<ItemScriptable> _itemToDisplay) =>
        {
            inventoryUI.SetActive(true);

            foreach(Transform child in itemUIObjParent)
            {
                Destroy(child.gameObject);
            }

            foreach(ItemScriptable item in _itemToDisplay)
            {
                //Instantiate UI Grid
                GameObject itemGO = Instantiate(itemUIObj, itemUIObjParent);

                //Getting Component From Childs
                Image itemImage = itemGO.transform.GetChild(0).GetComponent<Image>();
                TextMeshProUGUI itemName = itemGO.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

                //Assign The Components To Items
                itemImage.sprite = item.itemSprite;
                itemName.text = item.itemName;
            };
        };
    }

    private void OnDisable()
    {
        inventoryManager.OpenInventoryUI -= (List<ItemScriptable> _itemToDisplay) =>
        {
            inventoryUI.SetActive(true);

            foreach (Transform child in itemUIObjParent)
            {
                Destroy(child.gameObject);
            }

            foreach (ItemScriptable item in _itemToDisplay)
            {
                //Instantiate UI Grid
                GameObject itemGO = Instantiate(itemUIObj, itemUIObjParent);

                //Getting Component From Childs
                Image itemImage = itemGO.transform.GetChild(0).GetComponent<Image>();
                TextMeshProUGUI itemName = itemGO.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

                //Assign The Components To Items
                itemImage.sprite = item.itemSprite;
                itemName.text = item.itemName;
            };
        };
    }
}
