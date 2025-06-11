using Northwind.Blazor.Model.Cybersource.Authorization;
using Northwind.Blazor.Model.Cybersource.BaseData;
using Northwind.Blazor.Model.Cybersource.Boarding;
using Northwind.Blazor.Model.Cybersource.CloudPos;
using Northwind.Blazor.Model.Cybersource.ErrorModel;
using Northwind.Blazor.Model.Cybersource.FlexResponse;
using Northwind.Blazor.Model.Cybersource.FollowOnTransactions;
using Northwind.Blazor.Model.Cybersource.PASetupResponse;
using Northwind.Blazor.Model.Cybersource.PayerAuthentication;
using Northwind.Blazor.Model.Cybersource.TokenCreate;
using Northwind.Blazor.Model.OutboundObjects;
using Northwind.Blazor.Services.DTOs;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Northwind.Blazor.Services.Utilities
{
    public static class PropertiesProcessor
    {

        private static List<string> propertyValues = new List<string>();

        private static AuthTransResponse? authTransResponse = new();
        private static NtDecodeInstIdRequest ntDecodeInstIdRequest = new();
        private static RootToken rootToken = new();
        private static B2cCustomer b2cCustomer = new();
        private static CheckEnrollDto checkEnrollDto = new();
        private static AftCheckEnrollDto aftCheckEnrollDto = new();
        private static FollowOnTransResponse followOnTransResponse = new();
        private static FollowOnInvoiceTransResponse followOnInvoiceTransResponse = new();
        private static ConsumerAuthenticationInformation consumerAuthenticationInformation = new();
        private static ErrorResponse errorResponse = new();
        private static FlexRoot flexRoot = new();
        private static TokenData tokenData = new();
        private static HashSet<object> visitedObjects = new HashSet<object>();
        private static PASetupResponse paSetupResponse = new();
        private static BoardingResponseRoot boardingResponseRoot = new();
        private static CloudPaymentResponseJson cloudPaymentResponseJson = new();
        private static DeviceDataCollectionInformation deviceDataCollectionInformation = new();
        private static Dictionary<string, string> propertyValuesDict = new Dictionary<string, string>();
        private static PaReqResponse paReqResponse = new();
        private static ErrorObject errorObject = new();

        public static void Clear()
        {
            propertyValues.Clear();
        }


        public static List<string> GetProperties(object response)
        {
            propertyValues.Clear();

            if (response is AuthTransResponse)
            {
                authTransResponse = (AuthTransResponse)response;
                GatherProperties(authTransResponse!, "");
            }
            else if (response is ErrorObject)
            {
                errorObject = (ErrorObject)response;
                GatherProperties(errorObject!, "");
            }
            else if (response is RootToken)
            {
                rootToken = (RootToken)response;
                GatherProperties(rootToken!, "");
            }
            else if (response is NtDecodeInstIdRequest)
            {
                ntDecodeInstIdRequest = (NtDecodeInstIdRequest)response;
                GatherProperties(ntDecodeInstIdRequest!, "");
            }
            else if (response is FollowOnTransResponse)
            {
                followOnTransResponse = (FollowOnTransResponse)response;
                GatherProperties(followOnTransResponse!, "");
            }
            else if (response is FollowOnInvoiceTransResponse)
            {
                followOnInvoiceTransResponse = (FollowOnInvoiceTransResponse)response;
                GatherProperties(followOnInvoiceTransResponse!, "");
            }
            else if (response is ErrorResponse)
            {
                errorResponse = (ErrorResponse)response;
                GatherProperties(errorResponse!, "");
            }
            else if (response is FlexRoot)
            {
                flexRoot = (FlexRoot)response;
                GatherProperties(flexRoot, "");
            }
            else if (response is TokenData)
            {
                tokenData = (TokenData)response;
                GatherProperties(tokenData, "");
            }
            else if (response is PASetupResponse)
            {
                paSetupResponse = (PASetupResponse)response;
                GatherProperties(paSetupResponse, "");
            }
            else if (response is BoardingResponseRoot)
            {
                boardingResponseRoot = (BoardingResponseRoot)response;
                GatherProperties(boardingResponseRoot, "");
            }
            else if (response is CloudPaymentResponseJson)
            {
                cloudPaymentResponseJson = (CloudPaymentResponseJson)response;
                GatherProperties(cloudPaymentResponseJson, "");
            }
            else if (response is DeviceDataCollectionInformation)
            {
                deviceDataCollectionInformation = (DeviceDataCollectionInformation)response;
                GatherProperties(deviceDataCollectionInformation, "");
            }
            else if (response is CheckEnrollDto)
            {
                checkEnrollDto = (CheckEnrollDto)response;
                GatherProperties(checkEnrollDto, "");
            }
            else if (response is AftCheckEnrollDto)
            {
                aftCheckEnrollDto = (AftCheckEnrollDto)response;
                GatherProperties(aftCheckEnrollDto, "");
            }
            else if (response is B2cCustomer)
            {
                b2cCustomer = (B2cCustomer)response;
                GatherProperties(b2cCustomer, "");
            }
            else if (response is ConsumerAuthenticationInformation)
            {
                consumerAuthenticationInformation = (ConsumerAuthenticationInformation)response;
                GatherProperties(consumerAuthenticationInformation, "");
            }
            else if (response is PaReqResponse)
            {
                paReqResponse = (PaReqResponse)response;
                GatherProperties(paReqResponse, "");
            }

            return propertyValues;
        }

        public static void GatherProperties(object obj, string prefix)
        {
            if (obj == null) return;

            // Check if this object has already been visited to prevent infinite loops
            if (visitedObjects.Contains(obj))
            {
                return;
            }

            // Mark this object as visited
            visitedObjects.Add(obj);

            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                // Check if the property is an indexer. If it is, skip it.
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
                        propertyValues.Add($"{prefix}{prop.Name}: {value}");
                        Console.WriteLine($"{prefix}{prop.Name}: {value}");
                    }
                }
                else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>) && type.GetGenericArguments()[0] == typeof(Detail))
                {
                    value = prop.GetValue(obj);
                    if (value is not null)
                    {
                        List<Detail>? list = value as List<Detail>;
                        int index = 0;
                        foreach (var item in list!)
                        {
                            GatherProperties(item, $"{prefix}{prop.Name}.");
                            index++;
                        }
                    }
                }
                else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>) && type.GetGenericArguments()[0] == typeof(Details))
                {
                    value = prop.GetValue(obj);
                    if (value is not null)
                    {
                        List<Details>? list = value as List<Details>;
                        int index = 0;
                        foreach (var item in list!)
                        {
                            GatherProperties(item, $"{prefix}{prop.Name}.");
                            index++;
                        }
                    }
                }
                else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>) && type.GetGenericArguments()[0] == typeof(LineItems))
                {
                    value = prop.GetValue(obj);
                    if (value is not null)
                    {
                        List<LineItems>? list = value as List<LineItems>;
                        int index = 0;
                        foreach (var item in list!)
                        {
                            GatherProperties(item, $"{prefix}{prop.Name}.");
                            index++;
                        }
                    }
                }
                else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>) && type.GetGenericArguments()[0] == typeof(ConsumerAuthenticationInformation))
                {
                    value = prop.GetValue(obj);
                    if (value is not null)
                    {
                        List<LineItems>? list = value as List<LineItems>;
                        int index = 0;
                        foreach (var item in list!)
                        {
                            GatherProperties(item, $"{prefix}{prop.Name}.");
                            index++;
                        }
                    }
                }
                else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>) && type.GetGenericArguments()[0] == typeof(RiskInformation))
                {
                    value = prop.GetValue(obj);
                    if (value is not null)
                    {
                        List<LineItems>? list = value as List<LineItems>;
                        int index = 0;
                        foreach (var item in list!)
                        {
                            GatherProperties(item, $"{prefix}{prop.Name}.");
                            index++;
                        }
                    }
                }
                else if (value != null) // Assuming it's a nested object
                {
                    GatherProperties(value, $"{prefix}{prop.Name}.");
                }
            }
        }
        public static Object GetTypeForForm(Object obj)
        {
            System.Type t1 = obj.GetType();
            bool isString;
            if (t1.IsValueType || (isString = t1 == typeof(string)))
            {
                return obj;
            }
            else
            {
                return "";
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
                                                        //Console.WriteLine(extractedValue); // Output: ShippingSameAsBilling
            }
            //if (string.IsNullOrEmpty(input)) return input;

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
