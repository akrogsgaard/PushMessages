using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PushMessages.MessageFactories
{
    public abstract class MessageBuilderFactoryBase<T> : IMessageBuilderFactoryBase<T>
    {
        public virtual T BuildMessage()
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> BuildSecondGenerationMessages()
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> BuildMessages(int numberOfMessages)
        {
            var messages = new List<T>();

            for (var x = 0; x < numberOfMessages; x++)
            {
                messages.Add(BuildMessage());
            }

            return messages;
        }
    }
}
