using UnityEngine;

/// <summary>
/// Transit the object's position, rotation and scale.
/// </summary>
[AddComponentMenu("BetweenUI/Transform")]
public class BetweenTransform : BetweenBase
{
    public Transform From;
    public Transform To;

    /// <summary>
    /// Check weather want to free position from transitions calculation. Improve performance
    /// </summary>
    /// 
    [Tooltip("Unlock when DON'T need it. Improve performance")]
    public bool UnlockPos = false;

    /// <summary>
    /// Check weather want to free rotation from transitions calculation. Improve performance
    /// </summary>
    /// 
    [Tooltip("Unlock when DON'T need it. Improve performance")]
    public bool UnlockRot = true;

    /// <summary>
    /// Check weather want to free scale from transitions calculation. Improve performance
    /// </summary>
    [Tooltip("Unlock when DON'T need it. Improve performance")]
    public bool UnlockScl = true;

    private Transform objectTransform;
    private Vector3 position;
    private Quaternion rotation;
    private Vector3 scale;

    /// <summary>
    /// Interpolate the position, scale, and rotation.
    /// </summary>
    protected override void OnUpdate(float timeFactor, bool isFinished)
    {
        if (this.To != null)
        {
            if (this.objectTransform == null)
            {
                this.objectTransform = this.transform;
                this.position = this.objectTransform.position;
                this.rotation = this.objectTransform.rotation;
                this.scale = this.objectTransform.localScale;
            }

            if (this.From != null)
            {
                if (!this.UnlockPos)
                {
                    this.objectTransform.position = this.From.position * (1f - timeFactor) + this.To.position * timeFactor;
                }

                if (!this.UnlockRot)
                {
                    this.objectTransform.rotation = Quaternion.Slerp(this.From.rotation, this.To.rotation, timeFactor);
                }

                if (!this.UnlockScl)
                {
                    this.objectTransform.localScale = this.From.localScale * (1f - timeFactor) + this.To.localScale * timeFactor;
                }
            }
            else
            {
                if (!this.UnlockPos)
                {
                    this.objectTransform.position = this.position * (1f - timeFactor) + this.To.position * timeFactor;
                }

                if (!this.UnlockRot)
                {
                    this.objectTransform.rotation = Quaternion.Slerp(this.rotation, this.To.rotation, timeFactor);
                }

                if (!this.UnlockScl)
                {
                    this.objectTransform.localScale = this.scale * (1f - timeFactor) + this.To.localScale * timeFactor;
                }
            }
        }
    }
}
