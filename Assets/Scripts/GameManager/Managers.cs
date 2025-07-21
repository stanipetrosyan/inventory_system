using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManager {
    [RequireComponent(typeof(InventoryManager), typeof(HUDManager))]
    public class Managers : MonoBehaviour {
        public static InventoryManager Inventory { get; private set; }
        public static HUDManager HUD { get; private set; }

        private List<IGameManager> startSequence;


        void Awake() {
            Inventory = GetComponent<InventoryManager>();
            HUD = GetComponent<HUDManager>();

            startSequence = new List<IGameManager> {
                Inventory,
                HUD
            };

            StartCoroutine(StartupManagers());
        }

        private IEnumerator StartupManagers() {
            foreach (IGameManager manager in startSequence) {
                manager.Startup();
            }

            yield return null;

            int numModules = startSequence.Count;
            int numReady = 0;

            while (numReady < numModules) {
                int lastReady = numReady;
                numReady = 0;

                foreach (IGameManager manager in startSequence) {
                    if (manager.status == ManagerStatus.Started) {
                        numReady++;
                    }
                }

                if (numReady > lastReady) {
                    Debug.Log($"Progress: {numReady}/{numModules}");
                }

                yield return null;
            }

            Debug.Log("All manager started up");
        }
    }
}