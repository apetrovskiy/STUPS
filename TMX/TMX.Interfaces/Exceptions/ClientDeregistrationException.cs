/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/25/2014
 * Time: 6:23 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    
    /// <summary>
    /// Desctiption of ClientDeregistrationException.
    /// </summary>
    public class ClientDeregistrationException : Exception, ISerializable
    {
        public ClientDeregistrationException()
        {
        }

         public ClientDeregistrationException(string message) : base(message)
        {
        }

        public ClientDeregistrationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        // This constructor is needed for serialization.
        protected ClientDeregistrationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}