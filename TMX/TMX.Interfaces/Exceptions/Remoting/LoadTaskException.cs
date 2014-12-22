/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/23/2014
 * Time: 5:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Exceptions
{
	using System;
	using System.Runtime.Serialization;
	
	/// <summary>
	/// Desctiption of LoadTaskException.
	/// </summary>
	public class LoadTaskException : Exception, ISerializable
	{
		public LoadTaskException()
		{
		}

	 	public LoadTaskException(string message) : base(message)
		{
		}

		public LoadTaskException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// This constructor is needed for serialization.
		protected LoadTaskException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}