/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/27/2012
 * Time: 1:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    /// <summary>
    /// Description of BDDAddinData.
    /// </summary>
    public static class BDDAddinData
    {
        static BDDAddinData()
        {
            Features =
                new List<ScenarioProcessingClass>();
        }
        
        public static List<ScenarioProcessingClass> Features { get; set; }
        
        public static ScenarioProcessingClass GetFeature(string featureName, string narrative)
        {
            //ScenarioProcessingClass feature = null;
            
            System.Collections.Generic.IEnumerable<Tmx.ScenarioProcessingClass> features =
                from f in Features
                where f.FeatureCreated.Title == featureName && f.FeatureCreated.Narrative == narrative
                select f;

            return features.First();
        }
    }
}
