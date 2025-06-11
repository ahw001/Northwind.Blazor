using System.Reflection;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

public static class RouteGenerator
{
    public static List<(string Route, string ComponentName)> GetRoutes(Assembly assembly)
    {
        return assembly
            .ExportedTypes
            .Where(t => typeof(ComponentBase).IsAssignableFrom(t))
            .SelectMany(t => t.GetCustomAttributes<RouteAttribute>(true),
                        (type, routeAttr) => (routeAttr.Template, type.Name))
            .ToList();
    }
}
