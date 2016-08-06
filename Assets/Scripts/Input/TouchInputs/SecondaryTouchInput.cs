using UnityEngine;

// triggers secondary input such as skillshot
public class SecondaryTouchInput : Framer
{
    public delegate void SecondaryTouchDown(Transform touchedTr, Vector3 pointTouched);
    public static event SecondaryTouchDown OnSecondaryTouchDown;

    public delegate void SecondaryTouch(Transform touchedTr, Vector3 pointTouched);
    public static event SecondaryTouch OnSecondaryTouch;

    private LayerMask secondaryLayerMask;

    public SecondaryTouchInput(LayerMask secondaryLayerMask)
    {
        this.secondaryLayerMask = secondaryLayerMask;
    }

    public virtual void FrameUpdate()
    {
        if (InputConfig.Skillshot())
        {
            RaycastHit hit = TouchInputCaster.CastToMousePos(secondaryLayerMask);

            NotifySecondaryFrameTouchPos(hit);
            NotifySecondaryTouchDownPos(hit);
        }
    }

    // Each frame
    private static void NotifySecondaryFrameTouchPos(RaycastHit hit)
    {
        if (hit.transform != null && OnSecondaryTouch != null)
        {
            OnSecondaryTouch(hit.transform, hit.point);
        }
    }

    // if the secondary key is pressed
    private static void NotifySecondaryTouchDownPos(RaycastHit hit)
    {
        if (hit.transform != null && InputConfig.SecondaryTouchDown() && OnSecondaryTouchDown != null)
        {
            OnSecondaryTouchDown(hit.transform, hit.point);
        }
    }
}