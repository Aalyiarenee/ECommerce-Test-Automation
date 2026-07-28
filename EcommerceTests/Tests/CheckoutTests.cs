using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace EcommerceTests.Tests;

public class CheckoutTests : PageTest
{
    [Test]
    public async Task ValidUser_ShouldCompleteCheckoutSuccessfully()
    {
        await Page.GotoAsync("https://www.saucedemo.com/");

        await Page.Locator("#user-name").FillAsync("standard_user");
        await Page.Locator("#password").FillAsync("secret_sauce");
        await Page.Locator("#login-button").ClickAsync();

        await Page.Locator("#add-to-cart-sauce-labs-backpack").ClickAsync();
        await Page.Locator(".shopping_cart_link").ClickAsync();

        await Page.Locator("#checkout").ClickAsync();

        await Page.Locator("#first-name").FillAsync("Aalyia");
        await Page.Locator("#last-name").FillAsync("Castle");
        await Page.Locator("#postal-code").FillAsync("43207");

        await Page.Locator("#continue").ClickAsync();

        await Expect(Page.Locator(".summary_info"))
            .ToBeVisibleAsync();

        await Page.Locator("#finish").ClickAsync();

        await Expect(Page.Locator(".complete-header"))
            .ToHaveTextAsync("Thank you for your order!");
    }

    [Test]
    public async Task Checkout_ShouldShowError_WhenRequiredFieldsAreMissing()
    {
        await Page.GotoAsync("https://www.saucedemo.com/");

        await Page.Locator("#user-name").FillAsync("standard_user");
        await Page.Locator("#password").FillAsync("secret_sauce");
        await Page.Locator("#login-button").ClickAsync();

        await Page.Locator("#add-to-cart-sauce-labs-backpack").ClickAsync();
        await Page.Locator(".shopping_cart_link").ClickAsync();

        await Page.Locator("#checkout").ClickAsync();
        await Page.Locator("#continue").ClickAsync();

        await Expect(Page.Locator("[data-test='error']"))
            .ToContainTextAsync("First Name is required");
    }
}