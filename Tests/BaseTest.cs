using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightTests.cofiguration;
using PlaywrightTests.PageObjects;
using System.Configuration;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class BaseTest
{
    private IConfiguration Configuration { get; set; }
    TestsSettings settings { get; set; } = new TestsSettings() { };
    public string PageAddress { get; set; }

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
        // Create a new page inside context.
        var page = await context.NewPageAsync();
        await page.GotoAsync(settings.Link);
        MainPage mainPage = new MainPage(page);
        mainPage.OpenLoginPagesAsync().Wait();
        LoginPage loginPage = new LoginPage(Page);
        await loginPage.FillEmailAdress("sejak92669@soombo.com");
        await loginPage.ClickContinueButton();
        await loginPage.FillPassword("123Qwerty");
        await loginPage.ClickLoginButton();

        await Context.StorageStateAsync(new()
        {
            Path = "state.json"
        });
        // Dispose context once it is no longer needed.
    }


    [Test]
    public async Task CreateNewTable()
    {
        using var playwright = await Playwright.CreateAsync();
        // Create a Chromium browser instance
        await using var browser = await playwright.Chromium.LaunchAsync(new()
        {
            Headless = false,
        });
        await using var context = await browser.NewContextAsync(new BrowserNewContextOptions()
        {
            BaseURL = settings.Link,
            IsMobile = true,
            StorageStatePath = "state.json"
        });

        var page = await context.NewPageAsync();
        DashBoardPage dashBoard = new DashBoardPage(page);
        dashBoard.OpenCreateNewTableFormAsync().Wait();
    }


}