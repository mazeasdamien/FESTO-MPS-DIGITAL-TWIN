using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RosSharp.RosBridgeClient.MessageTypes.RosOpcua;
using RosSharp.RosBridgeClient;

namespace festo
{
    public class INFO : MonoBehaviour
    {
        public PLC_Output_Manager PLC_Output_Manager;
        public RosSharp.RosBridgeClient.RosConnector RosConnector;
        public Text text;
        public Camera cam;
        public GameObject inspection;
        public static GameObject inspectionH;

        private bool ishighting;

        // Update is called once per frame
        void Update()
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform.gameObject.tag == "mouseHoverInfo" || hit.transform.gameObject.tag == "flipper")
                {
                    text.text = hit.transform.name;
                    if (hit.transform.name == "First flipper") 
                    {
                        if (Input.GetMouseButtonDown(0))
                        {

                            StartDown(RosConnector);
                        }
                    }
                }
                else
                {
                    text.text = "";
                }


            }
        }

        public void StartDown(RosSharp.RosBridgeClient.RosConnector RosConnector)
        {
            if (!ishighting)
            {
                RosConnector.RosSocket.CallService<WriteRequest, WriteResponse>("/sorting/sorting_client/write", ServiceCallHandlerWrite, new WriteRequest(new Address("ns=4;i=2", "''"), new TypeValue("bool", true, 0, 0, 0, 0, 0, 0, 0, 0, 0f, 0, "")));
                inspection.SetActive(true);
                ishighting = true;
            }
            else
            {
                RosConnector.RosSocket.CallService<WriteRequest, WriteResponse>("/sorting/sorting_client/write", ServiceCallHandlerWrite, new WriteRequest(new Address("ns=4;i=2", "''"), new TypeValue("bool", false, 0, 0, 0, 0, 0, 0, 0, 0, 0f, 0, "")));
                inspection.SetActive(false);
                ishighting = false;
            }
        }

        public void CheckifInspection()
        {
            RosConnector.RosSocket.CallService<ReadRequest, ReadResponse>("/sorting/sorting_client/read", ServiceCallHandlerRead, new ReadRequest(new Address("ns=4;i=2", "''")));
        }

        private static void ServiceCallHandlerWrite(WriteResponse message)
        {
        }
        static void ServiceCallHandlerRead(ReadResponse message)
        {
            if (message.data.bool_d)
            {
                inspectionH.SetActive(true);
            }
            else
            {
                inspectionH.SetActive(false);
            }
        }
    }
}
