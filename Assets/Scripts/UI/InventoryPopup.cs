using System;
using System.Collections.Generic;
using GameManager;
using UnityEngine;

namespace UI {
    public class InventoryPopup : MonoBehaviour {
        [SerializeField] private GameObject background;
        [SerializeField] private GameObject itemPrefab;
        private int spaceBetweenItems;
        private List<GameObject> items = new List<GameObject>();

        private void Start() {
            Managers.Inventory.onItemUsed += OnItemUsed;
        }

        private void OnEnable() {
            GenerateItems();
        }

        private void OnDisable() {
            ClearAllItems();
        }


        private void OnItemUsed() {
            ClearAllItems();
            GenerateItems();
        }

        private void GenerateItems() {
            var x = -450;
            var y = 150;

            Managers.Inventory.GetItems().ForEach(item => {
                var itemObject = Instantiate(itemPrefab, background.transform);
                var itemComponent = itemObject.GetComponent<UsableItemUI>();

                itemComponent.SetItem(item);

                itemObject.transform.localPosition = new Vector2(x, y);

                spaceBetweenItems = itemComponent.GetWidth() + 10;
                x += spaceBetweenItems;


                items.Add(itemObject);
            });
        }


        private void ClearAllItems() {
            items.ForEach(Destroy);
            items.Clear();
        }
    }
}