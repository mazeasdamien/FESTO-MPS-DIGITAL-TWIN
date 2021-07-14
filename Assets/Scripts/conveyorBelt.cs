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
        private Material mymat;

        public TMP_Text metal;
        public TMP_Text red;
        public TMP_Text black;

        public int m;
        public int r;
        public int b;

        public float ScrollY = 0.05f;
        private void Start()
        {
            mymat = GetComponent<Renderer>().material;
            m = 0;
            r = 0;
            b = 0;
        }

        void FixedUpdate()
        {
            if (stationsManager.pieceHasCollided)
                direction = new Vector3(1, 0, 1);

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
            if (collision.gameObject.GetComponent<MeshRenderer>().material.color == Color.grey) 
            {
                m = m + 1;
                metal.text = m.ToString();
            }
            else if (collision.gameObject.GetComponent<MeshRenderer>().material.color == Color.red)
            {
                r = r + 1;
                red.text = r.ToString();
            }
            else if (collision.gameObject.GetComponent<MeshRenderer>().material.color == Color.black)
            {
                b = b + 1;
                black.text = b.ToString();
            }

            onBelt.Remove(collision.gameObject);
        }
    }
}
