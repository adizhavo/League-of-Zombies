using UnityEngine;
using System.Collections.Generic;

// Entity that will have different components attached
public class Entity
{
    private List<Component> unitComponents = new List<Component>();

    public void AddComponent(Component cmp)
    {
        // we now that for now multiple same components can be added
        // addind more than one of the same component will not be allowed
        if (cmp == null) return;
        else unitComponents.Add(cmp);

        cmp.Entity = this;
    }

    public void RemoveComponent<T>() where T : Component
    {
        for (int i = 0; i < unitComponents.Count; i ++)
        {
            if (unitComponents[i] is T) 
            {
                unitComponents[i].Entity = null;
                unitComponents.RemoveAt(i);
            }
        }
    }

    public void RemoveAllComponents()
    {
        for (int i = 0; i < unitComponents.Count; i ++)
        {
            unitComponents[i].Entity = null;
            unitComponents.RemoveAt(i);
        }
    }

    public T GetComponent<T>() where T : class, Component
    {
        for (int i = 0; i < unitComponents.Count; i ++)
        {   
            if (unitComponents[i] as T != null) 
                return (T)unitComponents[i];
        }

        return default(T);
    }

    // the container will be accessable from different components
    public Transform container;

    public Entity(Transform container)
    {
        this.container = container;
    }

    ~Entity()
    {
        container = null;
        unitComponents.Clear();
    }

    // each component will be poked each frame
    public void FrameUpdate()
    {
        for (int i = 0; i < unitComponents.Count; i ++)
            unitComponents[i].FrameUpdate();
    }
}