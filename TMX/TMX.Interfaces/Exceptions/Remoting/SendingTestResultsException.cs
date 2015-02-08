/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/28/2014
 * Time: 5:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    
    /// <summary>
    /// Desctiption of SendingTestResultsException.
    /// </summary>
    public class SendingTestResultsException : Exception, ISerializable
    {
        public SendingTestResultsException()
        {
        }

         public SendingTestResultsException(string message) : base(message)
        {
        }

        public SendingTestResultsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        // This constructor is needed for serialization.
        protected SendingTestResultsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}