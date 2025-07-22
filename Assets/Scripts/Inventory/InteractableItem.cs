using GameManager;
using Port;
using UnityEngine;

namespace Inventory {
    public class InteractableItem : MonoBehaviour, Interactable {
        [SerializeField] private UsableItemSO itemSo;
        public bool interacted = false;

        public void Interact() {
            Managers.Inventory.Add(itemSo);
            interacted = true;
            Destroy(gameObject);
        }


        public bool CanInteract() {
            return !interacted;
        }
    }
}