using GameManager;
using Port;
using UnityEngine;

namespace Inventory {
    public class InteractableItem : MonoBehaviour, Interactable {
        [SerializeField] private UsableItemSO item;
        public bool interacted = false;

        public void Interact() {
            Managers.Inventory.Add(item);
            interacted = true;
            Destroy(gameObject);
        }


        public bool CanInteract() {
            return !interacted;
        }
    }
}