using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLC_Input_Manager : MonoBehaviour
{
    [Header("DISTRIBUTING STATION")]
    public bool magazineBackposition;
    public bool magazineFrontposition;
    public bool workPieceSucked;
    public bool swivelDriveMagazinePosition;
    public bool swivelDriveNextStation;
    public bool workPieceAvailableDistributing;


    [Header("SORTING STATION")]
    public bool workPieceAvailableSorting;
    public bool workPieceIsMetal;
    public bool workPieceIsBack; // if 0 = black else red or metal
    public bool workPieceIsFalling;
    public bool firstFlipperRetracted;
    public bool firstFlipperAdvanced;
    public bool secondFlipperRetracted;
    public bool secondFlipperAdvanced;

    [Header("HANDLING STATION")]
    public bool workPieceAvailableHandling;
    public bool handlingDevicePreviousStation;
    public bool handlingDeviceNextStation;
    public bool handlingDeviceSortingStation;
    public bool liftingCylinderDown;
    public bool liftingCylinderUp;
    public bool NotABlackPiece;
}
