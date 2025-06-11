using Northwind.Blazor.Model.Cybersource.Authorization;
using Northwind.Blazor.Model.Cybersource.BaseData;
using Northwind.Blazor.Model.Cybersource.Boarding;
using Northwind.Blazor.Model.Cybersource.ErrorModel;
using Northwind.Blazor.Model.Cybersource.FlexResponse;
using Northwind.Blazor.Model.Cybersource.FollowOnTransactions;
using Northwind.Blazor.Model.Cybersource.PASetupResponse;
using Northwind.Blazor.Model.Cybersource.TokenCreate;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Text;

namespace Northwind.Blazor.Services.Utilities
{
    public static class DictPropertiesProcessor
    {
        private static Dictionary<string, string> propertyValues = new Dictionary<string, string>();
        private static HashSet<object> visitedObjects = new HashSet<object>();

        public static Dictionary<string, string> GetProperties(object response)
        {
            // Clear previous data
            propertyValues.Clear();
            visitedObjects.Clear();

            // Call GatherProperties to populate the dictionary
            GatherProperties(response, "");

            return propertyValues;
        }

        public static void GatherProperties(object obj, string prefix)
        {
            if (obj == null) return;

            // Prevent infinite loops with cyclic references
            if (visitedObjects.Contains(obj))
            {
                return;
            }

            // Mark object as visited
            visitedObjects.Add(obj);

            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                // Skip indexers
                if (prop.GetIndexParameters().Length > 0)
                {
                    continue;
                }

                var value = prop.GetValue(obj);
                var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                if (type.IsPrimitive || type == typeof(string) || type == typeof(DateTime) || type == typeof(decimal))
                {
                    if (value != null)
                    {
                        // Add property name and value to dictionary
                        propertyValues.Add($"{prefix}{prop.Name}", value!.ToString()!);
                    }
                }
                else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
                {
                    var list = value as System.Collections.IEnumerable;
                    if (list != null)
                    {
                        int index = 0;
                        foreach (var item in list)
                        {
                            GatherProperties(item, $"{prefix}{prop.Name}[{index}].");
                            index++;
                        }
                    }
                }
                else if (value != null) // For nested objects
                {
                    GatherProperties(value, $"{prefix}{prop.Name}.");
                }
            }
        }

        public static string ConvertToSpaced(string input)
        {
            string pattern = @"\<(.*?)\>"; // Regex pattern to match text between < and >
            string extractedValue = string.Empty;

            Match match = Regex.Match(input, pattern);
            if (match.Success)
            {
                extractedValue = match.Groups[1].Value; // The content between < and >
            }

            StringBuilder result = new StringBuilder();
            result.Append(extractedValue[0]);

            for (int i = 1; i < extractedValue.Length; i++)
            {
                if (char.IsUpper(extractedValue[i]))
                {
                    result.Append(" ");
                }
                result.Append(extractedValue[i]);
            }

            return result.ToString();
        }
    }

}
