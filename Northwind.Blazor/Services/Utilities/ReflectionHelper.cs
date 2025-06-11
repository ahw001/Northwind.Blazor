using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Northwind.Blazor.Services.Utilities;

public static class ReflectionHelper
{
    public static List<object> ConvertGenericListToListOfObject(object propertyValue)
    {
        // Check if propertyValue is a generic list
        if (propertyValue is IList && propertyValue.GetType().IsGenericType)
        {
            // Get the type of the elements in the list
            Type itemType = propertyValue.GetType().GetGenericArguments()[0];
            
            // Create a new List<object> to hold the elements
            var listOfObject = new List<object>();
            
            // Cast each element to object and add it to the new list
            foreach (var item in (IEnumerable)propertyValue)
            {
                listOfObject.Add(item);
            }
            
            return listOfObject;
        }
        else
        {
            throw new ArgumentException("The provided value is not a generic list.", nameof(propertyValue));
        }
    }
}
