/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/19/2012
 * Time: 2:42 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Collections.Generic;
	using TMX.Interfaces;

    /// <summary>
    /// Description of IBDDFeature.
    /// </summary>
    public interface IBDDFeature : ITestSuite
    {
        string FeatureName { get; }
        string Narrative { get; }
    }
}
