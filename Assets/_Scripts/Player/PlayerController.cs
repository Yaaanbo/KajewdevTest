using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private Transform mainCam;
    [field: SerializeField] public float moveSpeed { get; set; } = 7f;

    [Header("Rotataion")]
    [SerializeField] private float smoothTime;
    private float currentRotVelocity;

    [Header("Jumping")]
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float jumpHeight = 3f;
    private Vector3 jumpingVelocity;

    [Header("Ground Checker")]
    [SerializeField] private Transform groundChecker;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundCheckerRadius;
    private bool isGrounded;

    // Update is called once per frame
    void FixedUpdate()
    {
        MovementHandler();
        GravityHandler();
    }

    private void MovementHandler()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        Vector3 moveDir = new Vector3(horizontal, 0f, vertical).normalized;

        if(moveDir.magnitude >= .1f)
        {
            float targetAngle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg + mainCam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(this.transform.eulerAngles.y, targetAngle, ref currentRotVelocity, smoothTime);
            this.transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 dir = Quaternion.Euler(0f, targetAngle, 0f).normalized * Vector3.forward;
            controller.Move(dir * moveSpeed * Time.deltaTime);
        }
    }

    private void GravityHandler()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, groundCheckerRadius, groundMask);

        if (isGrounded && jumpingVelocity.y < 0)
            jumpingVelocity.y = -2f;

        jumpingVelocity.y += gravity * Time.deltaTime;

        controller.Move(jumpingVelocity * Time.deltaTime);
    }

    public void JumpHandler()
    {
        if(isGrounded)
            jumpingVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundChecker.position, groundCheckerRadius);
    }
}
