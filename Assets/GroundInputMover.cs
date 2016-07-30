using UnityEngine;
using System.Collections;

public class GroundInputMover : MonoBehaviour 
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float inputDistance;

    private Vector3 startPos;
    private Vector3 targetPos;
    private Quaternion targetRotation;

    private void Start()
    {
        GroundInput.OnGroundTouch += GrounPosition;

        startPos = transform.position;
        targetPos = transform.position;
        targetRotation = transform.rotation;
    }

    private void OnDestroy()
    {
        GroundInput.OnGroundTouch -= GrounPosition;
    }
	
    private void GrounPosition(Vector3 pos)
    {
        startPos = transform.position;
        targetPos = pos;

        targetDistance = Vector3.Distance(startPos, targetPos);

        timeCounter = 0;
    }

    private void Update()
    {
        float distance = Vector3.Distance(targetPos, transform.position);

        if (distance > inputDistance && timeCounter < 1f)
        {
            LerpMovement();
        }
    }

    private void LerpMovement()
    {
        transform.position = Vector3.Lerp(startPos, targetPos, timeCounter);
        float moveTime = targetDistance / movementSpeed;
        timeCounter += Time.deltaTime / moveTime;
    }

    private float timeCounter;
    private float targetDistance;
}
