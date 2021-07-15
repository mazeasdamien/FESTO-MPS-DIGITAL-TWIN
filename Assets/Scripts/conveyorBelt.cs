using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.RosBridgeClient;
using TMPro;

namespace festo
{
    public class conveyorBelt : MonoBehaviour
    {
        public PLC_Output_Manager stationsManager;
        public float speed;
        public Vector3 direction;
        public List<GameObject> onBelt;
        public float ScrollY = 0.05f;

        void FixedUpdate()
        {

            if (stationsManager.conveyorBelt)
            {
                for (int i = 0; i <= onBelt.Count - 1; i++)
                {
                    onBelt[i].GetComponent<Rigidbody>().velocity = speed * direction * Time.deltaTime;
                }
                float offSetY = Time.fixedTime * ScrollY;
                GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, -offSetY);
            }
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
