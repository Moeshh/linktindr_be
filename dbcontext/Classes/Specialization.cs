using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbcontext.Classes {
    public enum Specialization {
        [Description("DevOps")]
        DEVOPS,
        [Description("Informatie Analist")]
        INFO,
        [Description("C# Programmeur")]
        CSHARP,
        [Description("Java Programmeur")]
        JAVA
    }
    public static class EnumExtensions {
        public static string GetDescription(this Enum value) {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = fieldInfo.GetCustomAttributes(
                typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            return attributes != null && attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}
