using UnityEngine;
using System.Collections;

public class GroundInput : MonoBehaviour {

    public delegate void GroundTouch(Vector3 groudPos);
    public static event GroundTouch OnGroundTouch;

    [SerializeField] private LayerMask groundMask;

	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
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