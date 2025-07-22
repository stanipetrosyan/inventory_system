using GameManager;
using TMPro;
using UnityEngine;

namespace UI {
    public class StatsPopup : MonoBehaviour {
        [SerializeField] private TMP_Text healthText;
        [SerializeField] private TMP_Text energyText;        
        private void Start() {
            healthText.text = "Health: 0";
            energyText.text = "Energy: 0";

            Managers.Stats.onStatsChanged += SetStats;
        }

        private void SetStats() {
            Debug.Log("Stats changed");
            var health = Managers.Stats.health;
            var energy = Managers.Stats.energy;
            
            healthText.text = $"Health: {health}";
            energyText.text = $"Energy: {energy}";
        }
    }
}