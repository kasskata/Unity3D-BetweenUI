using UnityEngine;
using UnityEngine.UI;

public class Dropdown : MonoBehaviour
{
    /// <summary>
    /// Scale the options menu.
    /// </summary>
    public BetweenScale DropdownScaleTransit;
    
    /// <summary>
    /// Dropdown alpha element.
    /// </summary>
    public BetweenAlpha DropdownAlphaTransit;

    /// <summary>
    /// Current selected option from dropdowsn menu.
    /// </summary>
    public Text SelectedOption;

    /// <summary>
    /// Selected item from dropdown.
    /// </summary>
    public int SelectedItem;

    /// <summary>
    /// Cached dropdown options.
    /// </summary>
    public string[] DropdownOptions;

    public void Start()
    {
        Transform parentDropdown = this.DropdownAlphaTransit.transform;
        this.DropdownOptions = new string[parentDropdown.childCount];

        Transform child;
        for (int i = 0; i < parentDropdown.childCount; i++)
        {
            child = parentDropdown.GetChild(i);
            this.DropdownOptions[i] = child.GetComponent<Text>().text;
            Button button = child.GetComponent<Button>() ?? child.gameObject.AddComponent<Button>();
            int index = i;
            button.onClick.AddListener(() => Select(index));
        }
    }

    /// <summary>
    /// Switch options container from the menu.
    /// </summary>
    public void Switch()
    {
        if (!this.DropdownAlphaTransit.Active)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    /// <summary>
    /// Open options container.
    /// </summary>
    public void Open()
    {
        this.DropdownAlphaTransit.PlayForward();
        this.DropdownScaleTransit.PlayForward();
    }

    /// <summary>
    /// Close options container.
    /// </summary>
    public void Close()
    {
        this.DropdownAlphaTransit.PlayReverse();
        this.DropdownScaleTransit.PlayReverse();
    }

    /// <summary>
    /// Select new Option
    /// </summary>
    /// <param name="item">The new option index.</param>
    public void Select(int item)
    {
        this.SelectedItem = item;
        this.SelectedOption.text = this.DropdownOptions[this.SelectedItem];
        Close();
    }
}
