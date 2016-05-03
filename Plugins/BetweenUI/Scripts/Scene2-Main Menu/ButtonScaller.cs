using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(BetweenScale))]
public class ButtonScaller : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Vector3 Clicked = new Vector3(1.1f, 1.1f, 1f);
    public float Duration = 0.2f;

    public BetweenScale Scaler;

    public void Start()
    {
        if (this.Scaler == null)
        {
            this.Scaler = this.GetComponent<BetweenScale>();
        }

        if (this.Scaler.To != this.Clicked || this.Scaler.Duration != this.Duration)
        {
            this.Scaler.To = this.Clicked;
            this.Scaler.Duration = this.Duration;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        this.Scaler.PlayForward(); 
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        this.Scaler.PlayReverse();
    }
}
