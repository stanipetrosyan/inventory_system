using System.Collections.Generic;
using Inventory;
using UnityEngine;

namespace GameManager {
    public class InventoryManager : MonoBehaviour, IGameManager {
        public ManagerStatus status { get; private set; }

        [SerializeField] private List<UsableItem> inventory;

        public void Startup() {
            Debug.Log("Inventory manager starting...");

            inventory = new List<UsableItem>();

            status = ManagerStatus.Started;
        }

        public void Add(UsableItem item) {
            inventory.Add(item);
        }

        public List<UsableItem> GetItems() {
            return inventory;
        }
    }
}