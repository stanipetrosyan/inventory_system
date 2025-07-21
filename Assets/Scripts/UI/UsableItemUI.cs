using GameManager;
using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI {
    public class UsableItemUI : MonoBehaviour, IPointerClickHandler {
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text descriptionText;
        [SerializeField] private TMP_Text countText;
        private UsableItem item;

        public int GetWidth() {
            return (int)GetComponent<RectTransform>().rect.width;
        }

        public void SetItem(UsableItem usableItem) {
            this.item = usableItem;

            icon.sprite = item.icon;
            descriptionText.text = item.displayName;
            countText.text = $"Count: {item.count}";
        }

        public void OnPointerClick(PointerEventData eventData) {
            Managers.Inventory.UseItem(item);
        }
    }
}