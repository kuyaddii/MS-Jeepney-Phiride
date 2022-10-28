using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public static float forwardspeed = 2;
    public float maxspeed;

    private int desiredlane = 1;//middle
    public float lanedistance = 4;//distance between lane
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;
        //increase speed
        if(forwardspeed < maxspeed)
            forwardspeed += 0.1f * Time.deltaTime;

        direction.z = forwardspeed;
        if (SwipeManager.swipeRight)
        {
            desiredlane++;
            if (desiredlane == 3)
                desiredlane = 2;
        }
        if (SwipeManager.swipeLeft)
        {
            desiredlane--;
            if (desiredlane == -1)
                desiredlane = 0;
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(desiredlane == 0)
        {
            targetPosition += Vector3.left * lanedistance;
        }else if (desiredlane == 2)
        {
            targetPosition += Vector3.right * lanedistance;
        }

        //transform.position = Vector3.Lerp(transform.position, targetPosition, 80 * Time.deltaTime);
        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);


    }
    private void FixedUpdate()
    {
        if (!PlayerManager.isGameStarted)
            return;
        controller.Move(direction * Time.fixedDeltaTime);
    }

   private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacles")
        {
            PlayerManager.gameOver = true;
        }
    }

}
