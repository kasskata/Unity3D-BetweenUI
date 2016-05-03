using UnityEngine;
using UnityEngine.UI;

public class SwitchButton : MonoBehaviour
{
    public bool isOn;

    [Header("ON State")]
    public Color32 Background = Color.white;
    public Color32 Thumb = Color.white;

    public BetweenColor thumbColorTrans;
    public BetweenColor backgroundColorTrans;
    public BetweenPosition positionThumbTween;


    private void Start()
    {
        //From
        this.backgroundColorTrans.From = this.backgroundColorTrans.GetComponent<Graphic>().color;
        this.thumbColorTrans.From = this.thumbColorTrans.GetComponent<Graphic>().color;
        //To
        this.backgroundColorTrans.To = this.Background;
        this.thumbColorTrans.To = this.Thumb;
        //Prepare trans positions to be on the half of the button's background width
        float positionX = this.backgroundColorTrans.GetComponent<RectTransform>().sizeDelta.x / 2;
        this.positionThumbTween.From.x = -positionX;
        this.positionThumbTween.To.x = positionX;
    }

    public void ChangeState()
    {
        if (this.isOn)
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
        this.isOn = true;
        this.backgroundColorTrans.PlayForward();
        this.thumbColorTrans.PlayForward();
        this.positionThumbTween.PlayForward();
    }

    public void Off()
    {
        this.isOn = false;
        this.backgroundColorTrans.PlayReverse();
        this.thumbColorTrans.PlayReverse();
        this.positionThumbTween.PlayReverse();
    }
}
