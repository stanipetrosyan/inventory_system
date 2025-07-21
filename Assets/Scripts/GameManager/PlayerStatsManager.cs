using UnityEngine;

namespace GameManager {
    public class PlayerStatsManager : MonoBehaviour, IGameManager {
        public ManagerStatus status { get; private set; }

        private int health;
        private int energy;
        
        public void Startup() {
            health = 0;
            energy = 0;
            
            status = ManagerStatus.Started;
        }

        public void IncrementHealth() {
            health += 20;
            Debug.Log("Health: " + health);
        }

        public void IncrementEnergy() {
            energy += 20;
            Debug.Log("Energy: " + energy);
        }
    }
}