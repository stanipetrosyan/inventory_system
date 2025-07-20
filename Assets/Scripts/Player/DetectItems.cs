using GameManager;
using InteractableItems;
using UnityEngine;

namespace Player {
    public class DetectItems : MonoBehaviour {
        [SerializeField] private float radius = 0.5f;
        [SerializeField] private LayerMask interactableLayer;

        private void Update() {
            DetectCollision();
        }

        private void DetectCollision() {
            RaycastHit hit;
            Physics.SphereCast(transform.position, radius, Vector3.forward, out hit, radius, interactableLayer);

            if (hit.collider is not null) {
                switch (LayerMask.LayerToName(hit.collider.gameObject.layer)) {
                    case "Interactable":
                        var interactableItem = hit.collider.gameObject.GetComponent<Interactable>();
                        if (interactableItem.CanInteract()) {
                            Managers.HUD.Enable();
                            if (Input.GetKeyDown(KeyCode.E)) {
                                interactableItem.Interact();
                            }
                        }

                        break;

                    default:
                        Managers.HUD.Disable();
                        break;
                }
            }
        }
    }
}