/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/26/2014
 * Time: 11:03 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Core.Types.Remoting
{
	using System;
	using Tmx.Interfaces.Remoting;
	
	/// <summary>
	/// Description of TestLab.
	/// </summary>
	public class TestLab : ITestLab
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
