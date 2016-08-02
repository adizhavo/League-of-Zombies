using UnityEngine;
using System.Collections;

public class CreepUnit : CharacterUnit
{
    protected override void Start()
    {
        entity = new Entity(transform);

        DamagableSystem damagable = new DamageComponent();
        entity.AddComponent(damagable);
    }
}