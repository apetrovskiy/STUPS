namespace Tmx.Server.Logic.ObjectModel
{
    using System.Linq;
    using System.Xml.Linq;

    public class DefaultsLoader
    {
        public virtual void Load(string fileWithDefaults)
        {
            var xDoc = XDocument.Load(fileWithDefaults);
            SetWorkflowElement(xDoc);
        }

        void SetWorkflowElement(XDocument xDocument)
        {
            var workflowElement = xDocument.Descendants(LogicConstants.DefaultsLoader_Workflow).FirstOrDefault();
            var defaultAttributeValue = new XAttribute(LogicConstants.DefaultsLoader_Workflow_Name, string.Empty);
            if (null != workflowElement)
                Defaults.Workflow = (workflowElement.Attribute(LogicConstants.DefaultsLoader_Workflow_Name) ?? defaultAttributeValue).Value;
        }
    }
}