using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform mainCam;
    [field: SerializeField] public float moveSpeed { get; set; } = 7f;
    public bool isRunning { get; private set; }

    [Header("Rotataion")]
    [SerializeField] private float smoothTime;
    private float currentRotVelocity;

    // Update is called once per frame
    void FixedUpdate()
    {
        MovementHandler();
    }

    private void MovementHandler()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 moveDir = new Vector3(horizontal, 0f, vertical).normalized;

        isRunning = moveDir.magnitude > 0;

        if(moveDir.magnitude >= .1f)
        {
            float targetAngle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg + mainCam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(this.transform.eulerAngles.y, targetAngle, ref currentRotVelocity, smoothTime);
            this.transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 dir = Quaternion.Euler(0f, targetAngle, 0f).normalized * Vector3.forward;
            controller.Move(dir * moveSpeed * Time.deltaTime);
        }
    }
}
