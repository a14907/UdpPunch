using System;

namespace Models
{
    [Serializable]
    public class TextMessage : IMessage
    {
        public MessageType Type => MessageType.Text;
        public string Content { get; set; }
    }

}
