using UnityEngine;

public class CharacterUnit : Unit 
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Animation animation;

    [Header("Attack properties")]
    [SerializeField] private float attackDamage;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackReloadTime;

    [Header("Skillshot properties")]
    [SerializeField] private float skillshotDamage;
    [SerializeField] private float skillshotRange;
    [SerializeField] private float skillshotReloadTime;
    [SerializeField] private float skillshotManaCost;
    [SerializeField] private GameObject SkillshotGizmoGraphic;
 
    protected override void Start () 
    {
        MoveSystem mover = new GroundInputMoverComponent(moveSpeed, rotationSpeed);
        AnimationSystem aniamtor = new AnimationComponent(animation);

        AttackSystem attacker = new AttackComponent(attackDamage, attackRange, attackReloadTime);
        AttackSystem skillshot = new SkillshotComponent(skillshotDamage, skillshotRange, skillshotRange, skillshotManaCost, SkillshotGizmoGraphic);

        // transform is only assigned to be manipolate from components
        entity = new Entity(transform);
        entity.AddComponent(mover);
        entity.AddComponent(aniamtor);
        entity.AddComponent(attacker);
        entity.AddComponent(skillshot);
	}

    protected override void Update ()
    {
        if (entity == null) return;

        entity.FrameUpdate();

        // Used to update the values each frame from the editor
        #if UNITY_EDITOR
        Refresh();
        #endif

//        Example of changing or removing component
//
//        if (Time.timeSinceLevelLoad > 5)
//        {
//            entity.RemoveComponent<MoveSystem>();
//            entity.AddComponent(new NullMover());
//        }
	}

    // Used to update teh values each frame from the editor
    #if UNITY_EDITOR
    private void Refresh()
    {
        MoveSystem moveSystem = entity.GetComponent<MoveSystem>();
        moveSystem.MovementSpeed = moveSpeed;
        moveSystem.RotationSpeed = rotationSpeed;

        AttackSystem attackSystem = entity.GetComponent<AttackComponent>();
        attackSystem.Damage = attackDamage;
        attackSystem.Range = attackRange;
        attackSystem.ReloadTime = attackReloadTime;
    }
    #endif
}