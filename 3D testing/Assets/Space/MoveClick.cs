using UnityEngine;
using System.Collections;
using System;

public class MoveClick : MonoBehaviour {
    [SerializeField][Range(1, 20)]
    private float maxSpeed = 10f;           // Max speed of ship thrust

    [SerializeField][Range(1, 20)]
    private float accelerationSpeed = 1f;   // Acceleration speed

    [SerializeField][Range(1, 20)]
    private float rotateSpeed = 5f;         // Rotate speed

    private Vector3 targetPosition;     // Where we want to travel too.
    private bool isMoving;              // Toggle to check if we are moving or not. 

    const int LEFT_MOUSE_BUTTON = 0;    // 0=Left mouse botton, this field is made for code readability.

	// Use this for initialization
	void Start () {
        targetPosition = transform.position;        // Current object position
        isMoving = false;
	}
	
	// Update is called once per frame
	void Update () {

        // if the player clicked on the screen, find out where
        if (Input.GetMouseButton(LEFT_MOUSE_BUTTON))
        {
            setTargetPosition();
        }

        
        // If we are still moving, then move the player
        if (isMoving)
        {
            rotatePlayer();
            acceleratePlayer();
            movePlayer();
        }

        // TODO ALIGN SHIP ACCORDING TO Z axis so they match
        else if( true )
        {
            
        }

	}

    private void acceleratePlayer()
    {

    }

    private void rotatePlayer()
    {
        // Look at where we want to move. 
        Vector3 newDir = Vector3.RotateTowards(transform.position, targetPosition, rotateSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
        //transform.LookAt(targetPosition);       
        //transform.position = Vector3.RotateTowards(transform.position, targetPosition, rotateSpeed, 0.0f);
        Debug.DrawRay(transform.position, newDir, Color.yellow);
    }

    private void movePlayer()
    {
        // This is what moves the player from A -> B
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, maxSpeed * Time.deltaTime);

        if (accelerationSpeed < maxSpeed)
        {
            accelerationSpeed = accelerationSpeed * 0.1f;
        }


        // If we are at the target position, then stop moving. 
        if (transform.position == targetPosition)
        {
            isMoving = false;
            accelerationSpeed = 1f;
        }

        
        Debug.DrawLine(transform.position, targetPosition, Color.red);
    }

    private void setTargetPosition()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;

        if (plane.Raycast(ray, out point))
        {
            targetPosition = ray.GetPoint(point);
        }
        isMoving = true;
    }
}
