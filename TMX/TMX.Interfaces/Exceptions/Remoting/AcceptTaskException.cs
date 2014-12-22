/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/23/2014
 * Time: 5:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Exceptions
{
	using System;
	using System.Runtime.Serialization;
	
	/// <summary>
	/// Desctiption of AcceptTaskException.
	/// </summary>
	public class AcceptTaskException : Exception, ISerializable
	{
		public AcceptTaskException()
		{
		}

	 	public AcceptTaskException(string message) : base(message)
		{
		}

		public AcceptTaskException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// This constructor is needed for serialization.
		protected AcceptTaskException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}