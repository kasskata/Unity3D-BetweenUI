using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("BetweenUI/Alpha")]
public class BetweenAlpha : BetweenBase
{
    [Range(0f, 1f)]
    public float From = 0f;
    [Range(0f, 1f)]
    public float To = 1f;

    private bool isParent;
    private bool cached;
    private CanvasGroup canvasGroup;
    private Graphic graphic;
    private Color graphicAlpha = Color.white;

    private void Cache()
    {
        this.cached = true;
        if (this.transform.childCount > 0)
        {
            this.isParent = true;

            CanvasGroup canvasGroupFound = this.gameObject.GetComponent<CanvasGroup>();
            if (canvasGroupFound == null)
            {
                Debug.LogWarning(string.Format(MessageNotCreatedComponent, this.name, "CanvasGroup"));
                this.canvasGroup = this.gameObject.AddComponent<CanvasGroup>();
            }
            else
            {
                this.canvasGroup = canvasGroupFound;
            }

            this.canvasGroup.alpha = this.From;
        }
        else
        {
            this.graphic = this.GetComponent<Graphic>();
            this.graphicAlpha = this.graphic.color;
        }
    }

    /// <summary>
    /// Transition's current value.
    /// </summary>
    private float Value
    {
        set
        {
            if (!this.cached)
            {
                Cache();
            }

            if (this.isParent)
            {
                this.canvasGroup.alpha = value;
            }
            else
            {
                this.graphicAlpha.a = value;
                this.graphic.color = this.graphicAlpha;
            }
        }
    }

    /// <summary>
    /// Transit the value.
    /// </summary>
    protected override void OnUpdate(float timeFactor, bool isFinished)
    {
        this.Value = Mathf.Lerp(this.From, this.To, timeFactor);
    }
}
