/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/11/2014
 * Time: 4:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Core
{
    using System;
    using Interfaces.Remoting;
    using Interfaces;
    
    /// <summary>
    /// Description of CodeBlock.
    /// </summary>
    public class CodeBlock : ICodeBlock
    {
        public string Code { get; set; }
    }
}
