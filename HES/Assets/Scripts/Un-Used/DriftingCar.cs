using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driftingcar : MonoBehaviour
{
    public float moveSpeed = 50;
    public float maxSpeed = 15;
    public float drag = 0.98f;
    public float steerAngle = 20;
    public float traction = 1;

    private Vector3 moveForce;

    void Update()
    {
        moveForce += transform.forward * moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime * Time.deltaTime;
        transform.position += moveForce * Time.deltaTime;

        // Steering
        float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerInput * moveForce.magnitude * steerAngle * Time.deltaTime);

        // Drag and max speed limit
        moveForce *= drag;
        moveForce = Vector3.ClampMagnitude(moveForce, maxSpeed);

        // Traction
        Debug.DrawRay(transform.position, moveForce.normalized * 3);
        Debug.DrawRay(transform.position, transform.forward * 3, Color.blue);
        moveForce = Vector3.Lerp(moveForce.normalized, transform.forward, traction * Time.deltaTime) * moveForce.magnitude;
    }
}
