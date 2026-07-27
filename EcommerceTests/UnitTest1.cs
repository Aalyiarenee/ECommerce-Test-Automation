using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace EcommerceTests;

public class LoginTests : PageTest
{
    [Test]
    public async Task ValidUser_ShouldLoginSuccessfully()
    {
        await Page.GotoAsync("https://www.saucedemo.com/");

        await Page.Locator("#user-name").FillAsync("standard_user");
        await Page.Locator("#password").FillAsync("secret_sauce");
        await Page.Locator("#login-button").ClickAsync();

        await Expect(Page)
            .ToHaveURLAsync("https://www.saucedemo.com/inventory.html");

        await Expect(Page.Locator(".title"))
            .ToHaveTextAsync("Products");
    }

    [Test]
    public async Task InvalidUser_ShouldSeeErrorMessage()
    {
        await Page.GotoAsync("https://www.saucedemo.com/");

        await Page.Locator("#user-name").FillAsync("invalid_user");
        await Page.Locator("#password").FillAsync("wrong_password");
        await Page.Locator("#login-button").ClickAsync();

        await Expect(Page.Locator("[data-test='error']"))
            .ToContainTextAsync("Username and password do not match");
    }

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
}