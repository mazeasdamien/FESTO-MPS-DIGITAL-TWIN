/* 
 * This message is auto generated by ROS#. Please DO NOT modify.
 * Note:
 * - Comments from the original code will be written in their own line 
 * - Variable sized arrays will be initialized to array of size 0 
 * Please report any issues at 
 * <https://github.com/siemens/ros-sharp> 
 */



namespace RosSharp.RosBridgeClient.MessageTypes.RosOpcua
{
    public class WriteResponse : Message
    {
        public const string RosMessageName = "ros_opcua_srvs/Write";

        public bool success { get; set; }
        public string error_message { get; set; }

        public WriteResponse()
        {
            this.success = false;
            this.error_message = "";
        }

        public WriteResponse(bool success, string error_message)
        {
            this.success = success;
            this.error_message = error_message;
        }
    }
}
