using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    /// <summary>
    /// Even handler for the all shop Buttons
    /// </summary>
    public class ShopButtonEvents : MonoBehaviour
    {
        public Button BuyButton;
        public Button SellButton;
        public ShopFlow shopFlow;
        public Button TalkButton;

        private void Start()
        {
            BuyButton.onClick.AddListener(BuyMenu);
            SellButton.onClick.AddListener(SellMenu);
            TalkButton.onClick.AddListener(TalkMenu);
        }

        void BuyMenu()
        {
            shopFlow.ChangeState(ShopFlow.ShopState.buying);
        }

        void SellMenu()
        {
            shopFlow.ChangeState(ShopFlow.ShopState.selling);
        }

        void TalkMenu()
        {
            shopFlow.ChangeState(ShopFlow.ShopState.chatting);
        }

    }
}
