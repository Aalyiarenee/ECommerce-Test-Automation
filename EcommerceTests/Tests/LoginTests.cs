using EcommerceTests.Pages;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace EcommerceTests.Tests;

public class LoginTests : PageTest
{
    [Test]
    public async Task ValidUser_ShouldLoginSuccessfully()
    {
        var loginPage = new LoginPage(Page);

        await loginPage.NavigateAsync();
        await loginPage.LoginAsync("standard_user", "secret_sauce");

        await Expect(Page)
            .ToHaveURLAsync("https://www.saucedemo.com/inventory.html");

        await Expect(Page.Locator(".title"))
            .ToHaveTextAsync("Products");
    }

    [Test]
    public async Task InvalidUser_ShouldSeeErrorMessage()
    {
        var loginPage = new LoginPage(Page);

        await loginPage.NavigateAsync();
        await loginPage.LoginAsync("invalid_user", "wrong_password");

        await Expect(loginPage.ErrorMessage)
            .ToContainTextAsync("Username and password do not match");
    }
}