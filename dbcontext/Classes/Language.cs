using System.ComponentModel;

namespace dbcontext.Classes {
    public enum Language {
        [Description("C#")]
        CSHARP,
        [Description("Java")]
        JAVA,
        [Description("Python")]
        PYTHON,
        [Description("Other")]
        OTHER
    }
}
