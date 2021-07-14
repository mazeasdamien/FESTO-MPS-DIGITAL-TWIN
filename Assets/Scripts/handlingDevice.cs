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

        private bool isdown;

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

        public void StartGoRight(RosSharp.RosBridgeClient.RosConnector RosConnector)
        {
            StartCoroutine(GoRight(RosConnector));
        }

        public void StartGoLeft(RosSharp.RosBridgeClient.RosConnector RosConnector)
        {
            StartCoroutine(GoLeft(RosConnector));
        }

        public void StartStop(RosSharp.RosBridgeClient.RosConnector RosConnector)
        {
            StartCoroutine(GoStop(RosConnector));
        }

        public void StartDown(RosSharp.RosBridgeClient.RosConnector RosConnector)
        {
            if (!isdown)
            {
                RosConnector.RosSocket.CallService<WriteRequest, WriteResponse>("/handling/handling_client/write", ServiceCallHandlerWrite, new WriteRequest(new Address("ns=4;i=24", "''"), new TypeValue("bool", true, 0, 0, 0, 0, 0, 0, 0, 0, 0f, 0, "")));

                isdown = true;
            }
            else
            {
                RosConnector.RosSocket.CallService<WriteRequest, WriteResponse>("/handling/handling_client/write", ServiceCallHandlerWrite, new WriteRequest(new Address("ns=4;i=24", "''"), new TypeValue("bool", false, 0, 0, 0, 0, 0, 0, 0, 0, 0f, 0, "")));

                isdown = false;
            }
        }

        IEnumerator GoRight(RosSharp.RosBridgeClient.RosConnector RosConnector)
        {
            RosConnector.RosSocket.CallService<WriteRequest, WriteResponse>("/handling/handling_client/write", ServiceCallHandlerWrite, new WriteRequest(new Address("ns=4;i=23", "''"), new TypeValue("bool", false, 0, 0, 0, 0, 0, 0, 0, 0, 0f, 0, "")));
            yield return new WaitForSeconds(0.2f);
            RosConnector.RosSocket.CallService<WriteRequest, WriteResponse>("/handling/handling_client/write", ServiceCallHandlerWrite, new WriteRequest(new Address("ns=4;i=22", "''"), new TypeValue("bool", true, 0, 0, 0, 0, 0, 0, 0, 0, 0f, 0, "")));
        }

        IEnumerator GoLeft(RosSharp.RosBridgeClient.RosConnector RosConnector)
        {
            RosConnector.RosSocket.CallService<WriteRequest, WriteResponse>("/handling/handling_client/write", ServiceCallHandlerWrite, new WriteRequest(new Address("ns=4;i=22", "''"), new TypeValue("bool", false, 0, 0, 0, 0, 0, 0, 0, 0, 0f, 0, "")));
            yield return new WaitForSeconds(0.2f);
            RosConnector.RosSocket.CallService<WriteRequest, WriteResponse>("/handling/handling_client/write", ServiceCallHandlerWrite, new WriteRequest(new Address("ns=4;i=23", "''"), new TypeValue("bool", true, 0, 0, 0, 0, 0, 0, 0, 0, 0f, 0, "")));
        }

        IEnumerator GoStop(RosSharp.RosBridgeClient.RosConnector RosConnector)
        {
            RosConnector.RosSocket.CallService<WriteRequest, WriteResponse>("/handling/handling_client/write", ServiceCallHandlerWrite, new WriteRequest(new Address("ns=4;i=22", "''"), new TypeValue("bool", false, 0, 0, 0, 0, 0, 0, 0, 0, 0f, 0, "")));
            yield return new WaitForSeconds(0.2f);
            RosConnector.RosSocket.CallService<WriteRequest, WriteResponse>("/handling/handling_client/write", ServiceCallHandlerWrite, new WriteRequest(new Address("ns=4;i=23", "''"), new TypeValue("bool", false, 0, 0, 0, 0, 0, 0, 0, 0, 0f, 0, "")));
        }

        private static void ServiceCallHandlerWrite(WriteResponse message)
        {
        }
    }
}
