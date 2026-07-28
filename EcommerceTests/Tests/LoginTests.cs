using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace EcommerceTests.Tests;

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
}