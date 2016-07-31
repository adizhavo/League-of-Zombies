using UnityEngine;
using System.Collections;

// Will notify all subscribers that the user has touch a specific position in the map
public class GroundInput : MonoBehaviour {

    public delegate void GroundTouch(Vector3 groudPos);
    public static event GroundTouch OnGroundTouch;

    [SerializeField] private LayerMask groundMask;

	void Update ()
    {
        if (InputConfig.TouchUp())
        {
            // are we clicking a UI object ?

            RaycastHit hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100, groundMask))
            {
                if (OnGroundTouch != null)
                    OnGroundTouch(hit.point);
            }
        }
	}
}