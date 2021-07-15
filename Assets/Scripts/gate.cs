using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RosSharp.RosBridgeClient.MessageTypes.RosOpcua;
using RosSharp.RosBridgeClient;

namespace festo
{
    public class gate : MonoBehaviour
    {
        public PLC_Output_Manager POM;
        public spawner s;
        public conveyorBelt cb;
        public TMP_Text counter;
        private int n;
        public GameObject warningSign;

        private void Start()
        {
            n = 0;    
        }

        private void OnTriggerEnter(Collider other)
        {
            cb.direction = new Vector3(1, 0, 0);
            s.hasbeenspawn = false;
            POM.conveyorBelt = false;
            n = n+1;
            counter.text = n.ToString();
            if (n == 4)
            {
                warningSign.SetActive(true);
            }
        }
    }
}