using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace festo
{
    public class piece : MonoBehaviour
    {
        private PLC_Output_Manager StationManager;

        void Start()
        {
            StationManager = GameObject.Find("StationsManager").GetComponent<PLC_Output_Manager>();
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.tag == "flipper")
            {
                if (StationManager.conveyorBelt == true) 
                {
                    StationManager.pieceHasCollided = true;
                }
            }
        }
    }
}
