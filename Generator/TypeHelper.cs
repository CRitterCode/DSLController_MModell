using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSLController_MModell.Generator
{
    public static class TypeHelper
    {
        public static string GetFullTypeAsString(Type type)
        {
            if (type.IsGenericType)
            {
                var name = type.GetGenericTypeDefinition().Name.Split('`')[0];
                name = name.StartsWith("M") ? name.Substring(1) : name;
                var args = type.GetGenericArguments().Select(GetFullTypeAsString);
                return $"{name}<{string.Join(", ", args)}>";
            }

            return type.Name.StartsWith("M") ? type.Name.Substring(1) : type.Name;
        }
    }
}
