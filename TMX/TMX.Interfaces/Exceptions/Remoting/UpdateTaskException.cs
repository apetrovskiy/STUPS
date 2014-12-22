/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/24/2014
 * Time: 3:24 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Exceptions
{
	using System;
	using System.Runtime.Serialization;
	
	/// <summary>
	/// Desctiption of UpdateTaskException.
	/// </summary>
	public class UpdateTaskException : Exception, ISerializable
	{
		public UpdateTaskException()
		{
		}

	 	public UpdateTaskException(string message) : base(message)
		{
		}

		public UpdateTaskException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// This constructor is needed for serialization.
		protected UpdateTaskException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}