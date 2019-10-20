using System;

namespace Models
{
    [Serializable]
    public class FileMessage : IMessage
    {
        public MessageType Type => MessageType.File;
        public string FileName { get; set; }
        public byte[] Content { get; set; }
    }

}
