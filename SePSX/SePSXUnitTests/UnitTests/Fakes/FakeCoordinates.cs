/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/13/2012
 * Time: 1:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Interactions.Internal;
    using OpenQA.Selenium.Internal;
    using System.Drawing;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    /// <summary>
    /// Description of FakeCoordinates.
    /// </summary>
    public class FakeCoordinates : ICoordinates
//    {
//        public FakeCoordinates()
//        {
//        }
//    }
//    
//	internal class RemoteCoordinates : ICoordinates
	{
		//private RemoteWebElement element;
		private FakeWebElement element;
		/// <summary>
		///       Gets the location of an element in absolute screen coordinates.
		///       </summary>
		public Point LocationOnScreen
		{
			get
			{
				return this.element.LocationOnScreenOnceScrolledIntoView;
			}
		}
		/// <summary>
		///       Gets the location of an element relative to the origin of the view port.
		///       </summary>
		public Point LocationInViewport
		{
			get
			{
				throw new NotImplementedException();
			}
		}
		/// <summary>
		///       Gets the location of an element's position within the HTML DOM.
		///       </summary>
		public Point LocationInDom
		{
			get
			{
				throw new NotImplementedException();
			}
		}
		/// <summary>
		///       Gets a locator providing a user-defined location for this element.
		///       </summary>
		public object AuxiliaryLocator
		{
			get
			{
			    return new object(); // this.element.InternalElementId;
			}
		}
		/// <summary>
		///       Initializes a new instance of the <see cref="T:OpenQA.Selenium.Remote.RemoteCoordinates" /> class.
		///       </summary>
		/// <param name="element">The <see cref="T:OpenQA.Selenium.Remote.RemoteWebElement" /> to be located.</param>
		//public RemoteCoordinates(RemoteWebElement element)
		//public FakeCoordinates(RemoteWebElement element)
		public FakeCoordinates(FakeWebElement element)
		{
			this.element = element;
		}
	}
}
