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
    public class UnsubscribeRequest : Message
    {
        public const string RosMessageName = "ros_opcua_srvs/Unsubscribe";

        public Address node { get; set; }

        public UnsubscribeRequest()
        {
            this.node = new Address();
        }

        public UnsubscribeRequest(Address node)
        {
            this.node = node;
        }
    }
}
