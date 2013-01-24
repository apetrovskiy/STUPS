/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 2:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSTestLib
{
    using System;
    
    /// <summary>
    /// Description of ILanguagePackage.
    /// </summary>
    public interface ILanguagePackage
    {
        string Name { get; }
        string RegionOpen { get; }
        string RegionClose { get; }
        string HereStringOpen { get; }
        string HereStringClose { get; }
        string SingleLineComment { get; }
        string ElementCode { get; }
        string ElementIdentity { get; }
        string ActionCode { get; }
        string Separator { get; }
    }
}
