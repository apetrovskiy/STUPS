/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/3/2014
 * Time: 9:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Exceptions
{
	using System;
	using System.Runtime.Serialization;
	
    /// <summary>
    /// Desctiption of SendingCommonDataItemException.
    /// </summary>
    public class SendingCommonDataItemException : Exception, ISerializable
    {
        public SendingCommonDataItemException()
        {
        }

         public SendingCommonDataItemException(string message) : base(message)
        {
        }

        public SendingCommonDataItemException(string message, Exception innerException) : base(message, innerException)
        {
        }

        // This constructor is needed for serialization.
        protected SendingCommonDataItemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}