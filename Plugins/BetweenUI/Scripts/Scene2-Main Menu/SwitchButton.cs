using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Switch button effect like Android/Iphone menu UI
/// </summary>
[AddComponentMenu("BetweenUI/Extra/Switcher")]
public class SwitchButton : MonoBehaviour
{
    /// <summary>
    /// Check whether of the switch.
    /// </summary>
    public bool IsOn;

    /// <summary>
    /// New On state color of the background.
    /// </summary>
    [Header("ON State")]
    public Color32 Background = Color.white;

    /// <summary>
    /// New On state color of the thumb.
    /// </summary>
    public Color32 Thumb = Color.white;

    /// <summary>
    /// BetweenUI background transition.
    /// </summary>
    public BetweenColor BackgroundColorTrans;

    /// <summary>
    /// BetweenUI thumb transition.
    /// </summary>
    public BetweenColor ThumbColorTween;

    /// <summary>
    /// BetweenUI Thumb position transition.
    /// </summary>
    public BetweenPosition PositionThumbTween;


    private void Start()
    {
        //From
        this.BackgroundColorTrans.From = this.BackgroundColorTrans.GetComponent<Graphic>().color;
        this.ThumbColorTween.From = this.ThumbColorTween.GetComponent<Graphic>().color;
        
        //To
        this.BackgroundColorTrans.To = this.Background;
        this.ThumbColorTween.To = this.Thumb;
        
        //Prepare trans positions to be on the half of the button's background width
        float positionX = this.BackgroundColorTrans.GetComponent<RectTransform>().sizeDelta.x / 2;
        this.PositionThumbTween.From.x = -positionX;
        this.PositionThumbTween.To.x = positionX;
    }

    /// <summary>
    /// Switch State On/Off
    /// </summary>
    public void ChangeState()
    {
        if (this.IsOn)
        {
            Off();
        }
        else
        {
            On();
        }
    }

    public void On()
    {
        this.IsOn = true;
        this.BackgroundColorTrans.PlayForward();
        this.ThumbColorTween.PlayForward();
        this.PositionThumbTween.PlayForward();
    }

    public void Off()
    {
        this.IsOn = false;
        this.BackgroundColorTrans.PlayReverse();
        this.ThumbColorTween.PlayReverse();
        this.PositionThumbTween.PlayReverse();
    }
}
