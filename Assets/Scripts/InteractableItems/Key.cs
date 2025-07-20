using System.Collections.Generic;
using GameManager;
using Inventory;
using UnityEngine;

namespace InteractableItems {
    public class Key : MonoBehaviour, Interactable {
        [SerializeField] private UsableItem item;
        public bool interacted = false;
        
        public void Interact() {
            Debug.Log("Collected");
            
            Managers.Inventory.Add(item);
            interacted = true;
        }


        public bool CanInteract() {
            return !interacted;
        }
    }
}