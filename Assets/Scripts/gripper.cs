using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace festo
{
    public class gripper : MonoBehaviour
    {
        public PLC_Output_Manager StationManager;
        private FixedJoint fj;

        private void Start()
        {
            fj = gameObject.GetComponent<FixedJoint>();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.layer == 7)
            {
                if (StationManager.gripperClose)
                {
                    fj.connectedBody = other.gameObject.GetComponent<Rigidbody>();
                }
                else
                {
                    fj.connectedBody = null;
                }
            }
        }
    }
}