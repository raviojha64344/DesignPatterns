using System;

namespace DesignPattern.MessagePattern.Attributes
{
    /*
     * Message Handler attribute
     */
    public class MessageHandler : Attribute
    {
        public Type Type { get; set; }

        public MessageHandler(Type type)
        {
            Type = type;
        }
    }
}
