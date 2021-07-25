using UnityEngine;

namespace Assets.Scripts.Inventory
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
    public class InventoryItem : ScriptableObject
    {
        public bool isEquipped;
        public string itemName;
        public string itemDescription;
        public Sprite itemImage;
        public enum EquipmentType
        {

            head,
            body,
            none

        }

        public EquipmentType equipmentType;
        public float itemBuyPrice;
        public float itemSellPrice;

    }
}