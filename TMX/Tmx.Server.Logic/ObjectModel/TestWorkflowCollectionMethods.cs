namespace Tmx.Server.Logic.ObjectModel
{
    using System.Diagnostics;
    using Objects;
    using System.Linq;
    using Tmx.Interfaces.Remoting;

    public class TestWorkflowCollectionMethods
    {
        public void SetDefaultWorkflow()
        {
            if (string.IsNullOrEmpty(Defaults.Workflow))
                return;
            if (null == WorkflowCollection.Workflows || 0 == WorkflowCollection.Workflows.Count)
                return;
            if (WorkflowCollection.Workflows.All(wfl => Defaults.Workflow != wfl.Name))
                return;
            var matchingWorkflow = WorkflowCollection.Workflows.FirstOrDefault(wfl => Defaults.Workflow == wfl.Name);
            if (null == matchingWorkflow)
                return;
            WorkflowCollection.Workflows.ForEach(wfl => wfl.IsDefault = false);
            matchingWorkflow.IsDefault = true;
        }

        public ITestWorkflow GetDefaultWorkflow()
        {
            return WorkflowCollection.Workflows.FirstOrDefault(wfl => wfl.IsDefault);
        }
    }
}