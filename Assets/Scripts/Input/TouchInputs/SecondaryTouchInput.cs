using UnityEngine;

public class SecondaryTouchInput : Framer
{
    public delegate void SecodnaryTouch(Transform touchedTr, Vector3 pointTouched);
    public static event SecodnaryTouch OnSecondaryTouch;

    public virtual void FrameUpdate()
    {
        if (InputConfig.SecondaryTouch())
        {
            // are we clicking a UI object ?

            RaycastHit hit = TouchInputCaster.CastToMousePos();
            if (hit.transform != null && OnSecondaryTouch != null)
            {
                OnSecondaryTouch(hit.transform, hit.point);
            }
        }
    }
}