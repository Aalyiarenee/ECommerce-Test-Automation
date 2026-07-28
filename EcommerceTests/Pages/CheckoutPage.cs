using Microsoft.Playwright;

namespace EcommerceTests.Pages;

public class CheckoutPage
{
    private readonly IPage _page;

    public CheckoutPage(IPage page)
    {
        _page = page;
    }

    public async Task StartCheckoutAsync()
    {
        await _page.Locator("#checkout").ClickAsync();
    }

    public async Task EnterCustomerInfoAsync(
        string firstName,
        string lastName,
        string postalCode)
    {
        await _page.Locator("#first-name").FillAsync(firstName);
        await _page.Locator("#last-name").FillAsync(lastName);
        await _page.Locator("#postal-code").FillAsync(postalCode);
    }

    public async Task ContinueAsync()
    {
        await _page.Locator("#continue").ClickAsync();
    }

    public async Task FinishAsync()
    {
        await _page.Locator("#finish").ClickAsync();
    }

    public ILocator Summary =>
        _page.Locator(".summary_info");

    public ILocator ConfirmationMessage =>
        _page.Locator(".complete-header");

    public ILocator ErrorMessage =>
        _page.Locator("[data-test='error']");
}