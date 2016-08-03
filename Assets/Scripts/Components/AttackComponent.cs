using UnityEngine;
using System.Collections;

public class AttackComponent : AttackSystem
{
    #region Component implementation
    public Entity Entity {set;get;}
    #endregion

    #region AttackSystem implementation
    public float Damage {set;get;}
    public float Range {set;get;}
    #endregion

    private MoveSystem movementComponent;

    public AttackComponent(float Damage, float Range)
    {
        DamagableInput.OnDamagableTouch += DamagableSelected;
        this.Damage = Damage;
        this.Range = Range;
    }

    ~AttackComponent()
    {
        DamagableInput.OnDamagableTouch -= DamagableSelected;
        this.Damage = 1;
        this.Range = 1;
    }

    private void DamagableSelected(Entity selectedEntity, DamagableSystem damagableComponent)
    {
        if (selectedEntity == Entity) return;
        if (movementComponent == null) movementComponent = Entity.GetComponent<MoveSystem>();
        if (movementComponent == null) return;

        target = damagableComponent;
        targetTr = selectedEntity.container;

        if (damagableDistance < Range)
            damagableComponent.ApplyDamage(Damage);
        else
        {
            Vector3 movePos = selectedEntity.container.position;
            movementComponent.MoveTo(movePos.x, movePos.y, movePos.z);
        }
    }

    #region Framer implementation
    public void FrameUpdate()
    {
        if (target != null && movementComponent != null && damagableDistance < Range)
        {
            movementComponent.Stop();
            target.ApplyDamage(Damage);
        }
    }
    #endregion

    private DamagableSystem target;
    private Transform targetTr;

    private float damagableDistance
    {
        get { return Vector3.Distance(Entity.container.position, targetTr.position);}
    }
}