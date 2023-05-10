using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightTests.cofiguration;
using PlaywrightTests.PageObjects;
using PlaywrightTests.PageObjects.Dashboard;
using System.Configuration;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class BaseTest : PageTest
{
    private IConfiguration Configuration { get; set; }
    public TestsSettings settings { get; set; } = new TestsSettings() { };
    public string? PageAddress { get; set; }

    public BaseTest()
    {
        Configuration = BuildConfig.ConfigurationRoot;
        Configuration.GetSection("LaunchSettings").Bind(settings);
    }

    [OneTimeSetUp]
    public async Task PrepareStorageStateAsync()
    {
        using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        IBrowser browser;
        switch (settings.Browser)
        {
            case "chromium":
                browser = await playwright.Chromium.LaunchAsync(new() { Headless = false });
                break;
            case "msedge":
                browser = await playwright.Chromium.LaunchAsync(new() { Channel = "msedge", Headless = false });
                break;
            case "firefox":
                browser = await playwright.Firefox.LaunchAsync(new() { Headless = true });
                break;
            default:
                browser = await playwright.Chromium.LaunchAsync(new() { Headless = true });
                break;
        }
        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();
        await page.GotoAsync(settings.Link);
        MainPage mainPage = new MainPage(page);
        mainPage.OpenLoginPagesAsync().Wait();
        LoginPage loginPage = new LoginPage(page);
        await loginPage.FillEmailAdress("sejak92669@soombo.com");
        await loginPage.ClickContinueButton();
        await loginPage.FillPassword("123Qwerty");
        await loginPage.ClickLoginButton();
        await page.WaitForURLAsync("**/u/testingman3/boards");
        await context.StorageStateAsync(new()
        {
            Path = "playwright/.auth/state.json"
        });
        // Dispose context once it is no longer needed.
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
            BaseURL = settings.Link,
            StorageStatePath = "playwright/.auth/state.json"
        };
    }
}