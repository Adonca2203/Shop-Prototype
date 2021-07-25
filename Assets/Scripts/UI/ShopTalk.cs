using UnityEngine;
using System.Collections;
using TMPro;

namespace Assets.Scripts.UI
{
    /// <summary>
    /// Basic talk system where characters are displayed over time instead of instantly along with basic logic for talk flow
    /// </summary>
    public class ShopTalk : MonoBehaviour
    {
        bool hasGreeted = false;
        public TMP_Text ShopKeeperText;
        private string Greeting = "Hello traveler.";
        private string[] ShopKeeperBanter = { "I offer the best deals on both tops and hairs.\nMr. TopUp they call me" };
        public bool awaitingInput;
        private bool doneTalking;
        public ShopFlow shopFlow;

        private void Start()
        {
            if (!hasGreeted)
            {
                StartCoroutine(DisplayText(Greeting));
                hasGreeted = true;
                return;
            }
            StartCoroutine(DisplayText(ShopKeeperBanter[Random.Range(0, ShopKeeperBanter.Length)], true));
        }

        private void OnEnable()
        {
            if (hasGreeted)
            {
                StartCoroutine(DisplayText(ShopKeeperBanter[Random.Range(0, ShopKeeperBanter.Length)], true));
            }
        }

        private void FixedUpdate()
        {
            if (!awaitingInput) return;
            if (Input.GetMouseButtonDown(0) && !doneTalking)
            {
                StartCoroutine(DisplayText(ShopKeeperBanter[Random.Range(0, ShopKeeperBanter.Length)], true));
            }
            if (Input.GetMouseButtonDown(0) && doneTalking)
            {
                shopFlow.ChangeState(ShopFlow.ShopState.choosing);
                awaitingInput = false;
            }
        }

        private IEnumerator DisplayText(string text, bool lastPiece = false)
        {
            ShopKeeperText.text = "";
            for (int i = 0; i < text.Length; i++)
            {
                ShopKeeperText.text += text[i];
                yield return new WaitForEndOfFrame();
            }
            doneTalking = lastPiece;
            awaitingInput = true;
        }
    }
}
