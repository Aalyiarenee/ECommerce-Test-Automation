using Microsoft.Playwright;

namespace EcommerceTests.Pages;

public class CartPage
{
    private readonly IPage _page;

    public CartPage(IPage page)
    {
        _page = page;
    }

    public async Task RemoveBackpackAsync()
    {
        await _page.Locator("#remove-sauce-labs-backpack").ClickAsync();
    }

    public ILocator BackpackName =>
        _page.Locator(".inventory_item_name");
}