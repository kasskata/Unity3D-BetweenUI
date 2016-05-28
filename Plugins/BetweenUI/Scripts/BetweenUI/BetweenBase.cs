using UnityEngine;
using UnityEngine.Events;

public abstract class BetweenBase : MonoBehaviour
{
    /// <summary>
    /// The component's direction now.
    /// </summary>
    public enum DirectionType
    {
        Reverse = -1,
        Toggle = 0,
        Forward = 1
    }

    /// <summary>
    /// Deactivate GameObject which carry that betweenUI component on state of the transition<para></para>
    /// Example: Start means will deactivate object when is in beggin state.
    /// </summary>
    public enum Deactivate
    {
        None,
        Start,
        Finish,
        Both
    }

    /// <summary>
    /// Which Style of the transition will be.<para></para>
    /// Once: only one direction and stops.
    /// PingPong: Go to final and reverse and loop it.
    /// </summary>
    public enum StyleType
    {
        Once,
        PingPong,
    }

    /// <summary>
    /// Message for not created component and created service one. Works on string.Format()<para></para>
    /// 0: Main component
    /// 1: Required component
    /// </summary>
    public const string MessageNotCreatedComponent = "{0} needs {1} but not created. Created service one. To avoid performance penalty, create it from Editor";

    /// <summary>
    /// Style for transition. Can be Once and PingPong effect.
    /// </summary>
    public StyleType Style;

    /// <summary>
    /// Transition will evaluate to animation curve from Inspector.
    /// </summary>
    public bool WantCurve = false;

    /// <summary>
    /// Optional curve to apply to the transition's time factor value.
    /// </summary>
    public AnimationCurve AnimationCurve = AnimationCurve.Linear(0, 0, 1, 1);

    /// <summary>
    /// Duration of the transition
    /// </summary>
    public float Duration = 0.5f;
    
    /// <summary>
    /// State want to deactivate GameObject carries this BetweenUI
    /// </summary>
    public Deactivate DeactivateOn;

    /// <summary>
    /// Check whether when transition is in between From and To state.<para></para> 
    /// When is in ease equal false. When is in play equals true. 
    /// </summary>
    [HideInInspector]
    public bool Started;

    /// <summary>
    /// Check whether when transition is in ease.<para></para> 
    /// When is in ease equal false. When is in play/not beginning equals true. 
    /// </summary>
    [HideInInspector]
    public bool Active;

    /// <summary>
    /// Play all connected events when the transition is finished (Play forward/reverse)
    /// </summary>
    [SerializeField]
    public UnityEvent OnFinish = new UnityEvent();

    private float startTime;
    private float amountPerDelta = 1000f;
    private float factor;
    private float timeFactor;

    /// <summary>
    /// Amount advanced per delta time.
    /// </summary>
    public float AmountPerDelta
    {
        get
        {
            this.amountPerDelta = Mathf.Abs(this.Duration > 0f ? 1f / this.Duration : 1000f) * Mathf.Sign(this.amountPerDelta);
            return this.amountPerDelta;
        }
    }

    /// <summary>
    /// Direction that the transition is currently playing in.
    /// </summary>
    public DirectionType Direction
    {
        get
        {
            return this.AmountPerDelta < 0f ? DirectionType.Reverse : DirectionType.Forward;
        }
    }

    /// <summary>
    /// Sample the transition at the specified factor.
    /// </summary>
    public void RowEvaluate(float specFactor, bool isFinished)
    {
        // Calculate the sampling value
        this.timeFactor = Mathf.Clamp01(specFactor);

        // Call the virtual update
        if (this.WantCurve)
        {
            OnUpdate(this.AnimationCurve.Evaluate(this.timeFactor), isFinished);
        }
        else
        {
            OnUpdate(this.timeFactor, isFinished);
        }
    }

    /// <summary>
    /// Transition forward.
    /// </summary>
    public void PlayForward()
    {
        Play(true);
    }

    /// <summary>
    /// Transition reverse.
    /// </summary>
    public void PlayReverse()
    {
        Play(false);
    }

    /// <summary>
    /// Manually activate the transition process, reversing it if necessary.
    /// </summary>
    public void Play(bool isForward)
    {
        if (this.DeactivateOn != Deactivate.None && !this.gameObject.activeSelf)
        {
            this.gameObject.SetActive(true);
        }

        this.amountPerDelta = Mathf.Abs(this.AmountPerDelta);
        if (!isForward)
        {
            this.amountPerDelta = -this.amountPerDelta;
        }

        this.enabled = true;
        Update();
    }

    /// <summary>
    /// Manually reset the transition's state to the beginning.
    /// If the transition is playing forward, this means the transition's start.
    /// If the transition is playing in reverse, this means the transition's end.
    /// </summary>
    public virtual void ResetToBeginning()
    {
        this.Started = false;
        this.factor = this.AmountPerDelta < 0f ? 1f : 0f;
        RowEvaluate(this.factor, false);
    }

    /// <summary>
    /// Manually start the transition process, reversing its direction.
    /// </summary>
    public void Toggle()
    {
        if (this.factor > 0f)
        {
            this.amountPerDelta = -this.AmountPerDelta;
        }
        else
        {
            this.amountPerDelta = Mathf.Abs(this.AmountPerDelta);
        }

        this.enabled = true;
    }

    /// <summary>
    /// Core method which determined behaviour of the transition component
    /// </summary>
    /// <param name="timeFactor"></param>
    /// <param name="isFinished"></param>
    protected abstract void OnUpdate(float timeFactor, bool isFinished);

    ///<summary>
    /// Update as soon as it's started so that there is no delay.
    /// </summary>
    protected virtual void Start()
    {
        Update();
    }

    /// <summary>
    /// Update the transition factor and call the virtual update function.
    /// </summary>
    protected void Update()
    {
        float delta = Time.deltaTime;
        float time = Time.time;

        if (!this.Started)
        {
            this.Started = true;
            this.startTime = time;
        }

        if (time < this.startTime)
        {
            return;
        }

        // Advance the sampling factor
        this.factor += this.AmountPerDelta * delta;
        this.Active = this.factor > 0f;

        if (this.Style == StyleType.PingPong)
        {
            // Ping-pong style reverses the direction
            if (this.factor > 1f)
            {
                this.factor = 1f - (this.factor - Mathf.Floor(this.factor));
                this.amountPerDelta = -this.amountPerDelta;
            }
            else if (this.factor < 0f)
            {
                this.factor = -this.factor;
                this.factor -= Mathf.Floor(this.factor);
                this.amountPerDelta = -this.amountPerDelta;
            }
        }

        // If the factor goes out of range and this is a one-time transition, disable the script
        if ((this.Style == StyleType.Once) && (this.Duration.Equals(0f) || this.factor > 1f || this.factor < 0f))
        {
            this.factor = Mathf.Clamp01(this.factor);
            RowEvaluate(this.factor, true);
            this.enabled = false;
            this.OnFinish.Invoke();
            DeactivateByChoise();
        }
        else
        {
            RowEvaluate(this.factor, false);
        }
    }

    private void DeactivateByChoise()
    {
        GameObject obj = this.gameObject;
        switch (this.DeactivateOn)
        {
            case Deactivate.None:
                break;
            case Deactivate.Start:
                if (this.Active == false)
                {
                    obj.SetActive(false);
                }
                break;
            case Deactivate.Finish:
                if (this.Active == true)
                {
                    obj.SetActive(false);
                }
                break;
            case Deactivate.Both:
                obj.SetActive(false);
                break;
        }
    }
}