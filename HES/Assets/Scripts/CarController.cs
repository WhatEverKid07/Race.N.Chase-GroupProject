using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody playerRB;
    public WheelColliders Colliders;
    public WheelMeshes WheelMesh;
    public float gasInput;
    public float brakeInput;
    public float steeringInput;

    public float motorPower;
    public float brakePower;
    private float slipAngle;
    private float speed;
    public AnimationCurve steeringCurve;
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        speed = playerRB.velocity.magnitude;
        CheckInput();
        ApplyWheelPositions();
        ApplyMotor();
        ApplySteering();
       // ApplyBrake();
    }
    void CheckInput()
    {
        gasInput = motorPower;
        steeringInput = Input.GetAxis("Horizontal") * 2f;
        slipAngle = Vector3.Angle(transform.forward, playerRB.velocity-transform.forward);
        if (slipAngle < 120f) {
            if (gasInput < 0)
            {
                brakeInput = Mathf.Abs(gasInput);
                gasInput = 0;
            }
        }
        else
        {
            brakeInput = 0;
        }
    }
    void ApplyBrake()
    {
        Colliders.FrontRightWheel.brakeTorque = brakeInput * brakePower * 0.7f;
        Colliders.FrontLeftWheel.brakeTorque = brakeInput * brakePower * 0.7f;

        Colliders.RearRightWheel.brakeTorque = brakeInput * brakePower * 0.3f;
        Colliders.RearLeftWheel.brakeTorque = brakeInput * brakePower * 0.3f;
    }
    void ApplyMotor()
    {

        Colliders.RearRightWheel.motorTorque = motorPower * 10f;
        Colliders.RearLeftWheel.motorTorque = motorPower * 10f;
        Colliders.FrontRightWheel.motorTorque = motorPower * 10f;
        Colliders.FrontLeftWheel.motorTorque = motorPower * 10f;

    }
    void ApplySteering()
    {
        float steeringAngle = steeringInput * steeringCurve.Evaluate(speed);
        if(slipAngle < 120f)
        {
            steeringAngle += Vector3.SignedAngle(transform.forward, playerRB.velocity + transform.forward, Vector3.up);
        }
        steeringAngle = Mathf.Clamp(steeringAngle, -90f, 90f);
        Colliders.FrontRightWheel.steerAngle = steeringAngle;
        Colliders.FrontLeftWheel.steerAngle = steeringAngle;
    }
    void ApplyWheelPositions()
    {
        UpdateWheel(Colliders.FrontRightWheel, WheelMesh.FrontRightWheel);
        UpdateWheel(Colliders.FrontLeftWheel, WheelMesh.FrontLeftWheel);
        UpdateWheel(Colliders.RearRightWheel, WheelMesh.RearRightWheel);
        UpdateWheel(Colliders.RearLeftWheel, WheelMesh.RearLeftWheel);
    }
    void UpdateWheel(WheelCollider coll, MeshRenderer wheelMesh)
    {
        Quaternion quat;
        Vector3 position;
        coll.GetWorldPose(out position, out quat);
        wheelMesh.transform.position = position;
        wheelMesh.transform.rotation = quat;
    }
}
[System.Serializable]
public class WheelColliders
{
    public WheelCollider FrontRightWheel;
    public WheelCollider FrontLeftWheel;
    public WheelCollider RearRightWheel;
    public WheelCollider RearLeftWheel;
}
[System.Serializable]
public class WheelMeshes
{
    public MeshRenderer FrontRightWheel;
    public MeshRenderer FrontLeftWheel;
    public MeshRenderer RearRightWheel;
    public MeshRenderer RearLeftWheel;
}
