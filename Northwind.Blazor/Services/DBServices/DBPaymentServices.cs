using Northwind.Blazor.Model;
using Northwind.Blazor.Model.Cybersource.Transactions;
using Northwind.Blazor.Services.DTOs;
using Northwind.Blazor.Services.Utilities;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Northwind.Blazor.Services.DBServices
{
    public static class DBPaymentServices
    {
        private static PaymentCardDto result = new PaymentCardDto();
        private static List<PaymentCardDto> paymentCardDtos = new List<PaymentCardDto>();
        private static SessionTransJson sessionTransJson = new SessionTransJson();
        private static List<NetworkTokenInfoDto> networkTokenInfoDtos = new List<NetworkTokenInfoDto>();

        //private static IQueryable<NetworkTokenInfoDto>? queryableNetworkTokens;

        private static string error = string.Empty;
        private static string responseContent = string.Empty;
        public static async Task<PaymentCardDto> GetPaymentCard(int paymentCardId)
        {
            using HttpClient client = HttpClientHelper.CreateClient("Northwind.WebApi.Service");

            try
            {
                string path = $"/api/PaymentCardInfo/{paymentCardId}";
                PaymentCardDto? paymentCardDto = await client.GetFromJsonAsync<PaymentCardDto>(path)!;
                if (paymentCardDto != null)
                {
                    return paymentCardDto;
                }
                else
                {
                    paymentCardDto!.error = "No payment card found";
                    return paymentCardDto;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                error = ex.Message;
                PaymentCardDto paymentCardDto = new PaymentCardDto();
                paymentCardDto.error = error;
                return paymentCardDto;
            }

        }

        public static async Task<List<PaymentCardDto>> GetPaymentCardByCustId(int b2cCustomerId)
        {
            using HttpClient client = HttpClientHelper.CreateClient("Northwind.WebApi.Service");

            try
            {
                string path = $"/api/PaymentCardInfo/customer/{b2cCustomerId}";
                List<PaymentCardDto>? paymentCardDtos = await client.GetFromJsonAsync<List<PaymentCardDto>>(path)!;
                if (paymentCardDtos != null)
                {
                    return paymentCardDtos!;
                }
                else
                {
                    Console.WriteLine($"Null response from server");
                    error = "Null response from server";
                    paymentCardDtos = new List<PaymentCardDto>
                    {
                        new PaymentCardDto { error = error }
                    };
                    return paymentCardDtos;
                }
            }
            catch (Exception ex)
            {
                if (paymentCardDtos is null)
                {
                    paymentCardDtos = new List<PaymentCardDto>();
                }
                Console.WriteLine($"{ex.GetType()}: {ex.Message}");
                error = ex.Message;
                PaymentCardDto paymentCardDto = new PaymentCardDto();
                paymentCardDto.error = error;
                paymentCardDtos.Add(paymentCardDto);
                return paymentCardDtos;
            }
        }

        public static async Task<SessionTransJson> InsertPaymentCard(PaymentCardDto paymentCardDto)
        {
            string statusNode = string.Empty;
            string id = string.Empty;
            string orderId = string.Empty;
            string error = string.Empty;

            using HttpClient client = HttpClientHelper.CreateClient("Northwind.WebApi.Service");

            HttpResponseMessage response;

            try
            {
                string path = $"/api/PaymentCardInfo/";

                response = await client.PostAsJsonAsync<PaymentCardDto>(path, paymentCardDto)!;

                if ((int)response.StatusCode >= 500)
                {
                    error = response.ReasonPhrase!;
                    sessionTransJson.TransactionStatus = error;
                    sessionTransJson.JsonTransactionStateValues = TransactionStateValues.Error;
                    sessionTransJson.error = error;
                    Console.WriteLine("Server error.");
                    return sessionTransJson;
                }
                else if ((int)response.StatusCode >= 400)
                {
                    error = response.ReasonPhrase!;
                    sessionTransJson.error = error;
                    Console.WriteLine("Client error.");
                    sessionTransJson.JsonTransactionStateValues = TransactionStateValues.Error;
                    return sessionTransJson;
                }
                else if (response.IsSuccessStatusCode)
                {
                    responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"New Payment Card ID:", responseContent);
                    sessionTransJson.JsonTransactionStateValues = TransactionStateValues.Complete;
                    sessionTransJson.TransactionId = responseContent;
                    return sessionTransJson;
                }
                else
                {
                    sessionTransJson.JsonTransactionStateValues = TransactionStateValues.Error;
                    sessionTransJson.error = "unkown response code";
                    return sessionTransJson;
                }
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

        public static async Task<List<NetworkTokenInfoDto>> GetNetworkTokens(int paymentCardId)
        {
            networkTokenInfoDtos.Clear();

            JsonSerializerOptions jsonOptions = new()
            {
                
                PropertyNameCaseInsensitive = true
            };

            using HttpClient client = HttpClientHelper.CreateClient("Northwind.WebApi.Service");
            string path = $"/api/NetworkTokenInfo/{paymentCardId}";
            try
            {
                networkTokenInfoDtos = (await client.GetFromJsonAsync<List<NetworkTokenInfoDto>>(
                path, jsonOptions))!;
                return networkTokenInfoDtos;
            }

            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType()}: {ex.Message}");
                error = ex.Message;
                NetworkTokenInfoDto networkTokenInfoDto = new NetworkTokenInfoDto();
                networkTokenInfoDto.Error = error;
                networkTokenInfoDtos.Add(networkTokenInfoDto);
                return networkTokenInfoDtos;
            }
        }

        public static async Task<List<NetworkTokenInfoDto>> GetShippingAddresses(int paymentCardId)
        {
            networkTokenInfoDtos.Clear();

            JsonSerializerOptions jsonOptions = new()
            {
                
                PropertyNameCaseInsensitive = true
            };

            using HttpClient client = HttpClientHelper.CreateClient("Northwind.WebApi.Service");
            string path = $"/api/NetworkTokenInfo/{paymentCardId}";
            try
            {
                networkTokenInfoDtos = (await client.GetFromJsonAsync<List<NetworkTokenInfoDto>>(
                path, jsonOptions))!;
                return networkTokenInfoDtos;
            }

            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType()}: {ex.Message}");
                error = ex.Message;
                NetworkTokenInfoDto networkTokenInfoDto = new NetworkTokenInfoDto();
                networkTokenInfoDto.Error = error;
                networkTokenInfoDtos.Add(networkTokenInfoDto);
                return networkTokenInfoDtos;
            }
        }
    }
}
