/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/21/2014
 * Time: 9:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Desctiption of ClientNotRegisterdException.
    /// </summary>
    public class ClientNotRegisteredException : Exception, ISerializable
    {
        public ClientNotRegisteredException()
        {
        }

         public ClientNotRegisteredException(string message) : base(message)
        {
        }

        public ClientNotRegisteredException(string message, Exception innerException) : base(message, innerException)
        {
        }

        // This constructor is needed for serialization.
        protected ClientNotRegisteredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}