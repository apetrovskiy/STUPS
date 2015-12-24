/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/19/2012
 * Time: 2:42 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Collections.Generic;
    using Tmx.Interfaces.TestStructure;

    /// <summary>
    /// Description of IBddFeature.
    /// </summary>
    public interface IBddFeature : ITestSuite
    {
        string FeatureName { get; }
        string Narrative { get; }
    }
}
