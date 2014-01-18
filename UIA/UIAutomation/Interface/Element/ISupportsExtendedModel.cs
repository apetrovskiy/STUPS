/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/4/2014
 * Time: 12:54 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    /// <summary>
    /// Description of ISupportsExtendedModel.
    /// </summary>
    public interface ISupportsExtendedModel
    {
        IExtendedModelHolder Descendants { get; }
        IExtendedModelHolder Children { get; }
        IControlInputHolder Control { get; }
//        IInputSimulatorHolder Mouse { get; }
//        IInputSimulatorHolder Keyboard { get; }
//        IInputSimulatorHolder Touch { get; }
        IMouseInputHolder Mouse { get; }
        IKeyboardInputHolder Keyboard { get; }
        ITouchInputHolder Touch { get; }
    }
}
