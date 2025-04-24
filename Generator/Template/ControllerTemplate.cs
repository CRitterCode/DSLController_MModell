namespace DSLController_MModell.Generator.Template
{
    public class ControllerTemplate
    {
        public string Name { get; set; }
        public List<string> Attributes { get; set; } = new();
        public List<ActionTemplate> Actions { get; set; } = new();
    }

}
