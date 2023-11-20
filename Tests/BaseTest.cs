using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightTests.cofiguration;
using PlaywrightTests.PageObjects;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class BaseTest : PageTest
{
    private IConfiguration Configuration { get; set; }

    public TestsSettings Settings { get; set; } = new TestsSettings() { };

    public UserCreditensials UserCreditensials { get; set; } = new UserCreditensials() { };

    public BaseTest()
    {
        Configuration = BuildConfig.ConfigurationRoot;
        Configuration.GetSection("LaunchSettings").Bind(Settings);
        Configuration.GetSection("UserCreditensials").Bind(UserCreditensials);
    }

    [OneTimeSetUp]
    public async Task PrepareStorageStateAsync()
    {
        using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        IBrowser browser = Settings.Browser switch
        {
            "chromium" => await playwright.Chromium.LaunchAsync(new() { Headless = false }),
            "msedge" => await playwright.Chromium.LaunchAsync(new() { Channel = "msedge", Headless = false }),
            "firefox" => await playwright.Firefox.LaunchAsync(new() { Headless = true }),
            _ => await playwright.Chromium.LaunchAsync(new() { Headless = true }),
        };
        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();
        await page.GotoAsync(Settings.Link);
        MainPage mainPage = new MainPage(page);
        mainPage.OpenLoginPagesAsync().Wait();
        LoginPage loginPage = new LoginPage(page);
        await loginPage.FillEmailAdress(UserCreditensials.Login);
        await loginPage.ClickContinueButton();
        await loginPage.FillPassword(UserCreditensials.Password);
        await loginPage.ClickLoginButton();
        await page.WaitForURLAsync($"**/u/{Settings.UserId}/boards");
        await context.StorageStateAsync(new()
        {
            Path = "state.json"
        });

        await context.CloseAsync();

    }

    public override BrowserNewContextOptions ContextOptions()
    {
        return new BrowserNewContextOptions()
        {
            ColorScheme = ColorScheme.Light,
            ViewportSize = new()
            {
                Width = 1920,
                Height = 1080
            },
            BaseURL = Settings.Link,
            StorageStatePath = "state.json",            
        };
    }
}