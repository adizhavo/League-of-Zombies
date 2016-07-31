using UnityEngine;
using System.Collections.Generic;

// Entity that will have different components attached
public class Entity
{
    private List<Component> unitComponents = new List<Component>();

    public void AddComponent(Component cmp)
    {
        if (cmp == null) return;
        if (unitComponents.Contains(cmp)) unitComponents[unitComponents.IndexOf(cmp)] = cmp; // really quick solution, can be optimized later
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

    public Component GetComponent<T>() where T : Component
    {
        for (int i = 0; i < unitComponents.Count; i ++)
        {
            if (unitComponents[i] is T) return unitComponents[i];
        }

        return null;
    }

    public Transform container;

    public Entity(Transform container)
    {
        this.container = container;
    }

    ~Entity()
    {
        unitComponents.Clear();
    }

    public void FrameUpdate()
    {
        for (int i = 0; i < unitComponents.Count; i ++)
            unitComponents[i].FrameMove();
    }
}