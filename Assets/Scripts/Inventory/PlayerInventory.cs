using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Inventory")]
    public class PlayerInventory : ScriptableObject
    {
        public List<InventoryItem> myItems = new List<InventoryItem>();
        public float Money = 0f;
    }
}