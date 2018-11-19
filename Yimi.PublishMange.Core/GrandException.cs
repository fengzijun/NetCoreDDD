using System;

namespace Yimi.PublishManage.Core
{
    /// <summary>
    /// Represents errors that occur during application execution
    /// </summary>
    [Serializable]
    public class YimiException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the Exception class.
        /// </summary>
        public YimiException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Exception class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public YimiException(string message)
            : base(message)
        {
        }

    }
}
