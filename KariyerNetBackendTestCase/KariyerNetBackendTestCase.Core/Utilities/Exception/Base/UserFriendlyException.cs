using System.Runtime.Serialization;

namespace KariyerNetBackendTestCase.Core.Utilities.Exception.Base
{
    public abstract class UserFriendlyException:System.Exception
    {
        protected UserFriendlyException()
        {

        }
     
        protected UserFriendlyException(string message) : base(message)
        {

        }

        protected UserFriendlyException(string message, System.Exception innerException) : base(message, innerException)
        {

        }

        protected UserFriendlyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
