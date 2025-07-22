using Port;
using UI;
using UnityEngine;

namespace GameManager {
    public class PlayerStatsManager : MonoBehaviour, IGameManager {
        public ManagerStatus status { get; private set; }

        public int health;
        public int energy;
        
        public delegate void OnStatsChanged();
        public event OnStatsChanged onStatsChanged;
        
        public void Startup() {
            health = 0;
            energy = 0;
            
            status = ManagerStatus.Started;
        }

        public void IncrementHealth() {
            health += 20;
            Debug.Log("Health: " + health);
            
            onStatsChanged?.Invoke();
        }

        public void IncrementEnergy() {
            energy += 20;
            Debug.Log("Energy: " + energy);
        }
    }
}