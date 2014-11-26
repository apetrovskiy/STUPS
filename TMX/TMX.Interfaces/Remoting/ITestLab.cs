/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/26/2014
 * Time: 11:02 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Remoting
{
	using System;
	
	/// <summary>
	/// Description of ITestLab.
	/// </summary>
	public interface ITestLab
	{
		Guid Id { get; set; }
		string Name { get; set; }
		string Description { get; set; }
		TestLabStatuses Status { get; set; }
	}
}
