using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.BetweenUI.Scripts
{
    [
        ExecuteInEditMode,
        RequireComponent(typeof(Button)),
        DisallowMultipleComponent
    ]
    public class ButtonScaler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private static readonly Vector3 TargetScale = new Vector3(1.2f, 1.2f, 1f);
        public Vector3 targetScale = TargetScale;
        public RectTransform targetRect;

        private Vector3 originalScale;

#if UNITY_EDITOR
        public void Start()
        {
            if (this.targetRect == null)
            {
                this.targetRect = this.GetComponent<RectTransform>();
            }
        }
#endif

        public void OnPointerDown(PointerEventData eventData)
        {
            if (this.originalScale == Vector3.zero)
            {
                this.originalScale = this.targetRect.GetComponent<RectTransform>().localScale;
            }

            this.targetRect.localScale = this.targetScale;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            this.targetRect.localScale = this.originalScale;
        }

        public void Reset()
        {
            this.targetScale = TargetScale;
            Debug.Log("Changed to " + this.targetScale);
        }
    }
}