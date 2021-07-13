using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.RosBridgeClient.MessageTypes.RosOpcua;
using RosSharp.RosBridgeClient;

namespace festo
{
    public class PLC_Output_Manager : MonoBehaviour
    {
        public enum MatPiece { red, black, metal };
        public MatPiece mat;
        public RosSharp.RosBridgeClient.RosConnector RosConnector;
        private bool handlingStoped;

        [Header("DISTRIBUTING STATION")]
        public bool magazineCylinder;
        public Animator magazineCylinderAnimator;
        public bool vacuumSwitches;
        public bool swivelDriveToSortingStation;
        public Animator swivelDriveToSortingStationAnimator;

        [Header("SORTING STATION")]
        public bool pieceHasCollided;
        public bool conveyorBelt;
        public Animator firstFlipperAnimator;
        public OPCUASubscriber flipper1Sub;
        public bool secondFlipper;
        public Animator secondFlipperAnimator;
        public OPCUASubscriber flipper2Sub;
        public bool clamper;
        public Animator clamperAnimator;
        public OPCUASubscriber clamperSub;
        public OPCUASubscriber FallingSub;
        public OPCUASubscriber pieceAvailableSub;

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
            mat = MatPiece.black;
        }

        private void FixedUpdate()
        {
            if (pieceAvailableSub.boolValue)
            {
                conveyorBelt = true;
            }
            else if (FallingSub.boolValue)
            {
                conveyorBelt = false;
            }

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

            if (flipper1Sub.boolValue)
            {
                mat = MatPiece.metal;
                firstFlipperAnimator.SetBool("isOn", true);
            }
            else
            {
                mat = MatPiece.black;
                firstFlipperAnimator.SetBool("isOn", false);
            }

            if (flipper2Sub.boolValue)
            {
                mat = MatPiece.red;
                secondFlipperAnimator.SetBool("isOn", true);
            }
            else
            {
                mat = MatPiece.black;
                secondFlipperAnimator.SetBool("isOn", false);
            }

            if (clamperSub.boolValue)
            {
                clamperAnimator.SetBool("isOn", false);
            }
            else
            {
                clamperAnimator.SetBool("isOn", true);
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
    }
}
