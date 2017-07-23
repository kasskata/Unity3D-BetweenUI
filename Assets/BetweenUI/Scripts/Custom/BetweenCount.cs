namespace Assets.BetweenUI.Scripts.Custom
{
    using BetweenUI;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Translate text number from some value to end value. 
    /// </summary>
    [AddComponentMenu("BetweenUI/Between Count")]
    public class BetweenCount : BetweenBase
    {
        public int From = 0;
        public int To = 10;

        private Text trans;

        private int value;

        private Text CachedText
        {
            get
            {
                if (this.trans == null)
                {
                    this.trans = this.GetComponent<Text>();
                }

                return this.trans;
            }
        }

        public int Value
        {
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    this.CachedText.text = value.ToString();
                }
            }
        }

        /// <summary>
        /// Transit the value.
        /// </summary>
        protected override void OnUpdate(float timeFactor)
        {
            this.Value = Mathf.RoundToInt(this.From * (1f - timeFactor) + this.To * timeFactor);
        }
    }
}
