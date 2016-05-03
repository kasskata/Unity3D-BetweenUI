using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Transition graphic color.
/// </summary>
[RequireComponent(typeof(Graphic))]
[AddComponentMenu("BetweenUI/BetweenColor")]
public class BetweenColor : BetweenBase
{
    public Color From = Color.white;
    public Color To = Color.white;

    private Graphic graphic;

    /// <summary>
    /// Transit's current value.
    /// </summary>

    public Color Value
    {
        get
        {
            if (this.graphic == null)
            {
                this.graphic = this.GetComponent<Graphic>();
            }

            return this.graphic.color;
        }
        set
        {
            if (this.graphic == null)
            {
                this.graphic = this.GetComponent<Graphic>();
            }

            this.graphic.color = value;
        }
    }

    /// <summary>
    /// Transition the value.
    /// </summary>

    protected override void OnUpdate(float factor, bool isFinished)
    {
        this.Value = Color.Lerp(this.From, this.To, factor);
    }
}
