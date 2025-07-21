using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManager {
    public class Managers : MonoBehaviour {
        public static InventoryManager Inventory { get; private set; }
        public static HUDManager HUD { get; private set; }
        public static ActionManager Action { get; private set; }
        public static PlayerStatsManager Stats { get; private set; }

        private List<IGameManager> startSequence;


        void Awake() {
            Inventory = GetComponent<InventoryManager>();
            HUD = GetComponent<HUDManager>();
            Action = GetComponent<ActionManager>();
            Stats = GetComponent<PlayerStatsManager>();

            startSequence = new List<IGameManager> {
                Inventory,
                HUD,
                Action,
                Stats
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