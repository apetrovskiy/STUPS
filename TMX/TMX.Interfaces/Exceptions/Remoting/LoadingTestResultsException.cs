/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/22/2014
 * Time: 8:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Desctiption of LoadingTestResultsException.
    /// </summary>
    public class LoadingTestResultsException : Exception, ISerializable
    {
        public LoadingTestResultsException()
        {
        }

         public LoadingTestResultsException(string message) : base(message)
        {
        }

        public LoadingTestResultsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        // This constructor is needed for serialization.
        protected LoadingTestResultsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}