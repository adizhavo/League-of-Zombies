using UnityEngine;
using System.Collections;

public class SkillshotGizmoComponent : MonoBehaviour, Component
{
    #region Component implementation
    public Entity Entity {set; get;}
    #endregion

    public void Init()
    {
        SecondaryTouchInput.OnSecondaryTouch += SkillshotAimPos;
    }

    private void OnDestroy()
    {
        SecondaryTouchInput.OnSecondaryTouch -= SkillshotAimPos;
    }

    private void SkillshotAimPos(Transform touchedTr, Vector3 pointTouched)
    {
        // TODO rotate the gizmo to face the aimed position
    }

    #region Framer implementation
    public void FrameUpdate()
    {
        skillshotPressed = InputConfig.Skillshot();
    }
    #endregion

    private bool skillshotPressed = false;
}
