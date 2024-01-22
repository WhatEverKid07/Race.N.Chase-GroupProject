using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private Rigidbody playerRB;
    public Vector3 offSet;
    public float speed;

    void Start()
    {
        playerRB = player.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 playerForward = (playerRB.velocity + transform.forward).normalized;
        transform.position = Vector3.Lerp(transform.position,
            player.position + player.transform.TransformVector(offSet)
            + playerForward * (-5f),
            speed * Time.deltaTime);
        transform.LookAt(player);
    }
}
