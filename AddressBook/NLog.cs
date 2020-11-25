using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class NLog
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        public void LogDebug(string message)
        {
            logger.Debug(message);
        }
    }
}
