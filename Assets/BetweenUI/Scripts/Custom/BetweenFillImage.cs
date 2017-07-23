namespace Assets.BetweenUI.Scripts.Custom
{
    using BetweenUI;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary
    /// Transition from 0 to 1 in fill image mode on UI sprite image
    /// </summary>
    [RequireComponent(typeof(Image))]
    public class BetweenFillImage : BetweenBase
    {
        public Image image;

        public Image Image
        {
            get
            {
                if (this.image == null)
                {
                    this.image = this.GetComponent<Image>();
                }

                return this.image;
            }
        }

        protected override void OnUpdate(float timeFactor)
        {
            this.image.fillAmount = timeFactor;
        }
    }
}
