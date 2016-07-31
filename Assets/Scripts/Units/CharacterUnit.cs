using UnityEngine;
using System.Collections;

public class CharacterUnit : MonoBehaviour {

    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;

    private Unit entity;

    protected virtual void Start () 
    {
        MoveSystem mover = new GroundInputMover(moveSpeed, rotationSpeed);

        entity = new Unit(transform, mover);

        // Used to update teh values each frame from the editor
        // Component dependecies will solve this problem in code
        #if UNITY_EDITOR
        moveSystem = mover;
        #endif
	}

    protected virtual void Update ()
    {
        if (entity == null) return;

        entity.unitMover.FrameMove();

        // Used to update teh values each frame from the editor
        #if UNITY_EDITOR
        Refresh();
        #endif
	}

    private MoveSystem moveSystem;

    // Used to update teh values each frame from the editor
    #if UNITY_EDITOR
    private void Refresh()
    {
        moveSystem.MovementSpeed = moveSpeed;
        moveSystem.RotationSpeed = rotationSpeed;
    }
    #endif
}