using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.RosBridgeClient.MessageTypes.RosOpcua;
using RosSharp.RosBridgeClient;

namespace festo
{
    public class spawner : MonoBehaviour
    {
        public bool hasbeenspawn;
        public PLC_Output_Manager manager;
        public GameObject instance;
        public OPCUASubscriber part_av_sorting;
        public OPCUASubscriber clamper;
        public GameObject lastinstance;
        public GameObject nonull;
        public GameObject sd2;

        // Start is called before the first frame update
        void Start()
        {
            hasbeenspawn = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (sd2.!hasbeenspawn)
            {
                GameObject g = Instantiate(instance, gameObject.transform.position, Quaternion.identity);
                lastinstance = g;
                hasbeenspawn = true;
            }
            else
            {
                lastinstance = nonull;
            }

            if (clamper.boolValue) 
            {
                if (manager.mat == PLC_Output_Manager.MatPiece.red) {
                    lastinstance.GetComponent<MeshRenderer>().material.color = Color.red;
                }
                else if (manager.mat == PLC_Output_Manager.MatPiece.black) {
                    lastinstance.GetComponent<MeshRenderer>().material.color = Color.black;
                }
                else if (manager.mat == PLC_Output_Manager.MatPiece.metal)
                {
                    lastinstance.GetComponent<MeshRenderer>().material.color = Color.grey;
                }
            }
            else
            {
                lastinstance = nonull;
            }
        }
    }
}
