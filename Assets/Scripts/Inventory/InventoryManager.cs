using UnityEngine;
using Assets.Scripts.HeroScripts;
using UnityEngine.Events;

namespace Assets.Scripts.Inventory
{
    /// <summary>
    /// Manager the player inventory
    /// </summary>
    public class InventoryManager : MonoBehaviour
    {
        public  PlayerInventory playerInventory { get; private set; }
        [HideInInspector] public UnityEvent onInventoryCreate;
        [HideInInspector] public UnityEvent onMoneyChange;
        [HideInInspector]public float initialMoney = 1000f;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void CreateInventory(Hero hero)
        {
            playerInventory = ScriptableObject.CreateInstance<PlayerInventory>();
            InitializeInventory(hero);
            onInventoryCreate?.Invoke();
            AddOrSubtractMoney(initialMoney);
        }

        public void AddOrSubtractMoney(float amount)
        {
            playerInventory.Money += amount;
            if (playerInventory.Money <= 0) playerInventory.Money = 0;
            onMoneyChange?.Invoke();
        }

        private void InitializeInventory(Hero hero)
        {
            playerInventory.myItems.Clear();

            InventoryItem head = hero.ToItem(hero.currentHead);
            InventoryItem body = hero.ToItem(hero.currentBody);

            playerInventory.myItems.Add(head);
            playerInventory.myItems.Add(body);
        }
    }
}