/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/1/2012
 * Time: 10:13 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests
{
    using System;
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Moq;
    using System.Text.RegularExpressions;
    
    /// <summary>
    /// Description of FakeBy.
    /// </summary>
    [Serializable]
    public class FakeBy
    {
        public FakeBy()
        {
            var byMock = new Mock<By>();
            fakeBy = byMock.Object;
        }
        
        private static By fakeBy;
    //}
    
    /// <summary>
    ///       Provides a mechanism by which to find elements within a document.
    ///       </summary>
    /// <remarks>It is possible to create your own locating mechanisms for finding documents.
    ///       In order to do this,subclass this class and override the protected methods. However,
    ///       it is expected that that all subclasses rely on the basic finding mechanisms provided 
    ///       through static methods of this class. An example of this can be found in OpenQA.Support.ByIdOrName
    ///       </remarks>
    
    //public class By
    //{
        private string description = "OpenQA.Selenium.By";
        private Func<ISearchContext, IWebElement> findElementMethod;
        private Func<ISearchContext, ReadOnlyCollection<IWebElement>> findElementsMethod;
        
#region commented
//        /// <summary>
//        ///       Gets or sets the value of the description for this <see cref="T:OpenQA.Selenium.By" /> class instance.
//        ///       </summary>
//        protected string Description
//        {
//            get
//            {
//                return this.description;
//            }
//            set
//            {
//                this.description = value;
//            }
//        }
//        /// <summary>
//        ///       Gets or sets the method used to find a single element matching specified criteria.
//        ///       </summary>
//        protected Func<ISearchContext, IWebElement> FindElementMethod
//        {
//            get
//            {
//                return this.findElementMethod;
//            }
//            set
//            {
//                this.findElementMethod = value;
//            }
//        }
//        /// <summary>
//        ///       Gets or sets the method used to find all elements matching specified criteria.
//        ///       </summary>
//        protected Func<ISearchContext, ReadOnlyCollection<IWebElement>> FindElementsMethod
//        {
//            get
//            {
//                return this.findElementsMethod;
//            }
//            set
//            {
//                this.findElementsMethod = value;
//            }
//        }
//        /// <summary>
//        ///       Initializes a new instance of the <see cref="T:OpenQA.Selenium.By" /> class.
//        ///       </summary>
//        protected By()
//        {
//        }
//        /// <summary>
//        ///       Initializes a new instance of the <see cref="T:OpenQA.Selenium.By" /> class using the given functions to find elements.
//        ///       </summary>
//        /// <param name="findElementMethod">A function that takes an object implementing <see cref="T:OpenQA.Selenium.ISearchContext" />
//        ///       and returns the found <see cref="T:OpenQA.Selenium.IWebElement" />.</param>
//        /// <param name="findElementsMethod">A function that takes an object implementing <see cref="T:OpenQA.Selenium.ISearchContext" /> 
//        ///       and returns a <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1" /> of the found<see cref="T:OpenQA.Selenium.IWebElement">IWebElements</see>.
//        ///       <see cref="T:OpenQA.Selenium.IWebElement">IWebElements</see>/&gt;.</param>
//        protected By(Func<ISearchContext, IWebElement> findElementMethod, Func<ISearchContext, ReadOnlyCollection<IWebElement>> findElementsMethod)
//        {
//            this.findElementMethod = findElementMethod;
//            this.findElementsMethod = findElementsMethod;
//        }
#endregion commented

        /// <summary>
        ///       Gets a mechanism to find elements by their ID.
        ///       </summary>
        /// <param name="idToFind">The ID to find.</param>
        /// <returns>A <see cref="T:OpenQA.Selenium.By" /> object the driver can use to find the elements.</returns>
        public static By Id(string idToFind)
        {
            if (idToFind == null)
            {
                throw new ArgumentNullException("idToFind", "Cannot find elements with a null id attribute.");
            }
            
            //
            //
            //return By;
//            var byMock = new Mock<By>();
//            return byMock.Object;
            return fakeBy;
            //
            //
#region commented
//            return new By
//            {
//                findElementMethod = (ISearchContext context) => ((IFindsById)context).FindElementById(idToFind),
//                findElementsMethod = (ISearchContext context) => ((IFindsById)context).FindElementsById(idToFind),
//                description = "By.Id: " + idToFind
//            };
#endregion commented
        }
        /// <summary>
        ///       Gets a mechanism to find elements by their link text.
        ///       </summary>
        /// <param name="linkTextToFind">The link text to find.</param>
        /// <returns>A <see cref="T:OpenQA.Selenium.By" /> object the driver can use to find the elements.</returns>
        public static By LinkText(string linkTextToFind)
        {
            if (linkTextToFind == null)
            {
                throw new ArgumentNullException("linkTextToFind", "Cannot find elements when link text is null.");
            }
            //
            //
            //return By;
//            var byMock = new Mock<By>();
//            return byMock.Object;
            return fakeBy;
            //
            //
#region commented
//            return new By
//            {
//                findElementMethod = (ISearchContext context) => ((IFindsByLinkText)context).FindElementByLinkText(linkTextToFind),
//                findElementsMethod = (ISearchContext context) => ((IFindsByLinkText)context).FindElementsByLinkText(linkTextToFind),
//                description = "By.LinkText: " + linkTextToFind
//            };
#endregion commented
        }
        /// <summary>
        ///       Gets a mechanism to find elements by their name.
        ///       </summary>
        /// <param name="nameToFind">The name to find.</param>
        /// <returns>A <see cref="T:OpenQA.Selenium.By" /> object the driver can use to find the elements.</returns>
        public static By Name(string nameToFind)
        {
            if (nameToFind == null)
            {
                throw new ArgumentNullException("nameToFind", "Cannot find elements when name text is null.");
            }
            
            //
            //
            //return By;
//            var byMock = new Mock<By>();
//            return byMock.Object;
            return fakeBy;
            //
            //
#region commented
//            return new By
//            {
//                findElementMethod = (ISearchContext context) => ((IFindsByName)context).FindElementByName(nameToFind),
//                findElementsMethod = (ISearchContext context) => ((IFindsByName)context).FindElementsByName(nameToFind),
//                description = "By.Name: " + nameToFind
//            };
#endregion commented
        }
        /// <summary>
        ///       Gets a mechanism to find elements by an XPath query.
        ///       </summary>
        /// <param name="xpathToFind">The XPath query to use.</param>
        /// <returns>A <see cref="T:OpenQA.Selenium.By" /> object the driver can use to find the elements.</returns>
        public static By XPath(string xpathToFind)
        {
            if (xpathToFind == null)
            {
                throw new ArgumentNullException("xpathToFind", "Cannot find elements when the XPath expression is null.");
            }
            //
            //
            //return By;
//            var byMock = new Mock<By>();
//            return byMock.Object;
            return fakeBy;
            //
            //
#region commented
//            return new By
//            {
//                findElementMethod = (ISearchContext context) => ((IFindsByXPath)context).FindElementByXPath(xpathToFind),
//                findElementsMethod = (ISearchContext context) => ((IFindsByXPath)context).FindElementsByXPath(xpathToFind),
//                description = "By.XPath: " + xpathToFind
//            };
#endregion commented
        }
        /// <summary>
        ///       Gets a mechanism to find elements by their CSS class.
        ///       </summary>
        /// <param name="classNameToFind">The CSS class to find.</param>
        /// <returns>A <see cref="T:OpenQA.Selenium.By" /> object the driver can use to find the elements.</returns>
        /// <remarks>If an element has many classes then this will match against each of them.
        ///       For example if the value is "one two onone", then the following values for the 
        ///       className parameter will match: "one" and "two".</remarks>
        public static By ClassName(string classNameToFind)
        {
            if (classNameToFind == null)
            {
                throw new ArgumentNullException("classNameToFind", "Cannot find elements when the class name expression is null.");
            }
            if (new Regex(".*\\s+.*").IsMatch(classNameToFind))
            {
                throw new IllegalLocatorException("Compound class names are not supported. Consider searching for one class name and filtering the results.");
            }
            //
            //
            //return By;
//            var byMock = new Mock<By>();
//            return byMock.Object;
            return fakeBy;
            //
            //
#region commented
//            return new By
//            {
//                findElementMethod = (ISearchContext context) => ((IFindsByClassName)context).FindElementByClassName(classNameToFind),
//                findElementsMethod = (ISearchContext context) => ((IFindsByClassName)context).FindElementsByClassName(classNameToFind),
//                description = "By.ClassName[Contains]: " + classNameToFind
//            };
#endregion commented
        }
        /// <summary>
        ///       Gets a mechanism to find elements by a partial match on their link text.
        ///       </summary>
        /// <param name="partialLinkTextToFind">The partial link text to find.</param>
        /// <returns>A <see cref="T:OpenQA.Selenium.By" /> object the driver can use to find the elements.</returns>
        public static By PartialLinkText(string partialLinkTextToFind)
        {
            //
            //
            //return By;
//            var byMock = new Mock<By>();
//            return byMock.Object;
            return fakeBy;
            //
            //
#region commented
//            return new By
//            {
//                findElementMethod = (ISearchContext context) => ((IFindsByPartialLinkText)context).FindElementByPartialLinkText(partialLinkTextToFind),
//                findElementsMethod = (ISearchContext context) => ((IFindsByPartialLinkText)context).FindElementsByPartialLinkText(partialLinkTextToFind),
//                description = "By.PartialLinkText: " + partialLinkTextToFind
//            };
#endregion commented
        }
        /// <summary>
        ///       Gets a mechanism to find elements by their tag name.
        ///       </summary>
        /// <param name="tagNameToFind">The tag name to find.</param>
        /// <returns>A <see cref="T:OpenQA.Selenium.By" /> object the driver can use to find the elements.</returns>
        public static By TagName(string tagNameToFind)
        {
            if (tagNameToFind == null)
            {
                throw new ArgumentNullException("tagNameToFind", "Cannot find elements when name tag name is null.");
            }
            //
            //
            //return By;
//            var byMock = new Mock<By>();
//            return byMock.Object;
            return fakeBy;
            //
            //
#region commented
//            return new By
//            {
//                findElementMethod = (ISearchContext context) => ((IFindsByTagName)context).FindElementByTagName(tagNameToFind),
//                findElementsMethod = (ISearchContext context) => ((IFindsByTagName)context).FindElementsByTagName(tagNameToFind),
//                description = "By.TagName: " + tagNameToFind
//            };
#endregion commented
        }
        /// <summary>
        ///       Gets a mechanism to find elements by their cascading stylesheet (CSS) selector.
        ///       </summary>
        /// <param name="cssSelectorToFind">The CSS selector to find.</param>
        /// <returns>A <see cref="T:OpenQA.Selenium.By" /> object the driver can use to find the elements.</returns>
        public static By CssSelector(string cssSelectorToFind)
        {
            if (cssSelectorToFind == null)
            {
                throw new ArgumentNullException("cssSelectorToFind", "Cannot find elements when name CSS selector is null.");
            }
            //
            //
            //return By;
//            var byMock = new Mock<By>();
//            return byMock.Object;
            return fakeBy;
            //
            //
#region commented
//            return new By
//            {
//                findElementMethod = (ISearchContext context) => ((IFindsByCssSelector)context).FindElementByCssSelector(cssSelectorToFind),
//                findElementsMethod = (ISearchContext context) => ((IFindsByCssSelector)context).FindElementsByCssSelector(cssSelectorToFind),
//                description = "By.CssSelector: " + cssSelectorToFind
//            };
#endregion commented
        }
        
#region commented
//        /// <summary>
//        ///       Determines if two <see cref="T:OpenQA.Selenium.By" /> instances are equal.
//        ///       </summary>
//        /// <param name="one">One instance to compare.</param>
//        /// <param name="two">The other instance to compare.</param>
//        /// <returns>
//        ///   <see langword="true" /> if the two instances are equal; otherwise, <see langword="false" />.</returns>
//        public static bool operator ==(By one, By two)
//        {
//            return object.ReferenceEquals(one, two) || (one != null && two != null && one.Equals(two));
//        }
//        /// <summary>
//        ///       Determines if two <see cref="T:OpenQA.Selenium.By" /> instances are unequal.
//        ///       </summary>s
//        ///       <param name="one">One instance to compare.</param><param name="two">The other instance to compare.</param><returns><see langword="true" /> if the two instances are not equal; otherwise, <see langword="false" />.</returns>
//        public static bool operator !=(By one, By two)
//        {
//            return !(one == two);
//        }
//        /// <summary>
//        ///       Finds the first element matching the criteria.
//        ///       </summary>
//        /// <param name="context">An <see cref="T:OpenQA.Selenium.ISearchContext" /> object to use to search for the elements.</param>
//        /// <returns>The first matching <see cref="T:OpenQA.Selenium.IWebElement" /> on the current context.</returns>
#endregion commented

        public virtual IWebElement FindElement(ISearchContext context)
        {
            return this.findElementMethod(context);
        }
        /// <summary>
        ///       Finds all elements matching the criteria.
        ///       </summary>
        /// <param name="context">An <see cref="T:OpenQA.Selenium.ISearchContext" /> object to use to search for the elements.</param>
        /// <returns>A <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1" /> of all <see cref="T:OpenQA.Selenium.IWebElement">WebElements</see>
        ///       matching the current criteria, or an empty list if nothing matches.</returns>
        public virtual ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
        {
            return this.findElementsMethod(context);
        }
        /// <summary>
        ///       Gets a string representation of the finder.
        ///       </summary>
        /// <returns>The string displaying the finder content.</returns>
        public override string ToString()
        {
            return this.description;
        }
        /// <summary>
        ///       Determines whether the specified <see cref="T:System.Object">Object</see> is equal 
        ///       to the current <see cref="T:System.Object">Object</see>.
        ///       </summary>
        /// <param name="obj">The <see cref="T:System.Object">Object</see> to compare with the 
        ///       current <see cref="T:System.Object">Object</see>.</param>
        /// <returns>
        ///   <see langword="true" /> if the specified <see cref="T:System.Object">Object</see>
        ///       is equal to the current <see cref="T:System.Object">Object</see>; otherwise,
        ///       <see langword="false" />.</returns>
        public override bool Equals(object obj)
        {
//            By other = obj as By;
//            return other != null && this.description.Equals(other.description);
            //
            //
            return true;
            //
            //
        }
        /// <summary>
        ///       Serves as a hash function for a particular type.
        ///       </summary>
        /// <returns>A hash code for the current <see cref="T:System.Object">Object</see>.</returns>
        public override int GetHashCode()
        {
            return this.description.GetHashCode();
        }
    }
}
