// New BetweenUI Example: You can use BetweenBase class timer fields and create our own transitions elements.
namespace Assets.BetweenUI.Scripts
{
    using UnityEngine;
    using UnityEngine.UI;
    using BetweenUI;

    /// <summary>
    /// Custom sprite transition script to animate array of sprites for given time.
    /// </summary>
    [AddComponentMenu("BetweenUI/Extra/Between Sprites")]
    public class BetweenSprites : BetweenBase
    {
        public Sprite[] Sprites;

        private Image cachedImage;
        private float step;
        private float evaluator;
        private int counter;

        //Usually use Start but in that case need Awake to take Image cached.
        protected void Awake()
        {
            this.cachedImage = this.GetComponent<Image>();
        }

        //You can override Start method in case when want initilize something new.
        protected override void Start()
        {
            ResetToBeginning();
            base.Start();
        }

        //Use OnUpdate method to implement your logic which will do on every update    
        protected override void OnUpdate(float timeFactor)
        {
            if (timeFactor >= this.evaluator && this.counter < this.Sprites.Length)
            {
                this.cachedImage.sprite = this.Sprites[this.counter];
                this.cachedImage.SetNativeSize();

                this.counter += 1;
                this.evaluator += this.step;
            }
        }

        //Can use ResetToBegining method to add variables on reset without repeating code.
        public override void ResetToBeginning()
        {
            this.counter = 0;
            this.step = 1 / (float)this.Sprites.Length;
            this.evaluator = 0;

            //Invoke base class method, because without it the logic will broke
            base.ResetToBeginning();
        }
    }
}
