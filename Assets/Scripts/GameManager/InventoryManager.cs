using System.Collections.Generic;
using System.Linq;
using Inventory;
using UnityEngine;

namespace GameManager {
    public class InventoryManager : MonoBehaviour, IGameManager {
        public ManagerStatus status { get; private set; }

        [SerializeField] private List<UsableItem> inventory;

        public delegate void OnItemUsed();

        public event OnItemUsed onItemUsed;

        public void Startup() {
            Debug.Log("Inventory manager starting...");

            inventory = new List<UsableItem>();

            status = ManagerStatus.Started;
        }

        public void Add(UsableItem item) {
            var alreadyExists = inventory.Where(inventoryItem => inventoryItem.type == item.type).ToList();

            if (alreadyExists.Count == 0) {
                item.count = 1;
                inventory.Add(item);
            }
            else {
                alreadyExists.ForEach(inventoryItem => inventoryItem.count++);
            }
        }


        public List<UsableItem> GetItems() {
            return inventory;
        }

        public void UseItem(UsableItem item) {
            Debug.Log("Using item " + item.name);
            item.Use();

            if (item.count == 0) {
                inventory.Remove(item);
            }

            onItemUsed?.Invoke();
            Managers.Action.PerformAction(item);
        }
    }
}