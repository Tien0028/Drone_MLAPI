using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DroneWork
{
    public class IP_Drone_Follow : MonoBehaviour
    {
        private Transform ourDrone;
        void Awake()
        {
            ourDrone = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private Vector3 velocityCameraFollow;
        public Vector3 behindPosition = new Vector3(0, 2, -4);
        public float angle;
        void FixedUpdate()
        {
            transform.position = Vector3.SmoothDamp(transform.position, ourDrone.transform.TransformPoint(behindPosition) + Vector3.up, ref velocityCameraFollow, 0.1f);
            transform.rotation = Quaternion.Euler(new Vector3(angle, ourDrone.GetComponent<IP_Drone_Controller>().finalRoll, 0));
        }
    }
}
