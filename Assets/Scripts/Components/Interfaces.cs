public interface MoveSystem
{
    float MovementSpeed {set; get;}
    float RotationSpeed {set; get;}
    Unit Entity {set;get;}

    void FrameMove();
}