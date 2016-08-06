using UnityEngine;

public class Main : MonoBehaviour
{
    private Framer[] touches;

	protected virtual void Awake() 
    {
        touches = new Framer[] 
            {
                new TouchInput(),
                new SecondaryTouchInput()
            };
	}

	private void Update () 
    {
        for (int i = 0; i < touches.Length; i ++)
            touches[i].FrameUpdate();
	}
}