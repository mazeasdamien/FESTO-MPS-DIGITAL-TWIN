using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.RosBridgeClient.MessageTypes.RosOpcua;
using RosSharp.RosBridgeClient;

namespace festo
{
    public class startreset : MonoBehaviour
    {

        public void StartDistributing(RosSharp.RosBridgeClient.RosConnector RosConnector)
        {
            StartCoroutine(StartD(RosConnector));
        }

        public void ResetDistributing(RosSharp.RosBridgeClient.RosConnector RosConnector)
        {
            StartCoroutine(ResetD(RosConnector));
        }

        public void StartSorting(RosSharp.RosBridgeClient.RosConnector RosConnector)
        {
            StartCoroutine(StartS(RosConnector));
        }

        public void ResetSorting(RosSharp.RosBridgeClient.RosConnector RosConnector)
        {
            StartCoroutine(ResetS(RosConnector));
        }

        public void StartHandling(RosSharp.RosBridgeClient.RosConnector RosConnector)
        {
            StartCoroutine(StartH(RosConnector));
        }

        public void ResetHandling(RosSharp.RosBridgeClient.RosConnector RosConnector)
        {
            StartCoroutine(ResetH(RosConnector));
        }

        private static void ServiceCallHandlerWrite(WriteResponse message)
        {
        }

        IEnumerator StartD(RosSharp.RosBridgeClient.RosConnector RosConnector)
        {
            RosConnector.RosSocket.CallService<WriteRequest, WriteResponse>("/distributing/distributing_client/write", ServiceCallHandlerWrite, new WriteRequest(new Address("ns=4;i=4", "''"), new TypeValue("bool", false, 0, 0, 0, 0, 0, 0, 0, 0, 0f, 0, "")));
            yield return new WaitForSeconds(0.5f);
            RosConnector.RosSocket.CallService<WriteRequest, WriteResponse>("/distributing/distributing_client/write", ServiceCallHandlerWrite, new WriteRequest(new Address("ns=4;i=2", "''"), new TypeValue("bool", true, 0, 0, 0, 0, 0, 0, 0, 0, 0f, 0, "")));
        }

        IEnumerator ResetD(RosSharp.RosBridgeClient.RosConnector RosConnector)
        {
            RosConnector.RosSocket.CallService<WriteRequest, WriteResponse>("/distributing/distributing_client/write", ServiceCallHandlerWrite, new WriteRequest(new Address("ns=4;i=2", "''"), new TypeValue("bool", false, 0, 0, 0, 0, 0, 0, 0, 0, 0f, 0, "")));
            yield return new WaitForSeconds(0.5f);
            RosConnector.RosSocket.CallService<WriteRequest, WriteResponse>("/distributing/distributing_client/write", ServiceCallHandlerWrite, new WriteRequest(new Address("ns=4;i=4", "''"), new TypeValue("bool", true, 0, 0, 0, 0, 0, 0, 0, 0, 0f, 0, "")));
        }

        IEnumerator StartS(RosSharp.RosBridgeClient.RosConnector RosConnector)
        {
            RosConnector.RosSocket.CallService<WriteRequest, WriteResponse>("/sorting/sorting_client/write", ServiceCallHandlerWrite, new WriteRequest(new Address("ns=4;i=8", "''"), new TypeValue("bool", false, 0, 0, 0, 0, 0, 0, 0, 0, 0f, 0, "")));
            yield return new WaitForSeconds(0.5f);
            RosConnector.RosSocket.CallService<WriteRequest, WriteResponse>("/sorting/sorting_client/write", ServiceCallHandlerWrite, new WriteRequest(new Address("ns=4;i=7", "''"), new TypeValue("bool", true, 0, 0, 0, 0, 0, 0, 0, 0, 0f, 0, "")));
        }

        IEnumerator ResetS(RosSharp.RosBridgeClient.RosConnector RosConnector)
        {
            RosConnector.RosSocket.CallService<WriteRequest, WriteResponse>("/sorting/sorting_client/write", ServiceCallHandlerWrite, new WriteRequest(new Address("ns=4;i=7", "''"), new TypeValue("bool", false, 0, 0, 0, 0, 0, 0, 0, 0, 0f, 0, "")));
            yield return new WaitForSeconds(0.5f);
            RosConnector.RosSocket.CallService<WriteRequest, WriteResponse>("/sorting/sorting_client/write", ServiceCallHandlerWrite, new WriteRequest(new Address("ns=4;i=8", "''"), new TypeValue("bool", true, 0, 0, 0, 0, 0, 0, 0, 0, 0f, 0, "")));
        }

        IEnumerator StartH(RosSharp.RosBridgeClient.RosConnector RosConnector)
        {
            RosConnector.RosSocket.CallService<WriteRequest, WriteResponse>("/handling/handling_client/write", ServiceCallHandlerWrite, new WriteRequest(new Address("ns=4;i=27", "''"), new TypeValue("bool", false, 0, 0, 0, 0, 0, 0, 0, 0, 0f, 0, "")));
            yield return new WaitForSeconds(0.5f);
            RosConnector.RosSocket.CallService<WriteRequest, WriteResponse>("/handling/handling_client/write", ServiceCallHandlerWrite, new WriteRequest(new Address("ns=4;i=26", "''"), new TypeValue("bool", true, 0, 0, 0, 0, 0, 0, 0, 0, 0f, 0, "")));
        }

        IEnumerator ResetH(RosSharp.RosBridgeClient.RosConnector RosConnector)
        {
            RosConnector.RosSocket.CallService<WriteRequest, WriteResponse>("/handling/handling_client/write", ServiceCallHandlerWrite, new WriteRequest(new Address("ns=4;i=26", "''"), new TypeValue("bool", false, 0, 0, 0, 0, 0, 0, 0, 0, 0f, 0, "")));
            yield return new WaitForSeconds(0.5f);
            RosConnector.RosSocket.CallService<WriteRequest, WriteResponse>("/handling/handling_client/write", ServiceCallHandlerWrite, new WriteRequest(new Address("ns=4;i=27", "''"), new TypeValue("bool", true, 0, 0, 0, 0, 0, 0, 0, 0, 0f, 0, "")));
        }
    }
}
