namespace DSLController_MModell.Generator.Template
{
    public class ControllerTemplate
    {
        public string Name { get; set; } = string.Empty;
        public List<string> Attributes { get; set; } = new();
        public List<ActionTemplate> Actions { get; set; } = new();
        public List<string> Usings { get; set; } = new();
        public string Namespace { get; set; } = string.Empty;
    }

}
