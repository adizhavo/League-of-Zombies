using UnityEngine;
using System.Collections;

public class SkillshotGizmoComponent
{
    private GameObject graphic;
    public Vector3 aimedPos
    {
        private set;
        get;
    }

    public SkillshotGizmoComponent()
    {
        graphic = null;
    }

    public SkillshotGizmoComponent(GameObject graphic)
    {
        this.graphic = graphic;
    }

    ~SkillshotGizmoComponent()
    {
        graphic = null;
    }

    public void EnableGraphic()
    {
        graphic.SetActive(true);
    }

    public void DisableGraphic()
    {
        graphic.SetActive(false);
    }

    public void CalculateAimPosition(Vector3 containerPos, Vector3 pointTouched, float Range)
    {
        Vector3 direction = (pointTouched - containerPos).normalized;
        Vector3 endPos = containerPos + direction * Range;
        aimedPos = new Vector3(endPos.x, containerPos.y, endPos.z);

        #if UNITY_EDITOR
        Debug.DrawLine(containerPos, aimedPos, Color.yellow);
        #endif

        PositionGraphic(containerPos, Range);
    }

    private void PositionGraphic(Vector3 containerPos, float Range)
    {
        if (graphic == null)
            return;
        graphic.transform.position = containerPos;
        graphic.transform.localScale = Vector3.one * Range;
    }
}