using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public CarHealth carHealth;

    public WheelColliders Colliders;
    public WheelMeshes WheelMesh;
    public AnimationCurve steeringCurve;
    public float gasInput;
    public float brakeInput;
    public float steeringInput;
    public float motorPower;
    public float brakePower;
    public bool isBoosting = false;
    public float speed;
    public float FieldOfView = 60;

    public float minSpeed;
    public float maxSpeed;
    public float minPitch;
    public float maxPitch;
    //private float pitchFromCar;

    private Rigidbody playerRB;
    private float slipAngle;
    private bool HornIsOn = false;

    public AudioSource carHorn;
    public AudioSource carEngine;
    
    void Start()
    {
        HornIsOn = false;
        isBoosting = false;
        playerRB = gameObject.GetComponent<Rigidbody>();
        //carEngine = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        speed = playerRB.velocity.magnitude;

        CarHorn();
        BoostSystem();
        CheckInput();
        ApplyWheelPositions();
        ApplyMotor();
        ApplySteering();
        EngineSound();
    }

    void EngineSound()
    {
        //pitchFromCar = playerRB.velocity.magnitude / 50f;

        if(speed < minSpeed)
        {
            carEngine.pitch = minPitch;
        }
      /*  if(speed > minSpeed && speed < maxSpeed)
        {
            carEngine.pitch = maxPitch;
        }*/
        if(speed > maxSpeed)
        {
            carEngine.pitch = maxPitch;
        }
    }
    void CarHorn()
    {
        if(Input.GetKey(KeyCode.E))
        {
            HornIsOn = true;
        }
        else
        {
            HornIsOn = false;
        }
        if(HornIsOn == true)
        {
            carHorn.Play();
            Debug.Log("Horn On");
        }
        else
        {
            carHorn.Stop();
            Debug.Log("No Horn");
        }
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
    void ApplyMotor()
    {

        Colliders.RearRightWheel.motorTorque = motorPower;
        Colliders.RearLeftWheel.motorTorque = motorPower;
        Colliders.FrontRightWheel.motorTorque = motorPower;
        Colliders.FrontLeftWheel.motorTorque = motorPower;

    }
    void ApplySteering()
    {
        float steeringAngle = steeringInput * steeringCurve.Evaluate(speed);
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
    void BoostSystem()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            motorPower = 225f;
            isBoosting = true;
        }
        else
        {
            isBoosting = false;
            motorPower = 125f;
        }
        if (isBoosting == true)
        {
            motorPower = 225f;
            Camera.main.fieldOfView = FieldOfView + 10;
        }
        else
        {
            Camera.main.fieldOfView = FieldOfView;
        }
        if (carHealth.currentBoost < 1)
        {
            isBoosting = false;
            motorPower = 125f;
            Camera.main.fieldOfView = FieldOfView;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            motorPower = motorPower - motorPower * 2;
        }
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