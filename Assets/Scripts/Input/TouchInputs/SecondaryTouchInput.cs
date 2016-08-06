using UnityEngine;

public class SecondaryTouchInput : Framer
{
    public delegate void SecondaryTouchDown(Transform touchedTr, Vector3 pointTouched);
    public static event SecondaryTouchDown OnSecondaryTouchDown;

    public delegate void SecondaryTouch(Transform touchedTr, Vector3 pointTouched);
    public static event SecondaryTouch OnSecondaryTouch;

    public virtual void FrameUpdate()
    {
        if (InputConfig.Skillshot())
        {
            RaycastHit hit = TouchInputCaster.CastToMousePos();

            NotifySecondaryTouchPos(hit);
            NotifySecondaryTouchDownPos(hit);
        }
    }

    private static void NotifySecondaryTouchPos(RaycastHit hit)
    {
        if (hit.transform != null && OnSecondaryTouch != null)
        {
            OnSecondaryTouch(hit.transform, hit.point);
        }
    }

    private static void NotifySecondaryTouchDownPos(RaycastHit hit)
    {
        if (hit.transform != null && InputConfig.SecondaryTouchDown() && OnSecondaryTouchDown != null)
        {
            OnSecondaryTouchDown(hit.transform, hit.point);
        }
    }
}