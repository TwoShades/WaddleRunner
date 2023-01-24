using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnState : BaseState
{
    [SerializeField] private float verticalDistance = 10.0f;
    [SerializeField] private float imunityTime = 1f;

    private float startTime;

    public override void Construct()
    {
        startTime = Time.time;

        //motor.controller.enable = false;
        motor.transform.position = new Vector3(0, verticalDistance, motor.transform.position.z);
        //motor.controller.enable = true;

        motor.verticalVelocity = 0.0f;
        motor.currentLane = 0;
        motor.anim?.SetTrigger("Respawn");
    }

    public override void Destruct()
    {
        GameManager.Instance.ChangeCamera(GameCamera.Game);
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
        if (motor.isGrounded && (Time.time - startTime) > imunityTime)
            motor.ChangeState(GetComponent<RunningState>());

        if (InputManager.Instance == null)
            return;

        if (InputManager.Instance.SwipeLeft)
            // Change lane, go left
            motor.ChangeLane(-1);

        if (InputManager.Instance.SwipeRight)
            //Change lane, go right
            motor.ChangeLane(1);
    }
}
