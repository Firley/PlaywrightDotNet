using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightTests.cofiguration;
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
        Configuration.GetSection("LunchSettings").Bind(settings);
    }



    [SetUp]
    public async Task GoToPage()
    {
        await Page.GotoAsync("");    
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
            BaseURL = settings.Link
        };
    }

}