/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 12/20/2014
 * Time: 10:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.Serialization;

namespace Tmx.Interfaces.Exceptions
{
    /// <summary>
    /// Desctiption of LoadingTestReportException.
    /// </summary>
    public class LoadingTestReportException : Exception, ISerializable
    {
        public LoadingTestReportException()
        {
        }

         public LoadingTestReportException(string message) : base(message)
        {
        }

        public LoadingTestReportException(string message, Exception innerException) : base(message, innerException)
        {
        }

        // This constructor is needed for serialization.
        protected LoadingTestReportException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}