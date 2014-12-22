/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/24/2014
 * Time: 7:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Exceptions
{
	using System;
	using System.Runtime.Serialization;
	
	/// <summary>
	/// Desctiption of WrongTaskDataException.
	/// </summary>
	public class WrongTaskDataException : Exception, ISerializable
	{
		public WrongTaskDataException()
		{
		}

	 	public WrongTaskDataException(string message) : base(message)
		{
		}

		public WrongTaskDataException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// This constructor is needed for serialization.
		protected WrongTaskDataException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}