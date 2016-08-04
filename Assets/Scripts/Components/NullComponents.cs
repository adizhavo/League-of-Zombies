using UnityEngine;

public class NullAnimationComponent : AnimationSystem
{
    public Entity Entity {set; get;}

    public void Play(string clipName) { }
    public float GetLenght(string clipName) { return Mathf.Infinity; }
    public void ReturnToIdle() { }
    public string CurrentClip() { return string.Empty; }
    public void FrameUpdate() { }
}

public class NullAttackComponent : AttackSystem
{
    public Entity Entity {set; get;}

    public float Damage {set; get;}
    public float Range {set; get;}
    public float ReloadTime {set; get;}

    public void FrameUpdate() { }
}

public class NullMoverComponent : MoveSystem
{
    public void FrameUpdate(){ }

    public Entity Entity {set; get;}

    public float MovementSpeed {set; get;}
    public float RotationSpeed {set; get;}

    public void MoveTo(float x, float y, float z) { }
    public void Stop() { }
}