namespace Assets.BetweenUI.Scripts.Custom
{
    using BetweenUI;
    using UnityEngine;

    /// <summary>
    /// Transition position.
    /// </summary>
    [AddComponentMenu("BetweenUI/Between Global Position")]
    public class BetweenGlobalPosition : BetweenBase
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

        private RectTransform recTtrans;

        private RectTransform RectCachedTransform
        {
            get
            {
                if (this.recTtrans == null)
                {
                    this.recTtrans = GetComponent<RectTransform>();
                }

                return this.recTtrans;
            }
        }

        /// <summary>
        /// Transition's current value.
        /// </summary>
        private Vector3 Value
        {
            set
            {
                this.CachedTransform.position = new Vector3(value.x, value.y, 0f);
                this.RectCachedTransform.anchoredPosition3D = new Vector3(this.RectCachedTransform.anchoredPosition3D.x, this.RectCachedTransform.anchoredPosition3D.y, 0f);

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