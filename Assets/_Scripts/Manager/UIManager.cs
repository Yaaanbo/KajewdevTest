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
        inventoryManager.OpenInventoryUI += (List<BaseItem> _itemToDisplay) =>
        {
            inventoryUI.SetActive(true);

            foreach(Transform child in itemUIObjParent)
            {
                Destroy(child.gameObject);
            }

            foreach(BaseItem item in _itemToDisplay)
            {
                //Instantiate UI Grid
                GameObject itemGO = Instantiate(itemUIObj, itemUIObjParent);

                //Getting Item Components
                Button itemButton = itemGO.GetComponent<Button>();
                Image itemImage = itemGO.transform.GetChild(0).GetComponent<Image>();
                TextMeshProUGUI itemName = itemGO.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

                //Assign The Components To UI Buttons
                itemImage.sprite = item.item.itemSprite;
                itemName.text = item.item.itemName;
                itemButton.onClick.AddListener(() =>
                {
                    item.OnUse();
                    inventoryUI.SetActive(false);
                });
            };
        };
    }

    private void OnDisable()
    {
        inventoryManager.OpenInventoryUI -= (List<BaseItem> _itemToDisplay) =>
        {
            inventoryUI.SetActive(true);

            foreach (Transform child in itemUIObjParent)
            {
                Destroy(child.gameObject);
            }

            foreach (BaseItem item in _itemToDisplay)
            {
                //Instantiate UI Grid
                GameObject itemGO = Instantiate(itemUIObj, itemUIObjParent);

                //Getting Item Components
                Button itemButton = itemGO.GetComponent<Button>();
                Image itemImage = itemGO.transform.GetChild(0).GetComponent<Image>();
                TextMeshProUGUI itemName = itemGO.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

                //Assign The Components To UI Buttons
                itemImage.sprite = item.item.itemSprite;
                itemName.text = item.item.itemName;
                itemButton.onClick.AddListener(() =>
                {
                    item.OnUse();
                    inventoryUI.SetActive(false);
                });
            };
        };
    }
}
