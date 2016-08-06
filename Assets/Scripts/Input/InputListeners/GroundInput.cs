using UnityEngine;

// Will notify all subscribers that the user has touch a specific position on the ground
public static class GroundInput 
{
    public delegate void GroundTouch(Vector3 groudPos);
    public static event GroundTouch OnGroundTouch;

    public static readonly string terrainTag = "Terrain";

    static GroundInput()
    {
        TouchInput.OnTouch += GroundTouchInput;
    }

    private static void GroundTouchInput(Transform touchedTr, Vector3 pointTouched)
    {
        if (OnGroundTouch != null && touchedTr.CompareTag(terrainTag))
        {
            OnGroundTouch(pointTouched);
        }
    }
}