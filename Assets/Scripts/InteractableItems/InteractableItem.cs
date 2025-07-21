using GameManager;
using Inventory;
using UnityEngine;

namespace InteractableItems {
    public class InteractableItem : MonoBehaviour, Interactable {
        [SerializeField] private UsableItem item;
        public bool interacted = false;
        
        public void Interact() {
            Debug.Log("Collected");
            
            Managers.Inventory.Add(item);
            interacted = true;
            Destroy(gameObject);
        }


        public bool CanInteract() {
            return !interacted;
        }
    }
}