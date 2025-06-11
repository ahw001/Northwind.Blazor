﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Northwind.Blazor.Model.Cybersource.BaseData;


namespace Northwind.Blazor.Model.Cybersource.CloudPos;

public class CloudPaymentResponseJson
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("transactionDetails")]
    public TransactionDetails? TransactionDetails { get; set; }

    [JsonPropertyName("processingDetails")]
    public ProcessingDetails? ProcessingDetails { get; set; }

    [JsonPropertyName("additionalInformation")]
    public AdditionalInformation? AdditionalInformation { get; set; }

    [JsonPropertyName("linkedOperations")]
    public List<object>? LinkedOperations { get; set; }

    [JsonPropertyName("tipAdjustStatus")]
    public string? TipAdjustStatus { get; set; }

    [JsonPropertyName("receipts")]
    public Receipts? Receipts { get; set; }

    [JsonPropertyName("merchantDetails")]
    public MerchantDetails? MerchantDetails { get; set; }

    [JsonPropertyName("taxDetails")]
    public TaxDetails? TaxDetails { get; set; }

    [JsonPropertyName("installmentDetails")]
    public InstallmentDetails? InstallmentDetails { get; set; }
}
