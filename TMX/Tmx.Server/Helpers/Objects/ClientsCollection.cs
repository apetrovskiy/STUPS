/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/17/2014
 * Time: 8:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server
{
	using System;
	using System.Collections.Generic;
	using Tmx.Interfaces.Remoting;
	
	/// <summary>
	/// Description of ClientsCollection.
	/// </summary>
	public class ClientsCollection
	{
		public static List<ITestClient> Clients = new List<ITestClient>();
		public static int MaxUsedClientId { get; set; }
	}
}
