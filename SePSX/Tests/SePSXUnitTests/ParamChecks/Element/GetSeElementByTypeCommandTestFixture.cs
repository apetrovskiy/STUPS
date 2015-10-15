/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/10/2012
 * Time: 11:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.CheckCmdletParameters
{
    using MbUnit.Framework;

    /// <summary>
    /// Description of GetSeElementByTypeCommand.
    /// </summary>
    [TestFixture]
    public class GetSeElementByTypeCommand_ParamCheck // GetElementByTypeCmdletBase
    {
        public GetSeElementByTypeCommand_ParamCheck()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspaceForParamChecks();
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            // MiddleLevelCode.DisposeRunspace(); // 20121226
        }
        
        [Test]
        [Category("Fast")]
        [Ignore]
        public void Need_Code()
        {
            
        }
    }
    
    /// <summary>
    /// Description of GetSeAnyCommand.
    /// </summary>
    [TestFixture]
    public class GetSeAnyCommandTestFixture // GetSeElementByTypeCommand
    {
        public GetSeAnyCommandTestFixture()
        {
        }
    }
    
//    /// <summary>
//    /// Description of GetSeCommentCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeComment")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeCommentCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeCommentCommandTestFixture()
//        { this.TagName = "Comment"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeDocTypeCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeDocType")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeDocTypeCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeDocTypeCommandTestFixture()
//        { this.TagName = "DocType"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeACommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeA")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeACommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeACommandTestFixture()
//        { this.TagName = "A"; }
//    }
//
//    /// <summary>
//    /// Description of GetSeAbbrCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeAbbr")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeAbbrCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeAbbrCommandTestFixture()
//        { this.TagName = "Abbr"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeAcronymCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeAcronym")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeAcronymCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeAcronymCommandTestFixture()
//        { this.TagName = "Acronym"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeAddressCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeAddress")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeAddressCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeAddressCommandTestFixture()
//        { this.TagName = "Address"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeAppletCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeApplet")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeAppletCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeAppletCommandTestFixture()
//        { this.TagName = "Applet"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeAreaCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeArea")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeAreaCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeAreaCommandTestFixture()
//        { this.TagName = "Area"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeArticleCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeArticle")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeArticleCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeArticleCommandTestFixture()
//        { this.TagName = "Article"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeAsideCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeAside")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeAsideCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeAsideCommandTestFixture()
//        { this.TagName = "Aside"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeAudioCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeAudio")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeAudioCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeAudioCommandTestFixture()
//        { this.TagName = "Audio"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeBCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeB")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeBCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeBCommandTestFixture()
//        { this.TagName = "B"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeBaseCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeBase")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeBaseCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeBaseCommandTestFixture()
//        { this.TagName = "Base"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeBasefontCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeBasefont")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeBasefontCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeBasefontCommandTestFixture()
//        { this.TagName = "Basefont"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeBdiCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeBdi")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeBdiCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeBdiCommandTestFixture()
//        { this.TagName = "Bdi"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeBdoCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeBdo")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeBdoCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeBdoCommandTestFixture()
//        { this.TagName = "Bdo"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeBigCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeBig")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeBigCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeBigCommandTestFixture()
//        { this.TagName = "Big"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeBlockQuoteCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeBlockQuote")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeBlockQuoteCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeBlockQuoteCommandTestFixture()
//        { this.TagName = "BlockQuote"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeBodyCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeBody")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeBodyCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeBodyCommandTestFixture()
//        { this.TagName = "Body"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeBrCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeBr")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeBrCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeBrCommandTestFixture()
//        { this.TagName = "Br"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeButtonCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeButton")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeButtonCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeButtonCommandTestFixture()
//        { this.TagName = "Button"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeCanvasCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeCanvas")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeCanvasCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeCanvasCommandTestFixture()
//        { this.TagName = "Canvas"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeCaptionCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeCaption")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeCaptionCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeCaptionCommandTestFixture()
//        { this.TagName = "Caption"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeCenterCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeCenter")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeCenterCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeCenterCommandTestFixture()
//        { this.TagName = "Center"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeCiteCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeCite")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeCiteCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeCiteCommandTestFixture()
//        { this.TagName = "Cite"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeCodeCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeCode")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeCodeCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeCodeCommandTestFixture()
//        { this.TagName = "Code"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeColCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeCol")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeColCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeColCommandTestFixture()
//        { this.TagName = "Col"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeColGroupCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeColGroup")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeColGroupCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeColGroupCommandTestFixture()
//        { this.TagName = "ColGroup"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeCommandCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeCommand")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeCommandCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeCommandCommandTestFixture()
//        { this.TagName = "Command"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeDataListCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeDataList")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeDataListCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeDataListCommandTestFixture()
//        { this.TagName = "DataList"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeDdCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeDd")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeDdCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeDdCommandTestFixture()
//        { this.TagName = "Dd"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeDelCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeDel")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeDelCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeDelCommandTestFixture()
//        { this.TagName = "Del"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeDetailsCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeDetails")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeDetailsCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeDetailsCommandTestFixture()
//        { this.TagName = "Details"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeDfnCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeDfn")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeDfnCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeDfnCommandTestFixture()
//        { this.TagName = "Dfn"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeDirCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeDir")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeDirCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeDirCommandTestFixture()
//        { this.TagName = "Dir"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeDivCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeDiv")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeDivCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeDivCommandTestFixture()
//        { this.TagName = "Div"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeDlCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeDl")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeDlCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeDlCommandTestFixture()
//        { this.TagName = "Dl"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeDtCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeDt")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeDtCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeDtCommandTestFixture()
//        { this.TagName = "Dt"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeEmCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeEm")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeEmCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeEmCommandTestFixture()
//        { this.TagName = "Em"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeEmbedCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeEmbed")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeEmbedCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeEmbedCommandTestFixture()
//        { this.TagName = "Embed"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeFieldSetCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeFieldSet")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeFieldSetCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeFieldSetCommandTestFixture()
//        { this.TagName = "FieldSet"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeFigCaptionCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeFigCaption")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeFigCaptionCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeFigCaptionCommandTestFixture()
//        { this.TagName = "FigCaption"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeFigureCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeFigure")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeFigureCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeFigureCommandTestFixture()
//        { this.TagName = "Figure"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeFontCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeFont")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeFontCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeFontCommandTestFixture()
//        { this.TagName = "Font"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeFooterCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeFooter")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeFooterCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeFooterCommandTestFixture()
//        { this.TagName = "Footer"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeFormCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeForm")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeFormCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeFormCommandTestFixture()
//        { this.TagName = "Form"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeFrameCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeFrame")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeFrameCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeFrameCommandTestFixture()
//        { this.TagName = "Frame"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeFrameSetCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeFrameSet")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeFrameSetCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeFrameSetCommandTestFixture()
//        { this.TagName = "FrameSet"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeHeadCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeHead")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeHeadCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeHeadCommandTestFixture()
//        { this.TagName = "Head"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeHeaderCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeHeader")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeHeaderCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeHeaderCommandTestFixture()
//        { this.TagName = "Header"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeHGroupCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeHGroup")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeHGroupCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeHGroupCommandTestFixture()
//        { this.TagName = "HGroup"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeH1Command.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeH1")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeH1CommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeH1CommandTestFixture()
//        { this.TagName = "H1"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeH2Command.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeH2")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeH2CommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeH2CommandTestFixture()
//        { this.TagName = "H2"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeH3Command.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeH3")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeH3CommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeH3CommandTestFixture()
//        { this.TagName = "H3"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeH4Command.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeH4")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeH4CommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeH4CommandTestFixture()
//        { this.TagName = "H4"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeH5Command.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeH5")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeH5CommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeH5CommandTestFixture()
//        { this.TagName = "H5"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeH6Command.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeH6")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeH6CommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeH6CommandTestFixture()
//        { this.TagName = "H6"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeHrCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeHr")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeHrCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeHrCommandTestFixture()
//        { this.TagName = "Hr"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeHtmlCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeHtml")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeHtmlCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeHtmlCommandTestFixture()
//        { this.TagName = "Html"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeICommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeI")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeICommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeICommandTestFixture()
//        { this.TagName = "I"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeIFrameCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeIFrame")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeIFrameCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeIFrameCommandTestFixture()
//        { this.TagName = "IFrame"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeImgCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeImg")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeImgCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeImgCommandTestFixture()
//        { this.TagName = "Img"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeInputCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeInput")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeInputCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeInputCommandTestFixture()
//        { this.TagName = "Input"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeInsCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeIns")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeInsCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeInsCommandTestFixture()
//        { this.TagName = "Ins"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeKbdCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeKbd")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeKbdCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeKbdCommandTestFixture()
//        { this.TagName = "Kbd"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeKeygenCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeKeygen")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeKeygenCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeKeygenCommandTestFixture()
//        { this.TagName = "Keygen"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeLabelCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeLabel")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeLabelCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeLabelCommandTestFixture()
//        { this.TagName = "Label"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeLegendCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeLegend")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeLegendCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeLegendCommandTestFixture()
//        { this.TagName = "Legend"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeLiCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeLi")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeLiCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeLiCommandTestFixture()
//        { this.TagName = "Li"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeLinkCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeLink")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeLinkCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeLinkCommandTestFixture()
//        { this.TagName = "Link"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeMapCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeMap")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeMapCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeMapCommandTestFixture()
//        { this.TagName = "Map"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeMarkCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeMark")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeMarkCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeMarkCommandTestFixture()
//        { this.TagName = "Mark"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeMenuCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeMenu")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeMenuCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeMenuCommandTestFixture()
//        { this.TagName = "Menu"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeMetaCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeMeta")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeMetaCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeMetaCommandTestFixture()
//        { this.TagName = "Meta"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeMeterCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeMeter")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeMeterCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeMeterCommandTestFixture()
//        { this.TagName = "Meter"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeNavCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeNav")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeNavCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeNavCommandTestFixture()
//        { this.TagName = "Nav"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeNoFramesCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeNoFrames")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeNoFramesCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeNoFramesCommandTestFixture()
//        { this.TagName = "NoFrames"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeNoScriptCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeNoScript")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeNoScriptCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeNoScriptCommandTestFixture()
//        { this.TagName = "NoScript"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeObjectCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeObject")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeObjectCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeObjectCommandTestFixture()
//        { this.TagName = "Object"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeOlCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeOl")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeOlCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeOlCommandTestFixture()
//        { this.TagName = "Ol"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeOptGroupCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeOptGroup")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeOptGroupCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeOptGroupCommandTestFixture()
//        { this.TagName = "OptGroup"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeOptionCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeOption")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeOptionCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeOptionCommandTestFixture()
//        { this.TagName = "Option"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeOutputCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeOutput")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeOutputCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeOutputCommandTestFixture()
//        { this.TagName = "Output"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSePCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeP")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSePCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSePCommandTestFixture()
//        { this.TagName = "P"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeParamCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeParam")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeParamCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeParamCommandTestFixture()
//        { this.TagName = "Param"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSePreCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SePre")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSePreCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSePreCommandTestFixture()
//        { this.TagName = "Pre"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeProgressCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeProgress")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeProgressCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeProgressCommandTestFixture()
//        { this.TagName = "Progress"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeQCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeQ")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeQCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeQCommandTestFixture()
//        { this.TagName = "Q"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeRpCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeRp")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeRpCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeRpCommandTestFixture()
//        { this.TagName = "Rp"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeRtCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeRt")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeRtCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeRtCommandTestFixture()
//        { this.TagName = "Rt"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeRubyCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeRuby")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeRubyCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeRubyCommandTestFixture()
//        { this.TagName = "Ruby"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeSCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeS")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeSCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeSCommandTestFixture()
//        { this.TagName = "S"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeSampCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeSamp")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeSampCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeSampCommandTestFixture()
//        { this.TagName = "Samp"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeScriptCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeScript")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeScriptCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeScriptCommandTestFixture()
//        { this.TagName = "Script"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeSectionCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeSection")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeSectionCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeSectionCommandTestFixture()
//        { this.TagName = "Section"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeSelectCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeSelect")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeSelectCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeSelectCommandTestFixture()
//        { this.TagName = "Select"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeSmallCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeSmall")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeSmallCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeSmallCommandTestFixture()
//        { this.TagName = "Small"; }
//    }
//
//    /// <summary>
//    /// Description of GetSeSourceCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeSource")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeSourceCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeSourceCommandTestFixture()
//        { this.TagName = "Source"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeSpanCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeSpan")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeSpanCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeSpanCommandTestFixture()
//        { this.TagName = "Span"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeStrikeCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeStrike")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeStrikeCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeStrikeCommandTestFixture()
//        { this.TagName = "Strike"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeStrongCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeStrong")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeStrongCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeStrongCommandTestFixture()
//        { this.TagName = "Strong"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeStyleCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeStyle")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeStyleCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeStyleCommandTestFixture()
//        { this.TagName = "Style"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeSubCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeSub")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeSubCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeSubCommandTestFixture()
//        { this.TagName = "Sub"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeSummaryCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeSummary")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeSummaryCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeSummaryCommandTestFixture()
//        { this.TagName = "Summary"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeSupCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeSup")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeSupCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeSupCommandTestFixture()
//        { this.TagName = "Sup"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeTableCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeTable")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeTableCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeTableCommandTestFixture()
//        { this.TagName = "Table"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeTBodyCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeTBody")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeTBodyCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeTBodyCommandTestFixture()
//        { this.TagName = "TBody"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeTdCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeTd")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeTdCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeTdCommandTestFixture()
//        { this.TagName = "Td"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeTextAreaCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeTextArea")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeTextAreaCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeTextAreaCommandTestFixture()
//        { this.TagName = "TextArea"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeTFootCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeTFoot")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeTFootCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeTFootCommandTestFixture()
//        { this.TagName = "TFoot"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeThCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeTh")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeThCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeThCommandTestFixture()
//        { this.TagName = "Th"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeTHeadCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeTHead")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeTHeadCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeTHeadCommandTestFixture()
//        { this.TagName = "THead"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeTimeCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeTime")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeTimeCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeTimeCommandTestFixture()
//        { this.TagName = "Time"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeTitleCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeTitle")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeTitleCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeTitleCommandTestFixture()
//        { this.TagName = "Title"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeTrCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeTr")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeTrCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeTrCommandTestFixture()
//        { this.TagName = "Tr"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeTrackCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeTrack")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeTrackCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeTrackCommandTestFixture()
//        { this.TagName = "Track"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeTtCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeTt")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeTtCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeTtCommandTestFixture()
//        { this.TagName = "Tt"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeUCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeU")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeUCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeUCommandTestFixture()
//        { this.TagName = "U"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeUlCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeUl")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeUlCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeUlCommandTestFixture()
//        { this.TagName = "Ul"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeVarCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeVar")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeVarCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeVarCommandTestFixture()
//        { this.TagName = "Var"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeVideoCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeVideo")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeVideoCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeVideoCommandTestFixture()
//        { this.TagName = "Video"; }
//    }
//    
//    /// <summary>
//    /// Description of GetSeWbrCommand.
//    /// </summary>
//    [Cmdlet(VerbsCommon.Get, "SeWbr")]
//    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
//    public class GetSeWbrCommandTestFixture // GetSeElementByTypeCommand
//    {
//        public GetSeWbrCommandTestFixture()
//        { this.TagName = "Wbr"; }
//    }
}
