using Port;
using TMPro;
using UnityEngine;

namespace GameManager {
    public class HUDManager: MonoBehaviour, IGameManager {
        public ManagerStatus status { get; private set; }
        [SerializeField] private TMP_Text interactText;
        
        public void Startup() {
            interactText.gameObject.SetActive(false);
            
            status = ManagerStatus.Started;
        }

        public void Enable() {
            interactText.gameObject.SetActive(true);
        }
        
        public void Disable() {
            interactText.gameObject.SetActive(false);
        }
        
    }
}