using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.RosBridgeClient.MessageTypes.RosOpcua;
using RosSharp.RosBridgeClient;

namespace festo
{
    public class startreset : MonoBehaviour
    {

        void StartDistributing(RosSharp.RosBridgeClient.RosConnector RosConnector)
        {
            WriteRequest request = new WriteRequest();
            //RosConnector.RosSocket.CallService<WriteRequest,ReadResponse>("/distributing/distributing_client/write", ServiceCallHandlerWrite, request)
        }

        void ResetDistributing(RosSharp.RosBridgeClient.RosConnector RosConnector)
        {

        }

        private static void ServiceCallHandlerWrite(ConnectResponse message)
        {
        }

    }
}
