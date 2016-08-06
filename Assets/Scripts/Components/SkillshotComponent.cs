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

    public SkillshotComponent(float Damage, float Range, float ReloadTime, float ManaCost)
    {
        SecondaryTouchInput.OnSecondaryTouch += SkillshotTouch;

        this.Damage = Damage;
        this.Range = Range;
        this.ReloadTime = ReloadTime;
        this.ManaCost = ManaCost;
        CanCast = false;
    }

    public SkillshotComponent()
    {
        SecondaryTouchInput.OnSecondaryTouch += SkillshotTouch;
        
        this.Damage = 1;
        this.Range = 1;
        this.ReloadTime = 1;
        this.ManaCost = 1;
        CanCast = false;
    }

    ~SkillshotComponent()
    {
        SecondaryTouchInput.OnSecondaryTouch -= SkillshotTouch;
        CanCast = false;
    }

    private void SkillshotTouch(Transform touchedTr, Vector3 touchedPos)
    {
        if (CanCast && CurrentReloadTimer > ReloadTime)
        {
            Debug.Log("Cast");

            // Subtract mana from mana component
            CurrentReloadTimer = 0f;
        }
    }

    #region Framer implementation
    public void FrameUpdate()
    {
        CanCast = InputConfig.Skillshot();
        CurrentReloadTimer += Time.deltaTime;
    }
    #endregion
}