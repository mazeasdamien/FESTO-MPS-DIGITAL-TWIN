using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.RosBridgeClient;

namespace festo
{
    public class conveyorBelt : MonoBehaviour
    {
        public PLC_Output_Manager stationsManager;
        public float speed;
        public Vector3 direction;
        public List<GameObject> onBelt;
        private Material mymat;
        public OPCUASubscriber pieceAvailableSub;

        public float ScrollY = 0.05f;
        private void Start()
        {
            mymat = GetComponent<Renderer>().material;
        }

        void FixedUpdate()
        {
            if (stationsManager.pieceHasCollided)
                direction = new Vector3(1, 0, 1);
            else
                direction = new Vector3(1, 0, 0);

            if (pieceAvailableSub.boolValue)
            {
                stationsManager.conveyorBelt = true;
                for (int i = 0; i <= onBelt.Count - 1; i++)
                {
                    onBelt[i].GetComponent<Rigidbody>().velocity = speed * direction * Time.deltaTime;
                }
                float offSetY = Time.fixedTime * ScrollY;
                GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, -offSetY);
            }
            else
            { stationsManager.conveyorBelt = false; }
        }

        private void OnCollisionEnter(Collision collision)
        {
            onBelt.Add(collision.gameObject);
        }

        private void OnCollisionExit(Collision collision)
        {
            onBelt.Remove(collision.gameObject);
        }
    }
}
