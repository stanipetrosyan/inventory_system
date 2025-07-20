namespace InteractableItems {
    public interface Interactable {
        public void Interact();

        public void Enable();

        public void Disable();

        public bool CanInteract();
    }
}