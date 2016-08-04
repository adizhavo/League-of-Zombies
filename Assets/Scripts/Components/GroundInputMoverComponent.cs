using UnityEngine;

// Will move all unit that are subscribe to the GrounInput event to a specific position
public class GroundInputMoverComponent : MoveSystem 
{
    public readonly float inputDistance = 0.1f;

    #region Component implementation
    public float MovementSpeed {set; get;}
    public float RotationSpeed {set; get;}

    public void MoveTo(float x, float y, float z) 
    {
        if (entity == null) return;

        GrounPosition(new Vector3(x, y, z));
    }

    public void Stop()
    {
        float distance = Vector3.Distance(targetPos, entity.container.position);
        if (distance < Mathf.Epsilon) return;

        startPos = entity.container.position;
        targetPos = entity.container.position;

        if (animationComponent != null) animationComponent.ReturnToIdle();
    }
    #endregion

    #region Component implementation
    private Entity entity;
    public Entity Entity 
    {
        set
        {
            if (value != null) // initialise the position when the entity is assigned
            {
                this.entity = value;
                Stop();
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

    public GroundInputMoverComponent(float MovementSpeed, float rotationSpeed)
    {
        GroundInput.OnGroundTouch += GrounPosition;
        this.MovementSpeed = MovementSpeed;
        this.RotationSpeed = rotationSpeed;
    }

    public GroundInputMoverComponent()
    {
        GroundInput.OnGroundTouch += GrounPosition;
        this.MovementSpeed = 1; // standart value
        this.RotationSpeed = 7;
    }

    ~GroundInputMoverComponent()
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
        else Stop();
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

        if (animationComponent == null) animationComponent = Entity.GetComponent<AnimationSystem>();
        animationComponent.Play("Run");
    }

    private float timeCounter;
    private float targetDistance;
    private AnimationSystem animationComponent;
}