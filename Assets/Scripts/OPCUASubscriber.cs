/*
? CentraleSupelec, 2017
Author: Dr. Jeremy Fix (jeremy.fix@centralesupelec.fr)

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

// Adjustments to new Publication Timing and Execution Framework
// ? Siemens AG, 2018, Dr. Martin Bischoff (martin.bischoff@siemens.com)

using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    [RequireComponent(typeof(RosConnector))]
    public class OPCUASubscriber : UnitySubscriber<MessageTypes.RosOpcua.TypeValue>
    {
        public MeshRenderer mat;

        public bool boolValue;
        public int intValue;
        public string stringValue;
        private bool isMessageReceived;

        protected override void Start()
        {
            base.Start();
        }
        private void Update()
        {
            if (isMessageReceived)
                ProcessMessage();
        }

        protected override void ReceiveMessage(MessageTypes.RosOpcua.TypeValue message)
        {
            boolValue = message.bool_d;
            intValue = message.int16_d;
            stringValue = message.string_d;
            isMessageReceived = true;
        }

        private void ProcessMessage()
        {
            if (boolValue)
                mat.material.color = Color.green;
            else
                mat.material.color = Color.red;

            isMessageReceived = false;
        }
    }
}