using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace EcommerceTests.Tests;

public class CartTests : PageTest
{
    [Test]
    public async Task ValidUser_ShouldAddProductToCart()
    {
        await Page.GotoAsync("https://www.saucedemo.com/");

        await Page.Locator("#user-name").FillAsync("standard_user");
        await Page.Locator("#password").FillAsync("secret_sauce");
        await Page.Locator("#login-button").ClickAsync();

        await Page.Locator("#add-to-cart-sauce-labs-backpack").ClickAsync();
        await Page.Locator(".shopping_cart_link").ClickAsync();

        await Expect(Page.Locator(".inventory_item_name"))
            .ToHaveTextAsync("Sauce Labs Backpack");
    }

    [Test]
    public async Task ValidUser_ShouldRemoveProductFromCart()
    {
        await Page.GotoAsync("https://www.saucedemo.com/");

        await Page.Locator("#user-name").FillAsync("standard_user");
        await Page.Locator("#password").FillAsync("secret_sauce");
        await Page.Locator("#login-button").ClickAsync();

        await Page.Locator("#add-to-cart-sauce-labs-backpack").ClickAsync();
        await Page.Locator(".shopping_cart_link").ClickAsync();

        await Page.Locator("#remove-sauce-labs-backpack").ClickAsync();

        await Expect(Page.Locator(".inventory_item_name"))
            .ToHaveCountAsync(0);
    }
}