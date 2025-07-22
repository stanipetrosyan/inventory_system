using GameManager;
using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class UsableItemUI : MonoBehaviour {
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text descriptionText;
        [SerializeField] private TMP_Text countText;
        [SerializeField] private Button useItem;
        private UsableItemSO _itemSo;

        private void Start() {
            useItem.onClick.AddListener(UseItem);
        }

        public int GetWidth() {
            return (int)GetComponent<RectTransform>().rect.width;
        }

        public void SetItem(UsableItemSO usableItemSo) {
            this._itemSo = usableItemSo;

            icon.sprite = _itemSo.icon;
            descriptionText.text = _itemSo.displayName;
            countText.text = $"Count: {_itemSo.count}";
        }

        private void UseItem() {
            Managers.Inventory.UseItem(_itemSo);
        }
    }
}