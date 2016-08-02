using UnityEngine;

public class Main : MonoBehaviour
{
    private Framer touch;

	protected virtual void Awake() 
    {
        touch = new TouchInput();
	}

	void Update () 
    {
        touch.FrameUpdate();
	}
}