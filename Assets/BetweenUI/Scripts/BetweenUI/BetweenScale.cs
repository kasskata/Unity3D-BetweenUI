namespace Assets.BetweenUI.Scripts.BetweenUI
{
    using UnityEngine;

    /// <summary>
    /// Transit the object's local scale.
    /// </summary>
    [AddComponentMenu("BetweenUI/Between Scale")]
    public class BetweenScale : BetweenBase
    {
        public Vector3 From = Vector3.one;
        public Vector3 To = Vector3.one;

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

        public Vector3 Value
        {
            get
            {
                return this.CachedTransform.localScale;
            }
            set
            {
                this.CachedTransform.localScale = value;
            }
        }

        /// <summary>
        /// Transit the value.
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

        [ContextMenu("Current Scale for To")]
        public void ToForCurrent()
        {
            this.To = this.transform.localScale;
        }

        [ContextMenu("Current Scale for From")]
        public void FromForCurrent()
        {
            this.From = this.transform.localScale;
        }
    }
}
