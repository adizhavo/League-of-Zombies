using UnityEngine;
using System.Collections;

public class MeleeAttackComponent : AttackSystem
{
    #region Component implementation
    public Entity Entity
    {
        get;
        set;
    }
    #endregion

    #region AttackSystem implementation
    public float Damage
    {
        set;
        get;
    }
    #endregion

    public MeleeAttackComponent(float Damage)
    {
        DamagableInput.OnDamagableTouch += DamagableSelected;
        this.Damage = Damage;
    }

    ~MeleeAttackComponent()
    {
        DamagableInput.OnDamagableTouch -= DamagableSelected;
        this.Damage = 1;
    }

    private void DamagableSelected(Entity entity, DamagableSystem damagableComponent)
    {
        if (entity == Entity) return;

        damagableComponent.ApplyDamage(Damage);
    }

    #region Framer implementation
    public void FrameUpdate()
    {
        
    }
    #endregion
}