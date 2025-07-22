using System;
using Inventory;
using Player;
using Port;
using TMPro;
using UnityEngine;

namespace GameManager {
    public class ActionManager : MonoBehaviour, IGameManager {
        public ManagerStatus status { get; private set; }

        public void Startup() {
            status = ManagerStatus.Started;
        }

        public void PerformAction(UsableItemSO itemSo) {
            Debug.Log("Performing action");
            switch (itemSo.type) {
                case UsableItemSO.Type.KEY:
                    break;
                case UsableItemSO.Type.HEALTH_POTION:
                    Managers.Stats.IncrementHealth();
                    break;
                case UsableItemSO.Type.ENERGY_POTION:
                    Managers.Stats.IncrementEnergy();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}