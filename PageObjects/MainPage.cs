using Microsoft.Playwright;

namespace PlaywrightTests.PageObjects
{
    public class MainPage : BasePage
    {
        ILocator LoginButton => Page.GetByTestId("bignav").GetByRole(AriaRole.Link, new() { Name = "Log in" });

        public MainPage(IPage page) : base(page) { }

        public async Task OpenLoginPagesAsync()
        {
            await LoginButton.ClickAsync();
        }
    }
}
