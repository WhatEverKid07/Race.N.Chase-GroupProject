using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private Rigidbody playerRB;
    public Vector3 offSet;
    public float speed;

    /*
    public Vector3 camMask;
    public float smooth = 4.0f;
    public Vector3 camPosition;

    [Header("Layer(s) to include")]
    public LayerMask CamOcclusion;
    */
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
    
    /*
    private void LateUpdate()
    {
        camPosition = transform.position;
        Vector3 targetOffset = new Vector3(player.position.x, (player.position.y + 2f), player.position.z);

        occludeRay(ref targetOffset);
        smoothCamMethod();
    }

    void smoothCamMethod()
    {

        smooth = 4f;
        transform.position = Vector3.Lerp(transform.position, camPosition, Time.deltaTime * smooth);
    }
    void occludeRay(ref Vector3 targetFollow)
    {
        #region prevent wall clipping
        //declare a new raycast hit.
        RaycastHit wallHit = new RaycastHit();
        //linecast from your player (targetFollow) to your cameras mask (camMask) to find collisions.
        if (Physics.Linecast(targetFollow, camMask, out wallHit, CamOcclusion))
        {
            //the smooth is increased so you detect geometry collisions faster.
            smooth = 10f;
            //the x and z coordinates are pushed away from the wall by hit.normal.
            //the y coordinate stays the same.
            camPosition = new Vector3(wallHit.point.x + wallHit.normal.x * 0.5f, camPosition.y, wallHit.point.z + wallHit.normal.z * 0.5f);
        }
        #endregion
    }
    */
}
