using UnityEngine;

public class CreepUnit : Unit
{
    protected override void Start()
    {
        entity = new Entity(transform);

        DamagableSystem damagable = new DamageComponent();
        entity.AddComponent(damagable);
    }

    protected override void Update()
    {
        
    }
}