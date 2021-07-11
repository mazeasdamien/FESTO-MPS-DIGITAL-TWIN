using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace festo
{
    public class handlingDevice : MonoBehaviour
    {
        public PLC_Output_Manager PLC_Output_Manager;

        void Update()
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                PLC_Output_Manager.handlingDeviceLeft = false;
                PLC_Output_Manager.handlingDeviceRight = true;

            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                PLC_Output_Manager.handlingDeviceRight = false;
                PLC_Output_Manager.handlingDeviceLeft = true;

            }
            else
            {
                PLC_Output_Manager.handlingDeviceRight = false;
                PLC_Output_Manager.handlingDeviceLeft = false;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                    PLC_Output_Manager.liftingCylinder = true;


            }
            else
            { 
                    PLC_Output_Manager.liftingCylinder = false;

            }

            if (Input.GetKey(KeyCode.Space))
            {
                PLC_Output_Manager.gripperClose = true;

            }
            else
            {
                PLC_Output_Manager.gripperClose = false;
            }
        }
    }
}
