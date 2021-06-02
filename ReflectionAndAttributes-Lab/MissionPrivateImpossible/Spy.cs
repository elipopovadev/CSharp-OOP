namespace Stealer
{
    using System;
    using System.Reflection;
    using System.Text;
    using System.Linq;
   public class Spy
    {
        public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
        {
            Type type = typeof(Hacker);
            var instance =  Activator.CreateInstance(type, new object[] { }) as Hacker;
           
            var sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {type}");
            foreach (var fieldAsString in fieldsToInvestigate)
            {
                var field = type.GetField($"{fieldAsString}", BindingFlags.Instance| BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
                var fieldValue = field.GetValue(instance);
                sb.AppendLine($"{field.Name} = {fieldValue}");
            }

            string result = sb.ToString().TrimEnd();
            return result;
        }

        public string AnalyzeAcessModifiers(string className)
        {
            Type type = typeof(Hacker);
            var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
            var publicMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            var privateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            var sb = new StringBuilder();
            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name} must be private");
            }

            foreach (var method in publicMethods.Where(m=>m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public");
            }

            foreach (var method in privateMethods.Where(m=> m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private");
            }

            string result = sb.ToString().TrimEnd();
            return result;
        }

        public string RevealPrivateMethods(string className)
        {
            Type type = typeof(Hacker);
            var sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {className}");
            var baseClass = type.BaseType.Name;
            sb.AppendLine($"Base Class: {baseClass}");
            var privateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach(var method in privateMethods)
            {
                sb.AppendLine(method.Name);
            }

            string result = sb.ToString().TrimEnd();
            return result;
        }
    }
}
