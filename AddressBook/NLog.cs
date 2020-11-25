using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class NLog
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Fine-grained statements concerning program state typically used for debugging
        /// </summary>
        /// <param name="message">The message.</param>
        
        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        /// <summary>
        /// statements that describes non-fatal errors in application
        /// </summary>
        /// <param name="message">The message.</param>

        public void LogError(string message)
        {
            logger.Error(message);
        }
    }
}
