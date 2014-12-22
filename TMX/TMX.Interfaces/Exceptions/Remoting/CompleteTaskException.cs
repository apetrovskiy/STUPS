/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/29/2014
 * Time: 5:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Exceptions
{
	using System;
	using System.Runtime.Serialization;
	
    /// <summary>
    /// Desctiption of CompleteTaskException.
    /// </summary>
    public class CompleteTaskException : Exception, ISerializable
    {
        public CompleteTaskException()
        {
        }

         public CompleteTaskException(string message) : base(message)
        {
        }

        public CompleteTaskException(string message, Exception innerException) : base(message, innerException)
        {
        }

        // This constructor is needed for serialization.
        protected CompleteTaskException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}