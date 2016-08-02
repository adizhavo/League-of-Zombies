using UnityEngine;

public class CharacterUnit : MonoBehaviour {

    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float damage;

    public Entity entity
    {
        protected set;
        get;
    }

    protected virtual void Start () 
    {
        MoveSystem mover = new GroundInputMover(moveSpeed, rotationSpeed);
        AttackSystem attacker = new MeleeAttackComponent(damage);

        // transform is only assigned to be manipolate from components
        entity = new Entity(transform);
        entity.AddComponent(mover);
        entity.AddComponent(attacker);
	}

    protected virtual void Update ()
    {
        if (entity == null) return;

        entity.FrameUpdate();

        // Used to update teh values each frame from the editor
        #if UNITY_EDITOR
//        Refresh();
        #endif

//        Example of changing or removing component
//
//        if (Time.timeSinceLevelLoad > 5)
//        {
//            entity.RemoveComponent<MoveSystem>();
//            entity.AddComponent(new NullMover());
//        }
	}

    private MoveSystem moveSystem;

    // Used to update teh values each frame from the editor
    #if UNITY_EDITOR
    private void Refresh()
    {
        MoveSystem moveSystem = entity.GetComponent<MoveSystem>();
        moveSystem.MovementSpeed = moveSpeed;
        moveSystem.RotationSpeed = rotationSpeed;
    }
    #endif
}