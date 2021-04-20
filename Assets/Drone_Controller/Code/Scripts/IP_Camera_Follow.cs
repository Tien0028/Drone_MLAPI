using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IP_Camera_Follow : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;

    //[Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    //public bool LookAtPlayer = false;

  /*  private void Start()
    {
        offset = transform.position - player.position;
    }*/

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position = player.position + offset;
        Vector3 newPos = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, newPos, SmoothFactor);
        transform.position = smoothedPosition;
        transform.LookAt(player);

        //transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        //if (LookAtPlayer)
            //transform.LookAt(player);
    }
}
