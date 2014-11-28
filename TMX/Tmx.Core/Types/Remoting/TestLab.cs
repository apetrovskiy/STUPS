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
        public TestLab()
        {
            Id = Guid.NewGuid();
            Status = TestLabStatuses.Free;
        }
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TestLabStatuses Status { get; set; }
    }
}
