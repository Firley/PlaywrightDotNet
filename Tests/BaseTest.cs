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
public class BaseTest : PageTest
{
    private IConfiguration Configuration { get; set; }
    TestsSettings settings { get; set; } = new TestsSettings() { };
    public string PageAddress { get; set; }

    public BaseTest()
    {
        Configuration = BuildConfig.ConfigurationRoot;
        Configuration.GetSection("LaunchSettings").Bind(settings);
    }

    [SetUp]
    public async Task PrepareStorageStateAsync()
    {
        await Page.GotoAsync(settings.Link);
        MainPage mainPage = new MainPage(Page);
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
        DashBoardPage dashBoard = new DashBoardPage(Page);
        dashBoard.OpenCreateNewTableFormAsync().Wait();
    }
    public override BrowserNewContextOptions ContextOptions()
    {
        return new BrowserNewContextOptions()
        {
            BaseURL = settings.Link,
            IsMobile = true,
            StorageStatePath = "state.json",
        };
    }

}