using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Use to scale buttons on click it. More performance way to play that animation. Required Between Scale.
/// </summary>

[AddComponentMenu("BetweenUI/Extra/Button Scaller")]
[RequireComponent(typeof(Button), typeof(BetweenScale))]
public class ButtonScaler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    /// <summary>
    /// Scale Vector this item when is clicked.
    /// </summary>
    public Vector3 ClickedScale = new Vector3(1.1f, 1.1f, 1f);

    /// <summary>
    /// Duration of time for that transition.
    /// </summary>
    public float Duration = 0.2f;
    public BetweenScale Scaler;

    public void Start()
    {
        if (this.Scaler == null)
        {
            this.Scaler = this.GetComponent<BetweenScale>();
        }

        if (this.Scaler.To != this.ClickedScale || this.Scaler.Duration != this.Duration)
        {
            this.Scaler.To = this.ClickedScale;
            this.Scaler.Duration = this.Duration;
        }
    }

    /// <summary>
    /// Event when pointer/touch is down.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        this.Scaler.PlayForward(); 
    }

    /// <summary>
    /// Event when pointer/touch is up.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerUp(PointerEventData eventData)
    {
        this.Scaler.PlayReverse();
    }
}
