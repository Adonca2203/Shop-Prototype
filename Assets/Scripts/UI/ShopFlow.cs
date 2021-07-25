using UnityEngine;
using Assets.Scripts.Inventory;

namespace Assets.Scripts.UI
{
    /// <summary>
    /// Handles the shop menu flow
    /// </summary>
    public class ShopFlow : MonoBehaviour
    {
        public enum ShopState
        {
            inactive,
            choosing,
            buying,
            selling,
            chatting
        }

        public ShopState currentShopState = ShopState.inactive;
        private GameManager gameManager;
        public GameObject choosingWindow;
        public GameObject buyingWindow;
        public GameObject sellingWindow;
        public GameObject chatWindow;
        public ShopTalk shopTalk;
        private bool isInitialized => gameManager != null;

        public void ToggleShop()
        {
            if (!isInitialized)
            {
                gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            }
            gameObject.SetActive(!gameObject.activeSelf);
            ChangeState(currentShopState == ShopState.inactive ? ShopState.choosing : ShopState.inactive);
        }

        private void OnStateChange()
        {
            switch (currentShopState)
            {
                case ShopState.inactive:
                    choosingWindow.SetActive(false);
                    buyingWindow.SetActive(false);
                    sellingWindow.SetActive(false);
                    chatWindow.SetActive(false);
                    gameManager.currentState = GameManager.GameState.play;
                    break;

                case ShopState.choosing:
                    choosingWindow.SetActive(true);
                    buyingWindow.SetActive(false);
                    sellingWindow.SetActive(false);
                    chatWindow.SetActive(false);
                    gameManager.currentState = GameManager.GameState.shop;
                    break;

                case ShopState.buying:
                    choosingWindow.SetActive(false);
                    buyingWindow.SetActive(true);
                    sellingWindow.SetActive(false);
                    chatWindow.SetActive(false);
                    gameManager.currentState = GameManager.GameState.shop;
                    break;

                case ShopState.selling:
                    choosingWindow.SetActive(false);
                    buyingWindow.SetActive(false);
                    sellingWindow.SetActive(true);
                    chatWindow.SetActive(false);
                    gameManager.currentState = GameManager.GameState.shop;
                    break;

                case ShopState.chatting:
                    choosingWindow.SetActive(false);
                    buyingWindow.SetActive(false);
                    sellingWindow.SetActive(false);
                    chatWindow.SetActive(true);
                    gameManager.currentState = GameManager.GameState.shop;
                    break;
            }

        }

        public void ChangeState(ShopState newState)
        {
            currentShopState = newState;
            OnStateChange();
        }
    }
}

