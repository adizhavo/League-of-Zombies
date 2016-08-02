using UnityEngine;

public class DamageComponent : DamagableSystem
{    
    #region Damagable implementation
    public void ApplyDamage(float damage)
    {
        Debug.Log(Entity.container.name + " received " + damage + " amount of damage");
    }
    public void ResetDamage()
    {
        Debug.Log(Entity.container.name + " damage resetted");
    }
    #endregion

    #region Framer implementation
    public void FrameUpdate()
    {
        
    }
    #endregion

    #region Component implementation
    public Entity Entity
    {
        get;
        set;
    }
    #endregion
}