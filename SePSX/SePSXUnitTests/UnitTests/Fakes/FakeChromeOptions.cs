/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/30/2012
 * Time: 9:05 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    
    /// <summary>
    /// Description of FakeChromeOptions.
    /// </summary>
    public class FakeChromeOptions
    {
		/// <summary>
		///       Gets the name of the capability used to store Chrome options in
		///       a <see cref="T:OpenQA.Selenium.Remote.DesiredCapabilities" /> object.
		///       </summary>
		public static readonly string Capability = "chromeOptions";
		private string binaryLocation = string.Empty;
		private List<string> arguments = new List<string>();
		private List<string> extensionFiles = new List<string>();
		/// <summary>
		///       Gets or sets the location of the Chrome browser's binary executable file.
		///       </summary>
		//[JsonProperty("binary")]
		public string BinaryLocation
		{
			get
			{
				return this.binaryLocation;
			}
			set
			{
				this.binaryLocation = value;
			}
		}
		/// <summary>
		///       Gets the list of arguments appended to the Chrome command line as a string array.
		///       </summary>
		//[JsonProperty("args")]
		public ReadOnlyCollection<string> Arguments
		{
			get
			{
				return this.arguments.AsReadOnly();
			}
		}
		/// <summary>
		///       Gets the list of extensions to be installed as an array of base64-encoded strings.
		///       </summary>
		//[JsonProperty("extensions")]
		public ReadOnlyCollection<string> Extensions
		{
			get
			{
				List<string> encodedExtensions = new List<string>();
				foreach (string extensionFile in this.extensionFiles)
				{
					//byte[] extensionByteArray = File.ReadAllBytes(extensionFile);
					string encodedExtension = "extension"; //Convert.ToBase64String(extensionByteArray);
					encodedExtensions.Add(encodedExtension);
				}
				return encodedExtensions.AsReadOnly();
			}
		}
		/// <summary>
		///       Adds a single argument to the list of arguments to be appended to the Chrome.exe command line.
		///       </summary>
		/// <param name="argument">The argument to add.</param>
		public void AddArgument(string argument)
		{
			if (string.IsNullOrEmpty(argument))
			{
				throw new ArgumentException("argument must not be null or empty", "argument");
			}
			this.AddArguments(new string[]
			{
				argument
			});
		}
		/// <summary>
		///       Adds arguments to be appended to the Chrome.exe command line.
		///       </summary>
		/// <param name="arguments">An array of arguments to add.</param>
		public void AddArguments(params string[] arguments)
		{
			this.AddArguments(new List<string>(arguments));
		}
		/// <summary>
		///       Adds arguments to be appended to the Chrome.exe command line.
		///       </summary>
		/// <param name="arguments">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> object of arguments to add.</param>
		public void AddArguments(IEnumerable<string> arguments)
		{
			if (arguments == null)
			{
				throw new ArgumentNullException("arguments", "arguments must not be null");
			}
			this.arguments.AddRange(arguments);
		}
		/// <summary>
		///       Adds a path to a packed Chrome extension (.crx file) to the list of extensions 
		///       to be installed in the instance of Chrome.
		///       </summary>
		/// <param name="pathToExtension">The full path to the extension to add.</param>
		public void AddExtension(string pathToExtension)
		{
			if (string.IsNullOrEmpty(pathToExtension))
			{
				throw new ArgumentException("pathToExtension must not be null or empty", "pathToExtension");
			}
			this.AddExtensions(new string[]
			{
				pathToExtension
			});
		}
		/// <summary>
		///       Adds a list of paths to packed Chrome extensions (.crx files) to be installed
		///       in the instance of Chrome.
		///       </summary>
		/// <param name="extensions">An array of full paths to the extensions to add.</param>
		public void AddExtensions(params string[] extensions)
		{
			this.AddExtensions(new List<string>(extensions));
		}
		/// <summary>
		///       Adds a list of paths to packed Chrome extensions (.crx files) to be installed
		///       in the instance of Chrome.
		///       </summary>
		/// <param name="extensions">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of full paths to the extensions to add.</param>
		public void AddExtensions(IEnumerable<string> extensions)
		{
			if (extensions == null)
			{
				throw new ArgumentNullException("extensions", "extensions must not be null");
			}
//			foreach (string extension in extensions)
//			{
//				if (!File.Exists(extension))
//				{
//					throw new FileNotFoundException("No extension found at the specified path", extension);
//				}
//				this.extensionFiles.Add(extension);
//			}
		}
//		/// <summary>
//		///       Returns DesiredCapabiliites for Chrome with these options included as
//		///       capabilities. This does not copy the options. Further changes will be
//		///       reflected in the returned capabilities.
//		///       </summary>
//		/// <returns>The DesiredCapabilities for Chrome with these options.</returns>
//		internal ICapabilities ToCapabilities()
//		{
//			DesiredCapabilities capabilities = DesiredCapabilities.Chrome();
//			capabilities.SetCapability(ChromeOptions.Capability, this);
//			capabilities.SetCapability("chrome.switches", this.arguments);
//			if (!string.IsNullOrEmpty(this.binaryLocation))
//			{
//				capabilities.SetCapability("chrome.binary", this.binaryLocation);
//			}
//			return capabilities;
//		}
	}
}
