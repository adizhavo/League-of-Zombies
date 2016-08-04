using UnityEngine;

public class AnimationComponent : AnimationSystem
{
    #region AnimationSystem implementation
    public void Play(string clipName)
    {
        animation.CrossFade(clipName);
    }

    public float GetLenght(string clipName)
    {
        return animation.GetClip(clipName).length;
    }

    public void ReturnToIdle()
    {
        Play("Idle");
    }

    public string CurrentClip()
    {
        return animation.clip.name;
    }
    #endregion

    #region Framer implementation
    public void FrameUpdate()
    {
        
    }
    #endregion

    #region Component implementation
    public Entity Entity {set; get;}
    #endregion

    private Animation animation;

    public AnimationComponent(Animation animation)
    {
        this.animation = animation;
    }

    ~AnimationComponent()
    {
        animation = null;
    }
}