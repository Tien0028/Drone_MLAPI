using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

namespace DroneWork
{
    [RequireComponent(typeof(Rigidbody))]
    public class IP_Base_Rigibody : NetworkBehaviour
    {
        #region Variables
        [Header("Rigibody Properties")]
        [SerializeField] private float weightInLbs = 3.5f;

        const float lbsToKg = 0.454f;
        protected Rigidbody rb;
        protected float startDrag;
        protected float stargAngularDrag;
        #endregion

        #region Main Methods
        
        // Start is called before the first frame update
        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            if (rb)
            {
                rb.mass = weightInLbs * lbsToKg;
                startDrag = rb.drag;
                stargAngularDrag = rb.angularDrag;
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (!rb)
            {
                return;
            }

            if (IsLocalPlayer)
            {
                HandlePhysics();
            }
        }
        #endregion

        #region Custom Methods
        protected virtual void HandlePhysics()
        {

        }
        #endregion
    }
}
