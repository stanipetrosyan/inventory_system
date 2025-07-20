using UnityEngine;

namespace UI {
    public class InventoryUIController : MonoBehaviour {
        [SerializeField] InventoryPopup popup;

        void Start() {
            popup.gameObject.SetActive(false);
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.I)) {
                bool isShowing = popup.gameObject.activeSelf;
                popup.gameObject.SetActive(!isShowing);
            }
        }
    }
}