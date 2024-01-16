using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driftingcar : MonoBehaviour
{
    private Vector3 moveForce;

    void Update()
    {
        transform.position += moveForce * Time.deltaTime;
    }
}
