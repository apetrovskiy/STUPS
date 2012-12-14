/* 
TestLink API library
Copyright (c) 2009, Stephan Meyn <stephanmeyn@gmail.com>

Permission is hereby granted, free of charge, to any person 
obtaining a copy of this software and associated documentation 
files (the "Software"), to deal in the Software without restriction, 
including without limitation the rights to use, copy, modify, merge, 
publish, distribute, sublicense, and/or sell copies of the Software, 
and to permit persons to whom the Software is furnished to do so, 
subject to the following conditions:

The above copyright notice and this permission notice shall be 
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES 
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
DEALINGS IN THE SOFTWARE.
*/


using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Meyn.TestLink
{
    /// <summary>
    /// basic exception thrown whenever Testlink returns an error
    /// </summary>
   [Serializable]
    public class TestLinkException : ApplicationException
    {
       /// <summary>
       /// basic Constructor
       /// </summary>
        public TestLinkException() : base("TestLinkAPI.TestLinkException: testlink returned error messages.") { }
       /// <summary>
       /// vConstructor that can take an inner exception
       /// </summary>
       /// <param name="msg"></param>
       /// <param name="innerException"></param>
        public TestLinkException(string msg, Exception innerException) : base(msg, innerException) { }

        protected TestLinkException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        
        public override void GetObjectData(SerializationInfo info, StreamingContext context) 
        { 
            base.GetObjectData(info, context); 
        }

        /// <summary>
        /// constructor that takes a list of error messages
        /// </summary>
        /// <param name="errs"></param>
        public TestLinkException(List<TLErrorMessage> errs)
            : base("TestLinkException: testlink returned error messages. See errors")
        {
            errors = errs;
            foreach (TLErrorMessage error in errs)
                base.Data.Add(error.code, error.message);
        }
       /// <summary>
       /// constructor 
       /// </summary>
       /// <param name="msg"></param>
       /// <param name="errs"></param>
        public TestLinkException(string msg, List<TLErrorMessage> errs)
            : base(msg)
        {
            errors = errs;
            foreach (TLErrorMessage error in errs)
                base.Data.Add(error.code, error.message);
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="msg"></param>
        public TestLinkException(string msg) : base(msg) { }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="fmt"></param>
       /// <param name="args"></param>
        public TestLinkException(string fmt, params object[] args) : base(string.Format(fmt, args)) { }

       /// <summary>
       /// temporarily stores current errors
       /// </summary>
        public List<TLErrorMessage> errors;
    }
}
