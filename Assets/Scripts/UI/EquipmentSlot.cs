using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using Assets.Scripts.Inventory;

namespace Assets.Scripts.UI
{
    /// <summary>
    /// Represents one of the equipment slots in the inventory screen
    /// </summary>
    public class EquipmentSlot : MonoBehaviour, IDropHandler
    {
        public Image thisImage;
        [HideInInspector] public UnityEvent<InventoryItem> onItemChange;
        [HideInInspector] public InventoryItem incomingInventoryItem;
        public InventoryItem outGoingInventoryItem;
        public InventoryItem.EquipmentType myEquipmentType;
        bool RejectItem() => incomingInventoryItem.equipmentType != myEquipmentType;

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null) return;

            GameObject otherObject = eventData.pointerDrag.gameObject;
            incomingInventoryItem = otherObject.GetComponent<UIItem>().myInventoryItem;
            if (RejectItem()) return;

            incomingInventoryItem.isEquipped = true;
            outGoingInventoryItem.isEquipped = false;

            otherObject.GetComponent<UIItem>().myInventoryItem = outGoingInventoryItem;
            outGoingInventoryItem = incomingInventoryItem;

            Image otherObjectSprite = otherObject.GetComponent<Image>();
            Sprite temp = thisImage.sprite;
            thisImage.sprite = otherObjectSprite.sprite;
            otherObjectSprite.sprite = temp;
            onItemChange?.Invoke(incomingInventoryItem);
        }
    }
}
