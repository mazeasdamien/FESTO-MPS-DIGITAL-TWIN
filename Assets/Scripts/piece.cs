using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace festo
{
    public class piece : MonoBehaviour
    {
        private PLC_Output_Manager StationManager;
        private conveyorBelt conveyor;
        private bool isMatAssign;

        void Start()
        {
            isMatAssign = false;
            StationManager = GameObject.Find("StationsManager").GetComponent<PLC_Output_Manager>();
        }

        private void Update()
        {
            if (StationManager.clamperSub.boolValue)
            {
                if (!isMatAssign)
                {
                    if (StationManager.mat == PLC_Output_Manager.MatPiece.black)
                    {
                        gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
                    }
                    else if (StationManager.mat == PLC_Output_Manager.MatPiece.red)
                    {
                        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    else if (StationManager.mat == PLC_Output_Manager.MatPiece.metal)
                    {
                        gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
                    }
                    isMatAssign = true;
                }
            }
            
        }
    }
}
