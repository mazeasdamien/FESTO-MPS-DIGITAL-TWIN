using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RosSharp.RosBridgeClient.MessageTypes.RosOpcua;
using RosSharp.RosBridgeClient;

namespace festo
{
    public class turner : MonoBehaviour
    {
        public conveyorBelt cb;
        public spawner s;

    // Start is called before the first frame update
    void Start()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            cb.direction = new Vector3(1, 0, 1);
            s.hasbeenspawn = false;
        }

        private void OnTriggerExit(Collider other)
        {
            cb.direction = new Vector3(1, 0, 0);
        }
    }
}
