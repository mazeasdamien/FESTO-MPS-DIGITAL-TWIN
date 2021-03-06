/* 
 * This message is auto generated by ROS#. Please DO NOT modify.
 * Note:
 * - Comments from the original code will be written in their own line 
 * - Variable sized arrays will be initialized to array of size 0 
 * Please report any issues at 
 * <https://github.com/siemens/ros-sharp> 
 */



using RosSharp.RosBridgeClient.MessageTypes.RosOpcua;

namespace RosSharp.RosBridgeClient.MessageTypes.RosOpcua
{
    public class CallMethodResponse : Message
    {
        public const string RosMessageName = "ros_opcua_srvs/CallMethod";

        public bool success { get; set; }
        public string error_message { get; set; }
        public TypeValue[] data { get; set; }

        public CallMethodResponse()
        {
            this.success = false;
            this.error_message = "";
            this.data = new TypeValue[0];
        }

        public CallMethodResponse(bool success, string error_message, TypeValue[] data)
        {
            this.success = success;
            this.error_message = error_message;
            this.data = data;
        }
    }
}
