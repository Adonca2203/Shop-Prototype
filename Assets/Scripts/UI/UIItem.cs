using UnityEngine;
using UnityEngine.EventSystems;
using Assets.Scripts.Inventory;

namespace Assets.Scripts.UI
{
    /// <summary>
    /// Represents an item on both the player and shop Inventory
    /// </summary>
    public class UIItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        private RectTransform rectTransform;
        private Vector3 homePosition;
        [SerializeField] private Canvas myCanvas;
        private GameObject parent;
        private CanvasGroup canvasGroup;
        public InventoryItem myInventoryItem;

        private void Awake()
        {
            parent = transform.parent.gameObject;
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
            homePosition = rectTransform.localPosition;
            myCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            gameObject.transform.SetParent(myCanvas.transform, true);
            rectTransform.anchoredPosition += eventData.delta / myCanvas.scaleFactor;

        }

        public void OnEndDrag(PointerEventData eventData)
        {
            gameObject.transform.SetParent(parent.transform, true);
            gameObject.transform.localPosition = homePosition;
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }
    }
}
