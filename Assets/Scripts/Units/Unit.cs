using UnityEngine;

public abstract class Unit : MonoBehaviour {

    public Entity entity
    {
        protected set;
        get;
    }

    protected abstract void Start();
    protected abstract void Update();
}