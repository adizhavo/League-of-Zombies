using UnityEngine;
using System.Collections;

public class GroundInputMover : MonoBehaviour 
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;

    public readonly float inputDistance = 0.1f;

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
            LerpRotation();
        }
    }

    private void LerpMovement()
    {
        transform.position = Vector3.Lerp(startPos, targetPos, timeCounter);
        float moveTime = targetDistance / movementSpeed;
        timeCounter += Time.deltaTime / moveTime;
    }

    private void LerpRotation()
    {
        Vector3 direction = targetPos - transform.position;
        Quaternion targetRot = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * rotationSpeed);
    }

    private float timeCounter;
    private float targetDistance;
}