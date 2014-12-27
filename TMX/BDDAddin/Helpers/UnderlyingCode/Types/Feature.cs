/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/19/2012
 * Time: 3:37 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Collections.Generic;
    using Tmx.Interfaces;
    using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of Feature.
    /// </summary>
    public class Feature : TestSuite, IBDDFeature
    {
        public Feature() : base()
        {
        }
        
        public Feature(string testSuiteName, string testSuiteId) : base(testSuiteName, testSuiteId)
        {
        }
        
        public string FeatureName { get; internal set; }
        public string Narrative { get; internal set; }
    }
}
