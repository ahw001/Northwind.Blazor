using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Northwind.Blazor.Services.ErrorHandling;

public class BasicErrorInfo
{
    public string? Status { get; set; }
    public string? Reason { get; set; }
    public string? Message { get; set; }
    public string? Action { get; set; }

    public override string ToString()
    {
        return $"Status: {Status}, Reason: {Reason}, Message: {Message}, Action: {Action}";
    }
}

public static class JsonErrorExtractor
{
    public static List<BasicErrorInfo> ExtractErrorObjects(string json)
    {
        using var document = JsonDocument.Parse(json);
        var results = new List<BasicErrorInfo>();

        ProcessElement(document.RootElement, results);

        return results;
    }

    private static void ProcessElement(JsonElement element, List<BasicErrorInfo> results)
    {
        if (element.ValueKind == JsonValueKind.Object)
        {
            var errorInfo = new BasicErrorInfo();

            // Try to extract fields from current object
            if (element.TryGetProperty("status", out var statusProp))
                errorInfo.Status = statusProp.GetString();

            if (element.TryGetProperty("errorInformation", out var errorInfoProp))
            {
                if (errorInfoProp.TryGetProperty("reason", out var reasonProp))
                    errorInfo.Reason = reasonProp.GetString();
                if (errorInfoProp.TryGetProperty("message", out var messageProp))
                    errorInfo.Message = messageProp.GetString();
            }

            if (element.TryGetProperty("riskInformation", out var riskProp) &&
                riskProp.TryGetProperty("profile", out var profileProp) &&
                profileProp.TryGetProperty("action", out var actionProp))
            {
                errorInfo.Action = actionProp.GetString();
            }

            // Fallback for objects that directly contain reason/message/action
            if (element.TryGetProperty("reason", out var reasonFallback))
                errorInfo.Reason = errorInfo.Reason ?? reasonFallback.GetString();
            if (element.TryGetProperty("message", out var messageFallback))
                errorInfo.Message = errorInfo.Message ?? messageFallback.GetString();
            if (element.TryGetProperty("action", out var actionFallback))
                errorInfo.Action = errorInfo.Action ?? actionFallback.GetString();

            // Include if any error info exists at all
            bool hasErrorContent =
                !string.IsNullOrEmpty(errorInfo.Status) ||
                !string.IsNullOrEmpty(errorInfo.Reason) ||
                !string.IsNullOrEmpty(errorInfo.Message) ||
                !string.IsNullOrEmpty(errorInfo.Action);

            // Optional: only include if status is ERROR, INVALID, DECLINED
            bool isErrorStatus = !string.IsNullOrEmpty(errorInfo.Status) &&
                (errorInfo.Status.Contains("ERROR", StringComparison.OrdinalIgnoreCase) ||
                 errorInfo.Status.Contains("INVALID", StringComparison.OrdinalIgnoreCase) ||
                 errorInfo.Status.Contains("DECLINED", StringComparison.OrdinalIgnoreCase));

            if (isErrorStatus || hasErrorContent)
                results.Add(errorInfo);

            // Recurse into properties
            foreach (var property in element.EnumerateObject())
            {
                ProcessElement(property.Value, results);
            }
        }
        else if (element.ValueKind == JsonValueKind.Array)
        {
            foreach (var item in element.EnumerateArray())
            {
                ProcessElement(item, results);
            }
        }
    }
}

