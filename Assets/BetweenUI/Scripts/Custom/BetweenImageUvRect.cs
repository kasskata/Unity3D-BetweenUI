namespace Assets.BetweenUI.Scripts.Custom
{
    using BetweenUI;
    using UnityEngine;
    using UnityEngine.UI;
 
    /// <summary>
    /// Translate UV rect from UI Raw Image position and size.
    /// </summary>
    [RequireComponent(typeof(RawImage))]
    public class BetweenImageUvRect : BetweenBase
    {
        [Header("Position")]
        public Vector2 positionFrom;
        public Vector2 positionTo;

        [Header("Size")]
        public Vector2 sizeFrom;
        public Vector2 sizeTo;

        private RawImage imageCache;

        public RawImage ImageCache
        {
            get
            {
                if (this.imageCache == null)
                {
                    this.imageCache = this.GetComponent<RawImage>();
                }

                return this.imageCache;
            }
        }

        /// <summary>
        /// Transit the value.
        /// </summary>
        protected override void OnUpdate(float timeFactor)
        {
            this.ImageCache.uvRect = new Rect(
                Vector2.Lerp(this.positionFrom, this.positionTo, timeFactor),
                Vector2.Lerp(this.sizeFrom, this.sizeTo, timeFactor));
        }

        public void Reset()
        {
            this.positionFrom = this.ImageCache.uvRect.position;
            this.positionTo = this.ImageCache.uvRect.position;

            this.sizeFrom = this.ImageCache.uvRect.size;
            this.sizeTo = this.ImageCache.uvRect.size;
        }

        [ContextMenu("Current position for From")]
        public void FromForCurrent()
        {
            this.positionFrom = this.ImageCache.uvRect.position;
            this.sizeFrom = this.ImageCache.uvRect.size;
        }

        [ContextMenu("Current position for To")]
        public void ToForCurrent()
        {
            this.positionTo = this.ImageCache.uvRect.position;
            this.sizeTo = this.ImageCache.uvRect.size;
        }
    }
}
