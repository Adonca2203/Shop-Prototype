using UnityEngine;
using TMPro;
using Assets.Scripts.Inventory;

namespace Assets.Scripts.UI
{
    /// <summary>
    /// Handles the UI representation of the player's balance
    /// </summary>
    public class MoneyCount : MonoBehaviour
    {
        public TMP_Text moneyText;
        private InventoryManager inventoryManager;
        private PlayerInventory playerInventory;

        private void Awake()
        {
            inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
            inventoryManager.onInventoryCreate.AddListener(Initialize);
            inventoryManager.onMoneyChange.AddListener(UpdateMoneyUI);
        }

        void Initialize()
        {
            playerInventory = inventoryManager.playerInventory;
            moneyText.text = "$" + playerInventory.Money.ToString();
        }

        void UpdateMoneyUI()
        {
            moneyText.text = "$" + playerInventory.Money.ToString();
        }
    }
}
