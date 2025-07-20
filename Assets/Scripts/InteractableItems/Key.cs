using UnityEngine;

namespace InteractableItems {
    public class Key : MonoBehaviour, Interactable {
        public void Interact() {
            Debug.Log("Collected");
        }

        public void Enable() {
            throw new System.NotImplementedException();
        }

        public void Disable() {
            throw new System.NotImplementedException();
        }

        public bool CanInteract() {
            return true;
        }
    }
}