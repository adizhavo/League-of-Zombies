using UnityEngine;
using System.Collections;

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

    public static bool CastSpell()
    {
        return false;
    }

    #endif
}