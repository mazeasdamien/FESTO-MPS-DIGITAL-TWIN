using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.RosBridgeClient.MessageTypes.RosOpcua;
using RosSharp.RosBridgeClient;

namespace festo
{
    public class handlingDevice : MonoBehaviour
    {
        public PLC_Output_Manager PLC_Output_Manager;
        public OPCUASubscriber godown;
        public OPCUASubscriber goleft;
        public OPCUASubscriber goright;
        public OPCUASubscriber gripper;

        void Update()
        {
            if (goright.boolValue)
            {
                PLC_Output_Manager.handlingDeviceLeft = false;
                PLC_Output_Manager.handlingDeviceRight = true;

            }
            else if (goleft.boolValue)
            {
                PLC_Output_Manager.handlingDeviceRight = false;
                PLC_Output_Manager.handlingDeviceLeft = true;

            }
            else
            {
                PLC_Output_Manager.handlingDeviceRight = false;
                PLC_Output_Manager.handlingDeviceLeft = false;
            }

            if (godown.boolValue)
            {
                    PLC_Output_Manager.liftingCylinder = true;


            }
            else
            { 
                    PLC_Output_Manager.liftingCylinder = false;

            }

            if (gripper.boolValue)
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
