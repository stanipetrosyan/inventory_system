using System;
using Inventory;
using Player;
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
                    Managers.Stats.IncrementHealth();
                    break;
                case UsableItem.Type.ENERGY_POTION:
                    Managers.Stats.IncrementEnergy();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}