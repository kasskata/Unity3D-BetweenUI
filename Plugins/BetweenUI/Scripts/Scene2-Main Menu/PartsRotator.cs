using UnityEngine;
using UnityEngine.UI;

public class PartsRotator : MonoBehaviour
{
    public BetweenTransform FirstObjectTween;
    public BetweenTransform SecondObjectTween;

    public Transform MiddlePoint;
    public Transform StartPoint;
    public Transform EndPoint;

    private bool isFirstInMiddle = true;
    private bool isSecondInMiddle;

    private Image firstItemImage;
    private Image secondItemImage;
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

    private Color32 GetRandomColor()
    {
        return new Color32(
            (byte) Random.Range(100, 255),
            (byte) Random.Range(100, 255),
            (byte) Random.Range(100, 255),
            255);
    }
}