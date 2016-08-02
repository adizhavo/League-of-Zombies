using UnityEngine;

public static class DamagableInput 
{
    public delegate void DamagableTouch(Entity entity, DamagableSystem damagableComponent);
    public static event DamagableTouch OnDamagableTouch;

    static DamagableInput()
    {
        TouchInput.OnTouch += DamagableTouchInput;
    }

    private static void DamagableTouchInput(Transform touchedTr, Vector3 pointTouched)
    {
        if (OnDamagableTouch != null)
        {
            CharacterUnit unit = touchedTr.GetComponent(typeof(CharacterUnit)) as CharacterUnit;

            if (unit != null)
            {
                DamagableSystem damagable = unit.entity.GetComponent<DamagableSystem>();

                if (damagable != null) 
                {
                    OnDamagableTouch(unit.entity, damagable);
                }
            }
        }
    }
}