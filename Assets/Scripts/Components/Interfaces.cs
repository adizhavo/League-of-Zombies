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
}