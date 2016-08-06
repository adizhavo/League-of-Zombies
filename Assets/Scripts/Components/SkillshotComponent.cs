using UnityEngine;
using System.Collections;

public class SkillshotComponent : AttackSystem
{
    #region Component implementation
    public Entity Entity {set; get;}
    #endregion

    #region AttackSystem implementation
    public float Damage {set; get;}
    public float Range {set; get;}
    public float ReloadTime {set; get;}
    #endregion
    // TODO : will communicate with mana component
    public float ManaCost {set; get;}

    public bool CanCast 
    {
        private set;
        get;
    }
    public float CurrentReloadTimer
    {
        private set;
        get;
    }

    // indicator will calculate the amed position and position graphcis
    public SkillshotGizmoComponent gizmoIndicator;

    public SkillshotComponent(float Damage, float Range, float ReloadTime, float ManaCost, GameObject Graphic)
    {
        SecondaryTouchInput.OnSecondaryTouchDown += SkillshotTouch;
        SecondaryTouchInput.OnSecondaryTouch += CalculateTarget;

        this.Damage = Damage;
        this.Range = Range;
        this.ReloadTime = ReloadTime;
        this.ManaCost = ManaCost;
        gizmoIndicator = new SkillshotGizmoComponent(Graphic);

        CanCast = false;
    }

    public SkillshotComponent()
    {
        SecondaryTouchInput.OnSecondaryTouchDown += SkillshotTouch;
        SecondaryTouchInput.OnSecondaryTouch += CalculateTarget;
        
        this.Damage = 1;
        this.Range = 1;
        this.ReloadTime = 1;
        this.ManaCost = 1;
        gizmoIndicator = new SkillshotGizmoComponent();

        CanCast = false;
    }

    ~SkillshotComponent()
    {
        SecondaryTouchInput.OnSecondaryTouchDown -= SkillshotTouch;
        SecondaryTouchInput.OnSecondaryTouch -= CalculateTarget;

        gizmoIndicator = null;
        CanCast = false;
    }

    // Theow the shot at the aimed direction
    private void SkillshotTouch(Transform touchedTr, Vector3 touchedPos)
    {
        if (CanCast && CurrentReloadTimer > ReloadTime)
        {
            // TODO : Cast skillshot and reduce mana
            Debug.Log("Cast");
            CurrentReloadTimer = 0f;
        }
    }

    private void CalculateTarget(Transform touchedTr, Vector3 touchedPos)
    {
        gizmoIndicator.CalculateAimPosition(Entity.container.position, touchedPos, Range);
    }

    private void UpdateGraphics()
    {
        if (CanCast)
            gizmoIndicator.EnableGraphic();
        else
            gizmoIndicator.DisableGraphic();
    }

    #region Framer implementation
    public void FrameUpdate()
    {
        CanCast = InputConfig.Skillshot();
        CurrentReloadTimer += Time.deltaTime;
        UpdateGraphics();
    }
    #endregion
}