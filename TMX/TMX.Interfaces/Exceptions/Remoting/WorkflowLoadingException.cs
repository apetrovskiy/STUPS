/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/14/2014
 * Time: 9:49 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Exceptions
{
	using System;
	using System.Runtime.Serialization;
	
    /// <summary>
    /// Desctiption of WorkflowLoadingException.
    /// </summary>
    public class WorkflowLoadingException : Exception, ISerializable
    {
        public WorkflowLoadingException()
        {
        }

         public WorkflowLoadingException(string message) : base(message)
        {
        }

        public WorkflowLoadingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        // This constructor is needed for serialization.
        protected WorkflowLoadingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}