/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/7/2012
 * Time: 7:43 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSTestLib
{
    public enum RecordingTypes {
        /// <summary>
        /// Represents an element to be written
        /// </summary>
        Element,
        /// <summary>
        /// Represents the falg that an action was performed
        /// </summary>
        Action,
        /// <summary>
        /// 
        /// </summary>
        Container,
        /// <summary>
        /// 
        /// </summary>
        Change,
        /// <summary>
        /// Represents the data the element has
        /// </summary>
        Data
    }
    
    public enum ActionTypes {
        Click,
        DoubleClick,
        TextInput,
        KeyboardDown
    }
    
    public enum CodeAmount {
        OnlyCode,
        DataCode,
        HeaderDataFooterCode
    }
    
    public enum LogLevels {
        Fatal,
        Error,
        Warn,
        Info,
        Debug,
        Trace
    }
}