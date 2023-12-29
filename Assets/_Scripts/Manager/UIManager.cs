using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Class Reference")]
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private ItemEffectManager itemEffectManager;
    [SerializeField] private ItemDetector itemDetector;

    [Header("Inventory UI")]
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private GameObject itemUIObj;
    [SerializeField] private Transform itemUIObjParent;

    [Header("HP UI")]
    [SerializeField] private Image hpBarFill;
    [SerializeField] private TMP_Text hpText;

    [Header("Interact Button")]
    [SerializeField] private Button interactButton;

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
        itemEffectManager.OnHpUpdated += (float _currentHealth, float _maxHealth) =>
        {
            hpBarFill.fillAmount = _currentHealth / _maxHealth;
            hpText.text = $"{_currentHealth} / {_maxHealth}";
        };
        itemDetector.OnItemTakable += (BaseItem _interactableItem) =>
        {
            //Grabbing button components
            Transform buttonTransform = interactButton.transform;
            TextMeshProUGUI itemNameText = buttonTransform.GetChild(0).GetComponent<TextMeshProUGUI>();
            Image itemImage = buttonTransform.GetChild(1).GetComponent<Image>();

            //Assign button components according to item component
            itemNameText.text = "(F) " + _interactableItem.item.itemName;
            itemImage.sprite = _interactableItem.item.itemSprite;

            //Activate button object and add OnTaken listener
            interactButton.gameObject.SetActive(true);
            interactButton.onClick.RemoveAllListeners();
            interactButton.onClick.AddListener(() => { _interactableItem.OnTaken(); });
        };
        itemDetector.OnItemIntakable += () =>
        {
            //Deactivate Interact Button
            interactButton.gameObject.SetActive(false);
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
        itemEffectManager.OnHpUpdated += (float _currentHealth, float _maxHealth) =>
        {
            hpBarFill.fillAmount = _currentHealth / _maxHealth;
            hpText.text = $"{_currentHealth} / {_maxHealth}";
        };
        itemDetector.OnItemTakable -= (BaseItem _interactableItem) =>
        {
            //Grabbing button components
            Transform buttonTransform = interactButton.transform;
            TextMeshProUGUI itemNameText = buttonTransform.GetChild(0).GetComponent<TextMeshProUGUI>();
            Image itemImage = buttonTransform.GetChild(1).GetComponent<Image>();

            //Assign button components according to item component
            itemNameText.text = "(F) " + _interactableItem.item.itemName;
            itemImage.sprite = _interactableItem.item.itemSprite;

            //Activate button object and add OnTaken listener
            interactButton.gameObject.SetActive(true);
            interactButton.onClick.RemoveAllListeners();
            interactButton.onClick.AddListener(() => { _interactableItem.OnTaken(); });
        };
        itemDetector.OnItemIntakable -= () =>
        {
            //Deactivate Interact Button
            interactButton.gameObject.SetActive(false);
        };
    }
}
