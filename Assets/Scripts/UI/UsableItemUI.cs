using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class UsableItemUI: MonoBehaviour {
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text descriptionText;
        [SerializeField] private TMP_Text countText;

        public void SetIcon(Sprite sprite) {
            icon.sprite = sprite;
        }
        
        public void SetDescription(string description) {
            descriptionText.text = description;
        }

        public void SetCount(string count) {
            countText.text = $"Count: {count}";
        }

        public int GetWidth() {
            return (int)GetComponent<RectTransform>().rect.width;
        }
    }
}