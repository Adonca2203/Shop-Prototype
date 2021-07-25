using UnityEngine;
using Assets.Scripts.Inventory;
using UnityEngine.Events;
using Assets.Scripts.UI;

namespace Assets.Scripts.HeroScripts
{
    /// <summary>
    /// Represents a playable character
    /// </summary>
    public class Hero : MonoBehaviour
    {
        public GameObject currentHead { get; private set; }
        public GameObject currentBody { get; private set; }
        public GameObject currentL_Hand { get; private set; }
        public GameObject currentR_Hand { get; private set; }
        public GameObject currentL_Foot { get; private set; }
        public GameObject currentR_Foot { get; private set; }
        public GameObject contextSign;
        public UIPlayer uiPlayer;
        private InventoryManager inventoryManager;
        private CollisionCheck collisionEvents;
        [SerializeField] private PlayerInventory inventoryGlossary;
        [HideInInspector] public UnityEvent<Hero> onEquipmentChange;

        void Awake()
        {
            inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
            Initialize();
            inventoryManager.CreateInventory(this);
            collisionEvents = gameObject.transform.Find("l_foot").GetComponent<CollisionCheck>();
            collisionEvents.interact.AddListener(ToggleContextMenu);
            uiPlayer.onEquipmentChange.AddListener(ChangeEquipmet);
        }

        private void ToggleContextMenu()
        {
            contextSign.gameObject.SetActive(!contextSign.activeSelf);
        }

        private void Initialize()
        {
            currentHead = gameObject.transform.Find("head").gameObject;
            currentBody = gameObject.transform.Find("body").gameObject;
            currentL_Hand = gameObject.transform.Find("l_hand").gameObject;
            currentR_Hand = gameObject.transform.Find("r_hand").gameObject;
            currentL_Foot = gameObject.transform.Find("l_foot").gameObject;
            currentR_Foot = gameObject.transform.Find("r_foot").gameObject;
            contextSign = gameObject.transform.Find("head").gameObject.transform.Find("interact_context").gameObject;
        }

        public InventoryItem ToItem(GameObject obj)
        {
            Sprite sprite = obj.GetComponent<SpriteRenderer>().sprite;
            foreach (InventoryItem item in inventoryGlossary.myItems)
            {
                if (sprite.name.Replace(" ", "") == item.itemName.Replace(" ", ""))
                {
                    return item;
                }
                continue;
            }
            return null;
        }

        public void ChangeEquipmet(InventoryItem item)
        {
            switch (item.equipmentType)
            {
                case InventoryItem.EquipmentType.head:
                    currentHead.GetComponent<SpriteRenderer>().sprite = item.itemImage;
                    break;

                case InventoryItem.EquipmentType.body:
                    currentBody.GetComponent<SpriteRenderer>().sprite = item.itemImage;
                    break;

                case InventoryItem.EquipmentType.none:

                    return;
            }

            onEquipmentChange?.Invoke(this);

        }

    }
}