using System.Collections.Generic;
using System.Threading.Tasks;

namespace PushMessages.MessageFactories
{
    public interface IMessageBuilderFactoryBase<out T>
    {
        IEnumerable<T> BuildMessages(int numberOfMessages);
        T BuildMessage();
        IEnumerable<T> BuildSecondGenerationMessages();
    }
}