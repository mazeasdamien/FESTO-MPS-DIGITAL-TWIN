using UnityEngine;
using UnityEngine.UI;

namespace RosSharp.RosBridgeClient
{
    [RequireComponent(typeof(RosConnector))]
    public class compressImageSubscriber : UnitySubscriber<MessageTypes.Sensor.CompressedImage>
    {
        public RawImage rawTexture;

        private Texture2D texture2D;
        private byte[] imageData;
        private bool isMessageReceived;

        protected override void Start()
        {
            base.Start();
            texture2D = new Texture2D(1, 1);
        }
        private void Update()
        {
            if (isMessageReceived)
                ProcessMessage();
        }

        protected override void ReceiveMessage(MessageTypes.Sensor.CompressedImage compressedImage)
        {
            imageData = compressedImage.data;
            //print(imageData.Length);
            isMessageReceived = true;
        }

        private void ProcessMessage()
        {
            texture2D.LoadImage(imageData);
            texture2D.Apply();
            rawTexture.texture = texture2D;
            isMessageReceived = false;
        }

    }
}
