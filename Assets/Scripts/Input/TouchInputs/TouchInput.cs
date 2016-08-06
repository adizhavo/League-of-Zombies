using UnityEngine;

public class TouchInput : Framer
{
    public delegate void Touch(Transform touchedTr, Vector3 pointTouched);
    public static event Touch OnTouch;

    private LayerMask PrimaryTouchLayer;

    public TouchInput(LayerMask PrimaryTouchLayer)
    {
        this.PrimaryTouchLayer = PrimaryTouchLayer;
    }

    public virtual void FrameUpdate()
    {
        if (InputConfig.TouchUp())
        {
            // are we clicking a UI object ?

            RaycastHit hit = TouchInputCaster.CastToMousePos(PrimaryTouchLayer);
            if (hit.transform != null && OnTouch != null)
            {
                OnTouch(hit.transform, hit.point);
            }
        }
    }
}