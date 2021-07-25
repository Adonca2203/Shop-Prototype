using UnityEngine;
using UnityEngine.EventSystems;
using Assets.Scripts.Inventory;
using UnityEngine.Events;

namespace Assets.Scripts.UI
{
    /// <summary>
    /// Handler for the Buy and Sell objects in the Buy and Sell menu
    /// </summary>
    public class BuySellDrop : MonoBehaviour, IDropHandler
    {
        public enum BuyOrSell
        {
            Buy,
            Sell
        }

        public BuyOrSell buyOrSell = BuyOrSell.Buy;
        public PlayerInventory shopInventory;
        private InventoryManager inventoryManager;
        [HideInInspector] public UnityEvent success;

        private void Start()
        {
            inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
        }

        public void OnDrop(PointerEventData eventData)
        {
            GameObject obj = eventData.pointerDrag;
            if (obj == null) return;
            InventoryItem item = obj.GetComponent<UIItem>().myInventoryItem;

            switch (buyOrSell)
            {
                case BuyOrSell.Buy:
                    if (inventoryManager.playerInventory.Money >= item.itemBuyPrice)
                    {
                        inventoryManager.AddOrSubtractMoney(-item.itemBuyPrice);
                        inventoryManager.playerInventory.myItems.Add(item);
                        shopInventory.myItems.Remove(item);
                        success?.Invoke();
                    }
                    break;
                case BuyOrSell.Sell:
                    inventoryManager.AddOrSubtractMoney(item.itemSellPrice);
                    inventoryManager.playerInventory.myItems.Remove(item);
                    shopInventory.myItems.Add(item);
                    success?.Invoke();
                    break;
            }
        }
    }
}
