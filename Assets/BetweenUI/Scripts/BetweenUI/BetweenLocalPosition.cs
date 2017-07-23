using UnityEngine;

namespace Assets.BetweenUI.Scripts.BetweenUI
{
    /// <summary>
    /// Transition position.
    /// </summary>
    [AddComponentMenu("BetweenUI/Between Local Position")]
    public class BetweenLocalPosition : BetweenBase
    {
        public Vector3 From;
        public Vector3 To;

        private Transform trans;

        private Transform CachedTransform
        {
            get
            {
                if (this.trans == null)
                {
                    this.trans = this.transform;
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
                this.CachedTransform.localPosition = value;
            }
        }

        /// <summary>
        /// Transition the value.
        /// </summary>
        protected override void OnUpdate(float timeFactor)
        {
            this.Value = this.From * (1f - timeFactor) + this.To * timeFactor;
        }
    }
}