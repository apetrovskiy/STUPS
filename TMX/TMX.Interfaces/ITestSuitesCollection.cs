/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17/02/2012
 * Time: 07:16 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
    using System;
    using System.Collections.Generic;
	using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of ITestSuitesCollection.
    /// </summary>
    public interface ITestSuitesCollection
    {
        string Source {get; }
        string SourceId {get; }
        List<ITestSuite> TestSuites {get; }
    }
}
