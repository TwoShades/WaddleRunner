using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : BaseState
{

    public override void Construct()
    {
        motor.anim?.SetTrigger("Fall");
    }

    public override Vector3 ProcessMotion()
    {
        // Apply gravity
        motor.ApplyGravity();

        // Create our return vector
        Vector3 m = Vector3.zero;

        m.x = motor.SnapToLane();
        m.y = motor.verticalVelocity;
        m.z = motor.baseRunSpeed;

        return m;
    }

    public override void Transition()
    {
        if (InputManager.Instance == null)
            return;

        if (InputManager.Instance.SwipeLeft)
            // Change lane, go left
            motor.ChangeLane(-1);

        if (InputManager.Instance.SwipeRight)
            //Change lane, go right
            motor.ChangeLane(1);

        if (motor.isGrounded)
            motor.ChangeState(GetComponent<RunningState>());
    }
}
