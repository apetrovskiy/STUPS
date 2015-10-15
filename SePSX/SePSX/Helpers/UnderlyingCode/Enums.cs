/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 09.08.2012
 * Time: 20:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    /// <summary>
    /// Used for determining what type (WebDriver or WebElement)
    /// of source search was performed against.
    /// </summary>
    internal enum WebElementsFrom
    {
        WebDriver,
        WebElement
    }
    
    // 20121206
    //public enum FindElementParameters
    internal enum FindElementParameters
    {
        ById,
        ByClassName,
        ByTagName,
        ByName,
        ByLinkText,
        ByPartialLinkText,
        ByCss,
        ByXPath,
        ByJavaScript//,
        //All
    }
    
    // // 20121206
    public enum Drivers {
    //internal enum Drivers {
        Chrome,
        Firefox,
        InternetExplorer,
        Safari,
//        Opera,
        Html //,
//        iOS,
//        Android
    }
    
    // 20121206
    //public enum InternetExplorer {
    internal enum InternetExplorer {
        X86,
        X64
    }
    
    public enum RecorderLanguages {
        PowerShell,
        CSharp,
        Java
    }
    
    internal enum DriverServers
    {
        None,
        Chrome,
        Ie
    }
    
    internal enum DriverServerConstructorOptions
    {
        Bare,
        WithPath,
        WithOptions,
        WithPathAndOptions,
        WithPathAndOptionsAndTimespan,
        WithServiceAndOptionsAndTimespan
    }

//    internal enum ChromeDriverConstructorOptions
//    {
//        chrome_bare,
//        chrome_with_path,
//        chrome_with_options,
//        chrome_with_path_and_options,
//        chrome_with_path_and_options_and_timespan,
//        chrome_with_service_and_options_and_timespan
//    }
//    
//    internal enum IEDriverConstructorOptions
//    {
//        ie_bare,
//        ie_with_path,
//        ie_with_options,
//        ie_with_path_and_options,
//        ie_with_path_and_options_and_timespan,
//        ie_with_service_and_options_and_timespan
//    }
    
    internal enum FirefoxProfileConstructorOptions
    {
        FfBare,
        FfWithPath,
        FfWithPathAndBool
    }

            //bare
            //FirefoxProfile profile
            //ICapabilities capabilities
            //FirefoxBinary binary, FirefoxProfile profile
            //FirefoxBinary binary, FirefoxProfile profile, TimeSpan commandTimeout
            
    internal enum FirefoxDriverConstructorOptions
    {
        FfBare,
        FfWithProfile,
        FfWithCapabilities,
        FfWithBinaryAndProfile,
        FfWithBinaryAndProfileAndTimeout
    }
    
    // // 20121206
    public enum DriverTimeoutTypes {
    //internal enum DriverTimeoutTypes {
        ImplicitlyWait,
        PageLoad,
        Script
    }
    
    // // 20121206
    public enum SwitchToFrameWays {
    //internal enum SwitchToFrameWays {
        FrameIndex,
        FrameName,
        FrameElement
    }
    
    internal enum Constructors {
        FakeWebElementNoParameters,
        FakeWebElementIWebElement,
        FakeWebElementTagNameText,
        FakeWebElementTagNameTextDisplayedEnabledSelected,
        FakeWebElementTagNameTextLocationSize,
        FakeWebElementAsDecorator
    }
}