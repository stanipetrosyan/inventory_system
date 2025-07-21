using System;
using Inventory;
using TMPro;
using UnityEngine;

namespace GameManager {
    public class ActionManager : MonoBehaviour, IGameManager {
        public ManagerStatus status { get; private set; }

        public void Startup() {
            status = ManagerStatus.Started;
        }

        public void PerformAction(UsableItem item) {
            Debug.Log("Performing action");
            switch (item.type) {
                case UsableItem.Type.KEY:
                    break;
                case UsableItem.Type.HEALTH_POTION:
                    break;
                case UsableItem.Type.ENERGY_POTION:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}