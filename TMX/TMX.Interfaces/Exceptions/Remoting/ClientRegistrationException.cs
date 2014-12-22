/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/23/2014
 * Time: 5:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Exceptions
{
	using System;
	using System.Runtime.Serialization;
	
	/// <summary>
	/// Desctiption of ClientRegistrationException.
	/// </summary>
	public class ClientRegistrationException : Exception, ISerializable
	{
		public ClientRegistrationException()
		{
		}

	 	public ClientRegistrationException(string message) : base(message)
		{
		}

		public ClientRegistrationException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// This constructor is needed for serialization.
		protected ClientRegistrationException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}