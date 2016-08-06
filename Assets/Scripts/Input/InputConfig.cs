using UnityEngine;
// responsible for every input in the game
// can be reconfigured fpr different platforms
public static class InputConfig
{
    #if UNITY_EDITOR

    public static bool TouchDown()
    {
        return Input.GetMouseButtonDown(0);
    }

    public static bool TouchUp()
    {
        return Input.GetMouseButtonUp(0);
    }

    public static bool TouchDrag()
    {
        return Input.GetMouseButton(0);
    }

    public static bool SecondaryTouchDown()
    {
        return Input.GetMouseButtonDown(1);
    }

    public static bool SecondaryTouch()
    {
        return Input.GetMouseButton(1);
    }

    public static bool Skillshot()
    {
        return Input.GetKey(KeyCode.Space);
    }

    #endif
}