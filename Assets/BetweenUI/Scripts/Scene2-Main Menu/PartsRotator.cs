namespace Assets.BetweenUI.Scripts
{
    using UnityEngine;
    using UnityEngine.UI;
    using BetweenUI;

    /// <summary>
    /// Rotate the items for select character part.
    /// </summary>
    public class PartsRotator : MonoBehaviour
    {
        /// <summary>
        /// First object which will transit from one to another container.
        /// </summary>
        public BetweenTransform FirstObjectTween;

        /// <summary>
        /// Second object which will transit from one to another container.
        /// </summary>
        public BetweenTransform SecondObjectTween;

        // Points for rotate.
        public Transform MiddlePoint;
        public Transform StartPoint;
        public Transform EndPoint;

        // Check when first or second item is in the middle right now.
        private bool isFirstInMiddle = true;
        private bool isSecondInMiddle;

        // Images to change the hero appearance.
        private Image firstItemImage;
        private Image secondItemImage;

        /// <summary>
        /// Slower effect for the items when is gone from the scene.
        /// </summary>
        private const float NormalDuration = 0.4f;
        private const float FastDuration = 0.25f;

        public void RotateRight()
        {
            CheckForNullImages();

            if (this.isFirstInMiddle)
            {
                this.secondItemImage.color = GetRandomColor();

                this.isFirstInMiddle = false;
                this.FirstObjectTween.From = this.MiddlePoint;
                this.FirstObjectTween.To = this.EndPoint;
                this.FirstObjectTween.Duration = NormalDuration;
                this.FirstObjectTween.PlayForward();

                this.isSecondInMiddle = true;
                this.SecondObjectTween.From = this.StartPoint;
                this.SecondObjectTween.To = this.MiddlePoint;
                this.SecondObjectTween.Duration = FastDuration;
                this.SecondObjectTween.PlayForward();
            }
            else if (this.isSecondInMiddle)
            {
                this.firstItemImage.color = GetRandomColor();

                this.isFirstInMiddle = true;
                this.FirstObjectTween.To = this.StartPoint;
                this.FirstObjectTween.From = this.MiddlePoint;
                this.FirstObjectTween.Duration = FastDuration;
                this.FirstObjectTween.PlayReverse();

                this.isSecondInMiddle = false;
                this.SecondObjectTween.To = this.MiddlePoint;
                this.SecondObjectTween.From = this.EndPoint;
                this.SecondObjectTween.Duration = NormalDuration;
                this.SecondObjectTween.PlayReverse();
            }
        }

        public void RotateLeft()
        {
            CheckForNullImages();

            if (this.isFirstInMiddle)
            {
                this.secondItemImage.color = GetRandomColor();

                this.isFirstInMiddle = false;
                this.FirstObjectTween.From = this.MiddlePoint;
                this.FirstObjectTween.To = this.StartPoint;
                this.FirstObjectTween.Duration = NormalDuration;
                this.FirstObjectTween.PlayForward();

                this.isSecondInMiddle = true;
                this.SecondObjectTween.From = this.EndPoint;
                this.SecondObjectTween.To = this.MiddlePoint;
                this.SecondObjectTween.Duration = FastDuration;
                this.SecondObjectTween.PlayForward();
            }
            else if (this.isSecondInMiddle)
            {
                this.firstItemImage.color = GetRandomColor();

                this.isFirstInMiddle = true;
                this.FirstObjectTween.To = this.EndPoint;
                this.FirstObjectTween.From = this.MiddlePoint;
                this.FirstObjectTween.Duration = FastDuration;
                this.FirstObjectTween.PlayReverse();

                this.isSecondInMiddle = false;
                this.SecondObjectTween.To = this.MiddlePoint;
                this.SecondObjectTween.From = this.StartPoint;
                this.SecondObjectTween.Duration = NormalDuration;
                this.SecondObjectTween.PlayReverse();
            }
        }

        private void CheckForNullImages()
        {
            if (this.firstItemImage != null)
            {
                return;
            }

            this.firstItemImage = this.FirstObjectTween.GetComponent<Image>();
            this.secondItemImage = this.SecondObjectTween.GetComponent<Image>();
        }

        /// <summary>
        /// Change Color of the item.
        /// </summary>
        /// <returns>randomed color</returns>
        private Color32 GetRandomColor()
        {
            return new Color32(
                (byte)Random.Range(100, 255),
                (byte)Random.Range(100, 255),
                (byte)Random.Range(100, 255),
                255);
        }
    }
}