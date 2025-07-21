using GameManager;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class InventoryPopup : MonoBehaviour {
        [SerializeField] private GameObject background;
        [SerializeField] private GameObject itemPrefab;
        private int spaceBetweenItems = 125;


        private void OnEnable() {
            var x = -450;
            var y = 150;
            
            Managers.Inventory.GetItems().ForEach(item => {
                var itemObject = Instantiate(itemPrefab, background.transform);
                itemObject.transform.GetChild(0).GetComponent<Image>().sprite = item.icon;
                itemObject.transform.localPosition = new Vector2(x, y);
                x += spaceBetweenItems;
            });
        }
    }
}