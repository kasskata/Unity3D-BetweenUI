namespace Assets.BetweenUI.Scripts.Custom
{
    using UnityEngine;
    using UnityEngine.UI;

    using BetweenUI;

    /// <summary>
    /// Transit the value of a slider.
    /// </summary>
    [AddComponentMenu("BetweenUI/Between Slider")]
    public class BetweenSlider : BetweenBase
    {
        public float From = 0f;
        public float To = 1f;

        private Slider trans;

        private Slider CachedTransform
        {
            get
            {
                if (this.trans == null)
                {
                    this.trans = this.GetComponent<Slider>();
                }

                return this.trans;
            }
        }

        public float Value
        {
            get
            {
                return this.CachedTransform.value;
            }
            set
            {
                this.CachedTransform.value = value;
            }
        }

        /// <summary>
        /// Transit the value.
        /// </summary>
        protected override void OnUpdate(float timeFactor)
        {
            this.Value = this.From * (1f - timeFactor) + this.To * timeFactor;
        }
    }
}
