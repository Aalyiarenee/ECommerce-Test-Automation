using EcommerceTests.Pages;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace EcommerceTests.Tests;

public class CheckoutTests : PageTest
{
    [Test]
    public async Task ValidUser_ShouldCompleteCheckoutSuccessfully()
    {
        var loginPage = new LoginPage(Page);
        var inventoryPage = new InventoryPage(Page);
        var checkoutPage = new CheckoutPage(Page);

        await loginPage.NavigateAsync();
        await loginPage.LoginAsync("standard_user", "secret_sauce");

        await inventoryPage.AddBackpackToCartAsync();
        await inventoryPage.OpenCartAsync();

        await checkoutPage.StartCheckoutAsync();
        await checkoutPage.EnterCustomerInfoAsync(
            "Aalyia",
            "Castle",
            "43207");

        await checkoutPage.ContinueAsync();

        await Expect(checkoutPage.Summary)
            .ToBeVisibleAsync();

        await checkoutPage.FinishAsync();

        await Expect(checkoutPage.ConfirmationMessage)
            .ToHaveTextAsync("Thank you for your order!");
    }

    [Test]
    public async Task Checkout_ShouldShowError_WhenRequiredFieldsAreMissing()
    {
        var loginPage = new LoginPage(Page);
        var inventoryPage = new InventoryPage(Page);
        var checkoutPage = new CheckoutPage(Page);

        await loginPage.NavigateAsync();
        await loginPage.LoginAsync("standard_user", "secret_sauce");

        await inventoryPage.AddBackpackToCartAsync();
        await inventoryPage.OpenCartAsync();

        await checkoutPage.StartCheckoutAsync();
        await checkoutPage.ContinueAsync();

        await Expect(checkoutPage.ErrorMessage)
            .ToContainTextAsync("First Name is required");
    }
}