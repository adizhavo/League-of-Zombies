public interface Component
{
    Entity Entity {set; get;}
    void FrameMove();
}

public interface MoveSystem : Component
{
    float MovementSpeed {set; get;}
    float RotationSpeed {set; get;}
}