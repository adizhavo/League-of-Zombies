using UnityEngine;

public class AttackComponent : AttackSystem
{
    #region Component implementation
    public Entity Entity {set; get;}
    #endregion

    #region AttackSystem implementation
    public float Damage {set; get;}
    public float Range {set; get;}
    public float ReloadTime {set; get;}
    #endregion

    private MoveSystem movementComponent;
    private AnimationSystem animationComponent;

    public AttackComponent(float Damage, float Range, float ReloadTime)
    {
        DamagableInput.OnDamagableTouch += DamagableSelected;
        GroundInput.OnGroundTouch += ClearAttack;

        this.Damage = Damage;
        this.Range = Range;
        this.ReloadTime = ReloadTime;
    }

    public AttackComponent()
    {
        this.Range = Mathf.Infinity;
    }

    ~AttackComponent()
    {
        DamagableInput.OnDamagableTouch -= DamagableSelected;
        GroundInput.OnGroundTouch -= ClearAttack;
    }

    private void ClearAttack(Vector3 pos)
    {
        target = null;
        targetTr = null;
    }

    private void DamagableSelected(Entity selectedEntity, DamagableSystem damagableComponent)
    {
        if (selectedEntity == Entity) return;
        if (movementComponent == null) movementComponent = Entity.GetComponent<MoveSystem>();
        if (movementComponent == null) return;
        if (animationComponent == null) animationComponent = Entity.GetComponent<AnimationSystem>();
        if (animationComponent == null) return;

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
        if (target != null && movementComponent != null)
        {
            if (damagableDistance < Range && timer > ReloadTime)
            {
                movementComponent.Stop();
                if (animationComponent != null) animationComponent.Play("Attack");

                // It should be triggered by an animation event
                target.ApplyDamage(Damage);


                timer = 0f;
            }

            timer += Time.deltaTime;
        }
    }
    #endregion

    private DamagableSystem target;
    private Transform targetTr;

    private float timer = Mathf.Infinity;

    private float damagableDistance
    {
        get { return Vector3.Distance(Entity.container.position, targetTr.position);}
    }
}