namespace Assets.BetweenUI.Scripts.Custom
{
    using UnityEngine;

    using BetweenUI;

    [AddComponentMenu("BetweenUI/Between Size")]
    public class BetweenSize : BetweenBase
    {
        public Vector2 From;
        public Vector2 To;

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

        public Vector2 Value
        {
            get
            {
                return this.CachedTransform.sizeDelta;
            }
            set
            {
                this.CachedTransform.sizeDelta = value;
            }
        }

        protected override void OnUpdate(float timeFactor)
        {
            this.Value = this.From * (1f - timeFactor) + this.To * timeFactor;
        }

        public void Reset()
        {
            ToForCurrent();
            FromForCurrent();
        }

        [ContextMenu("Current size for To")]
        public void ToForCurrent()
        {
            this.To = this.CachedTransform.sizeDelta;
        }

        [ContextMenu("Current size for From")]
        public void FromForCurrent()
        {
            this.From = this.CachedTransform.sizeDelta;
        }
    }
}
