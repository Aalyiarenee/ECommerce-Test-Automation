using EcommerceTests.Pages;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace EcommerceTests.Tests;

public class CartTests : PageTest
{
    [Test]
    public async Task ValidUser_ShouldAddProductToCart()
    {
        var loginPage = new LoginPage(Page);
        var inventoryPage = new InventoryPage(Page);
        var cartPage = new CartPage(Page);

        await loginPage.NavigateAsync();
        await loginPage.LoginAsync("standard_user", "secret_sauce");

        await inventoryPage.AddBackpackToCartAsync();
        await inventoryPage.OpenCartAsync();

        await Expect(cartPage.BackpackName)
            .ToHaveTextAsync("Sauce Labs Backpack");
    }

    [Test]
    public async Task ValidUser_ShouldRemoveProductFromCart()
    {
        var loginPage = new LoginPage(Page);
        var inventoryPage = new InventoryPage(Page);
        var cartPage = new CartPage(Page);

        await loginPage.NavigateAsync();
        await loginPage.LoginAsync("standard_user", "secret_sauce");

        await inventoryPage.AddBackpackToCartAsync();
        await inventoryPage.OpenCartAsync();

        await cartPage.RemoveBackpackAsync();

        await Expect(cartPage.BackpackName)
            .ToHaveCountAsync(0);
    }
}