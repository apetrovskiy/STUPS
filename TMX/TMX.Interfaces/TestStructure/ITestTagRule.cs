namespace Tmx.Interfaces.TestStructure
{
    public interface ITestTagRule
    {
        string Tag { get; set; }
        TestTagRuleScopes Scope { get; set; }
        TestTagRuleActions SeverityAction { get; set; }
    }
}