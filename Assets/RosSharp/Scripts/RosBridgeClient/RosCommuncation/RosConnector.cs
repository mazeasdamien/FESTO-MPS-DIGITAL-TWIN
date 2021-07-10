/*
© Siemens AG, 2017-2019
Author: Dr. Martin Bischoff (martin.bischoff@siemens.com)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

<http://www.apache.org/licenses/LICENSE-2.0>.

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System;
using System.Threading;
using RosSharp.RosBridgeClient.Protocols;
using UnityEngine;
using RosSharp.RosBridgeClient.MessageTypes.RosOpcua;

namespace RosSharp.RosBridgeClient
{
    public class RosConnector : MonoBehaviour
    {
        public int SecondsTimeout = 10;

        public RosSocket RosSocket { get; private set; }
        public RosSocket.SerializerEnum Serializer;
        public Protocol protocol;
        public string RosBridgeServerUrl = "ws://138.250.144.210:9090";
        public string OPCUAServerUrlPLCHandling = "opc.tcp://192.168.1.11:4840";
        public bool isConnected;

        public ManualResetEvent IsConnected { get; private set; }

        public virtual void Awake()
        {
            IsConnected = new ManualResetEvent(false);
            new Thread(ConnectAndWait).Start();
        }

        protected void ConnectAndWait()
        {
            RosSocket = ConnectToRos(protocol, RosBridgeServerUrl, OnConnected, OnClosed, Serializer);

            // OPCUA connect to server
            ConnectRequest request = new ConnectRequest(OPCUAServerUrlPLCHandling);
            RosSocket.CallService<ConnectRequest, ConnectResponse>("/opcua/opcua_client/connect", ServiceCallHandlerConnect, request);

            if (!IsConnected.WaitOne(SecondsTimeout * 1000))
                Debug.LogWarning("Failed to connect to RosBridge at: " + RosBridgeServerUrl);
        }

        public static RosSocket ConnectToRos(Protocol protocolType, string serverUrl, EventHandler onConnected = null, EventHandler onClosed = null, RosSocket.SerializerEnum serializer = RosSocket.SerializerEnum.Microsoft)
        {
            IProtocol protocol = ProtocolInitializer.GetProtocol(protocolType, serverUrl);
            protocol.OnConnected += onConnected;
            protocol.OnClosed += onClosed;

            return new RosSocket(protocol, serializer);
        }

        private void OnApplicationQuit()
        {
            RosSocket.Close();
        }

        private void OnConnected(object sender, EventArgs e)
        {
            IsConnected.Set();
            isConnected = true;
            Debug.Log("Connected to RosBridge: " + RosBridgeServerUrl);
        }

        private void OnClosed(object sender, EventArgs e)
        {
            DisconnectRequest request = new DisconnectRequest();
            RosSocket.CallService<DisconnectRequest, DisconnectResponse>("/opcua/opcua_client/disconnect", ServiceCallHandlerDisconnect, request);
            IsConnected.Reset();
            isConnected = false;
            Debug.Log("Disconnected from RosBridge: " + RosBridgeServerUrl);
        }

        private static void ServiceCallHandlerConnect(ConnectResponse message)
        {
        }

        private static void ServiceCallHandlerDisconnect(DisconnectResponse message)
        {
        }
    }
}