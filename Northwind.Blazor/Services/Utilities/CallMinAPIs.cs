using Northwind.Blazor.Model;
using Northwind.Blazor.Model.Cybersource.Transactions;
using Northwind.Blazor.Model.OutboundObjects;
using Northwind.Blazor.Services.DIServices;
using Northwind.Blazor.Services.ErrorHandling;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Northwind.Blazor.Services.Utilities
{
    public static class CallMinAPIs
    {

        private static SessionTransJson sessionTransJson = new SessionTransJson();
        private static CcTransactionTypes currentTransaction;
        private static List<BasicErrorInfo> basicErrorInfos = new List<BasicErrorInfo>();
        private static B2cCustomer b2cCustomer = new B2cCustomer();


        public static async Task<SessionTransJson> SubmitForFollowOn(string followOnInput, ISessionTransactions _sessionTransactions, CcTransactionTypes current)
        {

            sessionTransJson = new();

            currentTransaction = current;

            if (_sessionTransactions is not null && _sessionTransactions.Transactions is not null
                && _sessionTransactions.Transactions.LastOrDefault() is not null)
            {
                sessionTransJson = _sessionTransactions.Transactions.LastOrDefault()!;
            }

            if (sessionTransJson.Customer is not null)
            {
                b2cCustomer = sessionTransJson.Customer!;
            }

            string statusNode = string.Empty;
            string id = string.Empty;
            string orderId = string.Empty;
            string error = string.Empty;
            string amount = string.Empty;

            // Safely check if followOnInput can be deserialized into B2cCustomer
            bool canDeserializeToB2cCustomer = false;
            B2cCustomer? deserializedCustomer = null;
            try
            {
                deserializedCustomer = JsonSerializer.Deserialize<B2cCustomer>(followOnInput);
                if (deserializedCustomer != null)
                {
                    canDeserializeToB2cCustomer = true;
                }
            }
            catch (JsonException)
            {
                // Invalid or incompatible JSON for B2cCustomer, do nothing
            }

            // Optionally, use the deserialized customer if needed
            if (canDeserializeToB2cCustomer) { b2cCustomer = deserializedCustomer!; }

            // Parse the JSON string into a JsonNode and cast it to JsonObject
            JsonObject? jsonObject = JsonNode.Parse(followOnInput) as JsonObject;

            /*
            // Check if the conversion was successful
            if (jsonObject != null)
            {
                Console.WriteLine("Successfully parsed JSON to JsonObject.");
                //Console.WriteLine(jsonObject.ToString()); // To print the JSON string representation of the JsonObject
            }
            else
            {
                Console.WriteLine("Failed to parse JSON to JsonObject.");
            }
            */
            // Serialize the object into a string for submission

            var options = new JsonSerializerOptions { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
            string jsonString = JsonSerializer.Serialize(followOnInput, options);

            try
            {
                JsonNode? jsonTransactionNode = JsonNode.Parse(jsonString);

                // Log the JSON output

                Console.WriteLine($"REQUEST JSON = {jsonTransactionNode?.ToString()}");

                //Create string for Http Client POST input

                string? jsonTransString = jsonTransactionNode?.ToString()!;

                using HttpClient client = HttpClientHelper.CreateClient("Northwind.WebApi.Service");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(jsonTransString, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response;

                if (currentTransaction == CcTransactionTypes.SAMPLE_CARD_LIST)
                {
                    // GET the transaction for list of sample cards *******************************

                    response = await client.GetAsync("api/samplecards/");

                    // GET the transaction for list of sample cards *******************************
                }
                else if (currentTransaction == CcTransactionTypes.SESSION_STATE_STORE)
                {
                    // Store the state of Session Transactions *******************************

                    response = await client.PostAsync("/api/session/sessionstore", content);

                    // Store the state of Session Transactions *******************************
                }
                else if (currentTransaction == CcTransactionTypes.SESSION_STATE_RETRIEVE)
                {
                    // Retrieve the customer transaction *******************************

                    string guid = followOnInput.Trim('"');

                    // If client.BaseAddress is set (as it should be when using named clients), this will give the full absolute URL:
                    string relativePath = $"/api/session/sessionretrieve/{guid}";
                    string fullUrl = client.BaseAddress != null
                        ? new Uri(client.BaseAddress, relativePath).ToString()
                        : relativePath;

                    Console.WriteLine("GET request to: " + fullUrl);

                    response = await client.GetAsync($"/api/session/sessionretrieve/{guid}");

                    // Retrieve the customer transaction *******************************
                }
                else if (currentTransaction == CcTransactionTypes.RANDOM_CUSTOMER)
                {
                    // GET the transaction for list of random customers *******************************

                    response = await client.GetAsync("api/randomcustomer/");

                    // GET the transaction for list of random customers *******************************
                }
                else if (currentTransaction == CcTransactionTypes.SAMPLE_INVOICE)
                {
                    // GET the transaction for list of sample invoice data *******************************

                    response = await client.GetAsync("/api/SampleInvoiceDetail");

                    // GET the transaction for list of sample invoice data *******************************
                }
                else if (currentTransaction == CcTransactionTypes.SAMPLE_PA_CARDS)
                {
                    // GET the transaction for list of sample payer auth cards *******************************

                    response = await client.GetAsync("api/samplecards/");

                    // GET the transaction for list of sample payer auth cards *******************************
                }
                else if (currentTransaction == CcTransactionTypes.SAMPLE_CART)
                {
                    // GET the transaction for list of sample cart items *******************************

                    response = await client.GetAsync("api/randomproducts");

                    // GET the transaction for list of sample cart items *******************************
                }
                else if (currentTransaction == CcTransactionTypes.GET_CATEGORY_LIST)
                {
                    // GET the transaction for list of sample cards *******************************

                    response = await client.GetAsync("api/Category/");

                    // GET the transaction for list of sample cards *******************************
                }
                else if (currentTransaction == CcTransactionTypes.SINGLE_SAMPLE_MERCHANT)
                {
                    // GET the transaction for a random merchant *******************************

                    response = await client.GetAsync("/api/merchantsampledatum/");

                    // GET the transaction for a random merchant *******************************
                }
                else if (currentTransaction == CcTransactionTypes.SAMPLE_AFT)
                {
                    // GET the transaction for a random aft merchant *******************************

                    response = await client.GetAsync("/api/merchantsampledatum/");

                    // GET the transaction for a random aft merchant *******************************
                }
                else if (currentTransaction == CcTransactionTypes.CREDIT)
                {
                    // POST the transaction for stand alone credit transaction *******************************

                    response = await client.PostAsync("api/standalonecredit", content);

                    // POST the transaction for stand alone credit transaction *******************************
                }
                else if (currentTransaction == CcTransactionTypes.SIMPLE_STRING)
                {
                    // POST the transaction for simple json transaction *******************************

                    response = await client.PostAsync("/api/json/processor", content);

                    // POST the transaction for simple json credit transaction *******************************
                }
                else if (currentTransaction == CcTransactionTypes.STANDALONE_AFT_TRANSACTION)
                {
                    // POST the transaction for aft pull transaction *******************************

                    response = await client.PostAsync("/api/payouts/sendaft", content);

                    // POST the transaction for aft pull transaction *******************************
                }
                else if (currentTransaction == CcTransactionTypes.TOKEN_AFT_TRANSACTION)
                {
                    // POST the transaction for aft pull transaction *******************************

                    response = await client.PostAsync("/api/payouts/sendaft", content);

                    // POST the transaction for aft pull transaction *******************************
                }
                else if (currentTransaction == CcTransactionTypes.FLEX_AFT_TRANSACTION)
                {
                    // POST the transaction for aft pull transaction using flex *******************************

                    response = await client.PostAsync("/api/payouts/sendaftflex", content);

                    // POST the transaction for aft pull transaction using flex  *******************************
                }
                else if (currentTransaction == CcTransactionTypes.FLEX_AFT_CHECK_ENROLL_AUTH)
                {
                    // POST the transaction for aft pull transaction using flex *******************************

                    response = await client.PostAsync("/api/payerauth/flexaftpacheckenroll", content);

                    // POST the transaction for aft pull transaction using flex  *******************************
                }
                else if (currentTransaction == CcTransactionTypes.FLEX_PA_SETUP)
                {
                    // POST the transaction for pa setup using flex JWT *******************************

                    response = await client.PostAsync("/api/payerauth/flexpayerauthsetup", content);

                    // POST the transaction for pa setup using flex JWT *******************************
                }
                else if (currentTransaction == CcTransactionTypes.FLEX_AFT_VALIDATE_AUTH)
                {
                    // POST the transaction for pa auth using Transient Token *******************************

                    response = await client.PostAsync("/api/payerauth/flexaftpavalidateauth", content);

                    // POST the transaction for pa auth using Transient Token *******************************
                }
                else if (currentTransaction == CcTransactionTypes.PA_ENROLL)
                {
                    // POST the transaction for pa check enroll using flex JWT *******************************

                    response = await client.PostAsync("/api/payerauth/flexpacheckenroll", content);

                    // POST the transaction for pa check enroll using flex JWT *******************************
                }
                else if (currentTransaction == CcTransactionTypes.PA_VALIDATE)
                {
                    // POST the transaction for pa validate *******************************

                    response = await client.PostAsync("/api/payerauth/flexaftpavalidate", content);

                    // POST the transaction for pa validate *******************************
                }
                else if (currentTransaction == CcTransactionTypes.SEMI_POS_SETUP)
                {
                    // POST the transaction for semi integrated pos setup *******************************

                    response = await client.PostAsync("/api/semiintpos/setup", content);

                    // POST the transaction for semi integrated pos setup *******************************
                }
                else if (currentTransaction == CcTransactionTypes.SEMI_POS_SALE)
                {
                    //POST the transaction for semi integrated pos sale ******************************

                    response = await client.PostAsync("/api/semiintpos/sale", content);

                    //POST the transaction for semi integrated pos sale *******************************
                }
                else if (currentTransaction == CcTransactionTypes.CLOUD_POS_BEARER_CREATE)
                {
                    // POST the transaction for cloud POS bearer create *******************************

                    response = await client.PostAsync("/api/cloudpos/bearer", content);

                    // POST the transaction for cloud POS bearer create *******************************
                }
                else if (currentTransaction == CcTransactionTypes.CLOUD_POS_BEARER_SALE)
                {
                    // POST the transaction for cloud pos sale *******************************

                    response = await client.PostAsync("/api/cloudpos/sale", content);

                    // POST the transaction cloud pos sale *******************************
                }
                else if (currentTransaction == CcTransactionTypes.CLOUD_POS_BEARER_RETURN || currentTransaction == CcTransactionTypes.CLOUD_POS_BEARER_STATUS_CHECK
                    || currentTransaction == CcTransactionTypes.CLOUD_POS_BEARER_STANDALONE_RETURN || currentTransaction == CcTransactionTypes.CLOUD_POS_CANCEL
                    || currentTransaction == CcTransactionTypes.CLOUD_POS_TOKEN_RETURN || currentTransaction == CcTransactionTypes.CLOUD_POS_CAPTURE)
                {
                    // POST the transaction for cloud pos sale *******************************

                    response = await client.PostAsync("/api/cloudpos/followon", content);

                    // POST the transaction cloud pos sale *******************************
                }
                else if (currentTransaction == CcTransactionTypes.FLEX_CHECKOUT)
                {
                    // POST the transaction for flex checkout *******************************

                    response = await client.PostAsync("/api/tokens/flexcapturecontext", content);

                    // POST the transaction for flex checkout *******************************
                }
                else if (currentTransaction == CcTransactionTypes.PA_SETUP)
                {
                    // POST the transaction for payer auth setup *******************************

                    response = await client.PostAsync("/api/payerauth/payerauthsetup", content);

                    // POST the transaction for payer auth setup *******************************
                }
                else if (currentTransaction == CcTransactionTypes.FLEX_CHECKOUT_PAYMENT)
                {
                    // POST the transaction for flex checkout *******************************

                    response = await client.PostAsync("/api/unified/unifiedpayment", content);

                    // POST the transaction for flex checkout *******************************
                }
                else if (currentTransaction == CcTransactionTypes.UNIFIED_CHECKOUT)
                {
                    // POST the transaction for unified checkout capture context*******************************

                    response = await client.PostAsync("/api/tokens/capturecontext", content);

                    // POST the transaction for unified  capture context *******************************
                }
                else if (currentTransaction == CcTransactionTypes.UNIFIED_CHECKOUT_PAYMENT)
                {
                    // POST the transaction for unified checkout *******************************

                    response = await client.PostAsync("/api/unified/unifiedpayment", content);

                    // POST the transaction for unified checkout *******************************
                }
                else if (currentTransaction == CcTransactionTypes.TRANS_TOKEN_INFORMATION)
                {
                    // POST the transaction for transient token retrieval *******************************

                    response = await client.PostAsync("/api/unified/transtokeninfo", content);

                    // POST the transaction for transient token retrieval  *******************************
                }
                else if ((currentTransaction == CcTransactionTypes.TOKEN_CREATE) ||
                    (currentTransaction == CcTransactionTypes.INST_ID_CREATE) ||
                    (currentTransaction == CcTransactionTypes.CUST_ID_CREATE) ||
                    (currentTransaction == CcTransactionTypes.PAY_ID_CREATE)
                    )
                {
                    bool performZeroAuth = false;
                    if (jsonObject is not null)
                    {
                        JsonNode? performZeroAuthNode = jsonObject["PerformZeroAuth"];
                        if (performZeroAuthNode != null && performZeroAuthNode.GetValue<bool>())
                        {
                            performZeroAuth = performZeroAuthNode.GetValue<bool>();
                            Console.WriteLine("PerformZeroAuth: " + performZeroAuth);
                        }
                        else
                        {
                            Console.WriteLine("PerformZeroAuth property not found or is null.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Parsed JSON is not a JsonObject.");
                    }

                    if (performZeroAuth)
                    {
                        // POST for the TOKEN TRANSACTION *******************

                        response = await client.PostAsync("/api/tokens/zeroauthtoken", content);

                        // POST for the TOKEN TRANSACTION *******************
                    }
                    else
                    {
                        // POST for the INDIVIDUAL TOKEN TRANSACTION *******************

                        response = await client.PostAsync("api/tokens/combined", content);

                        // POST for the INDIVIDUAL TOKEN TRANSACTION *******************
                    }
                }
                else if (currentTransaction == CcTransactionTypes.AUTH || currentTransaction == CcTransactionTypes.SALE)
                {
                    // POST for the AUTH/SALE TRANSACTION *******************

                    response = await client.PostAsync("api/authtransaction", content);

                    // POST for the AUTH/SALE TRANSACTION *******************
                }
                else if (currentTransaction == CcTransactionTypes.SHIPPING_ID_RETRIEVE)
                {
                    // POST the transaction for token retrieval transaction *******************************

                    response = await client.PostAsync("/api/tokens/retrieval", content);

                    // POST the transaction for token retrieval credit transaction *******************************
                }
                else if (currentTransaction == CcTransactionTypes.INVOICE_CREATE)
                {
                    // POST the transaction for invoice creation *******************************

                    response = await client.PostAsync("/api/invoice/createinvoice", content);

                    // POST the transaction for invoice creation *******************************
                }
                else if (currentTransaction == CcTransactionTypes.MERCHANT_BOARDING_CREATE)
                {
                    // POST the transaction for merchant boarding *******************************

                    response = await client.PostAsync("/api/merchantboarding/createmerchant", content);

                    // POST the transaction for merchant boarding *******************************
                }
                else if (currentTransaction == CcTransactionTypes.TRANSACTION_BOARDING_CREATE)
                {
                    // POST the transaction for transacting merchant boarding *******************************

                    response = await client.PostAsync("/api/merchantboarding/createtransmerchant", content);

                    // POST the transaction for transacting merchant boarding *******************************
                }
                else
                {
                    // POST the transaction for follow on transaction *******************************

                    response = await client.PostAsync("api/followontrans", content);

                    // POST the transaction for follow on transaction *******************************
                }

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var jsonResponseNode = JsonNode.Parse(jsonResponse!); // TODO ADD BREAKPOINT

                if ((int)response.StatusCode >= 500)
                {
                    error = response.ReasonPhrase!;
                    _sessionTransactions?.DeleteAll();
                    sessionTransJson = new();
                    sessionTransJson.TransactionStatus = error;
                    sessionTransJson.error = error;
                    return sessionTransJson;
                }
                else if ((int)response.StatusCode >= 400)
                {
                    error = response.ReasonPhrase!;
                    _sessionTransactions?.DeleteAll();
                    sessionTransJson = new();
                    sessionTransJson.TransactionStatus = error;
                    sessionTransJson.error = error;
                    return sessionTransJson;
                }
                else if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Request was successful.\n");
                    Console.WriteLine($"JSON RESPONSE for {currentTransaction} = {jsonResponse}");
                    Console.WriteLine("****************** CALLING GENERIC ERROR HANDLER ******************\n");
                    basicErrorInfos = JsonErrorExtractor.ExtractErrorObjects(jsonResponse);

                    string[] errorKeywords = ["INVALID", "ERROR", "FAILED", "DECLINED", "error", "invalid", "failed", "declined"];
                    bool containsError = basicErrorInfos.Any(e =>
                        !string.IsNullOrWhiteSpace(e.Status) &&
                        errorKeywords.Any(keyword =>
                            e.Status.Contains(keyword, StringComparison.OrdinalIgnoreCase)));

                    if (containsError)
                    {
                        _sessionTransactions?.DeleteAll();
                        sessionTransJson = new();
                        sessionTransJson.TransactionJson = jsonResponseNode;
                        sessionTransJson.error = basicErrorInfos.FirstOrDefault(e => e.Status != null)?.ToString()
                            ?? "No Error Data";
                        sessionTransJson.TransactionStatus = "error";
                        sessionTransJson.JsonTransactionStateValues = TransactionStateValues.Error;
                        _sessionTransactions!.AddTrans(sessionTransJson);
                        return sessionTransJson;
                    }
                    else if (jsonResponse is null)
                    {
                        _sessionTransactions?.DeleteAll();
                        sessionTransJson = new();
                        error = "NULL TRANSACTION RESPONSE.";
                        sessionTransJson.TransactionStatus = error;
                        sessionTransJson.error = error;
                        return sessionTransJson;
                    }
                    else
                    {
                        sessionTransJson = new();

                        sessionTransJson.TransactionJson = jsonResponseNode;

                        if (jsonResponseNode is JsonObject jsonResponseObject)
                        {
                            statusNode = (string?)jsonResponseObject["status"] ?? "null";
                            orderId = (string?)jsonResponseObject["OrderId"] ?? "null";
                            id = (string?)jsonResponseObject["id"] ?? "null";
                            amount = (string?)jsonResponseObject["orderInformation"]?["amountDetails"]?["authorizedAmount"] ?? "0";
                        }

                        if (b2cCustomer is not null)
                        {
                            sessionTransJson.Customer = b2cCustomer;
                        }

                        sessionTransJson.TransactionType = statusNode ?? "null";
                        sessionTransJson.TransactionId = id ?? "null";
                        sessionTransJson.TransactionOrderId = orderId ?? "0";
                        sessionTransJson.TransactionAmount = amount ?? "0";
                        sessionTransJson.JsonTransactionStateValues = TransactionStateValues.Complete;
                        sessionTransJson.CurrentTransactionType = currentTransaction;
                        sessionTransJson.FollowOnTransaction = currentTransaction;
                        _sessionTransactions!.AddTrans(sessionTransJson);

                        return sessionTransJson;
                    }
                }

                Console.WriteLine("******** TRANSACTION STATE UNKNOWN \n");

                sessionTransJson.TransactionJson = jsonResponseNode;
                sessionTransJson.JsonTransactionStateValues = TransactionStateValues.Unknown;
                sessionTransJson.CurrentTransactionType = currentTransaction;
                sessionTransJson.FollowOnTransaction = currentTransaction;

                return sessionTransJson;


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                error = ex.Message;
                sessionTransJson.TransactionStatus = error;
                sessionTransJson.error = error;

                return sessionTransJson;
            }
        }
        public static async Task<string> SubmitForTokenDecryption(string tokenStringInput)
        {
            string error = string.Empty;
            // Serialize the object into a string for submission

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(tokenStringInput, options);

            try
            {
                // Convert product json string to JsonNode to allow for editing (if necessary)
                JsonNode? jsonTransactionNode = JsonNode.Parse(jsonString);

                // Log the JSON output

                Console.WriteLine("**************** SUBMITTING FOR TOKEN DECRYPT *********\n");

                Console.WriteLine($"REQUEST JSON = {jsonTransactionNode?.ToString()}");

                //Create string for Http Client POST input

                string? jsonTransString = jsonTransactionNode?.ToString()!;

                using HttpClient client = HttpClientHelper.CreateClient("Northwind.WebApi.Service");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(jsonTransString, System.Text.Encoding.UTF8, "application/json");

                // POST the transaction for NT decryption *******************************

                HttpResponseMessage response = await client.PostAsync("api/ntdecrypt", content);

                // POST the transaction for NT decryption *******************************

                if ((int)response.StatusCode >= 500)
                {
                    error = response.ReasonPhrase!;
                    Console.WriteLine("Server error.");
                    return error;
                }
                else if ((int)response.StatusCode >= 400)
                {
                    error = response.ReasonPhrase!;
                    Console.WriteLine("Client error.");
                    return error;
                }
                else if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Request was successful.");

                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    return jsonResponse;
                }
                else
                {
                    error = response.ReasonPhrase!;
                    Console.WriteLine($"Unexpected status code: {response.StatusCode}");
                    return error;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                error = ex.Message;
                return error;
            }

        }
    }
}
