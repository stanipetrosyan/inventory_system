using GameManager;
using Port;
using UnityEngine;

namespace Player {
    public class DetectItems : MonoBehaviour {
        [SerializeField] private LayerMask interactableLayer;
        [SerializeField] private Camera playerCamera;

        private void Update() {
            DetectCollision();
        }

        private void DetectCollision() {
            Vector3 point = new Vector3(playerCamera.pixelWidth / 2, playerCamera.pixelHeight / 2, 0);
            Ray ray = playerCamera.ScreenPointToRay(point);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
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
}