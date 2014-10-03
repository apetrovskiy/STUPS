/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/3/2014
 * Time: 8:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Exceptions
{
	using System;
	using System.Runtime.Serialization;
	
    /// <summary>
    /// Desctiption of SendingDetailedStatusException.
    /// </summary>
    public class SendingDetailedStatusException : Exception, ISerializable
    {
        public SendingDetailedStatusException()
        {
        }

         public SendingDetailedStatusException(string message) : base(message)
        {
        }

        public SendingDetailedStatusException(string message, Exception innerException) : base(message, innerException)
        {
        }

        // This constructor is needed for serialization.
        protected SendingDetailedStatusException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}