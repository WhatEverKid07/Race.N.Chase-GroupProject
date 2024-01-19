using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class WheelController : MonoBehaviour
{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    [SerializeField] Transform frontRightTranform;
    [SerializeField] Transform frontLeftTranform;
    [SerializeField] Transform backRightTranform;
    [SerializeField] Transform backLeftTranform;

    private Rigidbody playerRB;
    public float acceleration = 500f;
    public float breakingForce = 300f;
    public float maxTurnAngle = 15f;
    public float speed;

    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;

    private void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        speed = playerRB.velocity.magnitude;
    }
    private void FixedUpdate()
    {
        currentAcceleration = acceleration * Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
            currentBreakForce = breakingForce;
        else
            currentBreakForce = 0f;

        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;

        frontRight.brakeTorque = currentBreakForce;
        frontLeft.brakeTorque = currentBreakForce;
        backRight.brakeTorque = currentBreakForce;
        backLeft.brakeTorque = currentBreakForce;

        // currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;

        float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up *steerInput * maxTurnAngle * Time.deltaTime);

        UpdateWheel(frontLeft, frontLeftTranform);
        UpdateWheel(frontRight, frontRightTranform);
        UpdateWheel(backLeft, backLeftTranform);
        UpdateWheel(backRight, backRightTranform);
    }

    void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;
    }
}
