using Microsoft.Playwright;

namespace EcommerceTests.Pages;

public class InventoryPage
{
    private readonly IPage _page;

    public InventoryPage(IPage page)
    {
        _page = page;
    }

    public async Task AddBackpackToCartAsync()
    {
        await _page.Locator("#add-to-cart-sauce-labs-backpack").ClickAsync();
    }

    public async Task OpenCartAsync()
    {
        await _page.Locator(".shopping_cart_link").ClickAsync();
    }

    public ILocator CartBadge =>
        _page.Locator(".shopping_cart_badge");
}