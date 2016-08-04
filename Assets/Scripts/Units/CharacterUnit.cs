﻿using UnityEngine;

public class CharacterUnit : Unit 
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private float reloadTime;
    [SerializeField] private Animation animation;
 
    protected override void Start () 
    {
        MoveSystem mover = new GroundInputMoverComponent(moveSpeed, rotationSpeed);
        AttackSystem attacker = new AttackComponent(damage, range, reloadTime);
        AnimationSystem aniamtor = new AnimationComponent(animation);

        // transform is only assigned to be manipolate from components
        entity = new Entity(transform);
        entity.AddComponent(mover);
        entity.AddComponent(attacker);
        entity.AddComponent(aniamtor);
	}

    protected override void Update ()
    {
        if (entity == null) return;

        entity.FrameUpdate();

        // Used to update teh values each frame from the editor
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