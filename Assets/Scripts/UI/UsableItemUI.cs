using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class UsableItemUI: MonoBehaviour {
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text descriptionText;

        public void SetIcon(Sprite sprite) {
            icon.sprite = sprite;
        }
        
        public void SetDescription(string description) {
            descriptionText.text = description;
        }

        public int GetWidth() {
            return (int)GetComponent<RectTransform>().rect.width;
        }
    }
}