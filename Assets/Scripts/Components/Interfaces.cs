public interface Framer
{
    void FrameUpdate();
}

public interface Component : Framer
{
    Entity Entity {set; get;}
}

public interface MoveSystem : Component
{
    float MovementSpeed {set; get;}
    float RotationSpeed {set; get;}
    void MoveTo(float x, float y, float z);
    void Stop();
}

public interface DamagableSystem : Component
{
    void ApplyDamage(float damage);
    void ResetDamage();
}

public interface AttackSystem : Component
{
    float Damage {set; get;}
    float Range {set; get;}
    float ReloadTime {set; get;}
}