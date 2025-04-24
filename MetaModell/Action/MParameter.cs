namespace DSLController_MModell.MetaModell.Action
{
    public class MParameter
    {
        public string Name { get; set; } = string.Empty;
        public Type Type { get; set; } = typeof(void);
        public MHttpBinding Binding { get; set; } = MHttpBinding.None;

        public MParameter(string name, Type type, MHttpBinding binding)
        {
            Name = name;
            Type = type;
            Binding = binding;
        }

    }

}
