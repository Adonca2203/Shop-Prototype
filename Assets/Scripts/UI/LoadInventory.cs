using UnityEngine;
using Assets.Scripts.Inventory;
using UnityEngine.UI;
using TMPro;

namespace Assets.Scripts.UI
{
    /// <summary>
    /// Handles the loading for the shop and player inventory menus
    /// </summary>
    public class LoadInventory : MonoBehaviour
    {
        public GameObject inventoryItemObject;
        private InventoryManager inventoryManager;
        public BuySellDrop BuysellDrop;
        public BuySellDrop buySellDrop;
        public PlayerInventory inventoryToLoadFrom;
        public float itemPrice;
        public enum BuyOrSell
        {
            Buy,
            Sell
        }

        public BuyOrSell buyOrSell = BuyOrSell.Buy;
        bool isReady => inventoryToLoadFrom != null;

        private void Start()
        {
            if (BuysellDrop != null && buySellDrop != null)
            {
                BuysellDrop.success.AddListener(DisplayInventory);
                buySellDrop.success.AddListener(DisplayInventory);
            }
        }

        void Initialize()
        {
            if (!isReady)
            {
                inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
                inventoryToLoadFrom = inventoryManager.playerInventory;
            }
        }

        void DisplayInventory()
        {
            Initialize();

            DestroyInventory();
            foreach(InventoryItem item in inventoryToLoadFrom.myItems)
            {
                if (item.isEquipped)
                    continue;

                switch (buyOrSell)
                {
                    case BuyOrSell.Buy:
                        itemPrice = item.itemBuyPrice;
                        break;
                    case BuyOrSell.Sell:
                        itemPrice = item.itemSellPrice;
                        break;
                }

                GameObject child = Instantiate(inventoryItemObject, gameObject.transform);

                if(child.transform.Find("ItemPrice") != null)
                {
                    GameObject itemPriceObj = child.transform.Find("ItemPrice").gameObject;
                    TMP_Text itemText = itemPriceObj.GetComponent<TMP_Text>();
                    itemText.text = "$ " + itemPrice.ToString();
                }

                UIItem UIitem = child.transform.Find("ItemImage").GetComponent<UIItem>();
                child.transform.Find("ItemImage").GetComponent<Image>().sprite = item.itemImage;
                UIitem.myInventoryItem = item;
            }
        }

        void DestroyInventory()
        {
            foreach(Transform obj in gameObject.transform)
            {
                Destroy(obj.gameObject);
            }
        }

        private void OnEnable()
        {
            DisplayInventory();
        }
    }
}
