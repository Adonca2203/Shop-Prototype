using UnityEngine;
using Assets.Scripts.HeroScripts;

namespace Assets.Scripts.UI
{
    /// <summary>
    /// Handles UI Related inputs
    /// </summary>
    public class UIControls : MonoBehaviour
    {
        public GameManager gameManager;
        public GameObject inventoryPanel;
        public GameObject shopPanel;
        private Hero hero;
        [SerializeField] private ShopFlow shopFlow;
        private bool isTalking => shopFlow.shopTalk.awaitingInput;
        private bool enterShop => hero.contextSign.activeSelf;

        private void Awake()
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            inventoryPanel.SetActive(false);
            hero = GameObject.Find("Hero").GetComponent<Hero>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                switch (gameManager.currentState)
                {
                    case GameManager.GameState.play:
                        if (enterShop)
                        {
                            shopFlow.ToggleShop();
                            return;
                        }
                        inventoryPanel.SetActive(true);
                        gameManager.currentState = GameManager.GameState.inventory;
                        break;

                    case GameManager.GameState.inventory:
                        inventoryPanel.SetActive(false);
                        gameManager.currentState = GameManager.GameState.play;
                        break;

                    case GameManager.GameState.shop:
                        if (isTalking) return;
                        shopFlow.ToggleShop();
                        break;

                    default:
                        return;

                }
            }
        }
    }
}
