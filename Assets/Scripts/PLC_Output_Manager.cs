using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.RosBridgeClient.MessageTypes.RosOpcua;

namespace festo
{
    public class PLC_Output_Manager : MonoBehaviour
    {
        public RosSharp.RosBridgeClient.RosConnector RosConnector;
        private bool handlingStoped;

        [Header("DISTRIBUTING STATION")]
        public bool magazineCylinder;
        public Animator magazineCylinderAnimator;
        public bool vacuumSwitches;
        public bool swivelDriveToSortingStation;
        public Animator swivelDriveToSortingStationAnimator;

        [Header("SORTING STATION")]
        public bool conveyorBelt;
        public bool pieceHasCollided;
        public bool firstFlipper;
        public Animator firstFlipperAnimator;
        public bool secondFlipper;
        public Animator secondFlipperAnimator;
        public bool clamper;
        public Animator clamperAnimator;

        [Header("HANDLING STATION")]
        public Rigidbody handlingDevice;
        public bool handlingDeviceRight;
        public bool handlingDeviceLeft;
        public bool liftingCylinder;
        public bool gripperClose;
        public Animator liftingCylinderAnimator;

        private void Start()
        {
            handlingStoped = true;
        }

        private void FixedUpdate()
        {
            if (magazineCylinder)
            {
                magazineCylinderAnimator.SetBool("isON", true);
            }
            else
            {
                magazineCylinderAnimator.SetBool("isON", false);
            }

            if (swivelDriveToSortingStation)
            {
                swivelDriveToSortingStationAnimator.SetBool("nextStation", true);
            }
            else
            {
                swivelDriveToSortingStationAnimator.SetBool("nextStation", false);
            }

            if (firstFlipper)
            {
                firstFlipperAnimator.SetBool("isOn", true);
            }
            else
            {
                firstFlipperAnimator.SetBool("isOn", false);
            }

            if (secondFlipper)
            {
                secondFlipperAnimator.SetBool("isOn", true);
            }
            else
            {
                secondFlipperAnimator.SetBool("isOn", false);
            }

            if (clamper)
            {
                clamperAnimator.SetBool("isOn", true);
            }
            else
            {
                clamperAnimator.SetBool("isOn", false);
            }

            if (liftingCylinder)
            {
                liftingCylinderAnimator.SetBool("cylinderDown", true);
            }
            else
            {
                liftingCylinderAnimator.SetBool("cylinderDown", false);
            }

            if (handlingDeviceRight)
            {
                handlingStoped = false;
                handlingDevice.velocity = new Vector3(12, 0, 0);

            }
            else if (handlingDeviceLeft)
            {
                handlingStoped = false;
                handlingDevice.velocity = new Vector3(-12, 0, 0);

            }
            else
            {
                handlingDevice.velocity = Vector3.zero;
                handlingDevice.Sleep();
                if (handlingStoped == false)
                {
                    handlingStoped = true;
                }
            }
        }

        private static void ServiceCallHandlerWrite(WriteResponse message)
        {
            print(message.error_message);
        }

        public void writeValue(bool onoff, string id)
        {
            Address nodeLeft = new Address("ns=4;i="+id+"", "");
            TypeValue typevalueLeft = new TypeValue("bool", onoff, (sbyte)0, (byte)0, 0, 0, 0, 0, 0, 0, 0, 0, "");
            WriteRequest requestLeft = new WriteRequest(nodeLeft, typevalueLeft);
            RosConnector.RosSocket.CallService<WriteRequest, WriteResponse>("/opcua/opcua_client/write", ServiceCallHandlerWrite, requestLeft);
        }
    }
}
