/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/4/2014
 * Time: 4:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.Serialization;

namespace Tmx.Interfaces.Exceptions
{
    /// <summary>
    /// Desctiption of FailedToGetNextTaskException.
    /// </summary>
    public class FailedToGetNextTaskException : Exception, ISerializable
    {
        public FailedToGetNextTaskException()
        {
        }

         public FailedToGetNextTaskException(string message) : base(message)
        {
        }

        public FailedToGetNextTaskException(string message, Exception innerException) : base(message, innerException)
        {
        }

        // This constructor is needed for serialization.
        protected FailedToGetNextTaskException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}