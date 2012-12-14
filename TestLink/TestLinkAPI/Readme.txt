TestLink API library
Copyright (c) 2009, Stephan Meyn <stephanmeyn@gmail.com>

V1.3 Release 26 June 2012
This release is a major rework of the previous release - reflecting the changes that have occured in Testlink beetween versions 1.8 and 1.9
- Implemented more function calls, including uploading of attachments. 
- More refactoring
- extended the regression test suite.


V1.3a Pre-release 17 May 2012
Recompiled in C# V4
Adapted to Testlink V1.9.3 (Prague)
Modified function calls:
- ReportTC Result now has a single call and supports optional parameters, reflects testplanid

New Function Calls:
- CreateBuild
- CreateTestPlan
- CreateTestSuite
- GetProjectTestPlans
- GetTestPlanByName
- getTestPlanPlatforms

Fixed bugs where returns could not be parsed into XMLRPC Structs
Dealt with Bug fixes in TLINK

V1.2 Release 5 Dec 2009
Fixed bug by change in how return value from ListProjects was handled
Fixed bug that prevented test results being added to older builds.

V 1.0 Release, 12 March 2009

The TestLink API is a .NET library providing access to the XML-RPC API of Testlink.

TestLink enables easily to create and manage Test cases as well as organize 
them into Test plans. These Test plans allow team members to execute Test 
cases and track test results dynamically, generate reports, trace software 
requirements, prioritize and assign tasks. 

To find out more about Testlink go to http://www.teamst.org 

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
