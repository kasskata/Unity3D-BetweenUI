using UnityEngine;

/// <summary>
/// Transition position.
/// </summary>
[AddComponentMenu("CTransitions/Position")]
public class BetweenPosition : BetweenBase
{
    public Vector3 From;
    public Vector3 To;

    private RectTransform trans;

    private RectTransform CachedTransform
    {
        get
        {
            if (this.trans == null)
            {
                this.trans = this.GetComponent<RectTransform>();
            }

            return this.trans;
        }
    }

    /// <summary>
    /// Transition's current value.
    /// </summary>
    private Vector3 Value
    {
        set
        {
            this.CachedTransform.anchoredPosition = value;
        }
    }

    /// <summary>
    /// Transition the value.
    /// </summary>
    protected override void OnUpdate(float timeFactor, bool isFinished)
    {
        this.Value = this.From * (1f - timeFactor) + this.To * timeFactor;
    }
}
