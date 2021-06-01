namespace Stealer
{
    using System;
    using System.Reflection;
    using System.Text;
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
                var field = type.GetField($"{fieldAsString}", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
                var fieldValue = field.GetValue(instance);
                sb.AppendLine($"{field.Name} = {fieldValue}");
            }

            string result = sb.ToString().TrimEnd();
            return result;
        }
    }
}
