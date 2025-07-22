using UnityEngine;

namespace Inventory {
    [CreateAssetMenu(fileName = "UsableItem", menuName = "ScriptableObjects/UsableItem")]
    public class UsableItemSO: ScriptableObject{
        public int count = 1;
        public string displayName;
        public Type type;
        public Sprite icon;
        public void Use() {
            count--;
        }
        
        public enum Type {
            KEY, HEALTH_POTION, ENERGY_POTION
        }
    }
}