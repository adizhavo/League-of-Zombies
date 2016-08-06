using UnityEngine;

public class Main : MonoBehaviour
{
    public LayerMask PrimaryTouchLayer;
    public LayerMask SecondaryTouchLayer;

    private Framer[] touches;

	protected virtual void Awake() 
    {
        touches = new Framer[] 
            {
                new TouchInput(PrimaryTouchLayer),
                new SecondaryTouchInput(SecondaryTouchLayer)
            };
	}

	private void Update () 
    {
        for (int i = 0; i < touches.Length; i ++)
            touches[i].FrameUpdate();
	}
}