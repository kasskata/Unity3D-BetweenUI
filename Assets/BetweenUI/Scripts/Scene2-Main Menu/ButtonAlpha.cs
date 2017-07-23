namespace Assets.BetweenUI.Scripts
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using BetweenUI;

    /// <summary>
    /// Use to alpha buttons on click it. More performance way to play that animation. Required Between Alpha.
    /// </summary>

    [AddComponentMenu("BetweenUI/Extra/Button Alpha")]
    [RequireComponent(typeof(BetweenAlpha))]
    public class ButtonAlpha : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {

        public BetweenAlpha Button;

        public void Start()
        {
            if (this.Button == null)
            {
                this.Button = this.GetComponent<BetweenAlpha>();
            }
        }

        /// <summary>
        /// Event when pointer/touch is down.
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerDown(PointerEventData eventData)
        {
            this.Button.PlayForward();
        }

        /// <summary>
        /// Event when pointer/touch is up.
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerUp(PointerEventData eventData)
        {
            this.Button.PlayReverse();
        }
    }
}