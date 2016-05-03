using UnityEngine;

public class SceneTwoDemo : MonoBehaviour
{
    public BetweenPosition mainMenuTransit;
    public BetweenPosition characterTransit;
    public BetweenAlpha characterAlphaTransit;
    public BetweenPosition bottomTransit;
    public BetweenPosition protfileTransit;

    public void OnCharacterClicked()
    {
        this.mainMenuTransit.PlayReverse();

        OpenCharacterPanel();
    }

    public void OnCharacterDoneClicked()
    {
        this.mainMenuTransit.PlayForward();

        CloseCharacterPanel();
    }

    private void CloseCharacterPanel()
    {
        this.characterTransit.PlayReverse();
        this.characterAlphaTransit.PlayReverse();
        this.bottomTransit.PlayReverse();
    }

    private void OpenCharacterPanel()
    {
        this.characterTransit.PlayForward();
        this.characterAlphaTransit.PlayForward();
        this.bottomTransit.PlayForward();
    }

    public void OnProfileClicked()
    {
        this.protfileTransit.PlayForward();
        this.mainMenuTransit.PlayReverse();
    }

    public void OnProfileDoneClicked()
    {
        this.protfileTransit.PlayReverse();
        this.mainMenuTransit.PlayForward();
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
