using UnityEngine;

public class TouchInput : Framer
{
    public delegate void Touch(Transform touchedTr, Vector3 pointTouched);
    public static event Touch OnTouch;

    public virtual void FrameUpdate()
    {
        if (InputConfig.TouchUp())
        {
            // are we clicking a UI object ?

            RaycastHit hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (OnTouch != null)
                    OnTouch(hit.transform, hit.point);
            }
        }
    }
}
