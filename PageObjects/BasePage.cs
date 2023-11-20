using Microsoft.Playwright;
namespace PlaywrightTests.PageObjects
{
    public class BasePage
    {
        public IPage Page { get; }

        public BasePage(IPage page)
        {
            Page = page;
        }
    }
}
