using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace festo
{
    public class handlingDevice : MonoBehaviour
    {
        public PLC_Output_Manager StationManager;

        void Update()
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                StationManager.handlingDeviceLeft = false;
                StationManager.handlingDeviceRight = true;

            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                StationManager.handlingDeviceRight = false;
                StationManager.handlingDeviceLeft = true;

            }
            else
            {
                StationManager.handlingDeviceRight = false;
                StationManager.handlingDeviceLeft = false;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                    StationManager.liftingCylinder = true;


            }
            else
            { 
                    StationManager.liftingCylinder = false;

            }

            if (Input.GetKey(KeyCode.Space))
            {
                StationManager.gripperClose = true;

            }
            else
            {
                StationManager.gripperClose = false;
            }
        }
    }
}
