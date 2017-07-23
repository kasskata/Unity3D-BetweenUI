namespace Assets.BetweenUI.Scripts.BetweenUI
{
    using UnityEngine;

    /// <summary>
    /// Transition position.
    /// </summary>
    [AddComponentMenu("BetweenUI/Between Position")]
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
        protected override void OnUpdate(float timeFactor)
        {
            this.Value = this.From * (1f - timeFactor) + this.To * timeFactor;
        }

        public void Reset()
        {
            ToForCurrent();
            FromForCurrent();
        }

        [ContextMenu("Current position for From")]
        public void FromForCurrent()
        {
            this.From = this.CachedTransform.anchoredPosition;
        }

        [ContextMenu("Current position for To")]
        public void ToForCurrent()
        {
            this.To = this.CachedTransform.anchoredPosition;
        }
    }
}
