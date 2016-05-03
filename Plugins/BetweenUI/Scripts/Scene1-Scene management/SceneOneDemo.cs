using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneOneDemo : MonoBehaviour
{
    private static readonly Color WhiteWithoutAlpha = new Color32(255, 225, 255, 0);

    public BetweenSprites HedgehogTransit;
    public BetweenSprites SquirelTransit;
    public BetweenColor SecondScreenTransit;
    public BetweenAlpha ColoredTitleTransit;
    public BetweenRotation ColoredTitleRotationTransit;

    //For easier track of the componnent link it all here
    public BetweenScale StratoTransit;
    public BetweenPosition CloudLeftTransit;
    public BetweenPosition CloudRightTransit;
    public BetweenScale SeaTransit;
    public BetweenPosition IslandTransit;
    public BetweenRotation RingTransit;
    public BetweenPosition StartTransit;

    public BetweenAlpha SplashScreen;
    public GameObject LoadingBackground;

    private int loopHedgehogCounter;

    public void OnHedgehogLoopEnter()
    {
        if (this.HedgehogTransit.Sprites.Length > 3)
        {
            this.HedgehogTransit.Sprites = new[]
            {
            this.HedgehogTransit.Sprites[this.HedgehogTransit.Sprites.Length-1],
            this.HedgehogTransit.Sprites[this.HedgehogTransit.Sprites.Length-2],
            this.HedgehogTransit.Sprites[this.HedgehogTransit.Sprites.Length-3]
            };
        }

        this.HedgehogTransit.Duration = 1.2f;
        this.HedgehogTransit.ResetToBeginning();
        this.HedgehogTransit.PlayForward();

        this.loopHedgehogCounter += 1;

        if (this.loopHedgehogCounter == 5)
        {
            this.SecondScreenTransit.PlayForward();
        }
    }

    public void OnSecondScreenFinish()
    {
        //Example how easy change the values of the From/To variables.
        //On reverse transition just change dinamically colors.
        this.SecondScreenTransit.From = WhiteWithoutAlpha;
        this.SecondScreenTransit.PlayReverse();

        this.ColoredTitleTransit.PlayForward();
        this.StratoTransit.PlayForward();
        this.CloudLeftTransit.PlayForward();
        this.CloudRightTransit.PlayForward();
        this.SeaTransit.PlayForward();
        this.IslandTransit.PlayForward();
        this.RingTransit.PlayForward();
        this.StartTransit.PlayForward();

        //When OnFinish method from secondScreenTransit finish need to destroy or stop(better performance) the method.
        //UnityEvent the base class for triggers and is build in class from UnityEngine. 
        this.SecondScreenTransit.OnFinish.SetPersistentListenerState(0, UnityEventCallState.Off);

    }

    public void RandomRotateTitle()
    {
        Vector2 newRotation = new Vector2(
                Random.Range(-20f, 20f),
                Random.Range(-20f, 20f)
                );

        //Use Active property to take where is the transition. When is Active means its not of the begininning
        if (this.ColoredTitleRotationTransit.Active)
        {
            this.ColoredTitleRotationTransit.From = newRotation;
        }
        else
        {
            this.ColoredTitleRotationTransit.To = newRotation;
        }

        this.ColoredTitleRotationTransit.Play(!this.ColoredTitleRotationTransit.Active);
    }

    public void OnTapToPlayClicked()
    {
        this.SplashScreen.PlayReverse();
        this.LoadingBackground.SetActive(true);
    }

    public void GoToMenuScene()
    {
        SceneManager.LoadSceneAsync("Scene2-MainMenu");
    }
}
