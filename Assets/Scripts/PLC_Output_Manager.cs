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
        public OPCUASubscriber magazineCylinderSub;
        public Animator magazineCylinderAnimator;
        public MeshRenderer M1;
        public MeshRenderer M2;
        public GameObject piecemagasine;
        public OPCUASubscriber isSuckingSub;
        public OPCUASubscriber swivelDriveToSortingStationSub;
        public OPCUASubscriber swivelDriveToMagasineStationSub;
        public Animator swivelDriveToSortingStationAnimator;

        [Header("SORTING STATION")]
        public bool pieceHasCollided;
        public bool conveyorBelt;
        public Animator firstFlipperAnimator;
        public OPCUASubscriber flipper1Sub;
        public Animator secondFlipperAnimator;
        public OPCUASubscriber flipper2Sub;
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
        public OPCUASubscriber goDown;
        public MeshRenderer deuxB2;

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

            #region Magasine
            if (magazineCylinderSub.boolValue)
            {
                M1.material.color = Color.red;
                M2.material.color = Color.green;
                piecemagasine.SetActive(true);
                magazineCylinderAnimator.SetBool("isON", true);
            }
            else
            {
                M2.material.color = Color.red;
                M1.material.color = Color.green;
                magazineCylinderAnimator.SetBool("isON", false);
            }
            #endregion

            if (swivelDriveToSortingStationSub.boolValue)
            {
                piecemagasine.SetActive(false);
                swivelDriveToSortingStationAnimator.SetBool("nextStation", true);
            }
            if (swivelDriveToMagasineStationSub.boolValue)
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
                conveyorBelt = false;
                firstFlipperAnimator.SetBool("isOn", false);
            }

            if (flipper2Sub.boolValue)
            {
                mat = MatPiece.red;
                secondFlipperAnimator.SetBool("isOn", true);
            }
            else
            {
                conveyorBelt = false;
                secondFlipperAnimator.SetBool("isOn", false);
            }

            if (flipper1Sub.boolValue == false && flipper2Sub.boolValue == false)
                mat = MatPiece.black;

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

            if (!goDown.boolValue)
                deuxB2.material.color = Color.green;
            else
                deuxB2.material.color = Color.red;

        }
    }
}
