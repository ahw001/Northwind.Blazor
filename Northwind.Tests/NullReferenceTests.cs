using Bunit;
using Bunit.TestDoubles;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Northwind.Blazor.Model.Cybersource.BaseData;
using Northwind.Blazor.Components;
using Northwind.Blazor.Components.Pages;
using Northwind.Blazor.Components.Pages.PageUtils;// Adjust to your actual namespace
using Northwind.Blazor.Model.OutboundObjects;
using Northwind.Blazor.Services.DIServices;
using System.Collections.Generic;
using Xunit;

public class NullReferenceTests : TestContext
{
    private readonly Mock<ISessionTransactions> _mockSessionTransactions = new();

    public NullReferenceTests()
    {
        Services.AddSingleton(_mockSessionTransactions.Object);
    }

    [Fact]
    public void Renders_WhenAmountDetailsIsNull()
    {
        var customer = new B2cCustomer
        {
            FirstName = "Alice",
            AmountDetails = null,
            LineItem = new LineItems(),
            InvoiceInformation = new InvoiceInformation(),
            Freight = new Freight()
        };

        var cut = RenderComponent<CustomerComponent>(parameters => parameters
            .Add(p => p.FormCustomer, customer)
            .Add(p => p.FormElements, new List<string> { "ShowMainForm", "ShowBilling", "ShowAccountDetails", "ShowDefaults", "ShowAuthCapture", "ShowCart" })
        );

        Assert.Contains("First Name:", cut.Markup); // 👈 more reliable than "Billing Details"
    }


    [Fact]
    public void Renders_WhenLineItemIsNull()
    {
        var customer = new B2cCustomer
        {
            FirstName = "Bob",
            AmountDetails = new AmountDetails(),
            LineItem = null,
            InvoiceInformation = new InvoiceInformation(),
            Freight = new Freight()
        };

        var cut = RenderComponent<CustomerComponent>(parameters => parameters
            .Add(p => p.FormCustomer, customer)
            .Add(p => p.FormElements, new List<string> { "ShowMainForm", "ShowBilling", "ShowAccountDetails", "ShowDefaults", "ShowAuthCapture", "ShowCart" })
        );

        Assert.DoesNotContain("Line Item Discount Rate", cut.Markup);
    }

    [Fact]
    public void Redirects_WhenFormElementsIsNull()
    {
        var nav = Services.GetRequiredService<FakeNavigationManager>();

        var cut = RenderComponent<CustomerComponent>(parameters => parameters
            .Add(p => p.FormCustomer, new B2cCustomer())
            .Add(p => p.FormElements, null)
        );

        Assert.Contains("/errorhandler", nav.Uri);
    }

    [Fact]
    public void DoesNotCrash_WhenFreightIsNull()
    {
        var customer = new B2cCustomer
        {
            Freight = null,
            AmountDetails = new AmountDetails(),
            LineItem = new LineItems(),
            InvoiceInformation = new InvoiceInformation()
        };

        var cut = RenderComponent<CustomerComponent>(parameters => parameters
            .Add(p => p.FormCustomer, customer)
            .Add(p => p.FormElements, new List<string> { "ShowMainForm", "ShowBilling", "ShowAccountDetails", "ShowDefaults", "ShowAuthCapture", "ShowCart" })
        );

        // Confirm that the Freight-dependent section is skipped
        Assert.DoesNotContain("freightTaxable", cut.Markup);
    }


    [Fact]
    public void DoesNotCrash_WhenCustomerIsCompletelyNull()
    {
        var cut = RenderComponent<CustomerComponent>(parameters => parameters
            .Add(p => p.FormCustomer, null)
            .Add(p => p.FormElements, null)
        );

        Assert.Contains("Loading...", cut.Markup);
    }
}
