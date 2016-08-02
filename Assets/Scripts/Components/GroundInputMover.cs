using UnityEngine;

public class NullMover : MoveSystem
{
    public float MovementSpeed {set;get;}
    public float RotationSpeed {set;get;}
    public Entity Entity {set;get;}

    public void FrameUpdate(){ }
}

// Will move all unit that are subscribe to the GrounInput event to a specific position
public class GroundInputMover : MoveSystem 
{
    public readonly float inputDistance = 0.1f;

    public float MovementSpeed {set;get;}
    public float RotationSpeed {set;get;}

    #region Component implementation
    private Entity entity;
    public Entity Entity 
    {
        set
        {
            if (value != null) // initialise the position when the entity is assigned
            {
                this.entity = value;
                startPos = entity.container.position;
                targetPos = entity.container.position;
            }
        }

        get
        {
            return entity;
        }
    }
    #endregion

    private Vector3 startPos;
    private Vector3 targetPos;

    public GroundInputMover(float MovementSpeed, float rotationSpeed)
    {
        GroundInput.OnGroundTouch += GrounPosition;
        this.MovementSpeed = MovementSpeed;
        this.RotationSpeed = rotationSpeed;
    }

    public GroundInputMover()
    {
        GroundInput.OnGroundTouch += GrounPosition;
        this.MovementSpeed = 1; // standart value
        this.RotationSpeed = 7;
    }

    ~GroundInputMover()
    {
        entity = null;
        GroundInput.OnGroundTouch -= GrounPosition;
    }

    #region Framer implementation
    public void FrameUpdate()
    {
        if (entity == null) return;

        float distance = Vector3.Distance(targetPos, entity.container.position);

        if (distance > inputDistance && timeCounter < 1f)
        {
            LerpMovement();
            LerpRotation();
        }
    }
    #endregion

    private void LerpMovement()
    {
        entity.container.position = Vector3.Lerp(startPos, targetPos, timeCounter);
        float moveTime = targetDistance / MovementSpeed;
        timeCounter += Time.deltaTime / moveTime;
    }

    private void LerpRotation()
    {
        Vector3 direction = targetPos - entity.container.position;
        Quaternion targetRot = Quaternion.LookRotation(direction);
        entity.container.rotation = Quaternion.Lerp(entity.container.rotation, targetRot, Time.deltaTime * RotationSpeed);
    }

    private void GrounPosition(Vector3 pos)
    {
        startPos = entity.container.position;
        targetPos = pos;

        targetDistance = Vector3.Distance(startPos, targetPos);

        timeCounter = 0;
    }

    private float timeCounter;
    private float targetDistance;
}