using System.Collections.Generic;
using System.Linq;
using Inventory;
using Port;
using UnityEngine;

namespace GameManager {
    public class InventoryManager : MonoBehaviour, IGameManager {
        public ManagerStatus status { get; private set; }

        [SerializeField] private List<UsableItemSO> inventory;

        public delegate void OnItemUsed();

        public event OnItemUsed onItemUsed;

        public void Startup() {
            Debug.Log("Inventory manager starting...");

            inventory = new List<UsableItemSO>();

            status = ManagerStatus.Started;
        }

        public void Add(UsableItemSO itemSo) {
            var alreadyExists = inventory.Where(inventoryItem => inventoryItem.type == itemSo.type).ToList();

            if (alreadyExists.Count == 0) {
                itemSo.count = 1;
                inventory.Add(itemSo);
            }
            else {
                alreadyExists.ForEach(inventoryItem => inventoryItem.count++);
            }
        }


        public List<UsableItemSO> GetItems() {
            return inventory;
        }

        public void UseItem(UsableItemSO itemSo) {
            Debug.Log("Using item " + itemSo.name);
            itemSo.Use();

            if (itemSo.count == 0) {
                inventory.Remove(itemSo);
            }

            onItemUsed?.Invoke();
            Managers.Action.PerformAction(itemSo);
        }
    }
}