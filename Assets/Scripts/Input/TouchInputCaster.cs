using UnityEngine;

public static class TouchInputCaster
{
    private static RaycastHit hit = new RaycastHit();
    private readonly static RaycastHit emptyHit = new RaycastHit();

    public static RaycastHit CastToMousePos()
    {
        hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100))
        {
            return hit;
        }

        return emptyHit;
    }
}