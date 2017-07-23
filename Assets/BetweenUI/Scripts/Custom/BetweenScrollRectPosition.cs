namespace Assets.BetweenUI.Scripts.Custom
{
    using BetweenUI;
    using UnityEngine;
    using UnityEngine.UI;
   
    /// <summary>
    /// Translate position centered in UI ScrollRect content.
    /// </summary>
    [AddComponentMenu("BetweenUI/Between ScrollRect Position")]
    public class BetweenScrollRectPosition : BetweenBase
    {
        [Range(0f, 1f)]
        public float From;
        [Range(0f, 1f)]
        public float To;

        private ScrollRect scrollRect;

        private ScrollRect CachedScrollRect
        {
            get
            {
                if (this.scrollRect == null)
                {
                    this.scrollRect = this.GetComponent<ScrollRect>();
                }

                return this.scrollRect;
            }
        }

        /// <summary>
        /// Transition's current value.
        /// </summary>
        private float Value
        {
            set
            {
                if (this.CachedScrollRect.horizontal)
                {
                    this.CachedScrollRect.horizontalNormalizedPosition = value;
                }
                else if (this.CachedScrollRect.vertical)
                {
                    this.CachedScrollRect.verticalNormalizedPosition = value;
                }
            }
        }

        /// <summary>
        /// Transition the value.
        /// </summary>
        protected override void OnUpdate(float timeFactor)
        {
            this.Value = Mathf.Lerp(this.From, this.To, timeFactor);
        }

        public void Reset()
        {
            ToForCurrent();
            FromForCurrent();
        }

        [ContextMenu("Current position for To")]
        public void ToForCurrent()
        {
            if (this.CachedScrollRect.horizontal)
            {
                this.To = this.CachedScrollRect.horizontalNormalizedPosition;
            }
            else if (this.CachedScrollRect.vertical)
            {
                this.To = this.CachedScrollRect.verticalNormalizedPosition;
            }
        }

        [ContextMenu("Current position for From")]
        public void FromForCurrent()
        {
            if (this.CachedScrollRect.horizontal)
            {
                this.From = this.CachedScrollRect.horizontalNormalizedPosition;
            }
            else if (this.CachedScrollRect.vertical)
            {
                this.From = this.CachedScrollRect.verticalNormalizedPosition;
            }
        }
    }
}
