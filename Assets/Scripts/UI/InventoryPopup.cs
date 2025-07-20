using GameManager;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class InventoryPopup : MonoBehaviour {
        [SerializeField] private Image icon;

        private void OnEnable() {
            Managers.Inventory.GetItems().ForEach(item => { icon.sprite = item.icon; });
        }
    }
}