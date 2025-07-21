using GameManager;
using UnityEngine;

namespace UI {
    public class InventoryPopup : MonoBehaviour {
        [SerializeField] private GameObject background;
        [SerializeField] private GameObject itemPrefab;
        private int spaceBetweenItems;

        private void OnEnable() {
            var x = -450;
            var y = 150;

            Managers.Inventory.GetItems().ForEach(item => {
                var itemObject = Instantiate(itemPrefab, background.transform);
                var itemComponent = itemObject.GetComponent<UsableItemUI>();

                itemComponent.SetIcon(item.icon);
                itemComponent.SetDescription(item.displayName);

                itemObject.transform.localPosition = new Vector2(x, y);

                spaceBetweenItems = itemComponent.GetWidth() + 10;
                x += spaceBetweenItems;
            });
        }
    }
}