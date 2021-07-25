using Assets.Scripts.Inventory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Assets.Scripts.UI
{
    /// <summary>
    /// The UI Inventory representation of the player
    /// </summary>
    public class UIPlayer : MonoBehaviour
    {
        private List<EquipmentSlot> equipmentSlots = new List<EquipmentSlot>();
        [HideInInspector] public UnityEvent<InventoryItem> onEquipmentChange;

        private void Awake()
        {

            foreach (Transform child in transform.parent.Find("Costume").transform)
            {
                EquipmentSlot es = child.GetChild(0).GetComponent<EquipmentSlot>();
                equipmentSlots.Add(es);
                es.onItemChange.AddListener(changeThisSprite);
            }
        }

        private void changeThisSprite(InventoryItem myInventoryItem)
        {
            switch (myInventoryItem.equipmentType)
            {
                case InventoryItem.EquipmentType.head:
                    transform.Find("head").GetComponent<Image>().sprite = myInventoryItem.itemImage;
                    break;
                case InventoryItem.EquipmentType.body:
                    transform.Find("body").GetComponent<Image>().sprite = myInventoryItem.itemImage;
                    break;
                default:
                    return;
            }
            onEquipmentChange?.Invoke(myInventoryItem);
        }
    }
}
