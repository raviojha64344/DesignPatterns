using DesignPattern.MessagePattern.Global;
using DesignPattern.MessagePattern.Messages.Interfaces;

namespace DesignPattern.MessagePattern.Messages
{
    /**/
    public abstract class Message : IMessage
    {
        public void Send()
        {
            GlobalContext.Call(this);
        }
    }
}
