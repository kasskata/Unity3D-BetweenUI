namespace Assets.BetweenUI.Scripts
{
    using BetweenUI;
    using UnityEngine;
    using UnityEngine.UI;

    public class Dropdown : MonoBehaviour
    {
        public BetweenScale dropdownScaleTransit;
        public BetweenAlpha dropdownAlphaTransit;

        public Text selectedLabel;

        public int selectedItem;
        public string[] dropdownOptions;

        public void Start()
        {
            Transform parentDropdown = this.dropdownAlphaTransit.transform;
            this.dropdownOptions = new string[parentDropdown.childCount];

            Transform child;
            for (int i = 0; i < parentDropdown.childCount; i++)
            {
                child = parentDropdown.GetChild(i);
                this.dropdownOptions[i] = child.GetComponent<Text>().text;
                Button button = child.GetComponent<Button>() ?? child.gameObject.AddComponent<Button>();
                int index = i;
                button.onClick.AddListener(() => Select(index));
            }
        }

        public void Switch()
        {
            if (!this.dropdownAlphaTransit.Active)
            {
                Open();
            }
            else
            {
                Close();
            }
        }

        public void Open()
        {
            this.dropdownAlphaTransit.PlayForward();
            this.dropdownScaleTransit.PlayForward();
        }

        public void Close()
        {
            this.dropdownAlphaTransit.PlayReverse();
            this.dropdownScaleTransit.PlayReverse();
        }

        public void Select(int item)
        {
            this.selectedItem = item;
            this.selectedLabel.text = this.dropdownOptions[this.selectedItem];
            Close();
        }
    }
}