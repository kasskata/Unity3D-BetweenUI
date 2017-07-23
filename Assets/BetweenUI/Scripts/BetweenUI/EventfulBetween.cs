namespace Assets.BetweenUI.Scripts.BetweenUI
{
    using System;
    using UnityEngine;
    using UnityEngine.Events;

    [ExecuteInEditMode]
    public class EventfulBetween : MonoBehaviour
    {
        private enum BetweenType
        {
            ManualSet,
            BetweenAlpha,
            BetweenColor,
            BetweenLocalPosition,
            BetweenPosition,
            BetweenRotation,
            BetweenScale,
            BetweenSprites,
            BetweenTransform,
        }

        [SerializeField]
        private BetweenType betweenType;

        [SerializeField]
        private BetweenBase wrappedBetween;

        public UnityEvent OnFinishForward;

        public UnityEvent OnFinishReverse;

        public BetweenBase WrappedBetween
        {
            get { return this.wrappedBetween; }
            set { this.wrappedBetween = value; }
        }

#if UNITY_EDITOR
        private void Update()
        {
            if (this.betweenType == BetweenType.ManualSet)
            {
                return;
            }

            // If there is no wrapped between or the one set is not of the type required, try to find the proper one.
            if ((this.wrappedBetween == null) || (this.wrappedBetween.GetType() != this.GetBetweenType(this.betweenType)))
            {
                Type type = this.GetBetweenType(this.betweenType);
                this.wrappedBetween = this.GetComponent(type) as BetweenBase;

                // If the proper one is not available on the object, try to add it as a new component.
                if (this.wrappedBetween == null)
                {
                    this.wrappedBetween = this.gameObject.AddComponent(type) as BetweenBase;
                }
            }
        }
#endif

        public void Toggle()
        {
            this.wrappedBetween.Toggle();
        }

        public void Play(bool isForward)
        {
            this.wrappedBetween.Play(isForward);
        }

        public void PlayForward()
        {
            this.wrappedBetween.OnFinish.AddListener(this.InvokeOnFinishForward);
            this.wrappedBetween.PlayForward();
        }

        public void PlayReverse()
        {
            this.wrappedBetween.OnFinish.AddListener(this.InvokeOnFinishReverse);
            this.wrappedBetween.PlayReverse();
        }

        private void InvokeOnFinishForward()
        {
            if (this.OnFinishForward != null)
            {
                this.OnFinishForward.Invoke();
            }

            this.wrappedBetween.OnFinish.RemoveListener(this.InvokeOnFinishForward);
        }

        private void InvokeOnFinishReverse()
        {
            if (this.OnFinishReverse != null)
            {
                this.OnFinishReverse.Invoke();
            }

            this.wrappedBetween.OnFinish.RemoveListener(this.InvokeOnFinishReverse);
        }

        private Type GetBetweenType(BetweenType type)
        {
            switch (type)
            {
                case BetweenType.BetweenAlpha:
                    return typeof(BetweenAlpha);
                case BetweenType.BetweenColor:
                    return typeof(BetweenColor);
                case BetweenType.BetweenLocalPosition:
                    return typeof(BetweenLocalPosition);
                case BetweenType.BetweenPosition:
                    return typeof(BetweenPosition);
                case BetweenType.BetweenRotation:
                    return typeof(BetweenRotation);
                case BetweenType.BetweenScale:
                    return typeof(BetweenScale);
                case BetweenType.BetweenSprites:
                    return typeof(BetweenSprites);
                case BetweenType.BetweenTransform:
                    return typeof(BetweenTransform);

                default:
                    throw new ArgumentOutOfRangeException("type", type, null);
            }
        }
    }
}