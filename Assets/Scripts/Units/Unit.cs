using UnityEngine;
using System.Collections;

// Entity that will have different components attached
public class Unit
{
    public MoveSystem unitMover;
    public Transform container;

    public Unit(Transform container, MoveSystem unitMover)
    {
        this.container = container;
        this.unitMover = unitMover;

        unitMover.Entity = this;
    }

    ~Unit()
    {
        unitMover = null;
    }

    public void FrameUpdate()
    {
        unitMover.FrameMove();
    }
}