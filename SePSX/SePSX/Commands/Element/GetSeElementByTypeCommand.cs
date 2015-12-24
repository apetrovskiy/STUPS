/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/10/2012
 * Time: 11:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of GetSeElementByTypeCommand.
    /// </summary>
    public class GetSeElementByTypeCommand : GetElementByTypeCmdletBase
    {
        public GetSeElementByTypeCommand()
        {
        }
        
        #region temporary parameters decline
        [Parameter(Mandatory = false)]
        internal new string LinkText { get; set; }
        
        [Parameter(Mandatory = false)]
        [Alias("CSS")]
        internal new string CssSelector { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new string XPath { get; set; }

        [Parameter(Mandatory = false)]
        internal new string JavaScript { get; set; }

        //[Parameter(Mandatory = false)]
        //public SwitchParameter First { get; set; }
        #endregion temporary parameters decline
        
        protected override void ProcessRecord()
        {
            CheckInputWebDriverOrWebElement();
            
            var command =
                new SeGetElementByTypeCommand(this);
            command.Execute();
        }
    }
    
    /// <summary>
    /// Description of GetSeAnyCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeAny")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeAnyCommand : GetSeElementByTypeCommand
    {
        public GetSeAnyCommand()
        { TagName = "*"; }
    }
    
    /// <summary>
    /// Description of GetSeCommentCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeComment")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeCommentCommand : GetSeElementByTypeCommand
    {
        public GetSeCommentCommand()
        { TagName = "Comment"; }
    }
    
    /// <summary>
    /// Description of GetSeDocTypeCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeDocType")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeDocTypeCommand : GetSeElementByTypeCommand
    {
        public GetSeDocTypeCommand()
        { TagName = "DocType"; }
    }
    
    /// <summary>
    /// Description of GetSeACommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeA")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeACommand : GetSeElementByTypeCommand
    {
        public GetSeACommand()
        { TagName = "A"; }
    }

    /// <summary>
    /// Description of GetSeAbbrCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeAbbr")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeAbbrCommand : GetSeElementByTypeCommand
    {
        public GetSeAbbrCommand()
        { TagName = "Abbr"; }
    }
    
    /// <summary>
    /// Description of GetSeAcronymCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeAcronym")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeAcronymCommand : GetSeElementByTypeCommand
    {
        public GetSeAcronymCommand()
        { TagName = "Acronym"; }
    }
    
    /// <summary>
    /// Description of GetSeAddressCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeAddress")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeAddressCommand : GetSeElementByTypeCommand
    {
        public GetSeAddressCommand()
        { TagName = "Address"; }
    }
    
    /// <summary>
    /// Description of GetSeAppletCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeApplet")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeAppletCommand : GetSeElementByTypeCommand
    {
        public GetSeAppletCommand()
        { TagName = "Applet"; }
    }
    
    /// <summary>
    /// Description of GetSeAreaCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeArea")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeAreaCommand : GetSeElementByTypeCommand
    {
        public GetSeAreaCommand()
        { TagName = "Area"; }
    }
    
    /// <summary>
    /// Description of GetSeArticleCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeArticle")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeArticleCommand : GetSeElementByTypeCommand
    {
        public GetSeArticleCommand()
        { TagName = "Article"; }
    }
    
    /// <summary>
    /// Description of GetSeAsideCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeAside")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeAsideCommand : GetSeElementByTypeCommand
    {
        public GetSeAsideCommand()
        { TagName = "Aside"; }
    }
    
    /// <summary>
    /// Description of GetSeAudioCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeAudio")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeAudioCommand : GetSeElementByTypeCommand
    {
        public GetSeAudioCommand()
        { TagName = "Audio"; }
    }
    
    /// <summary>
    /// Description of GetSeBCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeB")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeBCommand : GetSeElementByTypeCommand
    {
        public GetSeBCommand()
        { TagName = "B"; }
    }
    
    /// <summary>
    /// Description of GetSeBaseCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeBase")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeBaseCommand : GetSeElementByTypeCommand
    {
        public GetSeBaseCommand()
        { TagName = "Base"; }
    }
    
    /// <summary>
    /// Description of GetSeBasefontCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeBasefont")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeBasefontCommand : GetSeElementByTypeCommand
    {
        public GetSeBasefontCommand()
        { TagName = "Basefont"; }
    }
    
    /// <summary>
    /// Description of GetSeBdiCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeBdi")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeBdiCommand : GetSeElementByTypeCommand
    {
        public GetSeBdiCommand()
        { TagName = "Bdi"; }
    }
    
    /// <summary>
    /// Description of GetSeBdoCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeBdo")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeBdoCommand : GetSeElementByTypeCommand
    {
        public GetSeBdoCommand()
        { TagName = "Bdo"; }
    }
    
    /// <summary>
    /// Description of GetSeBigCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeBig")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeBigCommand : GetSeElementByTypeCommand
    {
        public GetSeBigCommand()
        { TagName = "Big"; }
    }
    
    /// <summary>
    /// Description of GetSeBlockQuoteCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeBlockQuote")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeBlockQuoteCommand : GetSeElementByTypeCommand
    {
        public GetSeBlockQuoteCommand()
        { TagName = "BlockQuote"; }
    }
    
    /// <summary>
    /// Description of GetSeBodyCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeBody")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeBodyCommand : GetSeElementByTypeCommand
    {
        public GetSeBodyCommand()
        { TagName = "Body"; }
    }
    
    /// <summary>
    /// Description of GetSeBrCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeBr")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeBrCommand : GetSeElementByTypeCommand
    {
        public GetSeBrCommand()
        { TagName = "Br"; }
    }
    
    /// <summary>
    /// Description of GetSeButtonCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeButton")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeButtonCommand : GetSeElementByTypeCommand
    {
        public GetSeButtonCommand()
        { TagName = "Button"; }
    }
    
    /// <summary>
    /// Description of GetSeCanvasCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeCanvas")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeCanvasCommand : GetSeElementByTypeCommand
    {
        public GetSeCanvasCommand()
        { TagName = "Canvas"; }
    }
    
    /// <summary>
    /// Description of GetSeCaptionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeCaption")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeCaptionCommand : GetSeElementByTypeCommand
    {
        public GetSeCaptionCommand()
        { TagName = "Caption"; }
    }
    
    /// <summary>
    /// Description of GetSeCenterCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeCenter")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeCenterCommand : GetSeElementByTypeCommand
    {
        public GetSeCenterCommand()
        { TagName = "Center"; }
    }
    
    /// <summary>
    /// Description of GetSeCiteCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeCite")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeCiteCommand : GetSeElementByTypeCommand
    {
        public GetSeCiteCommand()
        { TagName = "Cite"; }
    }
    
    /// <summary>
    /// Description of GetSeCodeCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeCode")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeCodeCommand : GetSeElementByTypeCommand
    {
        public GetSeCodeCommand()
        { TagName = "Code"; }
    }
    
    /// <summary>
    /// Description of GetSeColCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeCol")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeColCommand : GetSeElementByTypeCommand
    {
        public GetSeColCommand()
        { TagName = "Col"; }
    }
    
    /// <summary>
    /// Description of GetSeColGroupCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeColGroup")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeColGroupCommand : GetSeElementByTypeCommand
    {
        public GetSeColGroupCommand()
        { TagName = "ColGroup"; }
    }
    
    /// <summary>
    /// Description of GetSeCommandCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeCommand")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeCommandCommand : GetSeElementByTypeCommand
    {
        public GetSeCommandCommand()
        { TagName = "Command"; }
    }
    
    /// <summary>
    /// Description of GetSeDataListCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeDataList")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeDataListCommand : GetSeElementByTypeCommand
    {
        public GetSeDataListCommand()
        { TagName = "DataList"; }
    }
    
    /// <summary>
    /// Description of GetSeDdCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeDd")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeDdCommand : GetSeElementByTypeCommand
    {
        public GetSeDdCommand()
        { TagName = "Dd"; }
    }
    
    /// <summary>
    /// Description of GetSeDelCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeDel")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeDelCommand : GetSeElementByTypeCommand
    {
        public GetSeDelCommand()
        { TagName = "Del"; }
    }
    
    /// <summary>
    /// Description of GetSeDetailsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeDetails")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeDetailsCommand : GetSeElementByTypeCommand
    {
        public GetSeDetailsCommand()
        { TagName = "Details"; }
    }
    
    /// <summary>
    /// Description of GetSeDfnCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeDfn")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeDfnCommand : GetSeElementByTypeCommand
    {
        public GetSeDfnCommand()
        { TagName = "Dfn"; }
    }
    
    /// <summary>
    /// Description of GetSeDirCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeDir")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeDirCommand : GetSeElementByTypeCommand
    {
        public GetSeDirCommand()
        { TagName = "Dir"; }
    }
    
    /// <summary>
    /// Description of GetSeDivCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeDiv")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeDivCommand : GetSeElementByTypeCommand
    {
        public GetSeDivCommand()
        { TagName = "Div"; }
    }
    
    /// <summary>
    /// Description of GetSeDlCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeDl")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeDlCommand : GetSeElementByTypeCommand
    {
        public GetSeDlCommand()
        { TagName = "Dl"; }
    }
    
    /// <summary>
    /// Description of GetSeDtCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeDt")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeDtCommand : GetSeElementByTypeCommand
    {
        public GetSeDtCommand()
        { TagName = "Dt"; }
    }
    
    /// <summary>
    /// Description of GetSeEmCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeEm")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeEmCommand : GetSeElementByTypeCommand
    {
        public GetSeEmCommand()
        { TagName = "Em"; }
    }
    
    /// <summary>
    /// Description of GetSeEmbedCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeEmbed")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeEmbedCommand : GetSeElementByTypeCommand
    {
        public GetSeEmbedCommand()
        { TagName = "Embed"; }
    }
    
    /// <summary>
    /// Description of GetSeFieldSetCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeFieldSet")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeFieldSetCommand : GetSeElementByTypeCommand
    {
        public GetSeFieldSetCommand()
        { TagName = "FieldSet"; }
    }
    
    /// <summary>
    /// Description of GetSeFigCaptionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeFigCaption")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeFigCaptionCommand : GetSeElementByTypeCommand
    {
        public GetSeFigCaptionCommand()
        { TagName = "FigCaption"; }
    }
    
    /// <summary>
    /// Description of GetSeFigureCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeFigure")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeFigureCommand : GetSeElementByTypeCommand
    {
        public GetSeFigureCommand()
        { TagName = "Figure"; }
    }
    
    /// <summary>
    /// Description of GetSeFontCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeFont")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeFontCommand : GetSeElementByTypeCommand
    {
        public GetSeFontCommand()
        { TagName = "Font"; }
    }
    
    /// <summary>
    /// Description of GetSeFooterCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeFooter")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeFooterCommand : GetSeElementByTypeCommand
    {
        public GetSeFooterCommand()
        { TagName = "Footer"; }
    }
    
    /// <summary>
    /// Description of GetSeFormCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeForm")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeFormCommand : GetSeElementByTypeCommand
    {
        public GetSeFormCommand()
        { TagName = "Form"; }
    }
    
    /// <summary>
    /// Description of GetSeFrameCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeFrame")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeFrameCommand : GetSeElementByTypeCommand
    {
        public GetSeFrameCommand()
        { TagName = "Frame"; }
    }
    
    /// <summary>
    /// Description of GetSeFrameSetCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeFrameSet")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeFrameSetCommand : GetSeElementByTypeCommand
    {
        public GetSeFrameSetCommand()
        { TagName = "FrameSet"; }
    }
    
    /// <summary>
    /// Description of GetSeHeadCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeHead")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeHeadCommand : GetSeElementByTypeCommand
    {
        public GetSeHeadCommand()
        { TagName = "Head"; }
    }
    
    /// <summary>
    /// Description of GetSeHeaderCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeHeader")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeHeaderCommand : GetSeElementByTypeCommand
    {
        public GetSeHeaderCommand()
        { TagName = "Header"; }
    }
    
    /// <summary>
    /// Description of GetSeHGroupCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeHGroup")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeHGroupCommand : GetSeElementByTypeCommand
    {
        public GetSeHGroupCommand()
        { TagName = "HGroup"; }
    }
    
    /// <summary>
    /// Description of GetSeH1Command.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeH1")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeH1Command : GetSeElementByTypeCommand
    {
        public GetSeH1Command()
        { TagName = "H1"; }
    }
    
    /// <summary>
    /// Description of GetSeH2Command.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeH2")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeH2Command : GetSeElementByTypeCommand
    {
        public GetSeH2Command()
        { TagName = "H2"; }
    }
    
    /// <summary>
    /// Description of GetSeH3Command.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeH3")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeH3Command : GetSeElementByTypeCommand
    {
        public GetSeH3Command()
        { TagName = "H3"; }
    }
    
    /// <summary>
    /// Description of GetSeH4Command.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeH4")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeH4Command : GetSeElementByTypeCommand
    {
        public GetSeH4Command()
        { TagName = "H4"; }
    }
    
    /// <summary>
    /// Description of GetSeH5Command.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeH5")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeH5Command : GetSeElementByTypeCommand
    {
        public GetSeH5Command()
        { TagName = "H5"; }
    }
    
    /// <summary>
    /// Description of GetSeH6Command.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeH6")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeH6Command : GetSeElementByTypeCommand
    {
        public GetSeH6Command()
        { TagName = "H6"; }
    }
    
    /// <summary>
    /// Description of GetSeHrCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeHr")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeHrCommand : GetSeElementByTypeCommand
    {
        public GetSeHrCommand()
        { TagName = "Hr"; }
    }
    
    /// <summary>
    /// Description of GetSeHtmlCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeHtml")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeHtmlCommand : GetSeElementByTypeCommand
    {
        public GetSeHtmlCommand()
        { TagName = "Html"; }
    }
    
    /// <summary>
    /// Description of GetSeICommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeI")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeICommand : GetSeElementByTypeCommand
    {
        public GetSeICommand()
        { TagName = "I"; }
    }
    
    /// <summary>
    /// Description of GetSeIFrameCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeIFrame")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeIFrameCommand : GetSeElementByTypeCommand
    {
        public GetSeIFrameCommand()
        { TagName = "IFrame"; }
    }
    
    /// <summary>
    /// Description of GetSeImgCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeImg")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeImgCommand : GetSeElementByTypeCommand
    {
        public GetSeImgCommand()
        { TagName = "Img"; }
    }
    
    /// <summary>
    /// Description of GetSeInputCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeInput")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeInputCommand : GetSeElementByTypeCommand
    {
        public GetSeInputCommand()
        { TagName = "Input"; }
    }
    
    /// <summary>
    /// Description of GetSeInsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeIns")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeInsCommand : GetSeElementByTypeCommand
    {
        public GetSeInsCommand()
        { TagName = "Ins"; }
    }
    
    /// <summary>
    /// Description of GetSeKbdCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeKbd")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeKbdCommand : GetSeElementByTypeCommand
    {
        public GetSeKbdCommand()
        { TagName = "Kbd"; }
    }
    
    /// <summary>
    /// Description of GetSeKeygenCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeKeygen")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeKeygenCommand : GetSeElementByTypeCommand
    {
        public GetSeKeygenCommand()
        { TagName = "Keygen"; }
    }
    
    /// <summary>
    /// Description of GetSeLabelCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeLabel")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeLabelCommand : GetSeElementByTypeCommand
    {
        public GetSeLabelCommand()
        { TagName = "Label"; }
    }
    
    /// <summary>
    /// Description of GetSeLegendCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeLegend")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeLegendCommand : GetSeElementByTypeCommand
    {
        public GetSeLegendCommand()
        { TagName = "Legend"; }
    }
    
    /// <summary>
    /// Description of GetSeLiCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeLi")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeLiCommand : GetSeElementByTypeCommand
    {
        public GetSeLiCommand()
        { TagName = "Li"; }
    }
    
    /// <summary>
    /// Description of GetSeLinkCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeLink")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeLinkCommand : GetSeElementByTypeCommand
    {
        public GetSeLinkCommand()
        { TagName = "Link"; }
    }
    
    /// <summary>
    /// Description of GetSeMapCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeMap")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeMapCommand : GetSeElementByTypeCommand
    {
        public GetSeMapCommand()
        { TagName = "Map"; }
    }
    
    /// <summary>
    /// Description of GetSeMarkCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeMark")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeMarkCommand : GetSeElementByTypeCommand
    {
        public GetSeMarkCommand()
        { TagName = "Mark"; }
    }
    
    /// <summary>
    /// Description of GetSeMenuCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeMenu")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeMenuCommand : GetSeElementByTypeCommand
    {
        public GetSeMenuCommand()
        { TagName = "Menu"; }
    }
    
    /// <summary>
    /// Description of GetSeMetaCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeMeta")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeMetaCommand : GetSeElementByTypeCommand
    {
        public GetSeMetaCommand()
        { TagName = "Meta"; }
    }
    
    /// <summary>
    /// Description of GetSeMeterCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeMeter")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeMeterCommand : GetSeElementByTypeCommand
    {
        public GetSeMeterCommand()
        { TagName = "Meter"; }
    }
    
    /// <summary>
    /// Description of GetSeNavCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeNav")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeNavCommand : GetSeElementByTypeCommand
    {
        public GetSeNavCommand()
        { TagName = "Nav"; }
    }
    
    /// <summary>
    /// Description of GetSeNoFramesCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeNoFrames")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeNoFramesCommand : GetSeElementByTypeCommand
    {
        public GetSeNoFramesCommand()
        { TagName = "NoFrames"; }
    }
    
    /// <summary>
    /// Description of GetSeNoScriptCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeNoScript")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeNoScriptCommand : GetSeElementByTypeCommand
    {
        public GetSeNoScriptCommand()
        { TagName = "NoScript"; }
    }
    
    /// <summary>
    /// Description of GetSeObjectCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeObject")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeObjectCommand : GetSeElementByTypeCommand
    {
        public GetSeObjectCommand()
        { TagName = "Object"; }
    }
    
    /// <summary>
    /// Description of GetSeOlCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeOl")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeOlCommand : GetSeElementByTypeCommand
    {
        public GetSeOlCommand()
        { TagName = "Ol"; }
    }
    
    /// <summary>
    /// Description of GetSeOptGroupCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeOptGroup")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeOptGroupCommand : GetSeElementByTypeCommand
    {
        public GetSeOptGroupCommand()
        { TagName = "OptGroup"; }
    }
    
    /// <summary>
    /// Description of GetSeOptionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeOption")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeOptionCommand : GetSeElementByTypeCommand
    {
        public GetSeOptionCommand()
        { TagName = "Option"; }
    }
    
    /// <summary>
    /// Description of GetSeOutputCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeOutput")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeOutputCommand : GetSeElementByTypeCommand
    {
        public GetSeOutputCommand()
        { TagName = "Output"; }
    }
    
    /// <summary>
    /// Description of GetSePCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeP")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSePCommand : GetSeElementByTypeCommand
    {
        public GetSePCommand()
        { TagName = "P"; }
    }
    
    /// <summary>
    /// Description of GetSeParamCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeParam")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeParamCommand : GetSeElementByTypeCommand
    {
        public GetSeParamCommand()
        { TagName = "Param"; }
    }
    
    /// <summary>
    /// Description of GetSePreCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SePre")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSePreCommand : GetSeElementByTypeCommand
    {
        public GetSePreCommand()
        { TagName = "Pre"; }
    }
    
    /// <summary>
    /// Description of GetSeProgressCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeProgress")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeProgressCommand : GetSeElementByTypeCommand
    {
        public GetSeProgressCommand()
        { TagName = "Progress"; }
    }
    
    /// <summary>
    /// Description of GetSeQCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeQ")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeQCommand : GetSeElementByTypeCommand
    {
        public GetSeQCommand()
        { TagName = "Q"; }
    }
    
    /// <summary>
    /// Description of GetSeRpCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeRp")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeRpCommand : GetSeElementByTypeCommand
    {
        public GetSeRpCommand()
        { TagName = "Rp"; }
    }
    
    /// <summary>
    /// Description of GetSeRtCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeRt")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeRtCommand : GetSeElementByTypeCommand
    {
        public GetSeRtCommand()
        { TagName = "Rt"; }
    }
    
    /// <summary>
    /// Description of GetSeRubyCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeRuby")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeRubyCommand : GetSeElementByTypeCommand
    {
        public GetSeRubyCommand()
        { TagName = "Ruby"; }
    }
    
    /// <summary>
    /// Description of GetSeSCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeS")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeSCommand : GetSeElementByTypeCommand
    {
        public GetSeSCommand()
        { TagName = "S"; }
    }
    
    /// <summary>
    /// Description of GetSeSampCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeSamp")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeSampCommand : GetSeElementByTypeCommand
    {
        public GetSeSampCommand()
        { TagName = "Samp"; }
    }
    
    /// <summary>
    /// Description of GetSeScriptCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeScript")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeScriptCommand : GetSeElementByTypeCommand
    {
        public GetSeScriptCommand()
        { TagName = "Script"; }
    }
    
    /// <summary>
    /// Description of GetSeSectionCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeSection")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeSectionCommand : GetSeElementByTypeCommand
    {
        public GetSeSectionCommand()
        { TagName = "Section"; }
    }
    
    /// <summary>
    /// Description of GetSeSelectCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeSelect")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeSelectCommand : GetSeElementByTypeCommand
    {
        public GetSeSelectCommand()
        { TagName = "Select"; }
    }
    
    /// <summary>
    /// Description of GetSeSmallCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeSmall")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeSmallCommand : GetSeElementByTypeCommand
    {
        public GetSeSmallCommand()
        { TagName = "Small"; }
    }

    /// <summary>
    /// Description of GetSeSourceCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeSource")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeSourceCommand : GetSeElementByTypeCommand
    {
        public GetSeSourceCommand()
        { TagName = "Source"; }
    }
    
    /// <summary>
    /// Description of GetSeSpanCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeSpan")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeSpanCommand : GetSeElementByTypeCommand
    {
        public GetSeSpanCommand()
        { TagName = "Span"; }
    }
    
    /// <summary>
    /// Description of GetSeStrikeCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeStrike")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeStrikeCommand : GetSeElementByTypeCommand
    {
        public GetSeStrikeCommand()
        { TagName = "Strike"; }
    }
    
    /// <summary>
    /// Description of GetSeStrongCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeStrong")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeStrongCommand : GetSeElementByTypeCommand
    {
        public GetSeStrongCommand()
        { TagName = "Strong"; }
    }
    
    /// <summary>
    /// Description of GetSeStyleCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeStyle")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeStyleCommand : GetSeElementByTypeCommand
    {
        public GetSeStyleCommand()
        { TagName = "Style"; }
    }
    
    /// <summary>
    /// Description of GetSeSubCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeSub")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeSubCommand : GetSeElementByTypeCommand
    {
        public GetSeSubCommand()
        { TagName = "Sub"; }
    }
    
    /// <summary>
    /// Description of GetSeSummaryCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeSummary")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeSummaryCommand : GetSeElementByTypeCommand
    {
        public GetSeSummaryCommand()
        { TagName = "Summary"; }
    }
    
    /// <summary>
    /// Description of GetSeSupCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeSup")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeSupCommand : GetSeElementByTypeCommand
    {
        public GetSeSupCommand()
        { TagName = "Sup"; }
    }
    
    /// <summary>
    /// Description of GetSeTableCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeTable")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeTableCommand : GetSeElementByTypeCommand
    {
        public GetSeTableCommand()
        { TagName = "Table"; }
    }
    
    /// <summary>
    /// Description of GetSeTBodyCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeTBody")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeTBodyCommand : GetSeElementByTypeCommand
    {
        public GetSeTBodyCommand()
        { TagName = "TBody"; }
    }
    
    /// <summary>
    /// Description of GetSeTdCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeTd")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeTdCommand : GetSeElementByTypeCommand
    {
        public GetSeTdCommand()
        { TagName = "Td"; }
    }
    
    /// <summary>
    /// Description of GetSeTextAreaCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeTextArea")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeTextAreaCommand : GetSeElementByTypeCommand
    {
        public GetSeTextAreaCommand()
        { TagName = "TextArea"; }
    }
    
    /// <summary>
    /// Description of GetSeTFootCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeTFoot")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeTFootCommand : GetSeElementByTypeCommand
    {
        public GetSeTFootCommand()
        { TagName = "TFoot"; }
    }
    
    /// <summary>
    /// Description of GetSeThCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeTh")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeThCommand : GetSeElementByTypeCommand
    {
        public GetSeThCommand()
        { TagName = "Th"; }
    }
    
    /// <summary>
    /// Description of GetSeTHeadCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeTHead")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeTHeadCommand : GetSeElementByTypeCommand
    {
        public GetSeTHeadCommand()
        { TagName = "THead"; }
    }
    
    /// <summary>
    /// Description of GetSeTimeCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeTime")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeTimeCommand : GetSeElementByTypeCommand
    {
        public GetSeTimeCommand()
        { TagName = "Time"; }
    }
    
    /// <summary>
    /// Description of GetSeTitleCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeTitle")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeTitleCommand : GetSeElementByTypeCommand
    {
        public GetSeTitleCommand()
        { TagName = "Title"; }
    }
    
    /// <summary>
    /// Description of GetSeTrCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeTr")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeTrCommand : GetSeElementByTypeCommand
    {
        public GetSeTrCommand()
        { TagName = "Tr"; }
    }
    
    /// <summary>
    /// Description of GetSeTrackCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeTrack")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeTrackCommand : GetSeElementByTypeCommand
    {
        public GetSeTrackCommand()
        { TagName = "Track"; }
    }
    
    /// <summary>
    /// Description of GetSeTtCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeTt")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeTtCommand : GetSeElementByTypeCommand
    {
        public GetSeTtCommand()
        { TagName = "Tt"; }
    }
    
    /// <summary>
    /// Description of GetSeUCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeU")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeUCommand : GetSeElementByTypeCommand
    {
        public GetSeUCommand()
        { TagName = "U"; }
    }
    
    /// <summary>
    /// Description of GetSeUlCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeUl")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeUlCommand : GetSeElementByTypeCommand
    {
        public GetSeUlCommand()
        { TagName = "Ul"; }
    }
    
    /// <summary>
    /// Description of GetSeVarCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeVar")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeVarCommand : GetSeElementByTypeCommand
    {
        public GetSeVarCommand()
        { TagName = "Var"; }
    }
    
    /// <summary>
    /// Description of GetSeVideoCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeVideo")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeVideoCommand : GetSeElementByTypeCommand
    {
        public GetSeVideoCommand()
        { TagName = "Video"; }
    }
    
    /// <summary>
    /// Description of GetSeWbrCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SeWbr")]
    [OutputType(typeof(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>))]
    public class GetSeWbrCommand : GetSeElementByTypeCommand
    {
        public GetSeWbrCommand()
        { TagName = "Wbr"; }
    }
}
