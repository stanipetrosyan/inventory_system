using UnityEngine;

namespace Inventory {
    [CreateAssetMenu(fileName = "UsableItem", menuName = "ScriptableObjects/UsableItem")]
    public class UsableItem: ScriptableObject{
        public int count = 1;
        public string displayName;
        public Type type;

        public void Use() {
            count--;
        }
        
        public enum Type {
            KEY
        }
    }
}