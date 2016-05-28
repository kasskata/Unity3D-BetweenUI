using UnityEngine;

/// <summary>
/// Main script for Scene Two: Main Menu
/// </summary>
public class SceneTwoDemo : MonoBehaviour
{
    public BetweenPosition MainMenuTransit;
    public BetweenPosition CharacterTransit;
    public BetweenAlpha CharacterAlphaTransit;
    public BetweenPosition BottomTransit;
    public BetweenPosition ProfileTransit;

    public void OnCharacterClicked()
    {
        this.MainMenuTransit.PlayReverse();

        OpenCharacterPanel();
    }

    public void OnCharacterDoneClicked()
    {
        this.MainMenuTransit.PlayForward();

        CloseCharacterPanel();
    }

    private void CloseCharacterPanel()
    {
        this.CharacterTransit.PlayReverse();
        this.CharacterAlphaTransit.PlayReverse();
        this.BottomTransit.PlayReverse();
    }

    private void OpenCharacterPanel()
    {
        this.CharacterTransit.PlayForward();
        this.CharacterAlphaTransit.PlayForward();
        this.BottomTransit.PlayForward();
    }

    public void OnProfileClicked()
    {
        this.ProfileTransit.PlayForward();
        this.MainMenuTransit.PlayReverse();
    }

    public void OnProfileDoneClicked()
    {
        this.ProfileTransit.PlayReverse();
        this.MainMenuTransit.PlayForward();
    }

    public void StopColorTransit(BetweenBase transitionObject)
    {
        if (!transitionObject.Active)
        {
            BetweenColor betweenColor = transitionObject.GetComponent<BetweenColor>();
            betweenColor.ResetToBeginning();
        }
    }
}
