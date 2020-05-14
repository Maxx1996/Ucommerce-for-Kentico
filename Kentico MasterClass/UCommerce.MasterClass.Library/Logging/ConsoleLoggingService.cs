using System;
using UCommerce.Infrastructure.Logging;

namespace UCommerce.MasterClass.BusinessLogic.Logging
{
    public class ConsoleLoggingService : ILoggingService
    {
        public void Log<T>(string customMessage)
        {
            Console.WriteLine(customMessage);
        }

        public void Log<T>(Exception exception)
        {
            Console.WriteLine(exception);
        }

        public void Log<T>(Exception exception, string customMessage)
        {
            Console.WriteLine(customMessage);
            Console.WriteLine(exception);
        }
    }
}
