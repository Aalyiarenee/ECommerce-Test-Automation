using Microsoft.Playwright;

namespace EcommerceTests.Pages;

public class LoginPage
{
    private readonly IPage _page;

    public LoginPage(IPage page)
    {
        _page = page;
    }

    public async Task NavigateAsync()
    {
        await _page.GotoAsync("https://www.saucedemo.com/");
    }

    public async Task LoginAsync(string username, string password)
    {
        await _page.Locator("#user-name").FillAsync(username);
        await _page.Locator("#password").FillAsync(password);
        await _page.Locator("#login-button").ClickAsync();
    }

    public ILocator ErrorMessage =>
        _page.Locator("[data-test='error']");
}